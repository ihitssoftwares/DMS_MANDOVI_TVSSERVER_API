using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class MCareCustomerDetails
    {

        
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string RegistrationDate { get; set; }
        public string EndDate { get; set; }
        public string VehRegNo { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public string PlanName { get; set; }
        public string Duration { get; set; }
        public DateTime ServiceDate { get; set; }

        public List<MCareCustomerDetails> List { get; set; }
        public List<ServiceDetails> CustomerServiceDetails { get; set; }
    }

    public class ServiceDetails
    {
        public int ServiceCode { get; set; }
        public string Name { get; set; }

        public int Amount { get; set; }
        public string Remarks { get; set; }
    }
}