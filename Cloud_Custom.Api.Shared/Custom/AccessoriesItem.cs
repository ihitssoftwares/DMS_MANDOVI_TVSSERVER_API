using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class AccessoriesItem
    {
        public string ItemName { get; set; }
        public string PartNumber { get; set; }
        public int CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public int ModelCode { get; set; }
        public string ModelName { get; set; }
        public Decimal Amount { get; set; }
        public int SlNo { get; set; }
        public List<AccessoriesItem> List { get; set; }
        public UserBase user { get; set; }
        public bool Active { get; set; }
        public int ActiveCount { get; set; }
        public int InactiveCount { get; set; }
        public Dropdown Category { get; set; }
        public Dropdown Model { get; set; }
        public string Mode { get; set; }
        public int ItemCode { get; set; }
        public bool ApplicableModel { get; set; }
    }
}
