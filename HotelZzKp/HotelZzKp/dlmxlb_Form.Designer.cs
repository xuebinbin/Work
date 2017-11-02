namespace HotelZzKp
{
    partial class dlmxlb_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlmxlb_Form));
            this.textBox_nsrsbh = new System.Windows.Forms.TextBox();
            this.textBox_dzdh = new System.Windows.Forms.TextBox();
            this.textBox_yhzh = new System.Windows.Forms.TextBox();
            this.textBox_mc = new System.Windows.Forms.TextBox();
            this.button_sm = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_yl = new System.Windows.Forms.Button();
            this.button_fh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_nsrsbh
            // 
            this.textBox_nsrsbh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_nsrsbh.Location = new System.Drawing.Point(267, 212);
            this.textBox_nsrsbh.Multiline = true;
            this.textBox_nsrsbh.Name = "textBox_nsrsbh";
            this.textBox_nsrsbh.Size = new System.Drawing.Size(302, 44);
            this.textBox_nsrsbh.TabIndex = 0;
            // 
            // textBox_dzdh
            // 
            this.textBox_dzdh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_dzdh.Location = new System.Drawing.Point(725, 159);
            this.textBox_dzdh.Multiline = true;
            this.textBox_dzdh.Name = "textBox_dzdh";
            this.textBox_dzdh.Size = new System.Drawing.Size(302, 44);
            this.textBox_dzdh.TabIndex = 0;
            // 
            // textBox_yhzh
            // 
            this.textBox_yhzh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_yhzh.Location = new System.Drawing.Point(725, 211);
            this.textBox_yhzh.Multiline = true;
            this.textBox_yhzh.Name = "textBox_yhzh";
            this.textBox_yhzh.Size = new System.Drawing.Size(302, 44);
            this.textBox_yhzh.TabIndex = 0;
            // 
            // textBox_mc
            // 
            this.textBox_mc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_mc.Location = new System.Drawing.Point(267, 156);
            this.textBox_mc.Multiline = true;
            this.textBox_mc.Name = "textBox_mc";
            this.textBox_mc.Size = new System.Drawing.Size(302, 44);
            this.textBox_mc.TabIndex = 0;
            // 
            // button_sm
            // 
            this.button_sm.BackColor = System.Drawing.Color.Transparent;
            this.button_sm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_sm.Location = new System.Drawing.Point(1066, 203);
            this.button_sm.Name = "button_sm";
            this.button_sm.Size = new System.Drawing.Size(170, 52);
            this.button_sm.TabIndex = 1;
            this.button_sm.UseVisualStyleBackColor = false;
            this.button_sm.Click += new System.EventHandler(this.button_sm_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView1.Location = new System.Drawing.Point(134, 372);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 35;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1102, 274);
            this.dataGridView1.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "dcodename";
            this.Column1.HeaderText = "费用名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 246;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "price";
            this.Column2.HeaderText = "单价";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 152;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "quantity";
            this.Column3.HeaderText = "数量";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 151;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "amount";
            this.Column4.HeaderText = "金额";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 151;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "billcoid";
            this.Column5.HeaderText = "单据号";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 398;
            // 
            // button_yl
            // 
            this.button_yl.BackColor = System.Drawing.Color.Transparent;
            this.button_yl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_yl.Location = new System.Drawing.Point(857, 667);
            this.button_yl.Name = "button_yl";
            this.button_yl.Size = new System.Drawing.Size(170, 51);
            this.button_yl.TabIndex = 3;
            this.button_yl.UseVisualStyleBackColor = false;
            this.button_yl.Click += new System.EventHandler(this.button_yl_Click);
            // 
            // button_fh
            // 
            this.button_fh.BackColor = System.Drawing.Color.Transparent;
            this.button_fh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_fh.Location = new System.Drawing.Point(1066, 667);
            this.button_fh.Name = "button_fh";
            this.button_fh.Size = new System.Drawing.Size(170, 51);
            this.button_fh.TabIndex = 3;
            this.button_fh.UseVisualStyleBackColor = false;
            this.button_fh.Click += new System.EventHandler(this.button_fh_Click);
            // 
            // dlmxlb_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1350, 730);
            this.Controls.Add(this.button_fh);
            this.Controls.Add(this.button_yl);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button_sm);
            this.Controls.Add(this.textBox_yhzh);
            this.Controls.Add(this.textBox_dzdh);
            this.Controls.Add(this.textBox_mc);
            this.Controls.Add(this.textBox_nsrsbh);
            this.Name = "dlmxlb_Form";
            this.Text = "dlmxlb_Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.dlmxlb_Form_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_nsrsbh;
        private System.Windows.Forms.TextBox textBox_dzdh;
        private System.Windows.Forms.TextBox textBox_yhzh;
        private System.Windows.Forms.TextBox textBox_mc;
        private System.Windows.Forms.Button button_sm;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button button_yl;
        private System.Windows.Forms.Button button_fh;
    }
}