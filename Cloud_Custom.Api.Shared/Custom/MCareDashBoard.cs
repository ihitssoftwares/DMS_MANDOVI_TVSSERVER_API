using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class MCareDashBoard
    {
        public Dropdown Region { get; set; }
        public DashboardKpis Kpis { get; set; }

        public List<RegistrationTrendItem> RegistrationTrend { get; set; }

        public List<PlanWiseSalesItem> PlanWiseSales { get; set; }

        public List<MonthlyRevenueItem> MonthlyRevenue { get; set; }


        public List<ModelWiseRegistrationItem> ModelWiseRegistration { get; set; }


        public List<ServiceUtilizationItem> ServiceUtilization { get; set; }


        public List<TopAdvisorItem> TopAdvisors { get; set; }


        public List<LatestRegistrationItem> LatestRegistrations { get; set; }


        public List<UpcomingRenewalItem> UpcomingRenewals { get; set; }
        public List<ServiceReportItem> ServiceReport { get; set; }
        public List<PlanDetailsItem> PlanDetails { get; set; }
        public List<PolicypopupItem> PolicyPopup { get; set; }
    }
    public class PlanDetailsItem
    {
        public int PlanCode { get; set; }
        public string PlanName { get; set; }
        public int Total { get; set; }
        public int Active { get; set; }
        public int Cancelled { get; set; }
        public int Expired { get; set; }
        public int Due30D { get; set; }
        public int ThisMonth { get; set; }
    }
    public class ServiceReportItem
    {
        public int PlanCode { get; set; }
        public string PlanName { get; set; }
        public int MonthCode { get; set; }
        public string MonthName { get; set; }
        public int ServiceCount { get; set; }
        //public string Month { get; set; }
        //public int TwoYearPlan { get; set; }
        //public int ThreeYearPlan { get; set; }
    }

    public class PolicypopupItem
    {

        public string EmployeeName { get; set; }
        public string EmployeeId { get; set; }
        public string Customer { get; set; }
        public string Model { get; set; }
        public string VehicleRegNo { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public decimal? Amount { get; set; }

    }
    public class DashboardKpis
    {

        public int TotalPlans { get; set; }
        public int Total2YearPlans { get; set; }
        public int Total3YearPlans { get; set; }
        public int YTD { get; set; }

        public int ActivePlans { get; set; }
        public int Active2YearPlans { get; set; }
        public int Active3YearPlans { get; set; }


        public int SalesCount { get; set; }
        public int Sales2YearPlans { get; set; }
        public int Sales3YearPlans { get; set; }

        public int Cancelled { get; set; }
        public int Cancelled2YearPlans { get; set; }
        public int Cancelled3YearPlans { get; set; }


        public int ExpiredPackages { get; set; }
        public int Expired2YearPlans { get; set; }
        public int Expired3YearPlans { get; set; }


        public int RenewalDue { get; set; }
        public int RenewalDue2YearPlans { get; set; }
        public int RenewalDue3YearPlans { get; set; }


        public decimal Revenue { get; set; }
      

        public decimal PlanAmount { get; set; }
        public decimal TotalplanAmt { get; set; }
        public decimal YTDAmt { get; set; }

        public int Services { get; set; }


        public decimal? ActivePlansChangePct { get; set; }


        public int? TotalCustomersNewThisWeek { get; set; }


        public decimal? RevenueTargetPct { get; set; }


        public decimal? ServicesUtilizationPct { get; set; }
    }


    public class RegistrationTrendItem
    {
        public string MonthName { get; set; }
        public int TotaltwoYearPlan { get; set; }
        public int TotalthreeYearPlan { get; set; }
    }


    public class PlanWiseSalesItem
    {

        public string Name { get; set; }


        public int TotalSale { get; set; }


        public decimal Revenue { get; set; }
    }


    public class MonthlyRevenueItem
    {

        public int MonthCode { get; set; }
       
        public string PlanName { get; set; }
        public int Count { get; set; }
        public decimal Amount { get; set; }
        public string MonthName { get; set; }

        public decimal TwoyearPlanRevenue { get; set; }
        public decimal ThreeyearPlanRevenue { get; set; }

        public int TwoyearPlanCount { get; set; }
        public int ThreeyearPlanCount { get; set; }
    }


    public class ModelWiseRegistrationItem
    {

        public string Model { get; set; }


        public int Total { get; set; }
    }


    public class ServiceUtilizationItem
    {

        public string Name { get; set; }


        public int TotalUsed { get; set; }
    }


    public class TopAdvisorItem
    {

        public string Advisor { get; set; }


        public int PlansSold { get; set; }


        public decimal Revenue { get; set; }


        public int ActivePlans { get; set; }


        public int ExpiredPlans { get; set; }


        public int Renewals { get; set; }
    }


    public class LatestRegistrationItem
    {

        public string EntryNo { get; set; }


        public string Customer { get; set; }


        public string VehicleRegistrationNumber { get; set; }


        public string Plan { get; set; }


        public string Model { get; set; }


        public decimal PlanAmount { get; set; }


        public DateTime? EndDate { get; set; }


        public string Status { get; set; }
    }


    public class UpcomingRenewalItem
    {

        public string Customer { get; set; }


        public string VehicleRegistrationNumber { get; set; }


        public string Plan { get; set; }


        public DateTime? EndDate { get; set; }


        public int RemainingDays { get; set; }


        public string Phone { get; set; }
    }


    public class DashboardDateRangeRequest
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }


}
