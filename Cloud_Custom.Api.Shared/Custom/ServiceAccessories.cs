using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class ServiceAccessories
    {
        public UserBase User { get; set; }
        public int AccessoriesCode { get; set; }
        public string Name { get; set; }

        public Dropdown Group { get; set; }
        //public bool BSLabour { get; set; }
        //public bool SLabour { get; set; }

        public int isAssigned { get; set; }
        public List<ServiceAccessories> List { get; set; }

    }
}
