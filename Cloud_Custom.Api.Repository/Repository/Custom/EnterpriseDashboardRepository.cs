using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Repository.IRepository.General;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.Repository.Custom
{
    public class EnterpriseDashboardRepository: IEnterpriseDashboardRepository
    {
        private readonly ISqlConnectionProvider _sql;
        private readonly ICommonRepository _common;

        public EnterpriseDashboardRepository(ISqlConnectionProvider sql, ICommonRepository common)
        {
            _sql = sql;
            _common = common;

        }

        public async Task<EnterpriseDashboard> GetReportList(UserBase user, int BranchCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@BranchCode",BranchCode),
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_WORKSHOP_STATUS_LIST]", sqlparameters);
                return ReportList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }


        private EnterpriseDashboard ReportList(DataSet ds)
        {
            EnterpriseDashboard model = new EnterpriseDashboard();
            model.ReportList = new List<ReportList>();
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    model.ReportList.Add(new ReportList
                    {
                        WorkshopCode = MakeSafe.ToSafeInt32(row["WorkShopCode"]),
                        WorkshopName = MakeSafe.ToSafeString(row["WorkShop"]),
                        JCNotOpened = MakeSafe.ToSafeInt32(row["JCNotOpened"]),
                        JCOpened = MakeSafe.ToSafeInt32(row["JCOpenedNotInBay"]),
                        InBay = MakeSafe.ToSafeInt32(row["InBay"]),
                        BillPending = MakeSafe.ToSafeInt32(row["BillPending"]),
                        Billed = MakeSafe.ToSafeInt32(row["Billed"]),
                        Hold = MakeSafe.ToSafeInt32(row["Hold"]),
                        Delayed = MakeSafe.ToSafeInt32(row["DelayedMoreThanOneDay"]),
                        DelayedInBay = MakeSafe.ToSafeInt32(row["DelayedInBay"]),
                        BillAmount = MakeSafe.ToSafeDecimal(row["BillAmount"])
                    });
                }
            }
            return model;
        }

        public async Task<EnterpriseDashboard> GetList(UserBase user,int WorkShopCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@WorkShopCode",WorkShopCode),
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_DASHBOARD_JOB_TRACK_WEB]", sqlparameters);
                return BindDashboard(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }


        private EnterpriseDashboard BindDashboard(DataSet ds)
        {
            EnterpriseDashboard model = new EnterpriseDashboard();

            /* =========================================================
               TABLE 0 - KPI SUMMARY
            ========================================================= */
         
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                model.KPI = new DashboardKPIModel
                {
                    JCNotOpened = MakeSafe.ToSafeInt32(row["JcNotOpened"]),
                    JCOpened = MakeSafe.ToSafeInt32(row["JCOpenedNotInBay"]),
                    InBay = MakeSafe.ToSafeInt32(row["InBay"]),
                    BillPending = MakeSafe.ToSafeInt32(row["BillPending"]),
                    Billed = MakeSafe.ToSafeInt32(row["Billed"]),
                    HoldCount = MakeSafe.ToSafeInt32(row["Hold"]),
                    DelayedCount = MakeSafe.ToSafeInt32(row["DelayedMoreThanOneDay"]),
                    DelayedInBay = MakeSafe.ToSafeInt32(row["DelayedInBay"]),
                    BillAmount = MakeSafe.ToSafeInt32(row["BillAmount"])
                };
            }

            /* =========================================================
               TABLE 1 - MONTHLY REVENUE CHART
            ========================================================= */
            model.MonthlyRevenueChart = new List<MonthlyRevenueChartModel>();
            if ((ds.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    model.MonthlyRevenueChart.Add(new MonthlyRevenueChartModel
                    {
                        MonthName = MakeSafe.ToSafeString(row["MonthName"]),
                        MonthNo = MakeSafe.ToSafeInt32(row["MonthNo"]),
                        TotalBookings = MakeSafe.ToSafeInt32(row["TotalBookings"]),
                        DeliveredVehicles = MakeSafe.ToSafeInt32(row["DeliveredVehicles"]),
                        Revenue = MakeSafe.ToSafeDecimal(row["Revenue"])
                    });
                }
            }

            /* =========================================================
               TABLE 2 - BOOKING STATUS DISTRIBUTION
            ========================================================= */
            model.BookingStatusDistribution = new List<BookingStatusDistributionModel>();
            if ((ds.Tables[2]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[2].Rows)
                {
                    model.BookingStatusDistribution.Add(new BookingStatusDistributionModel
                    {
                        BookingStatus = MakeSafe.ToSafeString(row["BookingStatus"]),
                        TotalCount = MakeSafe.ToSafeInt32(row["TotalCount"])
                    });
                }
            }

            /* =========================================================
               TABLE 3 - LIVE VEHICLE TRACKING
            ========================================================= */
            model.LiveVehicleTracking = new List<LiveVehicleTrackingModel>();
            if ((ds.Tables[3]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[3].Rows)
                {
                    model.LiveVehicleTracking.Add(new LiveVehicleTrackingModel
                    {
                        CustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
                        RegistrationNo = MakeSafe.ToSafeString(row["RegistrationNo"]),
                        Address = MakeSafe.ToSafeString(row["Address"]),
                        Phone = MakeSafe.ToSafeString(row["Phone"]),
                        Email = MakeSafe.ToSafeString(row["Email"]),
                        JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]),
                        BayName = MakeSafe.ToSafeString(row["BayName"]),
                        Status = MakeSafe.ToSafeString(row["Status"]),
                        BayInTime = MakeSafe.ToSafeDateTime(row["CheckIn"]),
                        BayOutTime = MakeSafe.ToSafeDateTime(row["CheckOut"]),
                        TATMinutes = MakeSafe.ToSafeInt32(row["TATMinutes"])
                    });
                }
            }

            /* =========================================================
               TABLE 4 - BAY UTILIZATION
            ========================================================= */
            model.BayUtilization = new List<BayUtilizationModel>();
            if ((ds.Tables[4]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[4].Rows)
                {
                    model.BayUtilization.Add(new BayUtilizationModel
                    {
                        BayCode = MakeSafe.ToSafeInt32(row["BayCode"]),
                        BayName = MakeSafe.ToSafeString(row["BayName"]),
                        TotalVehicles = MakeSafe.ToSafeInt32(row["TotalVehicles"]),
                        BayStatus = MakeSafe.ToSafeString(row["BayStatus"]),
                        
                    });
                }
            }

            /* =========================================================
               TABLE 5 - TECHNICIAN PRODUCTIVITY
            ========================================================= */
            model.TechnicianProductivity = new List<TechnicianProductivityModel>();
            if ((ds.Tables[5]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[5].Rows)
                {
                    model.TechnicianProductivity.Add(new TechnicianProductivityModel
                    {
                        TechnicianName = MakeSafe.ToSafeString(row["TechnicianName"]),
                        TotalJobs = MakeSafe.ToSafeInt32(row["TotalJobs"]),
                        AvgMinutes = MakeSafe.ToSafeInt32(row["AvgMinutes"]),
                        CurrentWorking = MakeSafe.ToSafeInt32(row["CurrentWorking"])
                    });
                }
            }

            /* =========================================================
               TABLE 6 - DRIVER PICKUP TRACKING
            ========================================================= */
            model.DriverPickupTracking = new List<DriverPickupTrackingModel>();
            if ((ds.Tables[6]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[6].Rows)
                {
                    model.DriverPickupTracking.Add(new DriverPickupTrackingModel
                    {
                        DriverName = MakeSafe.ToSafeString(row["DriverName"]),
                        CustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
                        RegistrationNo = MakeSafe.ToSafeString(row["RegistrationNo"]),

                        PickupDateTime = string.IsNullOrWhiteSpace(row["PickupDateTime"]?.ToString())
                            ? (DateTime?)null : MakeSafe.ToSafeDateTime(row["PickupDateTime"]),

                        ReachedTime = string.IsNullOrWhiteSpace(row["ReachedTime"]?.ToString())
                            ? (DateTime?)null : MakeSafe.ToSafeDateTime(row["ReachedTime"]),

                        VehicleCollectedTime = string.IsNullOrWhiteSpace(row["VehicleCollectedTime"]?.ToString())
                            ? (DateTime?)null : MakeSafe.ToSafeDateTime(row["VehicleCollectedTime"]),

                        WorkShopInTime = string.IsNullOrWhiteSpace(row["WorkshopInTime"]?.ToString())
                            ? (DateTime?)null : MakeSafe.ToSafeDateTime(row["WorkshopInTime"]),

                        PickupStatus = MakeSafe.ToSafeString(row["PickupStatus"])
                    });
                }
            }

            /* =========================================================
               TABLE 7 - TOP CUSTOMER ANALYTICS
            ========================================================= */
            model.TopCustomerAnalytics = new List<TopCustomerAnalyticsModel>();
            if ((ds.Tables[7]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[7].Rows)
                {
                    model.TopCustomerAnalytics.Add(new TopCustomerAnalyticsModel
                    {
                        CustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
                        RegistrationNo = MakeSafe.ToSafeString(row["RegistrationNo"]),
                        Address = MakeSafe.ToSafeString(row["Address"]),
                        Phone = MakeSafe.ToSafeString(row["Phone"]),
                        Email = MakeSafe.ToSafeString(row["Email"]),
                        TotalVisits = MakeSafe.ToSafeInt32(row["TotalVisits"]),
                        TotalRevenue = MakeSafe.ToSafeDecimal(row["TotalRevenue"]),
                        LastVisit = MakeSafe.ToSafeDateTime(row["LastVisit"])
                    });
                }
            }

            /* =========================================================
               TABLE 8 - VEHICLES INSIDE WORKSHOP
            ========================================================= */
            model.VehiclesInsideWorkshop = new List<VehiclesInsideWorkshopModel>();
            if ((ds.Tables[8]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[8].Rows)
                {
                    model.VehiclesInsideWorkshop.Add(new VehiclesInsideWorkshopModel
                    {
                        RegistrationNumber = MakeSafe.ToSafeString(row["RegistrationNumber"]),
                        InTime = MakeSafe.ToSafeDateTime(row["InTime"]),
                        HoursInside = MakeSafe.ToSafeInt32(row["HoursInside"])
                    });
                }
            }

            /* =========================================================
               TABLE 9 - COMPLETE SERVICE LIFECYCLE
            ========================================================= */
            model.CompleteServiceLifecycle = new List<CompleteServiceLifecycleModel>();
            if ((ds.Tables[9]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[9].Rows)
                {
                    model.CompleteServiceLifecycle.Add(new CompleteServiceLifecycleModel
                    {
                        BookingNo = MakeSafe.ToSafeString(row["BookingNo"]),
                        CustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
                        RegistrationNo = MakeSafe.ToSafeString(row["RegistrationNo"]),
                        BookingDate = MakeSafe.ToSafeDateTime(row["BookingDate"]),
                        PickupDateTime = MakeSafe.ToSafeDateTime(row["PickupDateTime"]),
                        GateIn = MakeSafe.ToSafeDateTime(row["GateIn"]),
                        JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]),
                        BayStart = MakeSafe.ToSafeDateTime(row["BayStart"]),
                        BayEnd = MakeSafe.ToSafeDateTime(row["BayEnd"]),
                        GateOut = MakeSafe.ToSafeDateTime(row["GateOut"]),
                        BookingStatus = MakeSafe.ToSafeString(row["BookingStatus"])
                    });
                }
            }

            /* =========================================================
               TABLE 10 - WORKSHOP VIS BAY MAP
            ========================================================= */
            model.WorkshopVisBaymap = new List<WorkshopVisBaymapModel>();
            if ((ds.Tables[10]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[10].Rows)
                {
                    model.WorkshopVisBaymap.Add(new WorkshopVisBaymapModel
                    {
                        BayName = MakeSafe.ToSafeString(row["BayUserCode"]),
                        BayStatus = MakeSafe.ToSafeString(row["BayStatus"]),
                        VehicleReg = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]),
                        Jobcard = MakeSafe.ToSafeString(row["JobCardNo"]),
                        Technician = MakeSafe.ToSafeString(row["Technician"]),
                        count = MakeSafe.ToSafeInt32(row["UnitCompleted"]),
                         BayType = MakeSafe.ToSafeString(row["BayType"])
                    });
                }
            }

            return model;
        }

        public async Task<EnterpriseDashboard> GetStatusList(UserBase user, int WorkShopCode, string Status)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid),
                 new SqlParameter("@WorkShopCode",WorkShopCode),
                 new SqlParameter("@Status",Status),
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_TRACKING_DASHBOARD_STATUS_LIST]", sqlparameters);
                return GetStatusList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }


        private EnterpriseDashboard GetStatusList(DataSet ds)
        {
            EnterpriseDashboard model = new EnterpriseDashboard();
           
            List<LiveVehicleTrackingModel> List = new List<LiveVehicleTrackingModel>();
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new LiveVehicleTrackingModel();
                    item.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                    item.RegistrationNo = MakeSafe.ToSafeString(row["RegistrationNo"]);
                    item.Address = MakeSafe.ToSafeString(row["Address"]);
                    item.Phone = MakeSafe.ToSafeString(row["Phone"]);
                    item.Email = MakeSafe.ToSafeString(row["Email"]);
                    item.JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]);
                    item.BayName = MakeSafe.ToSafeString(row["BayName"]);
                    item.Status = MakeSafe.ToSafeString(row["Status"]);
                    item.BayInTime = MakeSafe.ToSafeDateTime(row["CheckIn"]);
                    item.BayOutTime = MakeSafe.ToSafeDateTime(row["CheckOut"]);
                    item.TATMinutes = MakeSafe.ToSafeInt32(row["TATMinutes"]);

                    List.Add(item);
                }
                model.LiveVehicleTracking = List;
            }
            return model;

        }
    }
}
