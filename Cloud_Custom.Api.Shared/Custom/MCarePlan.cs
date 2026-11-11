using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
   public class MCarePlan
    {
        public int DescCode { get; set; }
        public string Name { get; set; }
        public string shortName { get; set; }
        public Dropdown DurationDrop { get; set; }
        public string Duration { get; set; }
        public string Mode { get; set; }
        public string Status { get; set; }
        public bool Active { get; set; }
        public int ActiveCount { get; set; }
        public int InactiveCount { get; set; }
        public List<MCarePlan> MCarePlanList { get; set; }
    }
}
