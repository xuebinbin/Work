using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountTool.Formf;

namespace AccountTool
{
    public partial class Form1 : Form
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            //MainForm mainform = new MainForm();
            //mainform.MdiParent = this;
            //mainform.WindowState = FormWindowState.Normal;
            //mainform.Dock = DockStyle.Fill;
            //mainform.Show();
        }

        private void listView1_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void SsdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ssd_Form form1 = new Ssd_Form();
            form1.Show();
        }
    }
}
