using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Account
{
    public class UserRoleDetails
    {
        public List<ApplicableMenus> ApplicableMenus { get; set; }
        public List<Dropdown> Location { get; set; }
        public List<Dropdown> Designation { get; set; }
        public List<Dropdown> Region { get; set; }

    }

        public class ApplicableMenus
        {
            public string Module { get; set; }
            public string SubModule { get; set; }
            public string Menus { get; set; }

        }
    
}
