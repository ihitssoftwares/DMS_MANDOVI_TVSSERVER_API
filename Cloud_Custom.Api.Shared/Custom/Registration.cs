using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class Registration
    {
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
        public DateTime? DeliveryDate { get; set; }

        public List<Registration> RegistrationList { get; set; }
        public CustomeAccitem CustomeRecieptList { get; set; }
        public List<CostPrice> CostPriceList { get; set; }

        public CustomerDetails CustomerDetails { get; set; }
        public VehicleDetails VehicleDetails { get; set; }
        public InsuranceDetails InsuranceDetails { get; set; }
        public FinanceDetails FinanceDetails { get; set; }
        public IdentityDetails IdentityDetails { get; set; }
        public RTODetails RTODetails { get; set; }
        public CustomerStatus CustomerStatus { get; set; }
    }
    public class CustomerStatus
    {


        public DateTime? BookingDate { get; set; }
        public DateTime? InvoiceCompleted { get; set; }
        public DateTime? DRAFTDONEDATE { get; set; }
        public DateTime? VERIFYDATE { get; set; }
        public DateTime? FINALSUBMITDATE { get; set; }
        public string BookingNo { get; set; }
        public string RecieptNo { get; set; }

        public string ModelName { get; set; }
        public string VariantName { get; set; }

        public string FuelType { get; set; }
        public string TransmissionType { get; set; }

        public string ColorName { get; set; }
    }


    public class CustomerDetails
    {
        public int CustomerOrderTrnCode { get; set; }

        public string FullName { get; set; }

        public string FatherName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string MobileNumber { get; set; }

        public string EmailAddress { get; set; }

        public string AddressLine { get; set; }

        public string PostalCode { get; set; }

        public File Photo { get; set; }

        public Dropdown District { get; set; }

        public Dropdown States { get; set; }

    }
    public class VehicleDetails
    {
        public string EngineNumber { get; set; }

        public string ChassisNumber { get; set; }

        public Dropdown Model { get; set; }

        public Dropdown Variant { get; set; }

        public Dropdown Color { get; set; }

        public Dropdown FuelType { get; set; }

        public Dropdown TransmissionType { get; set; }
        public string InvoiceNumber { get; set; }

        public DateTime? InvoiceDate { get; set; }
        public decimal? ExShowroomPrice { get; set; }

    }



    public class InsuranceDetails
    {
        public Dropdown InsuranceCompanyName { get; set; }

        public string PolicyNumber { get; set; }


        public DateTime? PolicyStartDate { get; set; }

        public DateTime? PolicyEndDate { get; set; }


        public decimal? InsuredDeclaredValue { get; set; }

        public Dropdown PolicyType { get; set; }


        public decimal? PremiumAmount { get; set; }
        public File Insurance { get; set; }


    }


    public class FinanceDetails
    {

        public bool IsFinanced { get; set; }

        public Dropdown Financier { get; set; }

        public decimal? LoanAmount { get; set; }
        public int? TenureInMonths { get; set; }
        public string LoanAccountNumber { get; set; }
        public File Form34 { get; set; }
    }


    public class IdentityDetails
    {
        public string AadhaarNumber { get; set; }

        public string PanCardNumber { get; set; }

        public string PassportNumber { get; set; }

        public string VoterIdNumber { get; set; }

        public string DrivingLicenseNumber { get; set; }

        public File Aadhaar { get; set; }
        public File PanCard { get; set; }
        public File BankAccount { get; set; }
        public File Form20 { get; set; }
        public File Form21 { get; set; }
        public File Form22 { get; set; }

    }

    public class RTODetails
    {
        public Dropdown RtoState { get; set; }

        public Dropdown RtoDistrict { get; set; }

        public Dropdown RtoOffice { get; set; }

        public Dropdown RegistrationType { get; set; }

        public Dropdown RegistrationCategory { get; set; }

        public string ApplicationNumber { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public string AcknowledgementNumber { get; set; }
        public string OnlinePortalReferenceNo { get; set; }
        public File RTOAttachmentFile { get; set; }

    }

}
