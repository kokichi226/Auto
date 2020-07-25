using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AutoBaccarat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private IWebDriver _driver;
        private int demGio = 0;
        private int kq1, kq2, kq3, kq4 = 5;
        private int i1, i2, i3, i4, i5, i6, i7, i8, i9 = 5;

        private string user = "";
        private string pass = "";

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

            //_driver.Close();
            _driver.Quit();
            //_driver.Dispose();

        }
        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddAdditionalCapability("useAutomationExtension", false);
            chromeOptions.AddExcludedArgument("enable-automation");
            chromeOptions.AddArguments(@"user-data-dir=./Profile");
            chromeOptions.AddArguments("--disable-notifications");
            _driver = new ChromeDriver(service, chromeOptions);
            //_driver.Navigate().GoToUrl("http://tj77.net");

            _driver.Url = txtURLWeb.Text.Trim();
            _driver.Navigate();
            WebDriverWait wait = new WebDriverWait(this._driver, TimeSpan.FromSeconds(30));
            wait.Until((x) =>
            {
                return ((IJavaScriptExecutor)this._driver).ExecuteScript("return document.readyState").Equals("complete");
            });
            //Login www.tj77
            Thread.Sleep(500);
            Login();
            // Vao WM => Xoc dia
            Thread.Sleep(500);
            Go_WM();

            //cho bam Choi
            btnChoi.Enabled = true;
            btnChoi.Visible = true;
            btn_DangNhap.Enabled = false;
        }
        private void btnChoi_Click(object sender, EventArgs e)
        {
            //
            DungVaChoi();
            //chuyen tab-frame
            ChuyenTab();
            ChuyenFrame("iframe_108");

            //var numTime = _driver.FindElement(By.Id("chip_box")).FindElement(By.ClassName("chip_b_20"));

            //LoadKetQuaCu();

            this.timer1.Enabled = true;
        }

        private void LoadLaiKetQua()
        {
            //Get kết quả cuối cùng
            var classLast = _driver.FindElement(By.XPath("//div[@id='cardroadtable-list1']/div[@id='cardroad-box-small-zhu']/div[last()]/div[last()]/span"));
            var kqCuoi = ChuyenKetQua(classLast.GetAttribute("class"));
            //Thread.Sleep(250);
            kq4 = kq3;
            kq3 = kq2;
            kq2 = kq1;
            kq1 = kqCuoi;

            labelKQ1.Text = kq1.ToString();
            labelKQ2.Text = kq2.ToString();
            labelKQ3.Text = kq3.ToString();
            labelKQ4.Text = kq4.ToString();
        }

        //load 4 kq cuối
        private void LoadKetQuaCu()
        {
            var columLast = _driver.FindElements(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list"));
            var itemColumLast = _driver.FindElements(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item"));

            var countColumLast = columLast.Count();
            var countitemColumLast = itemColumLast.Count();


            if (countitemColumLast >= 4)
            {
                var itemKQ1 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:last-child > span"));
                var itemKQ2 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (countitemColumLast - 1) + ") > span"));
                var itemKQ3 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (countitemColumLast - 2) + ") > span"));
                var itemKQ4 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (countitemColumLast - 3) + ") > span"));

                kq1 = ChuyenKetQua(itemKQ1.GetAttribute("class"));
                kq2 = ChuyenKetQua(itemKQ2.GetAttribute("class"));
                kq3 = ChuyenKetQua(itemKQ3.GetAttribute("class"));
                kq4 = ChuyenKetQua(itemKQ4.GetAttribute("class"));
            }
            if (countitemColumLast < 4 && countColumLast >= 2)
            {
                if (countitemColumLast == 3)
                {
                    var itemKQ1 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:last-child > span"));
                    var itemKQ2 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (countitemColumLast - 1) + ") > span"));
                    var itemKQ3 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (countitemColumLast - 2) + ") > span"));
                    var itemKQ4 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (countColumLast - 1) + ") > .cardroad-item:last-child > span"));

                    kq1 = ChuyenKetQua(itemKQ1.GetAttribute("class"));
                    kq2 = ChuyenKetQua(itemKQ2.GetAttribute("class"));
                    kq3 = ChuyenKetQua(itemKQ3.GetAttribute("class"));
                    kq4 = ChuyenKetQua(itemKQ4.GetAttribute("class"));
                }
                if (countitemColumLast == 2)
                {
                    var itemKQ1 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:last-child > span"));
                    var itemKQ2 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (countitemColumLast - 1) + ") > span"));
                    var itemKQ3 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (countColumLast - 1) + ") > .cardroad-item:last-child > span"));
                    var itemKQ4 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (countColumLast - 1) + ") > .cardroad-item:nth-child(5) > span"));

                    kq1 = ChuyenKetQua(itemKQ1.GetAttribute("class"));
                    kq2 = ChuyenKetQua(itemKQ2.GetAttribute("class"));
                    kq3 = ChuyenKetQua(itemKQ3.GetAttribute("class"));
                    kq4 = ChuyenKetQua(itemKQ4.GetAttribute("class"));
                }
                if (countitemColumLast == 1)
                {
                    var itemKQ1 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:last-child > span"));
                    var itemKQ2 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (countColumLast - 1) + ") > .cardroad-item:last-child > span"));
                    var itemKQ3 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (countColumLast - 1) + ") > .cardroad-item:nth-child(5) > span"));
                    var itemKQ4 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (countColumLast - 1) + ") > .cardroad-item:nth-child(4) > span"));

                    kq1 = ChuyenKetQua(itemKQ1.GetAttribute("class"));
                    kq2 = ChuyenKetQua(itemKQ2.GetAttribute("class"));
                    kq3 = ChuyenKetQua(itemKQ3.GetAttribute("class"));
                    kq4 = ChuyenKetQua(itemKQ4.GetAttribute("class"));
                }
            }
            if (countitemColumLast < 4 && countColumLast == 1)
            {
                if (countitemColumLast == 3)
                {
                    var itemKQ1 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:last-child > span"));
                    var itemKQ2 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (countitemColumLast - 1) + ") > span"));
                    var itemKQ3 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (countitemColumLast - 2) + ") > span"));

                    kq1 = ChuyenKetQua(itemKQ1.GetAttribute("class"));
                    kq2 = ChuyenKetQua(itemKQ2.GetAttribute("class"));
                    kq3 = ChuyenKetQua(itemKQ3.GetAttribute("class"));
                }
                if (countitemColumLast == 2)
                {
                    var itemKQ1 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:last-child > span"));
                    var itemKQ2 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (countitemColumLast - 1) + ") > span"));

                    kq1 = ChuyenKetQua(itemKQ1.GetAttribute("class"));
                    kq2 = ChuyenKetQua(itemKQ2.GetAttribute("class"));
                }
                if (countitemColumLast == 1)
                {
                    var itemKQ1 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:last-child > span"));

                    kq1 = ChuyenKetQua(itemKQ1.GetAttribute("class"));
                }
            }

            labelKQ1.Text = kq1.ToString();
            labelKQ2.Text = kq2.ToString();
            labelKQ3.Text = kq3.ToString();
            labelKQ4.Text = kq4.ToString();

        }
        //load 9 kết quả cuối
        private void LoadKetQuaTwoColum()
        {
            var columLast = _driver.FindElements(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list"));
            var itemColumLast = _driver.FindElements(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item"));

            var columL = columLast.Count();
            var itemCL = itemColumLast.Count();

            //có 1 cột
            if (columL == 1)
            {
                if (itemCL == 6)
                {
                    var itemKQ1 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:last-child > span"));
                    var itemKQ2 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 1) + ") > span"));
                    var itemKQ3 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 2) + ") > span"));
                    var itemKQ4 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 3) + ") > span"));
                    var itemKQ5 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 4) + ") > span"));
                    var itemKQ6 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 5) + ") > span"));

                    i9 = i8;
                    i8 = i7;
                    i7 = i6;
                    i6 = ChuyenKetQua(itemKQ6.GetAttribute("class"));
                    i5 = ChuyenKetQua(itemKQ5.GetAttribute("class"));
                    i4 = ChuyenKetQua(itemKQ4.GetAttribute("class"));
                    i3 = ChuyenKetQua(itemKQ3.GetAttribute("class"));
                    i2 = ChuyenKetQua(itemKQ2.GetAttribute("class"));
                    i1 = ChuyenKetQua(itemKQ1.GetAttribute("class"));
                }
                if (itemCL == 5)
                {
                    var itemKQ1 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:last-child > span"));
                    var itemKQ2 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 1) + ") > span"));
                    var itemKQ3 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 2) + ") > span"));
                    var itemKQ4 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 3) + ") > span"));
                    var itemKQ5 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 4) + ") > span"));

                    i9 = i8;
                    i8 = i7;
                    i7 = i6;
                    i6 = i5;
                    i5 = ChuyenKetQua(itemKQ5.GetAttribute("class"));
                    i4 = ChuyenKetQua(itemKQ4.GetAttribute("class"));
                    i3 = ChuyenKetQua(itemKQ3.GetAttribute("class"));
                    i2 = ChuyenKetQua(itemKQ2.GetAttribute("class"));
                    i1 = ChuyenKetQua(itemKQ1.GetAttribute("class"));
                }
                if (itemCL == 4)
                {
                    var itemKQ1 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:last-child > span"));
                    var itemKQ2 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 1) + ") > span"));
                    var itemKQ3 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 2) + ") > span"));
                    var itemKQ4 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 3) + ") > span"));

                    i9 = i8;
                    i8 = i7;
                    i7 = i6;
                    i6 = i5;
                    i5 = i4;
                    i4 = ChuyenKetQua(itemKQ4.GetAttribute("class"));
                    i3 = ChuyenKetQua(itemKQ3.GetAttribute("class"));
                    i2 = ChuyenKetQua(itemKQ2.GetAttribute("class"));
                    i1 = ChuyenKetQua(itemKQ1.GetAttribute("class"));
                }
                if (itemCL == 3)
                {
                    var itemKQ1 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:last-child > span"));
                    var itemKQ2 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 1) + ") > span"));
                    var itemKQ3 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 2) + ") > span"));

                    i9 = i8;
                    i8 = i7;
                    i7 = i6;
                    i6 = i5;
                    i5 = i4;
                    i4 = i3;
                    i3 = ChuyenKetQua(itemKQ3.GetAttribute("class"));
                    i2 = ChuyenKetQua(itemKQ2.GetAttribute("class"));
                    i1 = ChuyenKetQua(itemKQ1.GetAttribute("class"));
                }
                if (itemCL == 2)
                {
                    var itemKQ1 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:last-child > span"));
                    var itemKQ2 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 1) + ") > span"));

                    i9 = i8;
                    i8 = i7;
                    i7 = i6;
                    i6 = i5;
                    i5 = i4;
                    i4 = i3;
                    i3 = i2;
                    i2 = ChuyenKetQua(itemKQ2.GetAttribute("class"));
                    i1 = ChuyenKetQua(itemKQ1.GetAttribute("class"));
                }
                if (itemCL == 1)
                {
                    var itemKQ1 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:last-child > span"));

                    i9 = i8;
                    i8 = i7;
                    i7 = i6;
                    i6 = i5;
                    i5 = i4;
                    i4 = i3;
                    i3 = i2;
                    i2 = i1;
                    i1 = ChuyenKetQua(itemKQ1.GetAttribute("class"));
                }
            }
            //có 2 cột và item nhỏ hơn 2
            if (columL == 2 && itemCL <= 2)
            {
                if (itemCL == 2)
                {
                    var itemKQ1 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:last-child > span"));
                    var itemKQ2 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 1) + ") > span"));
                    var itemKQ3 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:last-child > span"));
                    var itemKQ4 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(5) > span"));
                    var itemKQ5 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(4) > span"));
                    var itemKQ6 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(3) > span"));
                    var itemKQ7 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(2) > span"));
                    var itemKQ8 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(1) > span"));

                    i9 = i8;
                    i8 = ChuyenKetQua(itemKQ8.GetAttribute("class"));
                    i7 = ChuyenKetQua(itemKQ7.GetAttribute("class"));
                    i6 = ChuyenKetQua(itemKQ6.GetAttribute("class"));
                    i5 = ChuyenKetQua(itemKQ5.GetAttribute("class"));
                    i4 = ChuyenKetQua(itemKQ4.GetAttribute("class"));
                    i3 = ChuyenKetQua(itemKQ3.GetAttribute("class"));
                    i2 = ChuyenKetQua(itemKQ2.GetAttribute("class"));
                    i1 = ChuyenKetQua(itemKQ1.GetAttribute("class"));
                }
                if (itemCL == 1)
                {
                    var itemKQ1 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:last-child > span"));
                    var itemKQ2 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:last-child > span"));
                    var itemKQ3 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(5) > span"));
                    var itemKQ4 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(4) > span"));
                    var itemKQ5 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(3) > span"));
                    var itemKQ6 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(2) > span"));
                    var itemKQ7 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(1) > span"));

                    i9 = i8;
                    i8 = i7;
                    i7 = ChuyenKetQua(itemKQ7.GetAttribute("class"));
                    i6 = ChuyenKetQua(itemKQ6.GetAttribute("class"));
                    i5 = ChuyenKetQua(itemKQ5.GetAttribute("class"));
                    i4 = ChuyenKetQua(itemKQ4.GetAttribute("class"));
                    i3 = ChuyenKetQua(itemKQ3.GetAttribute("class"));
                    i2 = ChuyenKetQua(itemKQ2.GetAttribute("class"));
                    i1 = ChuyenKetQua(itemKQ1.GetAttribute("class"));
                }
            }
            //có hơn 2 cột và item nhỏ hơn 2
            if (columL > 2 && itemCL <= 2)
            {
                if (itemCL == 2)
                {
                    var itemKQ1 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:last-child > span"));
                    var itemKQ2 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 1) + ") > span"));
                    var itemKQ3 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:last-child > span"));
                    var itemKQ4 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(5) > span"));
                    var itemKQ5 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(4) > span"));
                    var itemKQ6 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(3) > span"));
                    var itemKQ7 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(2) > span"));
                    var itemKQ8 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(1) > span"));
                    var itemKQ9 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 2) + ") > .cardroad-item:last-child > span"));

                    i9 = ChuyenKetQua(itemKQ9.GetAttribute("class"));
                    i8 = ChuyenKetQua(itemKQ8.GetAttribute("class"));
                    i7 = ChuyenKetQua(itemKQ7.GetAttribute("class"));
                    i6 = ChuyenKetQua(itemKQ6.GetAttribute("class"));
                    i5 = ChuyenKetQua(itemKQ5.GetAttribute("class"));
                    i4 = ChuyenKetQua(itemKQ4.GetAttribute("class"));
                    i3 = ChuyenKetQua(itemKQ3.GetAttribute("class"));
                    i2 = ChuyenKetQua(itemKQ2.GetAttribute("class"));
                    i1 = ChuyenKetQua(itemKQ1.GetAttribute("class"));
                }
                if (itemCL == 1)
                {
                    var itemKQ1 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:last-child > span"));
                    var itemKQ2 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:last-child > span"));
                    var itemKQ3 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(5) > span"));
                    var itemKQ4 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(4) > span"));
                    var itemKQ5 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(3) > span"));
                    var itemKQ6 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(2) > span"));
                    var itemKQ7 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(1) > span"));
                    var itemKQ8 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 2) + ") > .cardroad-item:last-child > span"));
                    var itemKQ9 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 2) + ") > .cardroad-item:nth-child(5) > span"));

                    i9 = ChuyenKetQua(itemKQ9.GetAttribute("class"));
                    i8 = ChuyenKetQua(itemKQ8.GetAttribute("class"));
                    i7 = ChuyenKetQua(itemKQ7.GetAttribute("class"));
                    i6 = ChuyenKetQua(itemKQ6.GetAttribute("class"));
                    i5 = ChuyenKetQua(itemKQ5.GetAttribute("class"));
                    i4 = ChuyenKetQua(itemKQ4.GetAttribute("class"));
                    i3 = ChuyenKetQua(itemKQ3.GetAttribute("class"));
                    i2 = ChuyenKetQua(itemKQ2.GetAttribute("class"));
                    i1 = ChuyenKetQua(itemKQ1.GetAttribute("class"));
                }
            }
            //có từ 2 cột và item lớn hơn 2
            if (columL > 1 && itemCL > 2)
            {
                if (itemCL == 3)
                {
                    var itemKQ1 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:last-child > span"));
                    var itemKQ2 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 1) + ") > span"));
                    var itemKQ3 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 2) + ") > span"));
                    var itemKQ4 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:last-child > span"));
                    var itemKQ5 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(5) > span"));
                    var itemKQ6 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(4) > span"));
                    var itemKQ7 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(3) > span"));
                    var itemKQ8 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(2) > span"));
                    var itemKQ9 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(1) > span"));

                    i9 = ChuyenKetQua(itemKQ9.GetAttribute("class"));
                    i8 = ChuyenKetQua(itemKQ8.GetAttribute("class"));
                    i7 = ChuyenKetQua(itemKQ7.GetAttribute("class"));
                    i6 = ChuyenKetQua(itemKQ6.GetAttribute("class"));
                    i5 = ChuyenKetQua(itemKQ5.GetAttribute("class"));
                    i4 = ChuyenKetQua(itemKQ4.GetAttribute("class"));
                    i3 = ChuyenKetQua(itemKQ3.GetAttribute("class"));
                    i2 = ChuyenKetQua(itemKQ2.GetAttribute("class"));
                    i1 = ChuyenKetQua(itemKQ1.GetAttribute("class"));
                }
                if (itemCL == 4)
                {
                    var itemKQ1 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:last-child > span"));
                    var itemKQ2 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 1) + ") > span"));
                    var itemKQ3 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 2) + ") > span"));
                    var itemKQ4 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 3) + ") > span"));
                    var itemKQ5 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:last-child > span"));
                    var itemKQ6 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(5) > span"));
                    var itemKQ7 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(4) > span"));
                    var itemKQ8 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(3) > span"));
                    var itemKQ9 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(2) > span"));

                    i9 = ChuyenKetQua(itemKQ9.GetAttribute("class"));
                    i8 = ChuyenKetQua(itemKQ8.GetAttribute("class"));
                    i7 = ChuyenKetQua(itemKQ7.GetAttribute("class"));
                    i6 = ChuyenKetQua(itemKQ6.GetAttribute("class"));
                    i5 = ChuyenKetQua(itemKQ5.GetAttribute("class"));
                    i4 = ChuyenKetQua(itemKQ4.GetAttribute("class"));
                    i3 = ChuyenKetQua(itemKQ3.GetAttribute("class"));
                    i2 = ChuyenKetQua(itemKQ2.GetAttribute("class"));
                    i1 = ChuyenKetQua(itemKQ1.GetAttribute("class"));
                }
                if (itemCL == 5)
                {
                    var itemKQ1 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:last-child > span"));
                    var itemKQ2 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 1) + ") > span"));
                    var itemKQ3 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 2) + ") > span"));
                    var itemKQ4 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 3) + ") > span"));
                    var itemKQ5 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 4) + ") > span"));
                    var itemKQ6 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:last-child > span"));
                    var itemKQ7 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(5) > span"));
                    var itemKQ8 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(4) > span"));
                    var itemKQ9 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(3) > span"));

                    i9 = ChuyenKetQua(itemKQ9.GetAttribute("class"));
                    i8 = ChuyenKetQua(itemKQ8.GetAttribute("class"));
                    i7 = ChuyenKetQua(itemKQ7.GetAttribute("class"));
                    i6 = ChuyenKetQua(itemKQ6.GetAttribute("class"));
                    i5 = ChuyenKetQua(itemKQ5.GetAttribute("class"));
                    i4 = ChuyenKetQua(itemKQ4.GetAttribute("class"));
                    i3 = ChuyenKetQua(itemKQ3.GetAttribute("class"));
                    i2 = ChuyenKetQua(itemKQ2.GetAttribute("class"));
                    i1 = ChuyenKetQua(itemKQ1.GetAttribute("class"));
                }
                if (itemCL == 6)
                {
                    var itemKQ1 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:last-child > span"));
                    var itemKQ2 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 1) + ") > span"));
                    var itemKQ3 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 2) + ") > span"));
                    var itemKQ4 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 3) + ") > span"));
                    var itemKQ5 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 4) + ") > span"));
                    var itemKQ6 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:last-child > .cardroad-item:nth-child(" + (itemCL - 5) + ") > span"));
                    var itemKQ7 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:last-child > span"));
                    var itemKQ8 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(5) > span"));
                    var itemKQ9 = _driver.FindElement(By.CssSelector("#cardroadtable-list1 #cardroad-box-small-zhu > div.cardroad-list:nth-child(" + (columL - 1) + ") > .cardroad-item:nth-child(4) > span"));

                    i9 = ChuyenKetQua(itemKQ9.GetAttribute("class"));
                    i8 = ChuyenKetQua(itemKQ8.GetAttribute("class"));
                    i7 = ChuyenKetQua(itemKQ7.GetAttribute("class"));
                    i6 = ChuyenKetQua(itemKQ6.GetAttribute("class"));
                    i5 = ChuyenKetQua(itemKQ5.GetAttribute("class"));
                    i4 = ChuyenKetQua(itemKQ4.GetAttribute("class"));
                    i3 = ChuyenKetQua(itemKQ3.GetAttribute("class"));
                    i2 = ChuyenKetQua(itemKQ2.GetAttribute("class"));
                    i1 = ChuyenKetQua(itemKQ1.GetAttribute("class"));
                }
            }

            labeli1.Text = i1.ToString();
            labeli2.Text = i2.ToString();
            labeli3.Text = i3.ToString();
            labeli4.Text = i4.ToString();
            labeli5.Text = i5.ToString();
            labeli6.Text = i6.ToString();
            labeli7.Text = i7.ToString();
            labeli8.Text = i8.ToString();
            labeli9.Text = i9.ToString();
        }

        private int ChuyenKetQua(string kq)
        {
            if (kq == "type51")
            {
                return 1;
            }
            if (kq == "type52")
            {
                return 2;
            }
            if (kq == "type53")
            {
                return 3;
            }
            if (kq == "type54")
            {
                return 4;
            }
            if (kq == "type55")
            {
                return 0;
            }
            else return 5;
        }
        private void DungVaChoi()
        {
            if (btnChoi.Text.Contains("Bắt đầu (Sau đếm ngược <  15s)"))
            {
                btnChoi.Text = "Dừng";
                btnChoi.ForeColor = Color.Red;
            }
            else
            {
                btnChoi.Text = "Bắt đầu (Sau đếm ngược <  15s)";
                btnChoi.ForeColor = Color.Green;

            }
        }
        private void Login()
        {
            if (txtUserName.Text.Trim() != "")
            {
                user = txtUserName.Text.Trim();
            }
            if (txtPassWord.Text.Trim() != "")
            {
                pass = txtPassWord.Text.Trim();
            }
            // User
            var txt_User = _driver.FindElement(By.Id("divNotLogined")).FindElement(By.Id("txtUser"));
            txt_User.SendKeys(user);
            Thread.Sleep(250);
            // Pass
            var txt_Password = _driver.FindElement(By.Id("divNotLogined")).FindElement(By.Id("txtPassword"));
            txt_Password.SendKeys(pass);
            Thread.Sleep(250);
            // Click login
            var btn_signIn = _driver.FindElement(By.Id("divNotLogined")).FindElement(By.ClassName("btn_signIn"));
            btn_signIn.Click();
        }

        private void Go_WM()
        {
            // Click menu
            var btn_menuMain = _driver.FindElement(By.ClassName("mainNav_In")).FindElement(By.ClassName("navList")).FindElement(By.ClassName("divCasino")).FindElement(By.ClassName("btn_gameBanner"));
            btn_menuMain.Click();
            Thread.Sleep(250);
            var btn_menuSub = _driver.FindElement(By.ClassName("mainNav_In")).FindElement(By.ClassName("navList")).FindElement(By.ClassName("divCasino")).FindElement(By.ClassName("liveGame")).FindElement(By.Id("wm"));
            btn_menuSub.Click();

            //goPlatfom
            //var goPlatfom = _driver.FindElement(By.ClassName("goPlatfom"));
            //MessageBox.Show(goPlatfom.GetAttribute("class")) ;
        }

        private void ChuyenTab()
        {
            ReadOnlyCollection<string> windowHandles = _driver.WindowHandles;
            string firstTab = windowHandles.First();
            string lastTab = windowHandles.Last();
            _driver.SwitchTo().Window(lastTab);
            //Get the current window handle
            //var windowHandle = _driver.WindowHandles;
            //Use the list of window handles to switch between windows
            //_driver.SwitchTo().Window(_driver.WindowHandles.Last());
        }
        private void ChuyenFrame(string txtframe)
        {
            IWebElement iframe = _driver.FindElement(By.Id(txtframe));
            _driver.SwitchTo().Frame(iframe);
        }


        private void Timer1_Tick(object sender, EventArgs e)
        {

            if (btnChoi.Text == "Dừng")
            {
                var numTime = _driver.FindElement(By.Id("countdown-box")).FindElement(By.Id("countdown-wrapper")).FindElement(By.Id("countdown-time"));
                demGio += 1;
                labelCountLoad.Text = demGio.ToString();
                if (numTime.Displayed == true)
                {
                    if (numTime.Text.Contains("20"))
                    {
                        //load lại kết quả
                        labelTrangThai.Text = "Load kết quả";
                        //Load 4
                        LoadKetQuaCu();
                        //Load 9
                        LoadKetQuaTwoColum();

                    }
                    if (numTime.Text.Contains("15"))
                    {
                        int dc = 0;
                        //đặt cược
                        labelTrangThai.Text = "Đang đặt cược";
                        dc = DatCuocTheoTu();
                        //dc = DatCuocTheoHangNgang();
                        //dc = DatCuocTheoVanTruoc();

                        //xong đặt cược
                        if (dc == 1)
                        {
                            labelTrangThai.Text = "Đã đặt cược lẻ";
                            XacNhan();
                        }
                        else if (dc == 2)
                        {
                            labelTrangThai.Text = "Đã đặt cược chẵn";
                            XacNhan();
                        }
                        else
                        {
                            labelTrangThai.Text = "Không đặt cược";
                        }

                    }
                    labelTime.Text = numTime.Text;
                }
                else
                {
                    //labelTrangThai.Text = "Chờ ván sau!";
                    //
                    XacNhanKhiOut();

                }
            }
            else
            {
                labelTrangThai.Text = "Stop";
                labelTime.Text = "@@";
            }
        }
        private void XacNhanKhiOut()
        {
            //về trang gốc
            _driver.SwitchTo().DefaultContent();
            //#extend-container > #popup-box-container > div > div.function-box > a.btn.btn-ok.text_3
            var btn_X = _driver.FindElement(By.CssSelector("#extend-container > #popup-box-container > div > div.function-box > a.btn.btn-ok.text_3"));
            if (btn_X.Displayed == true)
            {
                btn_X.Click();
                //ui_3_box > #btn_game_item9
                //var btn_Z = _driver.FindElement(By.CssSelector("#btn_game_item9"));
                //Thread.Sleep(50);
                //btn_Z.Click();
                //vào lại frame 
                ChuyenFrame("iframe_109");
                //Thread.Sleep(500);
                //#groupseDie_108_2_0
                var btn_Y = _driver.FindElement(By.XPath("//*[@id=\"groupSeDie_108_2_0\"]"));

                btn_Y.Click();
                Thread.Sleep(50);
            }
            //VaoLaiBan();

            _driver.SwitchTo().DefaultContent();
            //vào lại frame 
            ChuyenFrame("iframe_108");
        }
        private void VaoLaiBan()
        {
            //vào lại frame 
            ChuyenFrame("iframe_109");
            Thread.Sleep(50);
            //#groupseDie_108_2_0
            var btn_Y = _driver.FindElement(By.CssSelector("#groupseDie_108_2_0"));

            btn_Y.Click();
            Thread.Sleep(50);
            _driver.SwitchTo().DefaultContent();
        }
        // đặt cược theo tứ
        private int DatCuocTheoTu()
        {
            int dc = 0;
            //kết quả 3
            if (kq3 == 0 || kq3 == 4)
            {
                // kq4 chẵn
                if (kq4 == 0 || kq4 == 2 || kq4 == 4)
                {
                    //đã ăn - không vào 
                    if (kq2 == 1 || kq2 == 3 || kq1 == 1 || kq1 == 3)
                    {
                        dc = 0;
                    }
                    else
                    {
                        //vào lẻ
                        dc = 1;
                        DatCuocLe();
                        Thread.Sleep(150);
                        DatCuocLe();
                        Thread.Sleep(150);
                        DatCuocLe();
                        Thread.Sleep(150);
                        DatCuocLe();
                    }
                }
                //kq4 lẻ
                else
                {
                    //đã ăn - không vào 
                    if ((kq2 != 1 && kq2 != 3) || (kq1 != 1 && kq1 != 3))
                    {
                        dc = 0;
                    }
                    else
                    {
                        //vào chẵn
                        dc = 2;
                        DatCuocChan();
                        Thread.Sleep(150);
                        DatCuocChan();
                        Thread.Sleep(150);
                        DatCuocChan();
                        Thread.Sleep(150);
                        DatCuocChan();
                    }
                }
            }
            //kết quả 2
            else if (kq2 == 0 || kq2 == 4)
            {
                // kq3 chẵn
                if (kq3 == 2)
                {
                    //đã ăn - không vào 
                    if (kq1 == 1 || kq1 == 3)
                    {
                        dc = 0;
                    }
                    else
                    {
                        //vào lẻ
                        dc = 1;
                        DatCuocLe();
                        Thread.Sleep(150);
                        DatCuocLe();
                    }
                }
                //kq3 lẻ
                else
                {
                    //đã ăn - không vào 
                    if (kq1 != 1 && kq1 != 3)
                    {
                        dc = 0;
                    }
                    else
                    {
                        //vào chẵn
                        dc = 2;
                        DatCuocChan();
                        Thread.Sleep(150);
                        DatCuocChan();
                    }
                }
            }
            //kết quả 1
            else if (kq1 == 0 || kq1 == 4)
            {
                // kq2 chẵn
                if (kq2 == 2)
                {
                    //vào lẻ
                    dc = 1;
                    DatCuocLe();
                    Thread.Sleep(150);
                }
                //kq3 lẻ
                else
                {
                    //vào chẵn
                    dc = 2;
                    DatCuocChan();
                    Thread.Sleep(150);
                }
            }

            return dc;
        }
        //đặt theo hàng ngang
        private int DatCuocTheoHangNgang()
        {
            int dc = 0;

            //i6 Chẵn
            if ((i6 % 2) == 0)
            {
                //i7 ngược i1
                if ((i7 % 2) != (i1 % 2))
                {
                    dc = 1;
                    //đặt lẻ 1 lần
                    DatCuocLe();
                    Thread.Sleep(150);
                }
                //i8 ngược i2 và i7 cùng i1
                if ((i8 % 2) != (i2 % 2) && (i7 % 2) == (i1 % 2))
                {
                    dc = 1;
                    //đặt lẻ 2 lần
                    DatCuocLe();
                    Thread.Sleep(150);
                    DatCuocLe();
                }
                //i9 ngược i3 và i8 cùng i2 và i7 cùng i1
                if ((i9 % 2) != (i3 % 2) && (i8 % 2) == (i2 % 2) && (i7 % 2) == (i1 % 2))
                {
                    dc = 1;
                    //đặt lẻ 4 lần
                    DatCuocLe();
                    Thread.Sleep(150);
                    DatCuocLe();
                    Thread.Sleep(150);
                    DatCuocLe();
                    Thread.Sleep(150);
                    DatCuocLe();
                }
                //3 cặp cùng nhau
                if ((i9 % 2) == (i3 % 2) && (i8 % 2) == (i2 % 2) && (i7 % 2) == (i1 % 2))
                {
                    dc = 1;
                    //đặt lẻ 1 lần
                    DatCuocLe();
                    Thread.Sleep(150);
                }
            }
            //i6 Lẻ
            if ((i6 % 2) != 0 && i6 != 5)
            {
                //i7 ngược i1
                if ((i7 % 2) != (i1 % 2))
                {
                    dc = 2;
                    //đặt chẵn 1 lần
                    DatCuocChan();
                    Thread.Sleep(150);
                }
                //i8 ngược i2 và i7 cùng i1
                if ((i8 % 2) != (i2 % 2) && (i7 % 2) == (i1 % 2))
                {
                    dc = 2;
                    //đặt chẵn 2 lần
                    DatCuocChan();
                    Thread.Sleep(150);
                    DatCuocChan();
                }
                //i9 ngược i3 và i8 cùng i2 và i7 cùng i1
                if ((i9 % 2) != (i3 % 2) && (i8 % 2) == (i2 % 2) && (i7 % 2) == (i1 % 2))
                {
                    dc = 2;
                    //đặt chẵn 4 lần
                    DatCuocChan();
                    Thread.Sleep(150);
                    DatCuocChan();
                    Thread.Sleep(150);
                    DatCuocChan();
                    Thread.Sleep(150);
                    DatCuocChan();
                }
                //3 cặp cùng nhau
                if ((i9 % 2) == (i3 % 2) && (i8 % 2) == (i2 % 2) && (i7 % 2) == (i1 % 2))
                {
                    dc = 2;
                    //đặt chẵn 1 lần
                    DatCuocChan();
                    Thread.Sleep(150);
                }
            }

            return dc;
        }
        //đặt theo ván trước
        private int DatCuocTheoVanTruoc()
        {
            int dc = 0;

            //kq1 lẻ
            if (kq1 == 1 || kq1 == 3)
            {
                //đã ăn
                if (kq2 == 1 || kq2 == 3)
                {
                    dc = 1;
                    //đặt lẻ 1 lần
                    DatCuocLe();
                    Thread.Sleep(150);
                }
                //chưa ăn
                else
                {
                    //kq3 lẻ
                    if (kq3 == 1 || kq3 == 3)
                    {
                        dc = 1;
                        //ko ăn đặt lẻ 3 lần
                        DatCuocLe();
                        Thread.Sleep(150);
                        DatCuocLe();
                        Thread.Sleep(150);
                        DatCuocLe();
                        Thread.Sleep(150);
                        DatCuocLe();
                    }
                    //kq3 chẵn
                    else
                    {
                        dc = 1;
                        //đã ăn đặt lẻ 2 lần
                        DatCuocLe();
                        Thread.Sleep(150);
                        DatCuocLe();
                    }

                }
            }
            //kq1 chẵn
            else
            {
                //chưa ăn
                if (kq2 == 1 || kq2 == 3)
                {
                    //kq3 lẻ
                    if (kq3 == 1 || kq3 == 3)
                    {
                        dc = 2;
                        //đã ăn đặt lẻ 2 lần
                        DatCuocChan();
                        Thread.Sleep(150);
                        DatCuocChan();
                    }
                    //kq3 chẵn
                    else
                    {
                        dc = 2;
                        //ko ăn đặt lẻ 3 lần
                        DatCuocChan();
                        Thread.Sleep(150);
                        DatCuocChan();
                        Thread.Sleep(150);
                        DatCuocChan();
                        Thread.Sleep(150);
                        DatCuocChan();
                    }
                }
                //đã ăn
                else
                {
                    dc = 2;
                    //đặt chẵn 1 lần
                    DatCuocChan();
                    Thread.Sleep(150);
                }

            }

            return dc;

        }

        private void DatCuocChan()
        {
            // #container > div.table_box > #lightEven 
            var btn_Chan = _driver.FindElement(By.CssSelector("#container > div.table_box > #lightEven"));
            Thread.Sleep(50);
            btn_Chan.Click();
        }

        private void DatCuocLe()
        {
            // #container > div.table_box > #lightOdd 
            var btn_Le = _driver.FindElement(By.CssSelector("#container > div.table_box > #lightOdd"));
            Thread.Sleep(50);
            btn_Le.Click();
        }
        private void XacNhan()
        {
            //#container > #bet_btn
            var btn_XN = _driver.FindElement(By.CssSelector("#container > #bet_btn"));
            Thread.Sleep(50);
            btn_XN.Click();
        }
        private void Huy()
        {
            //#container > #cancel_btn
            var btn_XN = _driver.FindElement(By.CssSelector("#container > #cancel_btn"));
            Thread.Sleep(50);
            btn_XN.Click();
        }


    }
}
