using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class MobileServiceAdvisor
    {
        public int ServiceAdvisorCode { get; set; }
        public int CustomerCode { get; set; }
        public int MechanicCode { get; set; }
        public int BayUserCode { get; set; }
        public int CriticalJobs { get; set; }
        public int JobCardEntryCode { get; set; }
        public int BayCount { get; set; }
        public string BayName { get; set; }
        public string ServiceAdvisorName { get; set; }
        public string Type { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public DateTime PickedDate { get; set; }
        public DateTime ServiceDate { get; set; }
        public DateTime JobCardDate { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public string ActiveJobCount { get; set; }
        public string ReadyPickupCount { get; set; }
        public string JobCardID { get; set; }
        public string ModelName { get; set; }
        public string VariantName { get; set; }
        public string MechanicName { get; set; }
        public string Technician { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public string RegistrationNo { get; set; }
        public string BookingNumber { get; set; }
        public string ServiceDueType { get; set; }
        public string ServiceTypeName { get; set; }
        public string PreferredTimeSlot { get; set; }
        public string PreferredDate { get; set; }
        public string PickUpAddress { get; set; }

        public string Mileage { get; set; }
        public string EngineNo { get; set; }
        public string ChassisNo { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }
        public string KeyNo { get; set; }
        public string CustomerName { get; set; }
        public string CustomerID { get; set; }
        public string JobCardNo { get; set; }
        public int JCNotOpened { get; set; }
        public int JCOpened { get; set; }
        public int InBay { get; set; }
        public int BillPending { get; set; }
        public int Billed { get; set; }
        public int Hold { get; set; }
        public int Delayed { get; set; }
        public int DelayedInBay { get; set; }
        public decimal BillAmount { get; set; }
        public string Customer { get; set; }
        public string Regno { get; set; }
        public string Checkin { get; set; }
        public string jcStatus { get; set; }

        public string VehicleReg { get; set; }
        public string Jobcard { get; set; }

        public int count { get; set; }
        public string BayStatus { get; set; }
        public string TodaysAppointmentCount { get; set; }

        public int MCare { get; set; }
        public string ServiceName { get; set; }
        public int AllowedLimit { get; set; }
        public int Availed { get; set; }
        public int Balance { get; set; }
        public Dropdown Advisor { get; set; }
        public List<MobileServiceAdvisor> List { get; set; }
        public List<MobileServiceAdvisor> BayOccupancy { get; set; }
        public List<MobileServiceAdvisor> CardList { get; set; }
        public List<MobileServiceAdvisor> BayList { get; set; }
        public List<MobileServiceAdvisor> DriverList { get; set; }
        public List<MobileServiceAdvisor> TodaysAppointments { get; set; }
        public List<MobileServiceAdvisor> ActiveJobs { get; set; }
        public List<MobileServiceAdvisor> ReadyForPickup { get; set; }
        public BayApplicablity BayApplicablity { get; set; }
        public BayApplicablity BayDetails { get; set; }
       
    }
    public class BayApplicablity
    {
        public int BayCode { get; set; }
        public string Bayname { get; set; }
        public int BayTypeCode { get; set; }
        public string BayTypename { get; set; }
        public bool Applicability { get; set; }
        public int JobCardCode { get; set; }
        public Dropdown WorkShop { get; set; }
        public List<BayApplicablity> BayDetailsList { get; set; }  
    }
    

}
