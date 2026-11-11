using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class DataValidationAlerts
    {
        public Dropdown Module { get; set; }
        public List<DataValidationAlerts> List { get; set; }
        public int Code { get; set; }

        public int ModuleCode { get; set; }

        public string ModuleName { get; set; }

        public string Category { get; set; }

        public string Alert { get; set; }

        public string Severity { get; set; }

        public string Status { get; set; }

        public int AlertCount { get; set; }
        public string Item { get; set; }
        public string Description { get; set; }
        public List<DataValidationAlerts> AltertList { get; set; }
     
    }
   

}
