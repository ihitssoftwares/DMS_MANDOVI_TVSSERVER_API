using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class ServiceParameterList
    {
        public Dropdown IncentiveGroup { get; set; }

        public int PendingCount { get; set; }
        public int ParameterCode { get; set; }
        public string ParameterName { get; set; }
        public string TargetType { get; set; }
        public string SlabType { get; set; }
        public string IncentiveType { get; set; }
        public string ParameterType { get; set; }
        public string Colorcode { get; set; }

        public List<ServiceParameterList> List { get; set; }
    }
}
