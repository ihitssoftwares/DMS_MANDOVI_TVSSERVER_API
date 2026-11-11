using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{

    public class DMSSALESFILEDOWNLOAD
    {
        public File ImportFromExcel { get; set; }
        public string Message { get; set; }
        public int BatchCode { get; set; }
        public List<VehicleSalesImportModel> VehicleSalesImportModel { get; set; }
        public Dropdown Month { get; set; }
        public Dropdown Branch { get; set; }
        public Dropdown Region { get; set; }
    }




    public class VehicleSalesImportModel
    {
        public string SalesDealerCode { get; set; }
        public string Remarks { get; set; }



        public string PromisedDeliveryDate { get; set; }
        public string AllotmentNo { get; set; }


        public string EnquirySource { get; set; }
        public string EnquiryMode { get; set; }
        public string BuyerType { get; set; }

        public string TestDriveDate { get; set; }
        public string HomeVisitDate { get; set; }

        public string EnquiryCustomerType { get; set; }

        public string Financier { get; set; }



        public string DispatchDate { get; set; }
        public string DeliveryDate { get; set; }

        public string CustomerCode { get; set; }
        public string CustomerTitle { get; set; }
        public string CustomerName { get; set; }

        public string CustomerCity { get; set; }
        public string CustomerState { get; set; }
        public string CustomerDistrict { get; set; }
        public string BookingTehsil { get; set; }
        public string CustomerVillage { get; set; }


        public string FuelDescription { get; set; }



        public string MIName { get; set; }
        public string MIDate { get; set; }
        public string MIMatchFlag { get; set; }

        public string ExchangeLostFlag { get; set; }

        public string ReceiptAmtAgainstBooking { get; set; }


        public string MGABooked { get; set; }
        public string MGAPaid { get; set; }

        public string EvaluatorCode { get; set; }
        public string EvaluatorMSPINNo { get; set; }
        public string EvaluatorName { get; set; }
        public string EvaluationDate { get; set; }

        public string BoughtDate { get; set; }

        public string OldCarRegNum { get; set; }
        public string OldCarModel { get; set; }
        public string OldCarSubModel { get; set; }

        public string OFFOfferedPrice { get; set; }
        public string CustomerExpectedPrice { get; set; }
        public string ReofferedPrice { get; set; }
        public string BuyingPrice { get; set; }
        public string ReferencePrice { get; set; }

        public string DateOfReg { get; set; }
        public string OldCarYOM { get; set; }

        public string ColorCode { get; set; }

        public string NewCarVariant { get; set; }

        public string BookingAmt { get; set; }

        public string ExchangeBonus { get; set; }

        public string DSEMSPIN { get; set; }

        public string CustomerOccupation { get; set; }
        public string DateOfManufacturing { get; set; }
        public string EnquiryStrength { get; set; }

        public string EWSoldDate { get; set; }

        public string LoyaltyCardNumber { get; set; }
        public string LoyaltyCardStatus { get; set; }
        public string InvoiceCancelDate { get; set; }

        public string EngineNo { get; set; }
        public string Chassis { get; set; }




        public string InvoiceDate { get; set; }

        public string InvoiceNum { get; set; }
        public string StoreorBranch { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public string Color { get; set; }
        public string NewVehVIN { get; set; }
        public string EnquiryNum { get; set; }
        public string EnquiryDate { get; set; }

        public string Executive { get; set; }
        public string BookingNum { get; set; }
        public string BookingDate { get; set; }
        public string Discount { get; set; }
        public string ISLDiscount { get; set; }
        public string InvoiceAmount { get; set; }
        public string Status { get; set; }


    }
}
