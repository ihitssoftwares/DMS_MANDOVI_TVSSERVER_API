
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Master
{
   public class ShiftDetails :Dropdown
    {      
        public string ShiftCode { get; set; }
        public Dropdown ShiftType { get; set; }
        public Dropdown ShiftCategory { get; set; }
        public Dropdown DutyRosterFontColor { get; set; }
        public string ShiftStartTime { get; set; }
        public Dropdown DutyRosterBackgroundColor { get; set; }
        public string ShiftEndTime { get; set; }
        public string BreakHourStartTime { get; set; }
        public string BreakHourEndTime { get; set; }
        public string FullDayHour { get; set; }
        public string HalfDayHour { get; set; }
        public string BreakHour { get; set; }
        public string ScheduledHour { get; set; }
        public bool ShiftAllowanceApplicable { get; set; }
        public List<ShiftDetails> ShiftList { get; set; }
    }
}
