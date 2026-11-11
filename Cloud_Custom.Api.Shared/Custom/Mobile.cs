using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
  public  class Mobile
    {
        public DashBoardDetails DashBoardDetails { get; set; }
        public SalesDetails SalesDetails { get; set; }
        public List<GADetails> GADetails { get; set; }
        public List<BookingDetails> BookingDetails { get; set; }
        public List<LeadDetails> LeadDetails { get; set; }
        public List<VehicleBrowse> Vehicles { get; set; }
        public List<Offers> Offers { get; set; }
    }

    public class DashBoardDetails
    {
        public int SALES { get; set; }
        public int ALLOTED { get; set; }
        public int BOOKING { get; set; }
        public string SALESPROGRESS { get; set; } 
        public int HOT { get; set; }
        public int WARM { get; set; }
        public int COLD { get; set; }
        public int APPOINTMENTS { get; set; }
        public int Offers { get; set; }
    }

    public class SalesDetails
    {
        public int TotalSales { get; set; } 
        public int SalesTarget { get; set; } 
        public decimal TotalSalesAmount { get; set; }
        public int InsuranceAchievedQuantity { get; set; } 
        public decimal InsuranceAchievedPercentage { get; set; }
        public int ExchangeAchievedQuantity { get; set; } 
        public decimal ExchangeAchievedPercentage { get; set; }
        public int GAAchievedQuantity { get; set; } 
        public decimal GAAchievedPercentage { get; set; }
        public decimal SpecialDiscountAmount { get; set; }
        public decimal SpecialDiscountPercAmount { get; set; }
       
        public decimal SalesPercentage { get; set; }
        public decimal GAAmount { get; set; }
        public decimal GAPerCar { get; set; }
        public decimal SpecialDiscountQuantity { get; set; }
        public int ExtendedAchievedCount { get; set; }
        public decimal ExtendedAchievedPercentage { get; set; }
    }
    public class GADetails
    {
        public string CustomerName { get; set; }
        public string MobileNo { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string DeliveryDate { get; set; }

        public decimal InvoiceAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetAmount { get; set; }
    }

    public class BookingDetails
    {
        public string CustomerName { get; set; }
        public string ModelName { get; set; }
        public string Variant { get; set; }
        public string MobileNo { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime? BookingDate { get; set; }
        public string HowManyDaysAgo { get; set; }
        public decimal BalanceAmount { get; set; }
    }

    public class LeadDetails
    {
        public string CustomerName { get; set; }
        public string ModelName { get; set; }
        public string Variant { get; set; }
        public string MobileNo { get; set; }
        public string ExecutiveName { get; set; }
        public string LastContactDate { get; set; }
        public string HowManyDaysAgo { get; set; }
        public string LEADTYPE { get; set; }
    }

    public class VehicleBrowse
    {
        public string VehicleModel { get; set; }
        public string Variant { get; set; }
        public string TransmissionType { get; set; }
        public string FuelType { get; set; }
        public decimal ExShowroomPrice { get; set; }
    }

    public class Offers
    {
        public string Message { get; set; }
        public DateTime? OfferFromDate { get; set; }      
        public DateTime? OfferToDate { get; set; }       
        public decimal ExecutiveAmount { get; set; }      
        public decimal TeamLeaderAmount { get; set; }    
        public decimal StoreManagerAmount { get; set; }

    }
}
