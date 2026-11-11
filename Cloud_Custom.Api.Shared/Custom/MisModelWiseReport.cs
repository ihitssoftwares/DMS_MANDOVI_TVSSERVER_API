using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class MisModelWiseReport
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int BranchCode { get; set; }
        public Dropdown Type { get; set; }
        public Dropdown Date { get; set; }
        public Dropdown Color { get; set; }
        public Dropdown Regions { get; set; }
        public Dropdown Channel { get; set; }
        // Common Output
        public int SlNo { get; set; }

        public string Region { get; set; }

        public string Branch { get; set; }

        public string Executive { get; set; }

        public string Model { get; set; }

        public int CarSales { get; set; }

        public decimal SaleValue { get; set; }

        public decimal Percentage { get; set; }
        public List<MisModelWiseReport> List { get; set; }
        public string Name { get; set; }
        public string Types { get; set; }

        public string ModeName { get; set; }
        public int ModeCode { get; set; }
        public int PBKG { get; set; }

        public int STK { get; set; }
        public int TY { get; set; }
        public int LY { get; set; }
        public int GOLY { get; set; }
        public int LM { get; set; }
        public int GOLM { get; set; }
        public int TotalGOLM { get; set; }
        public int TotalGOLY { get; set; }
        public int TotalLM { get; set; }
        public int TotalTY { get; set; }
        public int TYER { get; set; }
        public int TYBR { get; set; }
        public int TYEB { get; set; }
        public int LYER { get; set; }
        public int LYBR { get; set; }
        public int LYEB { get; set; }
        public int COEB { get; set; }
        public int COBR { get; set; }
        public int COER { get; set; }

        public  int TCOER { get; set;}
        public  int TCOBR { get; set;}
        public  int TCOEB { get; set; }
        public  int TLYER { get; set; }
        public  int TLYBR { get; set; }
        public int TLYEB { get; set; }
        public int TTYER { get; set; }
        public int TTYBR { get; set; }
        public int TTYEB { get; set; }

        /* ================= ENQUIRY ================= */
        public int EnquiryTY { get; set; }
        public int EnquiryLY { get; set; }
        public decimal EnquiryGrowth { get; set; }

        /* ================= BOOKING ================= */
        public int BookingTY { get; set; }
        public int BookingLY { get; set; }
        public decimal BookingGrowth { get; set; }

        /* ================= RETAIL ================= */
        public int RetailTY { get; set; }
        public int RetailLY { get; set; }
        public decimal RetailGrowth { get; set; }

        /* ============ CONVERSION RATIOS — CURRENT YEAR ============ */
        public decimal EnquiryToBookingTY { get; set; }
        public decimal BookingToRetailTY { get; set; }

        /* ============ CONVERSION RATIOS — LAST YEAR ============ */
        public decimal EnquiryToBookingLY { get; set; }
        public decimal BookingToRetailLY { get; set; }
        public decimal EnquiryToRetailLY { get; set; }
        public decimal EnquiryToRetailTY { get; set; }

        /* ================= NET RETAIL VALUE ================= */
        public decimal NetRetailAmountTY { get; set; }
        public decimal NetRetailAmountLY { get; set; }
        public decimal NetRetailGrowth { get; set; }


        public int EnquiryLM { get; set; }
        public decimal EnquiryGrowthLM { get; set; }

        public int BookingLM { get; set; }
        public decimal BookingGrowthLM { get; set; }

        public int RetailLM { get; set; }
        public decimal RetailGrowthLM { get; set; }
    }
}
