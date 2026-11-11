using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class WorkshopVsBay
    {
        public UserBase User { get; set; }
        public int BranchCode { get; set; }
        public int BranchDealershipCode { get; set; }
        public int stateCode { get; set; }
        public int RegionCode { get; set; }
        public int WorkShop { set; get; }
       


        public string BranchName { get; set; }
        public int  StoreType { get; set; }
        public string StoreTypeName { get; set; }


        public string DealershipName { get; set; }
        public string State { get; set; }
        public string Region { get; set; }
        public string? DMSCode { get; set; }
       

        public int SLno { get; set; }
      
        public List<WorkshopVsBay> List { get; set; }

        public List<WorkshopVsBay> BayList { get; set; }
        public int BayTypeCode { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }

        public string OneTechBay { get; set; }
        public string TwoTechBay { get; set; }
        public string ExpressBay { get; set; }
        public string BufferBay { get; set; }
        public string AllignmentBay { get; set; }
        public string ElectricalBay { get; set; }
        public string WashingBay { get; set; }


        public Dropdown Type { get; set; }
        public int WorkShopTypeCode { get; set; }
        public int Capacity { get; set; }
        public int AverageProductivityPerBay { get; set; }
        public int AverageServiceTime { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public int ActualBayCount { get; set; }
      
    }
}
