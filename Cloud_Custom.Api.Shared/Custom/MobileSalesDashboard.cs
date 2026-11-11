using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Mobile
{
    public class MobileSalesDashboard
    {
        public int Slno { get; set; }

        public int UserCode { get; set; }

        public string EmpName { get; set; }

        public string EmpID { get; set; }

        public int Target { get; set; }
        public int Achieved { get; set; }
        public decimal AchievedPercent { get; set; }
        public int TotalEnquiry { get; set; }
        public int TotalBooking { get; set; }
        public int TotalRetail { get; set; }
        public int Pending { get; set; }
        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

        

        public string Name { get; set; }
        public int Code { get; set; }
        public int Count { get; set; }
        public List<MobileSalesDashboard> List { get; set; }

        public List<MobileSalesDashboard> Details { get; set; }
        public int Amount { get; set; }
        public string ModeOfEnquiry { get; set; }
        public string Status { get; set; }
        public string Color { get; set; }
        public string Variant { get; set; }
        public string Model { get; set; }
        public string Customer { get; set; }
        public string Branch { get; set; }
        public DateTime Date { get; set; }
        public string Number { get; set; }
        public int MonthCode { get; set; }
        public string Month { get; set; }
        public int WorkDayLeft { get; set; }
        public decimal DailyRequirment { get; set; }
        public string TLName { get; set; }
        public int IsTL { get; set; }
    }
}
