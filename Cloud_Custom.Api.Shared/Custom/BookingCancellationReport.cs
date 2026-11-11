using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class BookingCancellationReport
    {
        public Dropdown Month { get; set; } = new Dropdown();
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public Dropdown ViewType { get; set; } = new Dropdown();
        public int ReportType { get; set; } = 1;
        public List<BookingCancellationSummary> SummaryList { get; set; } = new List<BookingCancellationSummary>();
        public List<BookingCancellationDetail> DetailList { get; set; } = new List<BookingCancellationDetail>();
    }

    public class BookingCancellationSummary
    {
        public string GroupHeader { get; set; }
        public int BookingCancel { get; set; }
    }

    public class BookingCancellationDetail
    {
        public string GroupHeader { get; set; }
        public DateTime? BookingDate { get; set; }
        public int FollowupCount { get; set; }
        public bool HasTakenTestDrive { get; set; }
        public bool HasTakenHomeVisit { get; set; }
        public DateTime? CancellationDate { get; set; }
        public int DaysBookingToCancel { get; set; }
    }
}
