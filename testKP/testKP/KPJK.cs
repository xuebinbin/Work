using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace testKP
{
    //开票接口
    class KPJK
    {
        //开启金税盘
        //[DllImport("M_GoldTax.dll", EntryPoint = "Open_Card",
        //CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        [DllImport("M_GoldTax.dll", EntryPoint = "Open_Card")]
        public static extern IntPtr Open_Card(byte[] inxml);

        //关闭金税盘
        [DllImport("M_GoldTax.dll", EntryPoint = "Close_Card")]
        public static extern bool Close_Card();

        //获取盘中发票信息
        [DllImport("M_GoldTax.dll", EntryPoint = "Get_FPXX")]
        public static extern IntPtr Get_FPXX(byte[] inxml);

        //校验开票信息
        [DllImport("M_GoldTax.dll", EntryPoint = "Check_Inv")]
        public static extern IntPtr Check_Inv(byte[] inxml);

        //开票
        [DllImport("M_GoldTax.dll", EntryPoint = "Makeout_Inv")]
        public static extern IntPtr Makeout_Inv(byte[] inxml);

        //打印发票
        [DllImport("M_GoldTax.dll", EntryPoint = "Print_Inv")]
        public static extern IntPtr Print_Inv(byte[] inxml);


        public static bool Open(string pswd, ref string errMsg)
        {
            try
            {
                string inStr = "<?xml version=\"1.0\" encoding=\"gb2312\"?><service id=\"Open_Card\" comment=\"打开金税盘\">" +
                              "<ROOT><PWD>" + pswd + "</PWD></ROOT></service>";
                LogLib.log.WriteLog("1", "inStr", inStr, "");
                byte[] inbyte = Encoding.Default.GetBytes(inStr);
                //  IntPtr outip = Marshal.AllocHGlobal(1000);
                IntPtr outip = Open_Card(inbyte);
                string outStr = Marshal.PtrToStringAnsi(outip);
                //byte[] outByte = Open_Card(inbyte);
                //string outStr = Encoding.Default.GetString(outByte);


                LogLib.log.WriteLog("1", "outStr", outStr, "");
                XElement xmlroot = XElement.Parse(outStr);
                if (xmlroot.Element("RTN_CODE").Value == "000")
                {
                    LogLib.log.WriteLog("1", "打开金税盘成功", "", "");
                    return true;
                }
                else
                {
                    errMsg = xmlroot.Element("RTN_MSG").Value;
                    LogLib.log.WriteLog("1", "打开金税盘失败", errMsg, "");
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogLib.log.WriteLog("3", "打开金税盘异常", ex.ToString(), "");
                errMsg = "打开金税盘异常";
                return false;
            }

           
        }

        public static bool Close()
        {
            return Close_Card();
        }

        public static bool GetFpkcxx(string fpType, ref string errMsg)
        {
            try
            {
                string inStr = "<?xml version=\"1.0\" encoding=\"gb2312\"?><service id=\"Get_FPXX\" comment=\"获取发票号码代码\">" +
               "<ROOT><FPZL>" + fpType + "</FPZL></ROOT></service>";
                LogLib.log.WriteLog("1", "inStr", inStr, "");
                byte[] inbyte = Encoding.Default.GetBytes(inStr);
                IntPtr outip = Get_FPXX(inbyte);
                string outStr = Marshal.PtrToStringAnsi(outip);

                LogLib.log.WriteLog("1", "outStr", outStr, "");

                XElement xmlroot = XElement.Parse(outStr);
                if (xmlroot.Element("RTN_CODE").Value == "000")
                {
                    _Fpkcxx.fpdm = xmlroot.Element("ROOT").Element("FPDM").Value;
                    _Fpkcxx.fphm = xmlroot.Element("ROOT").Element("FPHM").Value;
                    _Fpkcxx.fpfs = xmlroot.Element("ROOT").Element("FPFS").Value;
                    return true;
                }
                else
                {
                    errMsg = xmlroot.Element("RTN_MSG").Value;
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogLib.log.WriteLog("1", "获取发票号码代码异常", ex.ToString(), "");
                errMsg = "获取发票号码代码异常";
                return false;
            }
            
           
        }


        public static bool KaiPiao(ref string errMsg)
        {
            try
            {
                XDocument xDoc = new XDocument(
             new XDeclaration("1.0", "gb2312", null),
             new XElement("service", new XAttribute("id", "Makeout_Inv"), new XAttribute("comment", "发票开具"),
                  new XElement("ROOT",
                       new XElement("FPZL", _Fpkjxx.fpType),
                       new XElement("GFMC", _Fpkjxx.GFMC),
                       new XElement("GFSH", _Fpkjxx.GFSH),
                       new XElement("GFYHMCZH", _Fpkjxx.GFYHZH),
                       new XElement("GFDZDH", _Fpkjxx.GFDZDH),
                       new XElement("ShuiLv", "3"),
                       new XElement("ISMS", "N"),
                       new XElement("NOTE", "代开企业税号:" + _Fpkjxx.XFSH + " 代开企业名称:" + _Fpkjxx.XFMC),                   
                       new XElement("OTHERNOTE", ""),
                       new XElement("KPR", "开票人"),
                       new XElement("XFDZDH", _Fpkjxx.XFDZDH),
                       new XElement("XFYHMCZH", _Fpkjxx.XFYHZH),
                       new XElement("FHR", _Fpkjxx.FHR),
                       new XElement("SKR", _Fpkjxx.SKR),
                       new XElement("QDMC", ""),
                       new XElement("SPSM", _Fpkjxx.SPSM),
                       new XElement("WSPZH", _Fpkjxx.WSPZH),
                       new XElement("TYPE", "1"),
                       new XElement("DJJEHSBZ", "0"),
                       new XElement("ZB", "")
                       )
                     )
                  );

                XElement mxElmtList = xDoc.Element("service").Element("ROOT").Element("ZB");
                foreach (var temp in _Fpkjxx.mxList)
                {
                    XElement elmt = new XElement("ITEM",
                        new XElement("DJ", temp.DJ),
                        new XElement("GGXH", temp.GGXH),
                        new XElement("HWMC", temp.HWMC),
                        new XElement("HWSL", temp.HWSL),
                        new XElement("JE", temp.JE),
                        new XElement("JLDW", temp.JLDW),
                        new XElement("SE", temp.SE),
                        new XElement("SL", temp.SL)
                        );
                    mxElmtList.Add(elmt);
                }
                string inStr = "<?xml version=\"1.0\" encoding=\"gb2312\"?>"+xDoc.ToString();
                LogLib.log.WriteLog("1", "inStr", inStr, "");
                //  string outStr = Makeout_Inv(xDoc.ToString());


                byte[] inbyte = Encoding.Default.GetBytes(inStr);
                IntPtr outip = Makeout_Inv(inbyte);
                string outStr = Marshal.PtrToStringAnsi(outip);

                LogLib.log.WriteLog("1", "outStr", outStr, "");

                XElement xmlroot = XElement.Parse(outStr);
                if (xmlroot.Element("RTN_CODE").Value == "000")
                {
                    _Fpkjxx.KPCGBZ = "Y";
                    return true;
                }
                else
                {
                    _Fpkjxx.KPCGBZ = "N";
                    _Fpkjxx.DYCGBZ = "N";
                    errMsg = xmlroot.Element("RTN_MSG").Value;
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogLib.log.WriteLog("1", "开票异常", ex.ToString(), "");
                errMsg = "开票异常";
                return false;
            }
          
        }

        public static bool PrintFp(string fpType, ref string errMsg)
        {
            try
            {
                string inStr = "<?xml version=\"1.0\" encoding=\"gb2312\"?><service id=\"Print_Inv\" comment=\"打印发票\">" +
                              "<ROOT><FPZL>" + fpType + "</FPZL>" +
                              "<FPDM>" + _Fpkcxx.fpdm + "</FPDM>" +
                              "<FPHM>" + _Fpkcxx.fphm + "</FPHM>" +
                              "</ROOT></service>";
                LogLib.log.WriteLog("1", "inStr", inStr, "");
                // string outStr = Print_Inv(inStr);

                byte[] inbyte = Encoding.Default.GetBytes(inStr);
                IntPtr outip = Print_Inv(inbyte);
                string outStr = Marshal.PtrToStringAnsi(outip);
                LogLib.log.WriteLog("1", "outStr", outStr, "");

                XElement xmlroot = XElement.Parse(outStr);
                if (xmlroot.Element("RTN_CODE").Value == "000")
                {
                    _Fpkjxx.DYCGBZ = "Y";
                    return true;
                }
                else
                {
                    _Fpkjxx.DYCGBZ = "N";
                    errMsg = xmlroot.Element("RTN_MSG").Value;
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogLib.log.WriteLog("1", "发票打印异常", ex.ToString(), "");
                errMsg = "发票打印异常";
                return false;
            }
        }
           


    }
}
