using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testKP.testForm
{
    public partial class Scanner_Form : Form
    {
        public Scanner_Form()
        {
            InitializeComponent();
        }
        string errMsg = "";
        string data = "";
        long lenth;
        Boolean state;
        private void scann_button_Click(object sender, EventArgs e)
        {
            
            Scanner scanner = new Scanner("COM3", "1");
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
    }
}
