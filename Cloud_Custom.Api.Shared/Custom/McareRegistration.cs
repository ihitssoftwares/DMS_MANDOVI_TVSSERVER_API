using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class McareRegistration
    {
        public string Address { get; set; }
        public int BookingCode { get; set; }
        public string CustomerName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string RegistrationNo { get; set; }
        public string ModelName { get; set; }
        public string chasisNo { get; set; }
        public string VariantName { get; set; }
        public string Advisor { get; set; }
        public string KM { get; set; }
        public string status { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? BuyedDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string TimeSlots { get; set; }
        public string PlanAmount { get; set; }
        public string EntryNo { get; set; }
        public string planname { get; set; }
        public string SearchCustomerName { get; set; }
        public string SearchCustomerRegisterNo { get; set; }
        public string SearchPhoneNo { get; set; }
        public string city { get; set; }
        public string phone { get; set; }
        public string Model { get; set; }
        public int ModeCode { get; set; }
        public int VariantCode { get; set; }
        public string variant { get; set; }
        public string RegisterNumber { get; set; }
        public string EngineNumber { get; set; }
        public string GST { get; set; }
        public string VIN { get; set; }
        public string TransactionID { get; set; }
        public Dropdown PaymentMode { get; set; }
        public Dropdown Tax { get; set; }
        public Dropdown AppoinmentStatus { get; set; }

        public Dropdown ColourType { get; set; }
        public Dropdown PlanType { get; set; }
        public Dropdown VechicleModel { get; set; }

        public Dropdown Feedback { get; set; }
        public Dropdown Region { get; set; }
        public Dropdown Workshop { get; set; }
        public Dropdown ServiceAdvisor { get; set; }
        public Dropdown VechicleVariant { get; set; }

        public List<McareRegistration> McareRegistrationList { get; set; }
        public List<McareRegistrationSearch> SearchList { get; set; }
        public int EndingDate { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal NetAmount { get; set; }
        public string EntryUser { get; set; }
    }


    public class McareRegistrationSearch
    {
        public string CustomerName { get; set; }
        public string city { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }
        public string Model { get; set; }
        public string variant { get; set; }

        public string RegisterNumber { get; set; }
        public string Message { get; set; }
        public bool IsValid { get; set; }
    
    

    }
}