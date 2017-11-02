using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using System.Threading;
namespace HotelZzKp
{
    public partial class Form1 : Form
    {
        IDCardReaderOpt idreader;
        public string m_strID;
        public Form1()
        {
            InitializeComponent();
            initshow();
        }
        private void initshow()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

           // this.BackgroundImage = Image.FromFile(nomalVar.bgpath_kjfp);
            this.BackgroundImageLayout = ImageLayout.Stretch;

            PreventScreenFlicker();

            SetBtnStyle(button_kjfp);


        }
        public void PreventScreenFlicker()
        {
            //背景闪烁问题
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true); // 双缓冲
            this.UpdateStyles();
        }
        public void SetBtnStyle(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;//样式
            btn.ForeColor = Color.Transparent;//前景
            btn.BackColor = Color.Transparent;//去背景
            btn.FlatAppearance.BorderSize = 1;//去边线
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;//鼠标经过
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;//鼠标按下
            //无焦点的按钮，获取到焦点时不显示虚框
            MethodInfo methodinfo = btn.GetType().GetMethod("SetStyle", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod);
            methodinfo.Invoke(btn, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod, null, new object[] { ControlStyles.Selectable, false }, Application.CurrentCulture);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //开始扫描身份证
            //this.BackgroundImage = Image.FromFile(nomalVar.bgpath_smsfz);
            //button_kjfp.Visible = false;

            //idreader = IDCardReaderOpt.getInstance();
            //idreader.IDCardRearBack += new EventHandler<IDCardRearEventArgs>(idreader_IDCardRearBack);
            //if (idreader.StartReader() == 0)
            //{
            //    LogLib.log.WriteLog("1", "启动身份证读卡器失败:", "", "");

            //    MessageBox.Show("启动身份证读卡器失败");

            //}
            //else
            //{
            //    LogLib.log.WriteLog("1", "启动身份证读卡器成功 开始扫描:", "", "");

            //}

          //  this.BackgroundImage = Image.FromFile(nomalVar.bgpath_smsfz);
          //  Thread.Sleep(5000);

            djxx_Form djxxform = new djxx_Form(m_strID);
            djxxform.ShowDialog();
        }
        void idreader_IDCardRearBack(object sender, IDCardRearEventArgs e)
        {

            try
            {
                if (e.ResCode == "1")
                {
                    m_strID = e.IDNum;

                    //关闭身份证扫描
                    idreader.StopReader();


                    //this.Hide();
                    //关闭当前窗体
                    //djxx_Form djxxform = new djxx_Form(m_strID);
                    //djxxform.ShowDialog();

                   // getDjlb();
                }

                if (e.ResCode == "-1")
                {
                    MessageBox.Show("扫描中发生异常请重新开启扫描");
                }
            }
            catch (Exception ex)
            {
                LogLib.log.WriteLog("3", "异常错误", "", ex.Message);
                MessageBox.Show("异常错误");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process[] localByNameApp = Process.GetProcessesByName("HotelZzKp");//获取程序名的所有进程
            if (localByNameApp.Length > 0)
            {
                foreach (var app in localByNameApp)
                {
                    if (!app.HasExited)
                    {
                        app.Kill();//关闭进程
                    }
                }
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                DialogResult result = MessageBox.Show("确认退出？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                    this.Close();
                return;
            }
        }

    }
}
