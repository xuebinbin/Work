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
using testKP.testForm;
using System.Threading;
using System.Diagnostics;

namespace testKP
{
    public partial class Form1 : Form
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        public Form1()
        {
            string err = "";
            KPJK.Open("12345678", ref err);
            
            InitializeComponent();
#if DEBUG
            IdCard.Text = "210281198807112891";
#endif
          //  foreach (ColumnHeader ch in listView1.Columns)
          //  { ch.Width = -2; }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void getDj_Click(object sender, EventArgs e)
        {
            if (IdCard.Text == null)
            {
                MessageBox.Show("身份证号不能为空！");
                IdCard.Focus();
                return;
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            //string url =string.Format( "http://hi-thinking.gicp.net:8014/FB_Order/hotelinterfaceinvoice.ashx?sParam={\"flag\":\"getinvoicelist\",\"identity\": \"{0}\"}", IdCard.Text);
            string url = "http://hi-thinking.gicp.net:8014/FB_Order/hotelinterfaceinvoice.ashx?sParam={\"flag\":\"getinvoicelist\",\"identity\": \"";
            url += IdCard.Text;
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

                if(info.status.CompareTo("OK") !=0 )
                {
                    string err = string.Format("获取单据失败，错误信息：{0}", info.Msg);
                    MessageBox.Show(err);
                    return;
                }


                for (int i = 0; i < info.invoicelist.Count; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item = listView1.Items.Add((i+1).ToString());
                    item.SubItems.Add(info.invoicelist[i].Gname);
                    item.SubItems.Add(info.invoicelist[i].billcoid);
                    item.SubItems.Add(info.invoicelist[i].amount);
                    item.SubItems.Add(info.invoicelist[i].arrd);
                    item.SubItems.Add(info.invoicelist[i].depd);
                }
              

            }

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                int index = listView1.SelectedItems[0].Index;
                string djh = listView1.Items[index].SubItems[2].Text;
                string gfmc = listView1.Items[index].SubItems[1].Text;
                //MessageBox.Show(djh);
                FPMXKJ_Form fpkj = new FPMXKJ_Form(djh, gfmc);
                fpkj.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            testIDCard_Form idform = new testIDCard_Form();
            idform.ShowDialog();
            //if (idform.m_strID.Length>0)
           // {
                IdCard.Text = idform.m_strID;
           // }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
           // bool ret = KPJK.Close();
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            KPJK.Close();

            Process[] localByNameApp = Process.GetProcessesByName("testKP");//获取程序名的所有进程
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            KPJK.Close();
            Thread.Sleep(5000);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(DateTime.Now.GetDateTimeFormats('D')[0].ToString());
        }
    }
}
