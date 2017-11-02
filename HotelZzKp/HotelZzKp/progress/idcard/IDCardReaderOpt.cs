using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace HotelZzKp
{
    ///模块：身份证读卡器相关方法类
    ///作用：读取身份证信息
    ///作者：黄山
    ///编写日期：2016-12-01
    //////

    //读取身份证信息数据事件参数
    public class IDCardRearEventArgs : EventArgs
    {
        /// <summary>
        /// 扫描返回 1 成功 -1 异常（需要重调用START） 0 未获取到信息（主动停止扫描）
        /// </summary>
        public string ResCode { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDNum { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        public string Nation { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public string Birthdate { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 签发机关
        /// </summary>
        public string Issue { get; set; }

        /// <summary>
        /// 有效期起始
        /// </summary>
        public string EffectedDate { get; set; }

        /// <summary>
        /// 有效期截止
        /// </summary>
        public string ExpiredDate { get; set; }

        /// <summary>
        /// 照片
        /// </summary>
        public Image  BmpPhoto { get; set; }

    }


    /// <summary>
    /// 身份证读卡器相关方法类
    /// </summary>
    public class IDCardReaderOpt
    {
        /// <summary>
        /// 自动搜索身份证阅读器并连接身份证阅读器
        /// 	>0	成功返回端口号
        ///	0	失败
        /// </summary>
        /// <returns></returns>
        [DllImport("termb.dll")]
        public static extern int InitCommExt();

        /// <summary>
        /// 断开与身份证阅读器连接
        /// 1	成功
        /// 0	失败
        /// </summary>
        /// <returns></returns>
        [DllImport("termb.dll")]
        public static extern int CloseComm();

        /// <summary>
        /// 卡认证
        /// -1				|	寻卡失败
        /// -2				|	选卡失败
        /// 0				|	其他错误
        /// </summary>
        /// <returns></returns>
        [DllImport("termb.dll")]
        public static extern int Authenticate();

        /// <summary>
        /// 读卡操作
        /// Active 
        /// 1 读基本信息，形成文字信息文件WZ.TXT、相片文件XP.WLT、ZP.BMP，如果有指纹信息形成指纹信息文件FP.DAT</param>
        /// 2				|	只读文字信息，形成文字信息文件WZ.TXT和相片文件XP.WLT
        /// 3				|	读最新住址信息，形成最新住址文件NEWADD.TXT
        /// </summary>
        /// <returns>1	成功</returns>
        [DllImport("termb.dll")]
        public static extern int Read_Content(int Active);


        /// <summary>
        /// 解析身份证照片
        /// </summary>
        /// <returns>1	成功</returns>
        [DllImport("termb.dll")]
        public static extern int GetBmpPhotoExt();

        /// <summary>
        /// 获取姓名
        /// </summary>
        /// <returns></returns>
        [DllImport("termb.dll")]
        public static extern void getName(byte[] data, int len);

        /// <summary>
        /// 获取性别
        /// </summary>
        /// <returns></returns>
        [DllImport("termb.dll")]
        public static extern void getSex(byte[] data, int len);

        /// <summary>
        /// 获取民族
        /// </summary>
        /// <returns></returns>
        [DllImport("termb.dll")]
        public static extern void getNation(byte[] data, int len);

        /// <summary>
        /// 获取生日(YYYYMMDD)
        /// </summary>
        /// <returns></returns>
        [DllImport("termb.dll")]
        public static extern void getBirthdate(byte[] data, int len);

        /// <summary>
        /// 获取地址
        /// </summary>
        /// <returns></returns>
        [DllImport("termb.dll")]
        public static extern void getAddress(byte[] data, int len);

        /// <summary>
        /// 获取身份证号
        /// </summary>
        /// <returns></returns>
        [DllImport("termb.dll")]
        public static extern void getIDNum(byte[] data, int len);

        /// <summary>
        /// 获取签发机关
        /// </summary>
        /// <returns></returns>
        [DllImport("termb.dll")]
        public static extern void getIssue(byte[] data, int len);

        /// <summary>
        /// 获取有效期起始日期(YYYYMMDD)
        /// </summary>
        /// <returns></returns>
        [DllImport("termb.dll")]
        public static extern void getEffectedDate(byte[] data, int len);

        /// <summary>
        /// 获取有效期截止日期(YYYYMMDD)
        /// </summary>
        /// <returns></returns>
        [DllImport("termb.dll")]
        public static extern void getExpiredDate(byte[] data, int len);

        private BackgroundWorker bw;//操作读卡器线程
        private bool IsRunReader = false;//读卡器扫描运行标志
        private IDCardRearEventArgs args; //事件传输参数

        
        /// <summary>
        /// 读卡器状态 0 未开启扫描  1 正在扫描 2 发生异常
        /// </summary>
        public int IDCarderRearState { get; set; }


        /// <summary>  
        /// 扫描身份证信息回调事件  
        /// </summary>  
        public event EventHandler<IDCardRearEventArgs> IDCardRearBack;


        private static IDCardReaderOpt instance;
        private IDCardReaderOpt()
        {
            bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

        }

        
        /// <summary>
        /// 单例模式
        /// </summary>
        /// <returns></returns>
        public static IDCardReaderOpt getInstance()
        {
            if (instance == null)
            {
                instance =new IDCardReaderOpt();
                
            }

            return instance;
        }

        /// <summary>
        /// 开启身份证读卡器扫描
        /// 1 成功  0 失败
        /// </summary>
        public  int StartReader()
        {

            if (IDCarderRearState == 1)
                return 1;

            args = new IDCardRearEventArgs();

            if (InitCommExt() == 0)
                return 0;

            if (!bw.IsBusy)
            {
               
                IsRunReader = true;

                //启动线程
                bw.RunWorkerAsync();

                IDCarderRearState = 1;
            }
            else
            {
                return 0;
            }


            return 1;

        }

        /// <summary>
        /// 停止身份证读卡器扫描
        /// </summary>
        public void StopReader()
        {
            IDCarderRearState = 0;
            IsRunReader = false;
            CloseComm();
           

        }


        //线程操作事件
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                while (IsRunReader)
                {
                    //没认证到卡一直循环认证
                    if (Authenticate() != 1)
                    {
                        Thread.Sleep(500);
                        continue;
                    }

                    //读卡失败重复读取
                    if (1 != Read_Content(1))
                    {
                        Thread.Sleep(500);
                        continue;
                    }

                    //解析照片
                    GetBmpPhotoExt();

                    //开始获取信息
                    byte[] tmpbuf = new byte[128];

                    //照片
                    byte[] imagebuf;
                    FileStream fileStream = new FileStream(Application.StartupPath + "\\zp.bmp", FileMode.Open, FileAccess.Read);
                    imagebuf = new byte[fileStream.Length];
                    fileStream.Read(imagebuf, 0, imagebuf.Length);
                    fileStream.Close();
                    MemoryStream ms = new MemoryStream(imagebuf);
                    args.BmpPhoto = Image.FromStream(ms);

                    //姓名
                    getName(tmpbuf, 128);
                    args.Name = Encoding.Default.GetString(tmpbuf).Trim('\0');

                    //性别
                    getSex(tmpbuf, 128);
                    args.Sex = Encoding.Default.GetString(tmpbuf).Trim('\0');

                    //民族
                    getNation(tmpbuf, 128);
                    args.Nation = Encoding.Default.GetString(tmpbuf).Trim('\0');

                    //出生日期
                    getBirthdate(tmpbuf, 128);
                    args.Birthdate = Encoding.Default.GetString(tmpbuf).Trim('\0');

                    //地址
                    getAddress(tmpbuf, 128);
                    args.Address = Encoding.Default.GetString(tmpbuf).Trim('\0');

                    //签发机关
                    getIssue(tmpbuf, 128);
                    args.Issue = Encoding.Default.GetString(tmpbuf).Trim('\0');

                    //身份证号
                    getIDNum(tmpbuf, 128);
                    args.IDNum = Encoding.Default.GetString(tmpbuf).Trim('\0');

                    //有效期起始
                    getEffectedDate(tmpbuf, 128);
                    args.EffectedDate = Encoding.Default.GetString(tmpbuf).Trim('\0');

                    //有效期截止
                    getExpiredDate(tmpbuf, 128);
                    args.ExpiredDate = Encoding.Default.GetString(tmpbuf).Trim('\0');


                    IDCarderRearState = 0;
                    e.Result = 1;
                    IsRunReader = false;
                    return;
                }

                IDCarderRearState = 0;
                e.Result = 0;
            }
            catch(Exception  ex)
            {
                //LogLib.log.WriteLog("3", "扫描线程异常错误", "", ex.Message);
                //扫描线程异常后关闭读卡器设备
                IsRunReader = false;
                IDCarderRearState = 2;
                e.Result = -1;
                CloseComm();
            }



        }

        //线程完成事件
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //LogLib.log.WriteLog("1", "扫描线程完成", "", "");
            
            args.ResCode = Convert.ToString(e.Result);

            if (IDCardRearBack != null)
            {
                IDCardRearBack(this, args);
            }

        }





    }
}
