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
using myHttp;
using FpDate;
namespace testKP
{
    public partial class FPMXKJ_Form : Form
    {
        private string _djh;
        private string m_gfmc;
        public FPMXKJ_Form(string djh, string gfmc)
        {
            _djh = djh;
            m_gfmc = gfmc;
            InitializeComponent();
            initdate();
        }
        public void initdate()
        {
            comboBox_fptype.Text = "普通发票";
            gfmc_text.Text = m_gfmc;
            gfsh_text.Text = "913700007456721192";
            initlistview();
        }
        private void initlistview()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            string url = "http://hi-thinking.gicp.net:8014/FB_Order/hotelinterfaceinvoice.ashx?sParam={\"flag\":\"getinvoicelistdetail\",\"billcoid\": \"";
            //\"74073\"}";
            url += _djh;
            url += "\"}";
            LogLib.log.WriteLog("1", "单据明细url:", url, "");
            using (HttpWebResponse response = myHttp1.CreateHttpResponse(url))
            {
                Stream resStream = response.GetResponseStream();

                StreamReader streamReader = new StreamReader(resStream, Encoding.GetEncoding("gb2312"));
                string json = string.Empty;
                json = streamReader.ReadToEnd();
                streamReader.Close();

                var info = serializer.Deserialize<BillMxReq>(json);
                string status = info.status;

                //text_result.Text = status;

                for (int i = 0; i < info.invoicelistdetail.Count; i++)
                {               
                    ListViewItem item = new ListViewItem();
                    item = mx_listView.Items.Add((i + 1).ToString());
                    item.SubItems.Add(info.invoicelistdetail[i].dcodename);
                    item.SubItems.Add(info.invoicelistdetail[i].price);
                    item.SubItems.Add(info.invoicelistdetail[i].quantity);
                    item.SubItems.Add(info.invoicelistdetail[i].amount);
                    item.SubItems.Add(info.invoicelistdetail[i].billcoid);
                }

            }
        }

