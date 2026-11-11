using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class Allotment
    {
        public int OrderTrnCode { get; set; }

        public string OrderDate { get; set; }
        public string OrderNo { get; set; }
        public string CustomerName { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string Emailid { get; set; }
        public string SalesExecutive { get; set; }
        public Dropdown Model { get; set; }
        public Dropdown variant { get; set; }
        public Dropdown Status { get; set; }
        public string EngineNo { get; set; }
        public string ChassisNo { get; set; }
        public string color { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public decimal BookingAmountPaid { get; set; }
        public List<Allotment> AllotmentList { get; set; }
        public AllotmentItem AllotmentItem { get; set; }
    }
    public class AllotmentItem
    {

        public int OrderTrnCode { get; set; }
        public string Model { get; set; }
        public string variant { get; set; }
        public string Color { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public Dropdown Allotment { get; set; }
        public string InvoiceNo { get; set; }
        public string Mode { get; set; }
        public string VehinNo { get; set; }
        public List<AllotmentItem> AllotmentItemList { get; set; }
        public string OrderNo { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Applicable { get; set; }
    }
}

