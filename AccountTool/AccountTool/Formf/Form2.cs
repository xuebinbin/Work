using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace AccountTool.Formf
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //创建一个名为testQuestion的库  
            
            dynamicDb.CreateDataBase("questionType", "MSSql2012");

            //用一个dictionary类型，来保存 数据库表的字段 和 数据类型  
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("questionName", "varchar(20)");
            dic.Add("content", "varchar(20)");

            //在questionType库中创建一张名为xuanzeti的表  
            dynamicDb.CreateDataTable("questionType", "xuanzeti", dic, "MSSql2012");
        }
    }
}
