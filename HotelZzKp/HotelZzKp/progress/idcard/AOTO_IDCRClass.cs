using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HotelZzKp
{
    class AOTO_IDCRClass
    {
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDNum { get; set; }

        [DllImport("AOTO_IDCR.dll")]
        public static extern int IDCR_Initialize(string lpszConfigXml);

        [DllImport("AOTO_IDCR.dll")]
        public static extern int IDCR_BeginRead();

        [DllImport("AOTO_IDCR.dll")]
        public static extern int IDCR_DataAvailable(ref bool lpAvailable);

        [DllImport("AOTO_IDCR.dll")]
        public static extern int IDCR_ReadData(int dwIndex, byte[] lpBuffer, int dwBufferSize, ref int  lpNumberOfBytesRead);

        [DllImport("AOTO_IDCR.dll")]
        public static extern int IDCR_CancelRead();

        [DllImport("AOTO_IDCR.dll")]
        public static extern int IDCR_GetStatus(ref int lpStatus);

        public int StartReader()
        {
            int ret = IDCR_Initialize("<?xml version=\"1.0\" encoding=\"utf-8\"?><Device>  <DeviceId>IDCard</DeviceId>  <LogLevel>3</LogLevel></Device>");
            if (ret != 0)
                return 0;
            ret = IDCR_BeginRead();
            if (ret != 0)
                return 0;


            return 1;
        }

        public int getIDnumber(byte[] data, int len)
        {
           // char lpBuffer[1024] = { 0 };
           // int n = sizeof(lpBuffer);
            int NumberOfBytesRead = 0;
            int ret = IDCR_ReadData(6, data, len, ref NumberOfBytesRead); //这里6表示取身份证号，其他值参考接口文档
            return ret;       
        }
        /// <summary>
        /// 停止身份证读卡器扫描
        /// </summary>
        public void StopReader()
        {
            IDCR_CancelRead();
        }

    }
}
