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
    
    public partial class testIDCard_Form : Form
    {
        IDCardReaderOpt idreader;
        public string  m_strID;
        public testIDCard_Form()
        {
            InitializeComponent();
            idreader = IDCardReaderOpt.getInstance();
            idreader.IDCardRearBack += new EventHandler<IDCardRearEventArgs>(idreader_IDCardRearBack);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (idreader.StartReader() == 0)
            {
                MessageBox.Show("启动身份证读卡器失败");
            }
            else
            {
                MessageBox.Show("启动身份证读卡器成功 可以开始扫描");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            idreader.StopReader();
            MessageBox.Show("停止身份证读卡器");
        }
        void idreader_IDCardRearBack(object sender, IDCardRearEventArgs e)
        {

            try
            {
                if (e.ResCode == "1")
                {
                    //读取数据赋值

                    pb_BmpPhoto.BackgroundImage = e.BmpPhoto;

                    txt_ID.Text = e.IDNum;
                    m_strID = e.IDNum;
                    txt_Name.Text = e.Name;
                    txt_Sex.Text = e.Sex;
                    txt_Nation.Text = e.Nation;
                    txt_Birthdate.Text = e.Birthdate;
                    txt_Address.Text = e.Address;
                    txt_Issue.Text = e.Issue;
                    lb7.Text = e.EffectedDate;
                    lb8.Text = e.ExpiredDate;
                }

                if (e.ResCode == "-1")
                {
                    MessageBox.Show("扫描中发生异常请重新开启扫描");
                }
            }
            catch (Exception ex)
            {
                // LogLib.log.WriteLog("3", "异常错误", "", ex.Message);
                MessageBox.Show("异常错误");
            }
        }

        private void testIDCard_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            idreader.IDCardRearBack -= new EventHandler<IDCardRearEventArgs>(idreader_IDCardRearBack);
           
          
            this.Dispose();
        }

        private void testIDCard_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
