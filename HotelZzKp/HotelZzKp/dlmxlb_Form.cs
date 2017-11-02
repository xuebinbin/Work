using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;

namespace HotelZzKp
{
    public partial class dlmxlb_Form : Form
    {
        private IList<Invoicemx> invomx = new List<Invoicemx>();
        private BindingList<Invoicemx> Binvomx;
        string m_djh, m_gfmc;
        public dlmxlb_Form(string _djh, string _gfmc)
        {
            m_djh = _djh;
            m_gfmc = _gfmc;
            InitializeComponent();
            initBackgroud();
            initdate();
        }
        public void initdate()
        {
           // comboBox_fptype.Text = "普通发票";
            textBox_mc.Text = m_gfmc;
            textBox_nsrsbh.Text = "913700007456721192";
            debuggetDjlb();
            //initlistview();
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

            SetBtnStyle(button_fh);
            SetBtnStyle(button_sm);
            SetBtnStyle(button_yl);
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
        private bool openJSP(ref string err)
        {

            bool bres =  KPJK.Open("12345678", ref err);
          //  LogLib.log.WriteLog()
          if(bres)
          {
              LogLib.log.WriteLog("1", "金税盘打开", "", "");
              return true;    
          }
          else
            {
                LogLib.log.WriteLog("1", "金税盘打开失败", "", "");
                return false;
            }
            
        }
        private string m_fptype;
        private void getDebugFpkjxx()
        {
            _Fpkcxx.fpdm = "1100094110";
            _Fpkcxx.fphm = "87654321";

            _Fpkjxx.fpType = "1";
            _Fpkjxx.GFMC = textBox_mc.Text;
            _Fpkjxx.GFSH = textBox_nsrsbh.Text;
            _Fpkjxx.GFYHZH = "中国银行";
            _Fpkjxx.GFDZDH = "0582898150";
            _Fpkjxx.XFDZDH = "青岛";
            _Fpkjxx.XFYHZH = "28040101040017988";
            _Fpkjxx.XFSH = "51370200MJD800318N";
            _Fpkjxx.XFMC = "青岛市特种设备";
            _Fpkjxx.SPSM = "商品税目";
            _Fpkjxx.WSPZH = "320150810000016306";

            _Fpkjxx.mxList = new List<SPMX>(5);
            for (int i = 0; i < 5; i++)
            {
                SPMX spmx = new SPMX();
                spmx.HWMC = "xhb"+(i+1).ToString();
                spmx.DJ = "100";
                spmx.HWSL = "10";
                spmx.JE = "1000";
                spmx.SL = "0.03";
                spmx.SE = (float.Parse(spmx.JE) * float.Parse(spmx.SL)).ToString();
                spmx.JLDW = "元";
                _Fpkjxx.mxList.Add(spmx);
            }
        }
        private void getdataforFpkjxx()
        {         
            m_fptype = "1";
            string err = "";
            //获取发票号码和发票代码
            bool bfpxx = KPJK.GetFpkcxx(m_fptype, ref err);
            if (!bfpxx)
            {
                MessageBox.Show("发库存信息获取失败");
                LogLib.log.WriteLog("1", "发库存信息获取失败", "", "");
                return ;
            }

            int count = dataGridView1.RowCount;
            if (count < 0)
            {
                MessageBox.Show("没有商品明细");
                return ;
            }
            if (textBox_mc.Text.Length < 0 || textBox_nsrsbh.Text.Length < 0)
            {
                MessageBox.Show("请填写购方名称或税号");
                textBox_mc.Focus();
                return ;
            }
            _Fpkjxx.fpType = m_fptype;
            _Fpkjxx.GFMC = textBox_mc.Text;
            _Fpkjxx.GFSH = textBox_nsrsbh.Text;
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
                spmx.HWMC = dataGridView1.Rows[i].Cells[0].ToString();
                spmx.DJ = dataGridView1.Rows[i].Cells[1].ToString();
                spmx.HWSL = dataGridView1.Rows[i].Cells[2].ToString();
                spmx.JE = dataGridView1.Rows[i].Cells[3].ToString();
                spmx.SL = "0.03";
                spmx.SE = (float.Parse(spmx.JE) * float.Parse(spmx.SL)).ToString();
                spmx.JLDW = "元";
                _Fpkjxx.mxList.Add(spmx);
            }

            
        }
        private void initlistview()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            string url = "http://hi-thinking.gicp.net:8014/FB_Order/hotelinterfaceinvoice.ashx?sParam={\"flag\":\"getinvoicelistdetail\",\"billcoid\": \"";
            //\"74073\"}";
            url += m_djh;
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
                    Invoicemx invotemp = new Invoicemx();                                    
                    invotemp.dcodename = info.invoicelistdetail[i].dcodename;
                    invotemp.quantity = info.invoicelistdetail[i].quantity;
                    invotemp.price = info.invoicelistdetail[i].price;
                    invotemp.amount = info.invoicelistdetail[i].amount;
                    invotemp.billcoid = info.invoicelistdetail[i].billcoid;
                    invomx.Add(invotemp);
                }
                Binvomx = new BindingList<Invoicemx>(invomx);

