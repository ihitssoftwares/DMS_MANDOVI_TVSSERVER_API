using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
   public  class AllAdminForms
    {
        public int MenuCode { get; set; }
        public string menuname { get; set; }
        public string ControllerName { get; set; }
        public List<AllAdminForms> MenuList { get; set; }
        public UserBase User { get; set; }
    }
}
