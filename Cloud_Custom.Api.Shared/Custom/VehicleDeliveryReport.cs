using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class VehicleDeliveryReport
    {
        public Dropdown Month { get; set; }

        public Dropdown Branch { get; set; }
        public UserBase User { get; set; }
        public List<VehicleDeliveryReport> List { get; set; }
        public string InvoiceNumber { get; set; }
        public string InvoiceDate { get; set; }
        public int BranchCode { get; set; }
        public string BranchName { get; set; }
        public string Customer { get; set; }
        public string Model { get; set; }
        public string Varient { get; set; }
        public string Colour { get; set; }
        public string VinNo { get; set; }
        public string Executive { get; set; }
        public Decimal SalesAmount { get; set; }
        public string OrderBookingNo { get; set; }
        public int ModelCode { get; set; }
        public int VarientCode { get; set; }
        public int ColourCode { get; set; }
        public int OrderTrnCode { get; set; }
        public string VehicleDeliveryDate { get; set; }
       
    }
}
