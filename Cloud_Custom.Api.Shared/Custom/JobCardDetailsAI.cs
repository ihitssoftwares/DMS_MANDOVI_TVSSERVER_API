using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class JobCardDetailsAI
    {
        public List<JobCardDetailItem> List { get; set; } = new List<JobCardDetailItem>();
        public string FolderPath { get; set; }
    }
    public class JobCardDetailItem
    {
        public int JobCardEntryCode { get; set; }
        public string JobCardNo { get; set; }
        public string CustomerName { get; set; }
        public string VehicleNo { get; set; }
        public string ServiceAdvisorName { get; set; }
        public DateTime JobCardDate { get; set; }
        public string Model { get; set; }
        public string CustomerMobile { get; set; }
        public string ServisorAdvisorMobile { get; set; }
        public string Mechanic { get; set; }
        public DateTime DeliveryDate { get; set; }

        /* Keep remaining fields for future */

        public string CustomerID { get; set; }
        public string Address { get; set; }
        public string RegNo { get; set; }
        public string Chassis { get; set; }
        public string KeyNo { get; set; }
        public string Mileage { get; set; }
        public string VehUserName { get; set; }
        public string Engine { get; set; }
        public string Email { get; set; }
        public string RevisedDate { get; set; }
        public string RevisedTime { get; set; }
        public string Pin { get; set; }
        public string PDFName { get; set; }

    }
    public class JobCardPhotoAI
    {
        public File File { get; set; }

        public int JobCardPhotoEntryCode { get; set; }

        public string AIResponse { get; set; }

        public string Status { get; set; }

        public UserBase User { get; set; }
    }


    public class JobCardPhotoResponse
    {
        public int JobCardPhotoEntryCode { get; set; }
        public string Status { get; set; }
        public string JobCardNo { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMobile { get; set; }
        public string VehicleNo { get; set; }
        public string Chassis { get; set; }
        public string KeyNo { get; set; }
        public string Mileage { get; set; }
        public string Model { get; set; }
        public string Engine { get; set; }
        public string ServiceAdvisor { get; set; }
        public string SAMobile { get; set; }
        public string EstimatedDate { get; set; }
        public string EstimatedTime { get; set; }
        public string AbsoluteUri { get; set; }
        public string ServiceType { get; set; }
    }
}
