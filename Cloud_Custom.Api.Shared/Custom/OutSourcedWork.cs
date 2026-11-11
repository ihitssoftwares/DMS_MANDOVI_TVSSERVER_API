using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class OutSourcedWork
    {
        public UserBase User { get; set; }
        public string Mode { get; set; }
        public int OutSourcedWorkCode { get; set; }
        public int SLno { get; set; }
        public string OutSourcedWorkName { get; set; }
        public string ShortName { get; set; }
        public bool Active { get; set; }
        public int ActiveCount { get; set; }
        public int InactiveCount { get; set; }
        public List<OutSourcedWork> List { get; set; }
    }
}
