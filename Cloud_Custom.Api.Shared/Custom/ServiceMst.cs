using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class ServiceMst
    {
        public UserBase User { get; set; }
        public int ServiceCode { get; set; }
        public string Name { get; set; }
       
        public Dropdown Group { get; set; }
        public Dropdown Category { get; set; }
        //public bool BSLabour { get; set; }
        //public bool SLabour { get; set; }

        public int isAssigned { get; set; }
        public List<ServiceMst> List { get; set; }
    }
}
