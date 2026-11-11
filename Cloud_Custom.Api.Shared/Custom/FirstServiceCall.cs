using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
     public class FirstServiceCall
    {
        public int SlNo { get; set; }
        public int Attempt { get; set; }
        public string Status { get; set; }
        public string ServiceScheduleDate { get; set; }
        public string ServiceScheduleTime { get; set; }
        public string Location { get; set; }
        public string EmployeeName { get; set; }
        public string NextServicedate { get; set; }
        public string Deliverydate { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string Model { get; set; }
        public string Varient { get; set; }
        public string ColorName { get; set; }
        public string VehicleNo { get; set; }
        public string TransmissionName { get; set; }
        public string FuelName { get; set; }
        public string EngineNo { get; set; }
        public string ChasisNo { get; set; }
        public string CallDate { get; set; }
        public string CallTime { get; set; }
        public string SeviceDateTime { get; set; }

        public string ServiceDate { get; set; }
        public string ServiceTime { get; set; }
        public string ServiceLocation { get; set; }
        public string Complaint { get; set; }
        public string Remarks { get; set; }
        public Dropdown CallBy { get; set; }
        public Dropdown CallAttempt { get; set; }
        public bool PickorDrop { get; set; }
        public Dropdown CallStatus { get; set; }
        public int RegistrationCode { get; set; }
        public int OrdertrnCode { get; set; }
        public int HDCode { get; set; }
        public List<FirstServiceCall> List { get; set; }
    }
}
