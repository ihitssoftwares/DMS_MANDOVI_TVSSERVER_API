using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
   public  class StoreOrBranch
    {
        public UserBase User { get; set; }
        public int BranchCode { get; set; }
        public int SLno { get; set; }
        public string Mode { get; set; }
        public string Branchname { get; set; }
        public string ShortName { get; set; }
        public string StoreType { get; set; }
        public string Dealername { get; set; }
        public Dropdown Dealer { get; set; }
        public Dropdown State { get; set; }
        public Dropdown Region { get; set; }
        public Dropdown Type { get; set; }

        public string StateName { get; set; }
        public string RegionName { get; set; }
        public string TypeName { get; set; }

        public Dropdown Workshoponly { get; set; }
        public int? Code { get; set; }
        public string Name { get; set; }
        public bool Applicable { get; set; }

        public string? DMSCode { get; set; }
        public List<StoreOrBranch> List { get; set; }



        public int DtCode { get; set; }
        public string MatchingName { get; set; }

        public List<StoreOrBranch> PopupList { get; set; }



        public int WorkShop { get; set; }
        public bool WorkShopActive { get; set; }
        public bool MDSActive { get; set; }
        public bool TVActive { get; set; }
        public bool Active { get; set; }
        public string WorkShopOrBranch { get; set; }
        public string Pin { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string SalesDealerCode { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }

    }
}