        private void kj_btn_Click(object sender, EventArgs e)
        {
            if (comboBox_fptype.SelectedItem.ToString() == "普通发票")
            {
                m_fptype = "0";
            }
            else
                m_fptype = "1";
            string err = "";
            bool bfpxx = KPJK.GetFpkcxx(m_fptype, ref err);
            if (!bfpxx)
            {
                MessageBox.Show("发库存信息获取失败");

            }
            else
            {
                textBox_fpdm.Text = _Fpkcxx.fpdm;
                textBox_fphm.Text = _Fpkcxx.fphm;
            }

            int count = mx_listView.Items.Count;
            if (count < 0)
            {
                MessageBox.Show("没有商品明细");
                return;
            }
            if (gfmc_text.Text.Length <0 || gfsh_text.Text.Length <0)
            {
                MessageBox.Show("请填写购方名称或税号");
                gfmc_text.Focus();
            }
            _Fpkjxx.fpType = m_fptype;
            _Fpkjxx.GFMC = gfmc_text.Text;
            _Fpkjxx.GFSH = gfsh_text.Text;
            _Fpkjxx.GFYHZH = "中国银行";
            _Fpkjxx.GFDZDH = "0582898150";
            _Fpkjxx.XFDZDH = "青岛";
            _Fpkjxx.XFYHZH = "28040101040017988";
            _Fpkjxx.XFSH = "51370200MJD800318N";
            _Fpkjxx.XFMC = "青岛市特种设备";
            _Fpkjxx.SPSM = "商品税目";
            _Fpkjxx.WSPZH = "320150810000016306";

            _Fpkjxx.mxList = new List<SPMX>(count);
            for (int i = 0; i < count; i++)
            {
                SPMX spmx = new SPMX();
                spmx.HWMC = mx_listView.Items[i].SubItems[1].Text;
                spmx.DJ = mx_listView.Items[i].SubItems[2].Text;
                spmx.HWSL = mx_listView.Items[i].SubItems[3].Text;
                spmx.JE = mx_listView.Items[i].SubItems[4].Text;
                spmx.SL = "0.03";
                spmx.SE = (float.Parse(spmx.JE) * float.Parse(spmx.SL)).ToString();
                spmx.JLDW = "元";
                _Fpkjxx.mxList.Add(spmx);
            }

            string err1 = "";
            bool ret = KPJK.KaiPiao(ref err1);
            if (!ret)
            {
                string strerr= string.Format("发票开具失败: {0}", err1); 
                MessageBox.Show(strerr);
            }
            else
            {
                MessageBox.Show("发票开具成功");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string err="";
            bool bopen = KPJK.Open("12345678", ref err);
            if (bopen)
            {
                MessageBox.Show("金税盘成功打开");

            }
            else
                MessageBox.Show("金税盘打开失败，确认密码是否正确");
        }

        private void button_fpxx_Click(object sender, EventArgs e)
        {
           // string fptype;
            if (comboBox_fptype.SelectedItem.ToString() == "普通发票")
            {
                m_fptype = "0";
            }
            else
                m_fptype = "1";
            string err = "";
            bool bfpxx = KPJK.GetFpkcxx(m_fptype, ref err);
            if (!bfpxx)
            {
                MessageBox.Show("发库存信息获取失败");

            }
            else
            {
                textBox_fpdm.Text = _Fpkcxx.fpdm;
                textBox_fphm.Text = _Fpkcxx.fphm;
            }
            
        }

        private void comboBox_fptype_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private string m_fptype;

        private void FPMXKJ_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
           // KPJK.Close();
            LogLib.log.WriteLog("1", "金税盘关闭", "", "");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (KPJK.Close())
            {
                MessageBox.Show("成功关闭金税盘");
                LogLib.log.WriteLog("1", "金税盘关闭", "", "");
            }
            else
                MessageBox.Show("金税盘关闭失败");
            
        }

        private void button_print_Click(object sender, EventArgs e)
        {
            //string err = "";
            //bool ret = KPJK.PrintFp(m_fptype, ref err);
            //if (!ret)
            //{
            //    string strerr = string.Format("发票打印失败: {0}", err);
            //    MessageBox.Show(strerr);
            //    LogLib.log.WriteLog("1", "发票打印失败", err, "");
            //}
            //else
            //    MessageBox.Show("打印成功");
            JavaScriptSerializer serializer = new JavaScriptSerializer();
          
            string url = "http://hi-thinking.gicp.net:8014/FB_Order/hotelinterfaceinvoice.ashx?sParam={\"flag\":\"makeinvoice\",\"billcoid\":\"";
            url += _djh;
            url += "\",\"indate\":\"";
            url += DateTime.Now.ToString("yyyyMMdd");
            url += "\",\"intime\":\"";
            url += DateTime.Now.ToString("hhmm");
            url += "\",\"incode\":\"";
            url += _Fpkcxx.fpdm;
            url += "\",\"inno\":\"";
            url += _Fpkcxx.fphm;
            url += "\"}";
            LogLib.log.WriteLog("1", "打印url:", url, "");
            using (HttpWebResponse response = myHttp1.CreateHttpResponse(url))
            {
                Stream resStream = response.GetResponseStream();

                StreamReader streamReader = new StreamReader(resStream, Encoding.GetEncoding("gb2312"));
                string json = string.Empty;
                json = streamReader.ReadToEnd();
                streamReader.Close();

                var info = serializer.Deserialize<printReq>(json);
                // string status = info.status;

                if (info.status.CompareTo("OK") != 0)
                {
                    string err = string.Format("打印失败，错误信息：{0}", info.Msg);
                    MessageBox.Show(err);
                    LogLib.log.WriteLog("1", "打印失败",info.Msg, "");
                    return;
                }
                else
                    MessageBox.Show("打印成功");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
