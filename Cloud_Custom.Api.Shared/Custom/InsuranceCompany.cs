using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class InsuranceCompany
    {
        public UserBase User { get; set; }
        public string Mode { get; set; }
        public int InsComCode { get; set; }

        public string InsComName { get; set; }

        public bool Active { get; set; }


        public List<InsuranceCompany> List { get; set; }
    }
}
