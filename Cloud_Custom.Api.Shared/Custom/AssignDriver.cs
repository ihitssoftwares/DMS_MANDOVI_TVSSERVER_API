using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class AssignDriver
    {
        public Dropdown WORKSHOPES { get; set; }
        public Dropdown DriverList { get; set; }
        public int EmployeeCode { get; set; }
        public int BranchCode { get; set; }

        public List<AssignDriver> List { get; set; }
        public UserBase user { get; set; }
        public int isAssigned { get; set; }

        public int BookingCode { get; set; }
        public string BookingNumber { get; set; }
        public DateTime BookingDate { get; set; }
        public int CustomerCode { get; set; }
        public string CustomerName { get; set; }

        public string MobileNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public string Model { get; set; }
        public string ServiceDueType { get; set; }
        public string PickUpAddress { get; set; }
        public DateTime? PreferredDate { get; set; }
        public string PreferredTimeSlot { get; set; }
        public string ServiceTypeName { get; set; }

        public List<AssignDriver> CustomerList { get; set; }
        public string DriverName { get; set; }

    }
}