                //将DataGridView里的数据源绑定成BindingList

                this.dataGridView1.DataSource = Binvomx;
            }
        }

        private void button_fh_Click(object sender, EventArgs e)
        {
          //  KPJK.Close();
              this.Close();
        }

        private void dlmxlb_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            KPJK.Close();
            LogLib.log.WriteLog("1", "金税盘关闭", "", "");
        }

        private void button_yl_Click(object sender, EventArgs e)
        {
            getDebugFpkjxx();
            fpyl_Form fpylform = new fpyl_Form(m_djh);
            fpylform.ShowDialog();
        }

        private string errMsg;
        private bool state;
        private void button_sm_Click(object sender, EventArgs e)
        {
#if DEBUG
            textBox_mc.Text = "薛慧斌test";
            textBox_nsrsbh.Text = "111111111111111111";
            textBox_yhzh.Text = "建设银行 123456";
            textBox_dzdh.Text = "杏石口路甲18号";
            return;
#endif
            string data ="";
            long lenth;
            Scanner scanner = new Scanner("COM3", "0");

            try
            {

                //if (_PublicInfo.scanDebug == "1")
                //{
                //    state = true;
                //    data = @"https://nnfp.jss.com.cn/invoice/scan/k0.action?id=17071009512001034695";
                //    return;
                //}
                scanner.read();
                if (scanner.errMsg != "")
                {
                    state = false;
                    this.errMsg = scanner.errMsg;
                    return;
                }
                while (String.IsNullOrEmpty(data))
                {
                    //if (scanWorker.CancellationPending || timeOutFlag)
                    //{
                    //    state = false;
                    //    return;
                    //}
                    state = scanner.state;
                    data = scanner.data;
                    lenth = scanner.len;
                }


            }
            catch (Exception ex)
            {
                state = false;
                errMsg = "开启扫描头失败！";
                LogLib.log.WriteLog("3", "扫描二维码异常错误", "", ex.Message);
            }
            finally
            {
                scanner.data = "";
                scanner.Close();
            }
        }

        private void debuggetDjlb()
        {
            for (int i = 0; i < 5; i++)
            {
                Invoicemx invotemp = new Invoicemx();
                invotemp.dcodename = "xhb" + (i + 1).ToString();
               // invotemp.Gname = "xhb" + (i + 1).ToString();
                invotemp.quantity = "500";
                invotemp.price = "100";
                invotemp.amount = "50000";
                invotemp.billcoid = (1234567 + i).ToString();
                invomx.Add(invotemp);
            }

            Binvomx = new BindingList<Invoicemx>(invomx);

            //将DataGridView里的数据源绑定成BindingList

            this.dataGridView1.DataSource = Binvomx;
        }

    }
}
