using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelZzKp
{

    class nomalVar
    {
        public static string bgpath_kjfp = "image\\kjfp.jpg";
        public static string bgpath_smsfz = "image\\smsfz.jpg";
        public static string bgpath_djlb = "image\\djlb.jpg";
        public static string bgpath_djlbmx = "image\\djlbmx.jpg";
        public static string bgpath_fpyl = "image\\fpyl.jpg";
        public static string bgpath_failkjfp = "image\\failkjfp.jpg";
        public static string bgpath_failsm = "image\\failsm.jpg";
        public static string bgpath_failsmsfz = "image\\failsmsfz.jpg";
        public static string bgpath_kjcg = "image\\kjcg.jpg";
        public static string bgpath_nodjmx = "image\\nodjmx.jpg";
        public static string bgpath_nodjxx = "image\\nodjxx.jpg";

        public static void ProcessClose(string exename)
        {
            Process[] localByNameApp = Process.GetProcessesByName(exename);//获取程序名的所有进程
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

        public static void EscPressClose(KeyPressEventArgs e, Form form)
        {
            if (e.KeyChar == (char)27)
            {
                DialogResult result = MessageBox.Show("确认退出？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                    form.Close();
                return;
            }
        }
    }
}
