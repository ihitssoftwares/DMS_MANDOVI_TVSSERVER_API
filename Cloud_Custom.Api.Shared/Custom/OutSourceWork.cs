using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class OutSourceWork
    {
        public Dropdown Month { get; set; }
        public Dropdown Branch { get; set; }
        public Dropdown Region { get; set; }
        public Dropdown Advisor { get; set; }
        public Dropdown Work { get; set; }
        public int JcCardCode { get; set; }
        public string JcCardNo { get; set; }
        public string JcCardDate { get; set; }
        public string Customer { get; set; }
        public string RegNo { get; set; }
        public string InvoiceNo { get; set; }
        public List<OutSourceWork> OutSourceWorkList { get; set; }
        public WorkPopup WorkPopup { get; set; }
    }
    public class WorkPopup
    {

        public int JcCardCode { get; set; }
        public string JcCardNo { get; set; }
        public string JcCardDate { get; set; }
        public string Customer { get; set; }
        public string RegNo { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string Amount { get; set; }
        public string Remark { get; set; }
        public List<WorkPopup> WorkPopupList { get; set; }
    }
}
