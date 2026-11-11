using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
   public  class SalesRegister
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string Regionname { get; set; }
        public string Branchname { get; set; }
        public string custname { get; set; }
        public string modelname { get; set; }
        public string Executivename { get; set; }
        public Dropdown Region { get; set; }
        public Dropdown Branch { get; set; }
        public Dropdown Model { get; set; }
        public Dropdown Executive { get; set; }
        public Dropdown Month { get; set; }
        public int NetAmount { get; set; }
        public int Discount { get; set; }
        public int SaleAmount { get; set; }
        public int Revenue { get; set; }



        public string Address { get; set; }
        public int Phone { get; set; }
        public string Variant { get; set; }
        public string Color { get; set; }
        public string ChassisNo { get; set; }
        public string VinNo { get; set; }
        public string EngineNo { get; set; }



        public List<SalesRegister> SalesRegisterList { get; set; }
    }
}
