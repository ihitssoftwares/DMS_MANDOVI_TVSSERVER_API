using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Mobile
{
    public class TechnicianInOutSave
    {
        public UserBase User { get; set; }
        public string RegistrationNumber { get; set; }
        public int JobCardEntryCode { get; set; }
    }
}
