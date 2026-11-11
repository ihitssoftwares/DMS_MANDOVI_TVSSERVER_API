using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class EnterpriseDashboard
    {
        public UserBase User { get; set; }
        public Dropdown Workshop { get; set; }
        public DashboardKPIModel KPI { get; set; }

        public List<MonthlyRevenueChartModel> MonthlyRevenueChart { get; set; }

        public List<BookingStatusDistributionModel> BookingStatusDistribution { get; set; }

        public List<LiveVehicleTrackingModel> LiveVehicleTracking { get; set; }

        public List<BayUtilizationModel> BayUtilization { get; set; }

        public List<TechnicianProductivityModel> TechnicianProductivity { get; set; }

        public List<DriverPickupTrackingModel> DriverPickupTracking { get; set; }

        public List<TopCustomerAnalyticsModel> TopCustomerAnalytics { get; set; }

        public List<VehiclesInsideWorkshopModel> VehiclesInsideWorkshop { get; set; }

        public List<CompleteServiceLifecycleModel> CompleteServiceLifecycle { get; set; }
        public List<WorkshopVisBaymapModel> WorkshopVisBaymap { get; set; }
        public List<ReportList> ReportList { get; set; }
    }

    /* =========================================================
       1. KPI SUMMARY
    ========================================================= */

    public class DashboardKPIModel
    {
        public int HoldCount { get; set; }

        public int DelayedCount { get; set; }

        public int WorkInProgressCount { get; set; }

        public int CompletionPending { get; set; }

        public int JcOpenedCount { get; set; }

        public int WorkCompletedCount { get; set; }
        public int JCOpened { get; set; }

        public int JCNotOpened { get; set; }
        public int InBay { get; set; }
        public int BillPending { get; set; }
        public int Billed { get; set; }
        public int DelayedInBay { get; set; }
        public int BillAmount { get; set; }
    }

    /* =========================================================
       2. MONTHLY REVENUE CHART
    ========================================================= */

    public class MonthlyRevenueChartModel
    {
        public string MonthName { get; set; }

        public int MonthNo { get; set; }

        public int TotalBookings { get; set; }

        public int DeliveredVehicles { get; set; }

        public decimal Revenue { get; set; }
    }

    /* =========================================================
       3. BOOKING STATUS DISTRIBUTION
    ========================================================= */

    public class BookingStatusDistributionModel
    {
        public string BookingStatus { get; set; }

        public int TotalCount { get; set; }
    }

    /* =========================================================
       4. LIVE VEHICLE TRACKING
    ========================================================= */

    public class LiveVehicleTrackingModel
    {
        public string BookingNo { get; set; }

        public string CustomerName { get; set; }

        public string RegistrationNo { get; set; }

        public string JobCardNo { get; set; }

        public string BayName { get; set; }

        public string Status { get; set; }

        public DateTime? BayInTime { get; set; }

        public DateTime? BayOutTime { get; set; }

        public int TATMinutes { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; } 
        public List<LiveVehicleTrackingModel> LiveVehicleTrackingList { get; set; }
    }

    /* =========================================================
       5. BAY UTILIZATION
    ========================================================= */

    public class BayUtilizationModel
    {
        public int BayCode { get; set; }

        public string BayName { get; set; }

        public int TotalVehicles { get; set; }

        public string BayStatus { get; set; }
 
    }

    /* =========================================================
       6. TECHNICIAN PRODUCTIVITY
    ========================================================= */

    public class TechnicianProductivityModel
    {
        public string TechnicianName { get; set; }

        public int TotalJobs { get; set; }

        public int AvgMinutes { get; set; }

        public int CurrentWorking { get; set; }
    }

    /* =========================================================
       7. DRIVER PICKUP TRACKING
    ========================================================= */

    public class DriverPickupTrackingModel
    {
        public string DriverName { get; set; }

        public string CustomerName { get; set; }

        public string RegistrationNo { get; set; }

        public DateTime? PickupDateTime { get; set; }

        public DateTime? ReachedTime { get; set; }

        public DateTime? VehicleCollectedTime { get; set; }
        public DateTime? WorkShopInTime { get; set; }

        public string PickupStatus { get; set; }
    }

    /* =========================================================
       8. TOP CUSTOMER ANALYTICS
    ========================================================= */

    public class TopCustomerAnalyticsModel
    {
        public string CustomerName { get; set; }

        public string RegistrationNo { get; set; }


        public int TotalVisits { get; set; }

        public decimal TotalRevenue { get; set; }

        public DateTime? LastVisit { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }

    /* =========================================================
       9. VEHICLES INSIDE WORKSHOP
    ========================================================= */

    public class VehiclesInsideWorkshopModel
    {
        public string RegistrationNumber { get; set; }

        public DateTime? InTime { get; set; }

        public int HoursInside { get; set; }
    }

    /* =========================================================
       10. COMPLETE SERVICE LIFECYCLE
    ========================================================= */

    public class CompleteServiceLifecycleModel
    {
        public string BookingNo { get; set; }

        public string CustomerName { get; set; }

        public string RegistrationNo { get; set; }

        public DateTime? BookingDate { get; set; }

        public DateTime? PickupDateTime { get; set; }

        public DateTime? GateIn { get; set; }

        public string JobCardNo { get; set; }

        public DateTime? BayStart { get; set; }

        public DateTime? BayEnd { get; set; }

        public DateTime? GateOut { get; set; }

        public string BookingStatus { get; set; }
    }
    public class WorkshopVisBaymapModel
    {
        public string BayName { get; set; }
        public string VehicleReg { get; set; }
        public string Jobcard { get; set; }
        public string Technician { get; set; }
        public int count { get; set; }
        public string BayStatus { get; set; }
        public string BayType { get; set; }

    }
    public class ReportList
    {
        public int WorkshopCode { get; set; }
        public string WorkshopName { get; set; }
        public int JCNotOpened { get; set; }
        public int JCOpened { get; set; }
        public int InBay { get; set; }
        public int BillPending { get; set; }
        public int Billed { get; set; }
        public int Hold { get; set; }
        public int Delayed { get; set; }
        public int DelayedInBay { get; set; }
        public decimal BillAmount { get; set; }
    }
}

