using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class MCareServiceReport
    {
        public UserBase User { get; set; }
        public Guid RegistrationEntryCode { get; set; }

        public string EntryNo { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string PlanName { get; set; }

        public string PackageDuration { get; set; }

        public string CustomerName { get; set; }

        public string Phone { get; set; }

        public string VehicleRegistrationNumber { get; set; }

        public string Model { get; set; }

        public string Variant { get; set; }

        public string Colour { get; set; }

        public string ChassisNo { get; set; }

        public string EngineNo { get; set; }

        public decimal PlanAmount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Status { get; set; }

        public List<MCareServiceReport> List { get; set; }
        public Dropdown Statuso { get; set; }
        public Dropdown Plan { get; set; }

        public ServicePopUpDetails PopUpDetails { get; set; }
        public int RegEntryCode { get; set; }
        public int Qty { get; set; }
    }



    public class ServicePopUpDetails
    {
        public int RegEntryCode { get; set; }
        public int ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public decimal? Amount { get; set; }
        public int Limit { get; set; }
        public int Alreadytaken { get; set; }
        public int precentage { get; set; }
        public string Description { get; set; }
        public string McareEntryNo { get; set; }
        public string Customer { get; set; }
        public string JobCardNo { get; set; }
        public decimal? ActualServiceCost { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public decimal? DiscountAmt { get; set; }
        public decimal? TaxSum { get; set; }
        public int taxtypecode { get; set; }
        public List<ServicePopUpDetails> PopUpList { get; set; }
        public List<ServicePopUpDetails> AllList { get; set; }
        public List<ServicePopUpDetails> AfterList { get; set; }
        public List<ServicePopUpDetails> ServiceList { get; set; }
        public Dropdown Tax { get; set; }
        public decimal? NetAmount { get; set; }
        public decimal? TaxPercentage { get; set; }
        public string LabourCode { get; set; }

        public string LabourDescription { get; set; }
    

       

        public decimal BasicAmount { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal ChargesAmount { get; set; }

        public decimal BillAmout { get; set; }

        public string VehicleRegistrationNumber { get; set; }

        public DateTime JcDate { get; set; }

        public string BillNo { get; set; }

        public DateTime BillDate { get; set; }

    }


}
