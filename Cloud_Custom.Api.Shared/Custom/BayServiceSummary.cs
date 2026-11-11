using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class BayServiceSummary
    {
        public Dropdown WorkShopCode { get; set; }
        public List<BayServiceSummary> BayList { get; set; }
        public List<BayServiceSummary> BaydetailsList { get; set; }
        public List<Bays> BaysList { get; set; }
        public bool Applicability { get; set; }
        public int BayCode { get; set; }
        public string BayName { get; set; }
        public string Technician { get; set; }
        public string intime { get; set; }
        public string outtime { get; set; }
        public GateIn GateIn { get; set; }
        public JobCard JobCard { get; set; }
        public BayVsTech BayVsTech { get; set; }
        public BayVsJob BayVsJob { get; set; }
        public TechnicianVsBay TechnicianVsBay { get; set; }
        public TechnicianInOut TechnicianInOut { get; set; }
        public JobcardCompletetion JobcardCompletetion { get; set; }
        public Bays bays { get; set; }
        public GateOut GateOut { get; set; }
        public string Date { get; set; }
      
    }
    
    public class Bays
    {

        public int BayCode { get; set; }
        public string BayName { get; set; }
        public bool Applicability { get; set; }
   
    }
    public class GateIn
    {
        public string gateDate { get; set; }
        public string RegNo { get; set; }
        public string Intime { get; set; }
        public Dropdown WorkShopCode { get; set; }
        public Dropdown Technician { get; set; }
        public List<GateIn> GateInList { get; set; }
    }
    public class JobCard
    {
        public Dropdown WorkShopCode { get; set; }
        public Dropdown Advisor { get; set; }
        public int CustomerCode { get; set; }
        public string JobcardNo { get; set; }
        public string CustomerName { get; set; }
        public string RegistrationNumber { get; set; }
        public string MobileNo { get; set; }
        public Dropdown RegNo { get; set; }
        public string JcDate { get; set; }
        public string CheckIntime { get; set; }
        public Dropdown Model { get; set; }
        public Dropdown Variant { get; set; }
      public string Modell { get; set; }
        public string Variantt { get; set; }
        public string ChassisNo { get; set; }
        public string EngineNo { get; set; }
        public string Address { get; set; }
        public string JobcardPickDate { get; set; }
        public List<JobCard> JobCardList { get; set; }

    }
    public class BayVsTech
    {

        public Dropdown Technician { get; set; }
        public Dropdown Bay { get; set; }
        public Dropdown WorkShop { get; set; }
        public string Date { get; set; }
        public List<BayVsJob> BayVsTechList { get; set; }

    }

    public class BayVsJob
    {
        public Dropdown WorkShopCode { get; set; }
        public Dropdown JobcardNo { get; set; }
        public string RegNo { get; set; }
        public string CustomerName { get; set; }
        public string MobileNo { get; set; }
        public int JobcardCode { get; set; }
        public string PickedDate { get; set; }
        public List<BayVsJob> BayVsJobList { get; set; }
    }

    public class TechnicianVsBay
    {

        public string Date { get; set; }
        public Dropdown Technician { get; set; }
        public Dropdown Bay { get; set; }
        public Dropdown WorkShop { get; set; }
        public string PickedDate { get; set; }
        public string Techniciann { get; set; }
        public string BayS { get; set; }
        public List<TechnicianVsBay> TechnicianVsBayList { get; set; }
    }

    public class TechnicianInOut
    {
        public string Date { get; set; }
        public Dropdown Technician { get; set; }
        public string JobCardCode { get; set; }
        public Dropdown JobCardNo { get; set; }
        public string Intime { get; set; }
        public string OUTTime { get; set; }
        public Dropdown Bay { get; set; }
        public Dropdown WorkShop { get; set; }
        public string Techniciann { get; set; }
        public string Bays { get; set; }
        public string WorkShopp { get; set; }
        public string PickedDate { get; set; }
        public string JcCardNo { get; set; }
        public List<TechnicianInOut> TechnicianInOutList { get; set; }
    }

    public class JobcardCompletetion
    {
        public Dropdown WorkShopCode { get; set; }
        public string Date { get; set; }
        public Dropdown JobcardNo { get; set; }
        public string RegNo { get; set; }
        public string BayName { get; set; }
        public string Intime { get; set; }
        public string Outtime { get; set; }
        public string JobCardNOS { get; set; }
        public int BayCode { get; set; }
        public string PickedDate { get; set; }
        public string Technician { get; set; }
        public List<JobcardCompletetion> JobcardCompletetionList { get; set; }
    }

    public class GateOut
    {
        public string vehicleRegNo { get; set; }
        public string Intime { get; set; }
        public string Outtime { get; set; }
        public Dropdown WorkShop { get; set; }
        public string PickedDate { get; set; }
        public List<GateOut> GateOutList { get; set; }

    }

    public class JobCardResponse 
    {
        public string JobCardNo { get; set; }
   
    }
public class GateinResponse 
    {
        public string RegNo     { get; set; }
        public string  inTime      { get; set; }
   
    }

}
