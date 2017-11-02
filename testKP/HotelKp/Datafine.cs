using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
namespace testKP
{
   
   
    //---------------------------------------------------------------------------

    /// <summary>
    /// 通用信息
    /// </summary>
    public struct _PublicInfo
    {
        public static string addr;
        public static string LoadPath;            //图片文件夹路径地址
        public static string TerminalMac;         //终端Mac       
        public static string TAMID;
        public static string ZDMC; //终端名称
        public static string SWJGDM; //税务机关代码
        public static string SWJGMC; //税务机关名称
        public static string PWD;       //管理员密码
        public static string PrinterName; //打印机名称
        public static string CertificateName; //HTTPS证书路径
        public static string CertificatePwd;  //HTTPS证书密码

        public static string DKPSH; //代开盘税号
        public static string DKPMM;
        public static string TMDH;
        public static int ZPCamera;
        public static string PHBDKG;
        public static int SYFPFS;//票仓中剩余发票份数
        /// <summary>
        /// //是否暂停服务标示
        /// </summary>
        public static string LockService;

        public static string JSPKQ; // 金税盘开启状态

        public static string httpDebug; //网络调试模式

        public static string scannerCom; //扫描头串口号

        public static string scanDebug; //扫描头调试模式

        public static List<SQDXX> sqdList;
    }
    //---------------------------------------------------------------------------




    /// <summary>
    /// HTTP协议交互类库发送与返回的相关信息
    /// </summary>
    public struct _ProtocolState
    {
        /// <summary>
        /// 类库函数调用是否成功
        /// </summary>
        public static bool FunctionSuccess =false;
 
        /// <summary>
        /// 类库函数调用出错详细信息
        /// </summary>
        public static string FunctionErrorMsg="";


        /// <summary>
        /// 请求协议ID
        /// </summary>
        public static int ReqNo;



        /// <summary>
        /// 发送的XML字符串
        /// </summary>
        public static string InputXmlStr = "";

        /// <summary>
        ///  返回的XML字符串
        /// </summary>
        public static string OutPutXmlStr = "";

        /// <summary>
        /// 通信返回码
        /// </summary>
        public static string ReturnCode = "";       
    }

      /// <summary>
    /// 金税盘中发票库存信息
    /// </summary>
    public struct _Fpkcxx
    {
        public static string fpdm; //发票代码
        public static string fphm; //发票号码
        public static string fpfs;//发票份数
    }

    public class SQDXX
    {
        public string QDBZ; //清单标志
        public string FPZL; //发票种类
        public string SQDHM;//申请单号码
        public string NSRSBH;//代开方税号
    }

    //发票信息中的商品明细
    public class SPMX
    {
        public string DJ;// 单价
        public string GGXH;//规格型号
        public string HWMC;//货物名称
        public string HWSL;//数量
        public string JE;//金额
        public string JLDW;//单位
        public string SE;//税额
        public string SL;//税率
    }
    /// <summary>
    /// 发票开具信息
    /// </summary>
    public struct _Fpkjxx
    {
        public static string fpType = "0"; //发票种类 
        public static string GFMC; //购方名称
        public static string GFSH;//购方税号
        public static string GFYHZH;//购方银行账号
        public static string GFDZDH;//购方地址电话
        public static string ShuiLv;// 税率
        public static string XFSH;//销方税号
        public static string XFMC;//销方名称
        public static string XFDZDH;//销方地址电话
        public static string XFYHZH;//销方银行账号
        public static string FHR = "复核人";//复核人
        public static string SKR = "收款人";//收款人
        public static string SPSM = "";//商品税目
        public static string WSPZH;//完税凭证号
        public static List<SPMX> mxList;
        public static string ZJE; //总金额
        public static string ZSE; //总税额
        public static string KPCGBZ;//开票成功标志
        public static string DYCGBZ;//打印成功标志

    }
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;      
        
    }
    
}
