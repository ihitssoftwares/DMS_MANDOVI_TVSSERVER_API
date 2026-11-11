using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class TVSDetails
    {
        public UserBase User { get; set; }
        public string VehRegNo { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public string Plan { get; set; }
        public string Expiry { get; set; }
        public string MobNo { get; set; }
        public string Mail { get; set; }
        public List<TVSDetails> List { get; set; }

    }
}
