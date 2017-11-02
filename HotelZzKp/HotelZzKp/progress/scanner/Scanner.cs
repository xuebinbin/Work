using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.IO.Ports;


namespace HotelZzKp
{
    //读取身份证信息数据事件参数
    //public class ScanEventArgs : EventArgs
    //{
    //    public bool state { get; set; }

    //    public int errCode { get; set; }

    //    public string data { get; set; }

    //    public long len { get; set; }

    //}


   public class Scanner
    {
        public bool state = false;
        public string errMsg = ""; 
       // private static Scanner instance;
        //public ScanEventArgs args; //事件传输参数

        public string data = "";
        public long len = 0;
        public string type = "0";

        SerialPortCtr spc;
       
       // comName 格式: COM1
        public Scanner(string comName,string type)
        {
            this.type = type;
            spc = new SerialPortCtr(comName);
            spc.DataReceived += new SerialPortCtr.SerialPortDataReceiveEventArgs(spc_DataReceived);  
        }
        //单例模式
        //public static Scanner getInstance()
        //{
        //    if (instance == null)
        //    {
        //        instance = new Scanner();

        //    }
        //    return instance;
        //}

        

        public void Close()
        {
            byte[] stopCmd;
            if (this.type == "0")
            {
                stopCmd = new byte[] { 0x1A, 0x55, 0x0D };
            }
            else 
            {
                stopCmd = new byte[] { 0xFF, 0x55, 0x0D };
            }
            //byte[] stopCmd = new byte[] { 0x1A, 0x55, 0x0D };
            //byte[] stopCmd = new byte[] { 0xFF, 0x55, 0x0D };
            spc.SendData(stopCmd, 0, stopCmd.Length);
            spc.closePort();
           
        }

        //启动识读
        public bool read()
        {
            
            try
            {
                //byte[] szBuf = new byte[lenth];
               // byte[] readCmd = new byte[] { 0x1A, 0x54, 0x0D};
               // byte[] readCmd = new byte[] { 0xFF, 0x54, 0x0D };

                byte[] readCmd;
                if (this.type == "0")
                {
                    readCmd = new byte[] { 0x1A, 0x54, 0x0D };
                }
                else
                {
                    readCmd = new byte[] { 0xFF, 0x54, 0x0D };
                }

                if (!spc.openPort())
                {
                    errMsg = "扫描头开启串口失败!";
                    state = false;
                    return false;
                }
                spc.SendData(readCmd,0,readCmd.Length);
                            
            state = true;
            return true;      

            }
            catch (Exception ex)
            {

                LogLib.log.WriteLog("3", "读取二维码异常错误", "", ex.Message);
                state = false;
                errMsg = "读取二维码异常错误" + ex.Message;
                return false;
            }
                      
          //  args.errCode = 0;
           
         }

        private void spc_DataReceived(object sender, SerialDataReceivedEventArgs e, byte[] bits)
        {

            data = Encoding.Default.GetString(bits);
            len = data.Length;
            state = true;

        }

      
    }
}
