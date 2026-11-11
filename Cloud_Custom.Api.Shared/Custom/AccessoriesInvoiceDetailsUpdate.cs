using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class AccessoriesInvoiceDetailsUpdate
    {
        public Dropdown Month { get; set; }
        public Dropdown Branch { get; set; }

        public int DTCode { get; set; }
        public string InvNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string StoreBranch { get; set; }
        public string CustomerName { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public string Color { get; set; }
        public string Executive { get; set; }

        public int ItemCode { get; set; }
        public string SalesAccessoriesPartNumber { get; set; }
        public string AccessorieName { get; set; }
        public string PartCategory { get; set; }
      
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public int CostPrice { get; set; }
        public int SellingPrice { get; set; }
        public int Profit { get; set; }


        public int DocCode { get; set; }
        public string DocName { get; set; }
        public string AbsoluteUrl { get; set; }
        public string ActaulFileName { get; set; }
        public File File { get; set; }


        public List<AccessoriesInvoiceDetailsUpdate> List { get; set; }

        public string Applicability { get; set; }
    }
}
