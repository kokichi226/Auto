namespace AutoBaccarat
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnChoi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtURLWeb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelCountLoad = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labeli9 = new System.Windows.Forms.Label();
            this.labeli8 = new System.Windows.Forms.Label();
            this.labeli7 = new System.Windows.Forms.Label();
            this.labeli6 = new System.Windows.Forms.Label();
            this.labeli5 = new System.Windows.Forms.Label();
            this.labeli4 = new System.Windows.Forms.Label();
            this.labeli3 = new System.Windows.Forms.Label();
            this.labeli2 = new System.Windows.Forms.Label();
            this.labeli1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.labelKQ4 = new System.Windows.Forms.Label();
            this.labelKQ1 = new System.Windows.Forms.Label();
            this.labelKQ3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelKQ2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTrangThai = new System.Windows.Forms.Label();
            this.btn_DangNhap = new System.Windows.Forms.Button();
            this.labelTime = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnChoi
            // 
            this.btnChoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnChoi.Enabled = false;
            this.btnChoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChoi.ForeColor = System.Drawing.Color.Green;
            this.btnChoi.Location = new System.Drawing.Point(143, 94);
            this.btnChoi.Name = "btnChoi";
            this.btnChoi.Size = new System.Drawing.Size(367, 71);
            this.btnChoi.TabIndex = 0;
            this.btnChoi.Text = "Bắt đầu (Sau đếm ngược <  15s)";
            this.btnChoi.UseVisualStyleBackColor = false;
            this.btnChoi.Visible = false;
            this.btnChoi.Click += new System.EventHandler(this.btnChoi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Đếm ngược :";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.91018F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.08982F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(629, 327);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPassWord);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtURLWeb);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.labelTrangThai);
            this.panel1.Controls.Add(this.btn_DangNhap);
            this.panel1.Controls.Add(this.labelTime);
            this.panel1.Controls.Add(this.btnChoi);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panel1.Size = new System.Drawing.Size(623, 321);
            this.panel1.TabIndex = 0;
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(335, 51);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.Size = new System.Drawing.Size(174, 29);
            this.txtPassWord.TabIndex = 24;
            this.txtPassWord.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(275, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 24);
            this.label8.TabIndex = 23;
            this.label8.Text = "Pass:";
            // 
            // txtURLWeb
            // 
            this.txtURLWeb.Location = new System.Drawing.Point(68, 16);
            this.txtURLWeb.Name = "txtURLWeb";
            this.txtURLWeb.Size = new System.Drawing.Size(441, 29);
            this.txtURLWeb.TabIndex = 24;
            this.txtURLWeb.Text = "http://tj77.net";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 24);
            this.label9.TabIndex = 23;
            this.label9.Text = "Web";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(68, 51);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(174, 29);
            this.txtUserName.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 24);
            this.label7.TabIndex = 23;
            this.label7.Text = "User:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel4.Controls.Add(this.labelCountLoad);
            this.panel4.Controls.Add(this.label3);
            this.panel4.ForeColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(347, 227);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(162, 83);
            this.panel4.TabIndex = 22;
            // 
            // labelCountLoad
            // 
            this.labelCountLoad.AutoSize = true;
            this.labelCountLoad.Location = new System.Drawing.Point(49, 43);
            this.labelCountLoad.Name = "labelCountLoad";
            this.labelCountLoad.Size = new System.Drawing.Size(53, 24);
            this.labelCountLoad.TabIndex = 10;
            this.labelCountLoad.Text = "Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "Time run:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Navy;
            this.panel3.Controls.Add(this.labeli9);
            this.panel3.Controls.Add(this.labeli8);
            this.panel3.Controls.Add(this.labeli7);
            this.panel3.Controls.Add(this.labeli6);
            this.panel3.Controls.Add(this.labeli5);
            this.panel3.Controls.Add(this.labeli4);
            this.panel3.Controls.Add(this.labeli3);
            this.panel3.Controls.Add(this.labeli2);
            this.panel3.Controls.Add(this.labeli1);
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(531, 9);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(84, 216);
            this.panel3.TabIndex = 21;
            // 
            // labeli9
            // 
            this.labeli9.AutoSize = true;
            this.labeli9.Location = new System.Drawing.Point(12, 75);
            this.labeli9.Name = "labeli9";
            this.labeli9.Size = new System.Drawing.Size(24, 24);
            this.labeli9.TabIndex = 8;
            this.labeli9.Text = "i9";
            // 
            // labeli8
            // 
            this.labeli8.AutoSize = true;
            this.labeli8.Location = new System.Drawing.Point(12, 112);
            this.labeli8.Name = "labeli8";
            this.labeli8.Size = new System.Drawing.Size(24, 24);
            this.labeli8.TabIndex = 7;
            this.labeli8.Text = "i8";
            // 
            // labeli7
            // 
            this.labeli7.AutoSize = true;
            this.labeli7.Location = new System.Drawing.Point(12, 146);
            this.labeli7.Name = "labeli7";
            this.labeli7.Size = new System.Drawing.Size(24, 24);
            this.labeli7.TabIndex = 6;
            this.labeli7.Text = "i7";
            // 
            // labeli6
            // 
            this.labeli6.AutoSize = true;
            this.labeli6.Location = new System.Drawing.Point(12, 176);
            this.labeli6.Name = "labeli6";
            this.labeli6.Size = new System.Drawing.Size(24, 24);
            this.labeli6.TabIndex = 5;
            this.labeli6.Text = "i6";
            // 
            // labeli5
            // 
            this.labeli5.AutoSize = true;
            this.labeli5.Location = new System.Drawing.Point(48, 12);
            this.labeli5.Name = "labeli5";
            this.labeli5.Size = new System.Drawing.Size(24, 24);
            this.labeli5.TabIndex = 4;
            this.labeli5.Text = "i5";
            // 
            // labeli4
            // 
            this.labeli4.AutoSize = true;
            this.labeli4.Location = new System.Drawing.Point(48, 42);
            this.labeli4.Name = "labeli4";
            this.labeli4.Size = new System.Drawing.Size(24, 24);
            this.labeli4.TabIndex = 3;
            this.labeli4.Text = "i4";
            // 
            // labeli3
            // 
            this.labeli3.AutoSize = true;
            this.labeli3.Location = new System.Drawing.Point(48, 75);
            this.labeli3.Name = "labeli3";
            this.labeli3.Size = new System.Drawing.Size(24, 24);
            this.labeli3.TabIndex = 2;
            this.labeli3.Text = "i3";
            // 
            // labeli2
            // 
            this.labeli2.AutoSize = true;
            this.labeli2.Location = new System.Drawing.Point(48, 112);
            this.labeli2.Name = "labeli2";
            this.labeli2.Size = new System.Drawing.Size(24, 24);
            this.labeli2.TabIndex = 1;
            this.labeli2.Text = "i2";
            // 
            // labeli1
            // 
            this.labeli1.AutoSize = true;
            this.labeli1.Location = new System.Drawing.Point(48, 146);
            this.labeli1.Name = "labeli1";
            this.labeli1.Size = new System.Drawing.Size(24, 24);
            this.labeli1.TabIndex = 0;
            this.labeli1.Text = "i1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Green;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.labelKQ4);
            this.panel2.Controls.Add(this.labelKQ1);
            this.panel2.Controls.Add(this.labelKQ3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.labelKQ2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(7, 227);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(321, 83);
            this.panel2.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(247, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 24);
            this.label6.TabIndex = 19;
            this.label6.Text = "KQ 1";
            // 
            // labelKQ4
            // 
            this.labelKQ4.AutoSize = true;
            this.labelKQ4.Location = new System.Drawing.Point(20, 43);
            this.labelKQ4.Name = "labelKQ4";
            this.labelKQ4.Size = new System.Drawing.Size(40, 24);
            this.labelKQ4.TabIndex = 15;
            this.labelKQ4.Text = "kq4";
            // 
            // labelKQ1
            // 
            this.labelKQ1.AutoSize = true;
            this.labelKQ1.Location = new System.Drawing.Point(247, 43);
            this.labelKQ1.Name = "labelKQ1";
            this.labelKQ1.Size = new System.Drawing.Size(40, 24);
            this.labelKQ1.TabIndex = 12;
            this.labelKQ1.Text = "kq1";
            // 
            // labelKQ3
            // 
            this.labelKQ3.AutoSize = true;
            this.labelKQ3.Location = new System.Drawing.Point(96, 43);
            this.labelKQ3.Name = "labelKQ3";
            this.labelKQ3.Size = new System.Drawing.Size(40, 24);
            this.labelKQ3.TabIndex = 14;
            this.labelKQ3.Text = "kq3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(171, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 24);
            this.label5.TabIndex = 18;
            this.label5.Text = "KQ 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 24);
            this.label4.TabIndex = 17;
            this.label4.Text = "KQ 4";
            // 
            // labelKQ2
            // 
            this.labelKQ2.AutoSize = true;
            this.labelKQ2.Location = new System.Drawing.Point(171, 43);
            this.labelKQ2.Name = "labelKQ2";
            this.labelKQ2.Size = new System.Drawing.Size(40, 24);
            this.labelKQ2.TabIndex = 13;
            this.labelKQ2.Text = "kq2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 24);
            this.label2.TabIndex = 16;
            this.label2.Text = "KQ 3";
            // 
            // labelTrangThai
            // 
            this.labelTrangThai.AutoSize = true;
            this.labelTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTrangThai.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelTrangThai.Location = new System.Drawing.Point(228, 185);
            this.labelTrangThai.Name = "labelTrangThai";
            this.labelTrangThai.Size = new System.Drawing.Size(66, 24);
            this.labelTrangThai.TabIndex = 7;
            this.labelTrangThai.Text = "Status";
            // 
            // btn_DangNhap
            // 
            this.btn_DangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_DangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DangNhap.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btn_DangNhap.Location = new System.Drawing.Point(7, 94);
            this.btn_DangNhap.Name = "btn_DangNhap";
            this.btn_DangNhap.Size = new System.Drawing.Size(115, 71);
            this.btn_DangNhap.TabIndex = 5;
            this.btn_DangNhap.Text = "Đăng nhập";
            this.btn_DangNhap.UseVisualStyleBackColor = false;
            this.btn_DangNhap.Click += new System.EventHandler(this.btn_DangNhap_Click);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelTime.Location = new System.Drawing.Point(139, 185);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(30, 24);
            this.labelTime.TabIndex = 4;
            this.labelTime.Text = "@";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(629, 327);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Auto $$$";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChoi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Button btn_DangNhap;
        private System.Windows.Forms.Label labelTrangThai;
        private System.Windows.Forms.Label labelCountLoad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelKQ4;
        private System.Windows.Forms.Label labelKQ3;
        private System.Windows.Forms.Label labelKQ2;
        private System.Windows.Forms.Label labelKQ1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labeli9;
        private System.Windows.Forms.Label labeli8;
        private System.Windows.Forms.Label labeli7;
        private System.Windows.Forms.Label labeli6;
        private System.Windows.Forms.Label labeli5;
        private System.Windows.Forms.Label labeli4;
        private System.Windows.Forms.Label labeli3;
        private System.Windows.Forms.Label labeli2;
        private System.Windows.Forms.Label labeli1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtURLWeb;
        private System.Windows.Forms.Label label9;
    }
}

