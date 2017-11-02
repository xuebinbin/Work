namespace testKP
{
    partial class FPMXKJ_Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.gfmc_text = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gfsh_text = new System.Windows.Forms.TextBox();
            this.mx_listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.kj_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button_fpxx = new System.Windows.Forms.Button();
            this.comboBox_fptype = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_fphm = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_fpdm = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button_print = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "购方名称：";
            // 
            // gfmc_text
            // 
            this.gfmc_text.Location = new System.Drawing.Point(75, 33);
            this.gfmc_text.Name = "gfmc_text";
            this.gfmc_text.Size = new System.Drawing.Size(174, 21);
            this.gfmc_text.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "购方税号：";
            // 
            // gfsh_text
            // 
            this.gfsh_text.Location = new System.Drawing.Point(75, 60);
            this.gfsh_text.MaxLength = 20;
            this.gfsh_text.Name = "gfsh_text";
            this.gfsh_text.Size = new System.Drawing.Size(174, 21);
            this.gfsh_text.TabIndex = 1;
            // 
            // mx_listView
            // 
            this.mx_listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mx_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.mx_listView.FullRowSelect = true;
            this.mx_listView.GridLines = true;
            this.mx_listView.Location = new System.Drawing.Point(15, 112);
            this.mx_listView.Name = "mx_listView";
            this.mx_listView.Size = new System.Drawing.Size(537, 233);
            this.mx_listView.TabIndex = 2;
            this.mx_listView.UseCompatibleStateImageBehavior = false;
            this.mx_listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "序号";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "费用名称";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 90;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "单价";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "数量";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "金额";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 80;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "单据号";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 90;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "明细：";
            // 
            // kj_btn
            // 
            this.kj_btn.Location = new System.Drawing.Point(478, 27);
            this.kj_btn.Name = "kj_btn";
            this.kj_btn.Size = new System.Drawing.Size(75, 23);
            this.kj_btn.TabIndex = 4;
            this.kj_btn.Text = "开具";
            this.kj_btn.UseVisualStyleBackColor = true;
            this.kj_btn.Click += new System.EventHandler(this.kj_btn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(478, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "打开金税盘";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_fpxx
            // 
            this.button_fpxx.Location = new System.Drawing.Point(270, 60);
            this.button_fpxx.Name = "button_fpxx";
            this.button_fpxx.Size = new System.Drawing.Size(75, 23);
            this.button_fpxx.TabIndex = 6;
            this.button_fpxx.Text = "发票信息";
            this.button_fpxx.UseVisualStyleBackColor = true;
            this.button_fpxx.Click += new System.EventHandler(this.button_fpxx_Click);
            // 
            // comboBox_fptype
            // 
            this.comboBox_fptype.FormattingEnabled = true;
            this.comboBox_fptype.Items.AddRange(new object[] {
            "普通发票",
            "专用发票"});
            this.comboBox_fptype.Location = new System.Drawing.Point(75, 10);
            this.comboBox_fptype.Name = "comboBox_fptype";
            this.comboBox_fptype.Size = new System.Drawing.Size(121, 20);
            this.comboBox_fptype.TabIndex = 7;
            this.comboBox_fptype.SelectedIndexChanged += new System.EventHandler(this.comboBox_fptype_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "发票类型:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(263, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "发票号码：";
            // 
            // textBox_fphm
            // 
            this.textBox_fphm.Location = new System.Drawing.Point(326, 2);
            this.textBox_fphm.Name = "textBox_fphm";
            this.textBox_fphm.Size = new System.Drawing.Size(100, 21);
            this.textBox_fphm.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(263, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "发票代码：";
            // 
            // textBox_fpdm
            // 
            this.textBox_fpdm.Location = new System.Drawing.Point(326, 29);
            this.textBox_fpdm.Name = "textBox_fpdm";
            this.textBox_fpdm.Size = new System.Drawing.Size(100, 21);
            this.textBox_fpdm.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(351, 60);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "关闭金税盘";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_print
            // 
            this.button_print.Location = new System.Drawing.Point(478, 54);
            this.button_print.Name = "button_print";
            this.button_print.Size = new System.Drawing.Size(75, 23);
            this.button_print.TabIndex = 12;
            this.button_print.Text = "打印";
            this.button_print.UseVisualStyleBackColor = true;
            this.button_print.Click += new System.EventHandler(this.button_print_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(478, 80);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FPMXKJ_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 354);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button_print);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox_fpdm);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_fphm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_fptype);
            this.Controls.Add(this.button_fpxx);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.kj_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mx_listView);
            this.Controls.Add(this.gfsh_text);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gfmc_text);
            this.Controls.Add(this.label1);
            this.Name = "FPMXKJ_Form";
            this.Text = "FPMXKJ_Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FPMXKJ_Form_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox gfmc_text;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox gfsh_text;
        private System.Windows.Forms.ListView mx_listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button kj_btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_fpxx;
        private System.Windows.Forms.ComboBox comboBox_fptype;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_fphm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_fpdm;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_print;
        private System.Windows.Forms.Button button3;
    }
}