using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Threading;
using myHttp;
using FpDate;

namespace HotelKp
{
    public partial class Form1 : Form
    {
        IDCardReaderOpt idreader;
        public string m_strID;
        AutoSizeFormClass asc = new AutoSizeFormClass();

        public Form1()
        {
            InitializeComponent();
            // idreader = IDCardReaderOpt.getInstance();
            // idreader.IDCardRearBack += new EventHandler<IDCardRearEventArgs>(idreader_IDCardRearBack);
            initshow();
        }
        private void initshow()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            this.BackgroundImage = Image.FromFile(nomalVar.bgpath_kjfp);
            this.BackgroundImageLayout = ImageLayout.Stretch;

            

            //背景闪烁问题
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true); // 双缓冲
            this.UpdateStyles();

            SetBtnStyle(button_kjfp);

            dataGridView1.Columns[0].HeaderText = "序号";
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].HeaderText = "单据号";
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].HeaderText = "名称";
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].HeaderText = "金额";
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].HeaderText = "抵店时间";
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].HeaderText = "离店时间";
            dataGridView1.Columns[5].Width = 100;

            //label1.Visible = false;
            //textBox1.Visible = false;
            dataGridView1.Visible = false;
        }
        private void SetBtnStyle(Button btn)
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

        private void Form1_Load(object sender, EventArgs e)
        {
            
            asc.controllInitializeSize(this);
            
        }

        private void button_kjfp_Click(object sender, EventArgs e)
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
            //getDjlb();

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

                    getDjlb();
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
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                DialogResult result = MessageBox.Show("确认退出？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if(result == DialogResult.OK)
                       this.Close();
                return;
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           // idreader.IDCardRearBack -= new EventHandler<IDCardRearEventArgs>(idreader_IDCardRearBack);
            this.Dispose();
            Process[] localByNameApp = Process.GetProcessesByName("HotelKp");//获取程序名的所有进程
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

        private IList<Invoice> invo = new List<Invoice>();
        private BindingList<Invoice> Binvo;
        private void getDjlb()
        {
            this.BackgroundImage = Image.FromFile(nomalVar.bgpath_djlb);
            //textBox1.Visible = true;
            dataGridView1.Visible = true;
                   
            // textBox1.Text = m_strID.ToString();
#if DEBUG
            //textBox1.Text = "210281198807112891";
            m_strID = "210281198807112891";
#endif
           
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            //string url =string.Format( "http://hi-thinking.gicp.net:8014/FB_Order/hotelinterfaceinvoice.ashx?sParam={\"flag\":\"getinvoicelist\",\"identity\": \"{0}\"}", IdCard.Text);
            string url = "http://hi-thinking.gicp.net:8014/FB_Order/hotelinterfaceinvoice.ashx?sParam={\"flag\":\"getinvoicelist\",\"identity\": \"";
            url += m_strID;
            url += "\"}";
            LogLib.log.WriteLog("1", "取单据url:", url, "");
            using (HttpWebResponse response = myHttp1.CreateHttpResponse(url))
            {
                Stream resStream = response.GetResponseStream();

                StreamReader streamReader = new StreamReader(resStream, Encoding.GetEncoding("gb2312"));
                string json = string.Empty;
                json = streamReader.ReadToEnd();
                streamReader.Close();

                var info = serializer.Deserialize<BillReq>(json);
                // string status = info.status;

                if (info.status.CompareTo("OK") != 0)
                {
                    string err = string.Format("获取单据失败，错误信息：{0}", info.Msg);
                    MessageBox.Show(err);
                    return;
                }
                for (int i = 0; i < info.invoicelist.Count; i++)
                {
                    Invoice invotemp = new Invoice();
                    invotemp.index = (i+1).ToString();            
                    invotemp.Gname = info.invoicelist[i].Gname;
                    invotemp.billcoid = info.invoicelist[i].billcoid;
                    invotemp.amount = info.invoicelist[i].amount;
                    invotemp.arrd = info.invoicelist[i].arrd;
                    invotemp.depd = info.invoicelist[i].depd;
                    invo.Add(invotemp);
                }

                Binvo = new BindingList<Invoice>(invo);

                //将DataGridView里的数据源绑定成BindingList

                this.dataGridView1.DataSource = Binvo;

            }
        }
    }
}
