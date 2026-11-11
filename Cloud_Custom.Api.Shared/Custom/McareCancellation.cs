using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
  public  class McareCancellation
    {
        public Dropdown Plan { get; set; }
        public Dropdown Reason { get; set; }
        public int RegistrationEntryCode { get; set; }
        public string EntryNo { get; set; }
        public string RegistrationDate { get; set; }
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
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string BenefitUtilized { get; set; }
        public string CancellationEligibility { get; set; }
        public int RefundPercentage { get; set; }
        public decimal RefundAmount { get; set; }
        public Dropdown PaymentMode { get; set; }
        public string TransactionId { get; set; }
        public string Remarks { get; set; }
        public List<McareCancellation> CancellationList { get; set; }
    }
}
