using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class RetailCancellationReport
    {
        public Dropdown Month { get; set; } = new Dropdown();
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public Dropdown ViewType { get; set; } = new Dropdown();
        public int ReportType { get; set; } = 1;
        public List<RetailCancellationSummary> SummaryList { get; set; } = new List<RetailCancellationSummary>();
        public List<RetailCancellationDetail> DetailList { get; set; } = new List<RetailCancellationDetail>();
    }

    public class RetailCancellationSummary
    {
        public string GroupHeader { get; set; }
        public int RetailCancel { get; set; }
    }

    public class RetailCancellationDetail
    {
        public string GroupHeader { get; set; }
        public DateTime? BookingDate { get; set; }
        public int FollowupCount { get; set; }
        public bool HasTakenTestDrive { get; set; }
        public bool HasTakenHomeVisit { get; set; }
        public DateTime? RetailDate { get; set; }
        public DateTime? CancellationDate { get; set; }
        public int DaysBookingToCancel { get; set; }
        public int DaysRetailToCancel { get; set; }
    }
}
