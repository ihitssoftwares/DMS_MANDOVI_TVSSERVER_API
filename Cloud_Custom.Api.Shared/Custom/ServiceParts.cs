using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class ServiceParts
    {
        public UserBase User { get; set; }
        public int ServicePartsCode { get; set; }

        public string Name { get; set; }
        public string ShortName { get; set; }
        //public Dropdown Regionn { get; set; }
        public string ServiceType { get; set; }
        //public string Mode { get; set; }
        public string ServiceCategory { get; set; }
        //public bool Active { get; set; }
        //public int ActiveCount { get; set; }
        //public int InactiveCount { get; set; }
        public List<ServiceParts> List { get; set; }
    }
}
