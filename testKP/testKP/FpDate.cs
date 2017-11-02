using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FpDate
{
    class BillReq
    {
        public List<Invoice> invoicelist { get; set; }
        public string status { get; set; }
        public string Msg { get; set; }
    }
    
    class Invoice
    {
        public string Gname { get; set;} //姓名
        public string arrd { get; set; }//抵店日期
        public string depd { get; set; }//离店日期
        public string amount { get; set; }//金额
        public string billcoid { get; set; }//单据号

    }
    class BillMxReq
    {
        public List<Invoicemx> invoicelistdetail { get; set; }
        public string status { get; set; }
        public string Msg { get; set; }
    }
    class Invoicemx
    {
        public string dcodename { get; set; } //费用名称
        public string quantity { get; set; }//数量
        public string price { get; set; }//单价
        public string amount { get; set; }//金额
        public string billcoid { get; set; }//单据号
    }
    class printReq
    {
        public string status { get; set; }
        public string Msg { get; set; }
    }
}
