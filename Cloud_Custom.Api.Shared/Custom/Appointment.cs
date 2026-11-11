using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
 public    class Appointment
    {
        public int AppointmentCode { get; set; }
        public string CustomerName { get; set; }
        public string MobileNo { get; set; }
        public string DOA { get; set; }
        public string AppointTime { get; set; }
        public Dropdown SalesExecutive { get; set; }
        public Dropdown SoourceOfEnq { get; set; }
        public Dropdown Model { get; set; }
        public Dropdown PurchaseTimeLine { get; set; }
        public string Location { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Address { get; set; }
        public List<Appointment> AppointmentList { get; set; }


        public string SalesManName { get; set; }
       
        public string ModelName { get; set; }
        public string TimeLine { get; set; }
        public string SourceOfEnquiry { get; set; }


}
}
