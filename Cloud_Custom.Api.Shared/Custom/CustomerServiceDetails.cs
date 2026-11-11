using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public  class CustomerServiceDetails
    {
        public int CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string DMSCode { get; set; }
        public int DtCode { get; set; }
        public string WorkShopName { get; set; }
        public string ServiceAdvisorName { get; set; }
        public string mode { get; set; }
        public string Address1 { get; set; }
        public string ContactNo { get; set; }
        public string City { get; set; }
        public string MailId { get; set; }
        public string RegNo { get; set; }
        public string ModelName { get; set; }
        public string VariantName { get; set; }
        public string RunningKM { get; set; }
        public string BillAmt { get; set; }
        public string LastServiceType { get; set; }
        public DateTime LastServiceDate { get; set; }
        public Dropdown CarModel { get; set; }
        public Dropdown Variant { get; set; }
        public Dropdown Workshop { get; set; }
        public Dropdown ServiceAdvisor { get; set; }
        public Dropdown ServiceType { get; set; }
        public List<CustomerServiceDetails> List { get; set; }
    }
}
