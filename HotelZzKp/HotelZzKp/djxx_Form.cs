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
namespace HotelZzKp
{
    public partial class djxx_Form : Form
    {
        private string m_strID;
        private IList<Invoice> invo = new List<Invoice>();
        private BindingList<Invoice> Binvo;
        public djxx_Form(string _strId)
        {
            InitializeComponent();
            initBackgroud();
            //getDjlb();
            debuggetDjlb();
        }

        private void initBackgroud()
        {
            //this.BackgroundImage = Image.FromFile(nomalVar.bgpath_djlb);
            this.BackgroundImageLayout = ImageLayout.Stretch;

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            //背景闪烁问题
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true); // 双缓冲
            this.UpdateStyles();

            dataGridView1.DataSource = null;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.GreenYellow;
           
        }
        private void debuggetDjlb()
        {
            for (int i = 0; i < 5; i++)
            {
                Invoice invotemp = new Invoice();
                invotemp.index = (i + 1).ToString();
                invotemp.billcoid = (1234567 + i).ToString();
                invotemp.Gname = "xhb"+(i+1).ToString();           
                invotemp.amount = "500";
                invotemp.arrd = "20171010";
                invotemp.depd = "20171020";
                invo.Add(invotemp);
            }

            Binvo = new BindingList<Invoice>(invo);

            //将DataGridView里的数据源绑定成BindingList

            this.dataGridView1.DataSource = Binvo;
        }
        private void getDjlb()
        {

#if DEBUG
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

        private void djxx_Form_Load(object sender, EventArgs e)
        {

        }

        private void djxx_Form_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)27)
            //{
            //    DialogResult result = MessageBox.Show("确认退出？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //    if (result == DialogResult.OK)
            //        this.Close();
            //    return;
            //}
            nomalVar.EscPressClose(e, this);
        }

        private void djxx_Form_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // MessageBox.Show("您单击的是第" + (e.RowIndex + 1) + "行第" + (e.ColumnIndex + 1) + "列！");
           // MessageBox.Show("单元格的内容是：" + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //    MessageBox.Show("您单击的是第" + (e.RowIndex + 1) + "行第" + (e.ColumnIndex + 1) + "列！");
            //   MessageBox.Show("单元格的内容是：" + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            string djh = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string gfmc = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(); ;
            dlmxlb_Form mxform = new dlmxlb_Form(djh, gfmc);
            mxform.ShowDialog();
        }
    }
}
