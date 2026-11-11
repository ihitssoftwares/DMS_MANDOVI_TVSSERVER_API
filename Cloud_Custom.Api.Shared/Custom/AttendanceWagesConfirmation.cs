using Cloud_Custom.Api.Shared.General;
using Cloud_Custom.Api.Shared.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class AttendanceWagesConfirmation
    {
        public int PendingCount { get; set; }
        public int ConfirmedCount { get; set; }
        public int EmployeeCode { get; set; }
        public Dropdown Month { get; set; }
        public Dropdown Filter { get; set; }
        public string TabValues { get; set; }
        public int ConfirmationStatus { get; set; }
        public Guid EmployeeGI { get; set; }
        public UserBase User { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeId { get; set; }
        public string Type { get; set; }
        public string Mode { get; set; }
        public string IDName { get; set; }
        public AttendanceWagesConfirmationDetails Details { get; set; }
        public List<AttendanceWagesConfirmationDetails> ConfirmationList { get; set; }
        public List<AttnDetails> AttnDetails { get; set; }
        public int HolidayCount { get; set; }
        public int OffdayCount { get; set; }
        public int OTCount { get; set; }
        public int LessCount { get; set; }
        public int ShiftCount { get; set; }
        public File Excel { get; set; }
        public string Tab { get; set; }
        public int MonthCode { get; set; }
        public decimal DeductionDays { get; set; }
        public string Remarks { get; set; }
        public Dropdown Designation { get; set; }
        public Dropdown Department { get; set; }
    }
    public class AttendanceWagesConfirmationDetails
    {
        public EmployeeHeader EmployeeHeader { get; set; }
        public int Month { get; set; }
        public int EmployeeCode { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public Guid EmployeeGI { get; set; }
        public Dropdown Designation { get; set; }
        public Dropdown Department { get; set; }
        public Dropdown Location { get; set; }
        public decimal ActualValue { get; set; }
        public decimal ConfirmedValues { get; set; }
        public string Remarks { get; set; }

        public decimal DeductionDays { get; set; }
        public decimal NoOfDays { get; set; }
        public decimal? MinutesToCut { get; set; }
        public string MinutesToCutstr { get; set; }
        public Filter Filter { get; set; }

        public int active { get; set; }
        public int totalRecords { get; set; }

        public int ActHrs { get; set; }
        public int ActMin { get; set; }
        public int ConfHrs { get; set; }
        public int ConfMin { get; set; }
        public decimal Late { get; set; }
        public decimal Early { get; set; }
        public decimal TotalDay { get; set; }
        public decimal Balance { get; set; }
        public decimal BalanceAfterDeduction { get; set; }
        public decimal LateHrDay { get; set; }

        public int Tab { get; set; }

    }
    public class AttnDetails
    {
        public string Date { get; set; }
        public string IN { get; set; }
        public string Out { get; set; }
        public string LateIn { get; set; }
        public string EarlyOut { get; set; }
        public string Total { get; set; }

        public string Type { get; set; }
        public string Value { get; set; }
        public ShiftDetails Shift { get; set; }
        public string ACTUALWORKING { get; set; }
        public string ScheduledHours { get; set; }
        public string LessHours { get; set; }

    }
}
