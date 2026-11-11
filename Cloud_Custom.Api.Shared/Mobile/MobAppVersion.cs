using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Mobile
{
    public class MobAppVersion
    {
        public string AndroidVersion { get; set; }
        public string IOSVersion { get; set; }
        public string AndroidUrl { get; set; }
        public string IOSUrl { get; set; }
        public string updateStatus { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
