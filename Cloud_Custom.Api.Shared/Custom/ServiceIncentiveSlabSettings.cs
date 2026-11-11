using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class ServiceIncentiveSlabSettings
    {
        public string Branch { get; set; }
        public int ParameterCode { get; set; }
        public string Parameter { get; set; }
        public string Target { get; set; }
        public string Slab { get; set; }
        public string incentive { get; set; }
        public string WEFDate { get; set; }
        public Dropdown BranchCode { get; set; }
        public Dropdown Designation { get; set; }
        public List<ServiceIncentiveSlabSettings> ServiceIncentiveList { get; set; }
        public SlabItem SlabItem { get; set; }

    }
    public class SlabItem
    {
        public int BranchCode { get; set; }
        public string Branch { get; set; }
        public bool Applicablity { get; set; }
        public string Target { get; set; }
        public string SlabFrom { get; set; }
        public string SlabTo { get; set; }
        public string Incentive { get; set; }
        public int ParameterCode { get; set; }
        public int DesignationCode { get; set; }
        public string WEFDate { get; set; }
        public List<SlabItem> slabList { get; set; }
    }

}

