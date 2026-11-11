using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class LabourCls
    {
        public UserBase User { get; set; }
        public int LabourCode { get; set; }
        public string  Desc { get; set; }
        public Dropdown Type { get; set; }
        public Dropdown Group { get; set; }
        public bool BSLabour { get; set; }
        public bool SLabour { get; set; }

        public int isAssigned { get; set; }
        public List<LabourCls> List { get; set; }
    }
}
