using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using System.Diagnostics;
using myHttp;
using FpDate;
namespace HotelKp
{
    public partial class djxx_Form : Form
    {
        private string m_IDtext;
        private IList<Invoice> invo = new List<Invoice>();
        private BindingList<Invoice> Binvo;
        AutoSizeFormClass asc = new AutoSizeFormClass();

        public djxx_Form(string IDtext)
        {
            m_IDtext = IDtext;
            
            InitializeComponent();
            initBackgroud();

            getDjlb();
        }
        
        private void djxx_Form_Load(object sender, EventArgs e)
        {
            textBox1.Text = m_IDtext.ToString();
            asc.controllInitializeSize(this);
        }
        private void initBackgroud()
        {
            this.BackgroundImage = Image.FromFile(nomalVar.bgpath_djlb);
            this.BackgroundImageLayout = ImageLayout.Stretch;

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            //背景闪烁问题
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true); // 双缓冲
            this.UpdateStyles();

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
        }
        private void getDjlb()
        {
            
#if DEBUG
            m_IDtext = "210281198807112891";
#endif
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            //string url =string.Format( "http://hi-thinking.gicp.net:8014/FB_Order/hotelinterfaceinvoice.ashx?sParam={\"flag\":\"getinvoicelist\",\"identity\": \"{0}\"}", IdCard.Text);
            string url = "http://hi-thinking.gicp.net:8014/FB_Order/hotelinterfaceinvoice.ashx?sParam={\"flag\":\"getinvoicelist\",\"identity\": \"";
            url += m_IDtext;
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
                    invotemp.index = (i + 1).ToString();
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
        private void djxx_Form_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                DialogResult result = MessageBox.Show("确认退出？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                    this.Close();
                return;
            }
        }

        private void djxx_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
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

        private void djxx_Form_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
