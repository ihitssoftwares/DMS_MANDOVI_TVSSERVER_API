using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class BookingAndRetailReport
    {
        public UserBase User { get; set; }
        public string GroupName { get; set; }
        public int TotalBooking { get; set; }
        public int BookingCancel { get; set; }
        public int NetBooking { get; set; }
        public int TotalRetail { get; set; }
        public int Retailance { get; set; }
        public int NetRetail { get; set; }
        public int PendingBooking { get; set; }
        public string PreferredDate { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string ModelName { get; set; }
        public string FuelType { get; set; }
        public Dropdown ViewType { get; set; } = new Dropdown();
        public Dropdown Month { get; set; } = new Dropdown();
        public List<BookingAndRetailReport> List { get; set; }
        public int RetailCancel { get; set; }
    }


    public class StockBookingReportViewModel
    {

        public string PreferredDate { get; set; }



        public List<StockBookingRow> List { get; set; } = new List<StockBookingRow>();


        public List<BookingDetail> BookingList { get; set; } = new List<BookingDetail>();

        public int GrandTotalBooking { get; set; }
        public int GrandInStock { get; set; }
        public int GrandInTransit { get; set; }
        public int GrandAlloted { get; set; }
        public int GrandFreeStock { get; set; }
    }

    public class StockBookingRow
    {
        public int GroupKey { get; set; }
        public string GroupName { get; set; }

        public int ModelCode { get; set; }
        public int VariantCode { get; set; }
        public int ColorCode { get; set; }
        public int FuelTypeCode { get; set; }

        public string ModelName { get; set; }
        public string Variant { get; set; }
        public string Color { get; set; }
        public string FuelType { get; set; }

        public int TotalBooking { get; set; }
        public int InStock { get; set; }
        public int InTransit { get; set; }
        public int Alloted { get; set; }


    }


    public class BookingDetail
    {
        public int GroupKey { get; set; }
        public int ModelCode { get; set; }
        public int VariantCode { get; set; }
        public int ColorCode { get; set; }
        public int FuelTypeCode { get; set; }

        public int BookingId { get; set; }
        public string BookingNo { get; set; }
        public DateTime BookingDate { get; set; }

        public int Ageing { get; set; }

        public string CustomerName { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }

        public int DseId { get; set; }
        public string DseName { get; set; }
        public string TeamLeaderName { get; set; }
        public string BranchName { get; set; }

        public string ModelName { get; set; }
        public string Variant { get; set; }
        public string Color { get; set; }
        public string FuelType { get; set; }
        public string ChassisNo { get; set; }
        public string EngineNo { get; set; }

        public decimal ExShowroomPrice { get; set; }
        public decimal BookingAmount { get; set; }
        public string PaymentMode { get; set; }
        public string FinancierName { get; set; }

        public string BookingStatus { get; set; }
        public string AllotmentStatus { get; set; }
        public DateTime? AllotmentDate { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public string Remarks { get; set; }
    }
}
