using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
   public class DMSSalesMis
    {
        public int SLNO { get; set; }
        public string ModelName { get; set; }
        public string VariantDes { get; set; }
        public int SALESDONE { get; set; }
        public int EmployeeCode { get; set; }
        public int Target { get; set; }
        public int MinimumAchievement { get; set; }
        public string TLName { get; set; }
        public string BranchName { get; set; }
        public int TotalSales { get; set; }
        public Dropdown Model { get; set; }
        public Dropdown Delarship { get; set; }
        public Dropdown Type { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public int Sales { get; set; }
        public int Vahan { get; set; }
        public int ExtendedWarranty { get; set; }
        public int Finance { get; set; }
        public int Exchange { get; set; }
        public int Gas { get; set; }
        public int Insurance { get; set; }
        public int Booking { get; set; }
        public int Enquiry { get; set; }
        public decimal SalesPercentage { get; set; }
        public decimal ExtendedWarrantyPercentage { get; set; }
        public decimal FinancePercentage { get; set; }
        public decimal ExchangePercentage { get; set; }
        public decimal GasPercentage { get; set; }
        public decimal VahanPercentage { get; set; }
        public decimal InsurancePercentage { get; set; }
        public decimal BookingPercentage { get; set; }
        public decimal EnquiryPercentage { get; set; }
        public List<DMSSalesMis> ModelList { get; set; }
        public List<DMSSalesMis> TLList { get; set; }
        public List<DMSSalesMis> DMSSalesMisList { get; set; }
        public List<DMSSalesMis> VariantWiseList { get; set; }
        public List<DMSSalesMis> TLVSEMPLOYEELIST { get; set; }

        // KPI Summary
        public List<DMSSalesMis> KPISummaryList { get; set; }

        // Pipeline / Funnel
        public List<DMSSalesMis> PipelineList { get; set; }

        // Pipeline Pending
        public List<DMSSalesMis> PipelinePendingList { get; set; }

        // Monthly Sales Trend
        public List<DMSSalesMis> MonthlySalesTrendList { get; set; }

        // Enquiry Status
        public List<DMSSalesMis> EnquiryStatusList { get; set; }

        // Model Wise Enquiry
        public List<DMSSalesMis> ModelWiseEnquiryList { get; set; }

        // Model Wise Sales
        public List<DMSSalesMis> ModelWiseSalesList { get; set; }

        // Branch Performance
        public List<DMSSalesMis> BranchPerformanceList { get; set; }

        // Executive Performance
        public List<DMSSalesMis> ExecutivePerformanceList { get; set; }

        // Sales Exception
        public List<DMSSalesMis> SalesExceptionList { get; set; }

        // KPI
        public int TotalEnquiries { get; set; }
        public int TotalBookings { get; set; }
        public int TotalSalesCount { get; set; }
        public decimal SalesValue { get; set; }
        public decimal AverageInvoice { get; set; }
        public decimal BookingConversion { get; set; }
        public decimal InvoiceConversion { get; set; }

        // Pipeline
        public int Enquiries { get; set; }
        public int OrderBookings { get; set; }
        public int Invoices { get; set; }
        public int VehiclesInStock { get; set; }

        // Pending
        public int OrderBookingPending { get; set; }
        public int InvoicePending { get; set; }
        public int VehiclePending { get; set; }
        public int AllocationPending { get; set; }

        // Monthly Trend
        public string MonthName { get; set; }
        public int YearNo { get; set; }
        public int Bookings { get; set; }

        // Enquiry Status
        public string EnquiryStatus { get; set; }
        public int TotalCount { get; set; }

        // Branch & Executive
        public string Branch { get; set; }
        public string Executive { get; set; }
        public decimal ConversionPercentage { get; set; }
       

        // Sales Exception
        public string ExceptionType { get; set; }
        public string ReferenceNumber { get; set; }
        public string CustomerReference { get; set; }
        public string CustomerName { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string Status { get; set; }
    }
}
