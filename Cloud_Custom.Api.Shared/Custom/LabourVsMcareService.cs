using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class LabourVsMcareService
    {
        public UserBase User { get; set; }
        public int LabourCode { get; set; }

        public string ShortName { get; set; }
        public string Name { get; set; }
        public string McareService { get; set; }
        public Dropdown Service { get; set; }


        public List<LabourVsMcareService> List { get; set; }
    }
}
