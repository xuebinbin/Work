using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace HotelZzKp
{
    public partial class fpyl_Form : Form
    {
        private string m_djh;
        private IList<SPMX> spmx = new List<SPMX>();
        private BindingList<SPMX> Bspmx;
        public fpyl_Form(string _djh)
        {
            m_djh = _djh;
            InitializeComponent();
            initBackgroud();
            initdata();
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
           
            SetBtnStyle(button_fh);
            SetBtnStyle(button_fpkj);
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

        private void button_fpkj_Click(object sender, EventArgs e)
        {
            string err1 = "";
            bool ret = KPJK.KaiPiao(ref err1);
            if (!ret)
            {
                string strerr = string.Format("发票开具失败: {0}", err1);
                LogLib.log.WriteLog("1", strerr, "", "");
                MessageBox.Show(strerr);
                return;
            }
            else
            {
                // messagebox.show("发票开具成功");
                return ;
            }
        }

        private void httpfpprint()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            string url = "http://hi-thinking.gicp.net:8014/FB_Order/hotelinterfaceinvoice.ashx?sParam={\"flag\":\"makeinvoice\",\"billcoid\":\"";
            url += m_djh;
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
                    LogLib.log.WriteLog("1", "打印失败", info.Msg, "");
                    return;
                }
                else
                    MessageBox.Show("打印成功");
            }
        }
        private void button_fh_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void initdata()
        {
            text_fpdm.Text = _Fpkcxx.fpdm;
            text_fphm.Text = _Fpkcxx.fphm;
            text_gfmc.Text = _Fpkjxx.GFMC;
            text_gfnsrsbh.Text = _Fpkjxx.GFSH;
            text_gfdzdh.Text = _Fpkjxx.GFDZDH;
            text_gfyhzh.Text = _Fpkjxx.GFYHZH;
            text_xfmc.Text = _Fpkjxx.XFMC;
            text_xfsbh.Text = _Fpkjxx.XFSH;
            text_xfdzdh.Text = _Fpkjxx.XFDZDH;
            text_xfyhzh.Text = _Fpkjxx.XFYHZH;
            text_skr.Text = _Fpkjxx.SKR;
            text_fhr.Text = _Fpkjxx.FHR;
            text_kpr.Text = _Fpkjxx.KPR;
            text_bz.Text = _Fpkjxx.BZ;
            text_xsf.Text = _Fpkjxx.XFMC;

            float hjje = 0, hjse = 0, jshj = 0, jshjtemp = 0;

            for (int i = 0; i < _Fpkjxx.mxList.Count; i++)
            {
                SPMX spmxtemp = new SPMX();
                spmxtemp.HWMC = _Fpkjxx.mxList[i].HWMC; 
                // invotemp.Gname = "xhb" + (i + 1).ToString();
                spmxtemp.GGXH = _Fpkjxx.mxList[i].GGXH;
                spmxtemp.JLDW = _Fpkjxx.mxList[i].JLDW;
                spmxtemp.HWSL = _Fpkjxx.mxList[i].HWSL;
                spmxtemp.DJ = _Fpkjxx.mxList[i].DJ;
                spmxtemp.JE = _Fpkjxx.mxList[i].JE;
                spmxtemp.SL = _Fpkjxx.mxList[i].SL;
                spmxtemp.SE = _Fpkjxx.mxList[i].SE;
                hjje += Convert.ToSingle(spmxtemp.JE);
                hjse += Convert.ToSingle(spmxtemp.SE);              
                spmx.Add(spmxtemp);
            }

            Bspmx = new BindingList<SPMX>(spmx);

            //将DataGridView里的数据源绑定成BindingList

            this.dataGridView1.DataSource = Bspmx;

            //大写金额
            text_hjje.Text = hjje.ToString();
            text_hjse.Text = hjse.ToString();
            jshj = hjse + hjje;
            text_hjdx.Text = MoneyToString.GetCnString(jshj.ToString());
            text_hjxx.Text = jshj.ToString();

            text_date.Text = DateTime.Now.ToLongDateString().ToString();
        }
        
    }
}
