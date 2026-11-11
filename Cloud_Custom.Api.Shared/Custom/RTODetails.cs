using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class RTODetailsRegistration
    {
        public string TabName { get; set; }
        public int RegistrationCode { get; set; }
        public int OrderTrnCode { get; set; }
        public Dropdown Status { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public string AllotedStatus { get; set; }
        public decimal NetAmount { get; set; }
        public decimal ReceivedAmount { get; set; }
        public decimal BalanceDue { get; set; }
        public decimal BalanceAmt { get; set; }
        public string ReceiptNo { get; set; }
        public int IsAllotedOrNot { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public string TransactionNo { get; set; }
        public decimal NewReceivedAmount { get; set; }
        public Dropdown PaymentMode { get; set; }
        public decimal PerOfBalance { get; set; }
        public string Remarks { get; set; }
        public string Mode { get; set; }
        public List<Registration> Registration { get; set; }
        public CustomerStatus CustomerStatus { get; set; }
        public CustomerDetails CustomerDetails { get; set; }
        public VehicleDetails VehicleDetails { get; set; }
        public InsuranceDetails InsuranceDetails { get; set; }
        public FinanceDetails FinanceDetails { get; set; }
        public IdentityDetails IdentityDetails { get; set; }
        public RTODetails RTODetails { get; set; }
        public RegistrationDetails RegistrationDetails { get; set; }
        public RCDetails RCDetails { get; set; }
        public HSRPDetails HSRPDetails { get; set; }
        public AppointmentDetails AppointmentDetails { get; set; }
        public FitmentDetails FitmentDetails { get; set; }

    }
    public class RegistrationDetails
    {
        public string RegistrationNumber { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string TemporaryRegistrationNumber { get; set; }
        public Dropdown PermanentRegistrationStatus { get; set; }
        public decimal? RoadTaxAmount { get; set; }
        public DateTime? TaxPaidDate { get; set; }
        public string TaxReceiptNumber { get; set; }
        public decimal? GreenTax { get; set; }
        public decimal? SmartCardFee { get; set; }
        public string HypothecationEntryStatus { get; set; }
        public string BankNOCStatus { get; set; }
        public bool? HPEndorsementInRC { get; set; }
    }

    public class RCDetails
    {
        public bool? RCIssued { get; set; }
        public string RCNumber { get; set; }
        public DateTime? RCIssueDate { get; set; }
        public Dropdown RCDispatchStatus { get; set; }
        public string TrackingNumber { get; set; }
    }

    public class HSRPDetails
    {
        public string HSRPOrderID { get; set; }
        public DateTime? HSRPOrderDate { get; set; }
        public string HSRPVendorName { get; set; }
        public Dropdown HSRPStatus { get; set; }

        public string TrackingNumber { get; set; }
        public string CourierName { get; set; }
        public DateTime? DispatchDate { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public DateTime? DeliveredToDealerDate { get; set; }
    }
    public class AppointmentDetails
    {
        public DateTime? AppointmentDate { get; set; }
        public Dropdown TimeSlot { get; set; }
        public string FitmentLocation { get; set; }
        public bool? CustomerConfirmation { get; set; }
        public int? RescheduleCount { get; set; }
    }

    public class FitmentDetails
    {
        public bool? FitmentDone { get; set; }
        public DateTime? FitmentDate { get; set; }
        public string TechnicianName { get; set; }
        public bool? CustomerOTPVerified { get; set; }
        public string InstallationPhotoPath { get; set; }
        public File InstallationPhotoFile { get; set; }
    }
}
