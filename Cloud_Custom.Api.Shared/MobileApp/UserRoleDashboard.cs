using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.MobileApp
{
  public   class UserRoleDashboard
    {
        public List<Security> SecurityCountLIst { get; set; }
        public List<Security> SecurityDetailsLIst { get; set; }
        public List<Security> SecurityHistoryDetailsLIst { get; set; }
        public List<Security> SecurityPendingLIst { get; set; }
        public List<Security> vehiclepasslist { get; set; }
    }
    public class Security
    { 
     public int VehichleIn { get; set; }
     public int VehichleOut { get; set; }
     public int TrnCode { get; set; }
     public int VehichlePending { get; set; }
     public int WorkShopCode { get; set; }
     public int GatePassCode { get; set; }
     public string VehichleRegNo { get; set; }
     public string VehichleName { get; set; }
     public string VehichleInTime { get; set; }
     public string VehichleOutTime { get; set; } 
    }

}
