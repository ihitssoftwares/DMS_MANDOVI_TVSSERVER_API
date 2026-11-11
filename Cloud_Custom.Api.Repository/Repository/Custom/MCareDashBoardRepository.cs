using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.Custom;
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
    public class MCareDashBoardRepository : IMCareDashBoardRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public MCareDashBoardRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<MCareDashBoard> GetList(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid)

            };
                var ds = await _sql.GetDataSetAsync("[MCARE].[SP_GET_MCARE_DASHBOARD]", sqlparameters);
                return SummeryList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private MCareDashBoard SummeryList(DataSet ds)
        {
            MCareDashBoard model = new MCareDashBoard();

            if (ds == null || ds.Tables.Count == 0)
                return model;

            #region KPI (Table 0)

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                model.Kpis = new DashboardKpis
                {
                    TotalPlans = MakeSafe.ToSafeInt32(row["TotalPlans"]),
                    Total2YearPlans = MakeSafe.ToSafeInt32(row["Total2YearPlans"]),
                    Total3YearPlans = MakeSafe.ToSafeInt32(row["Total3YearPlans"]),
                    YTD = MakeSafe.ToSafeInt32(row["YTD"]),

                    ActivePlans = MakeSafe.ToSafeInt32(row["ActivePlans"]),
                    Active2YearPlans = MakeSafe.ToSafeInt32(row["Active2YearPlans"]),
                    Active3YearPlans = MakeSafe.ToSafeInt32(row["Active3YearPlans"]),

                    SalesCount = MakeSafe.ToSafeInt32(row["SalesCount"]),
                    Sales2YearPlans = MakeSafe.ToSafeInt32(row["Sales2YearPlans"]),
                    Sales3YearPlans = MakeSafe.ToSafeInt32(row["Sales3YearPlans"]),

                    Cancelled = MakeSafe.ToSafeInt32(row["Cancelled"]),
                    Cancelled2YearPlans = MakeSafe.ToSafeInt32(row["Cancelled2YearPlans"]),
                    Cancelled3YearPlans = MakeSafe.ToSafeInt32(row["Cancelled3YearPlans"]),

                    ExpiredPackages = MakeSafe.ToSafeInt32(row["ExpiredPackages"]),
                    Expired2YearPlans = MakeSafe.ToSafeInt32(row["Expired2YearPlans"]),
                    Expired3YearPlans = MakeSafe.ToSafeInt32(row["Expired3YearPlans"]),

                    RenewalDue = MakeSafe.ToSafeInt32(row["RenewalDue"]),
                    RenewalDue2YearPlans = MakeSafe.ToSafeInt32(row["RenewalDue2YearPlans"]),
                    RenewalDue3YearPlans = MakeSafe.ToSafeInt32(row["RenewalDue3YearPlans"]),

                    Revenue = MakeSafe.ToSafeDecimal(row["Revenue"]),
                    Services = MakeSafe.ToSafeInt32(row["Services"]),
                    PlanAmount = MakeSafe.ToSafeDecimal(row["ActiveplanAmt"]),
                    TotalplanAmt = MakeSafe.ToSafeDecimal(row["TotalplanAmt"]),
                    YTDAmt = MakeSafe.ToSafeDecimal(row["YTDAmt"]),
                };
            }

            #endregion

            #region Registration Trend (Table 1)

            model.RegistrationTrend = new List<RegistrationTrendItem>();

            if (ds.Tables.Count > 1)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    model.RegistrationTrend.Add(new RegistrationTrendItem
                    {
                        MonthName = MakeSafe.ToSafeString(row["MonthName"]),
                        TotaltwoYearPlan = MakeSafe.ToSafeInt32(row["TotaltwoYearPlan"]),
                        TotalthreeYearPlan = MakeSafe.ToSafeInt32(row["TotalthreeYearPlan"])
                    });
                }
            }

            #endregion

            #region Plan Wise Sales (Table 2)

            model.PlanWiseSales = new List<PlanWiseSalesItem>();

            if (ds.Tables.Count > 2)
            {
                foreach (DataRow row in ds.Tables[2].Rows)
                {
                    model.PlanWiseSales.Add(new PlanWiseSalesItem
                    {
                        Name = MakeSafe.ToSafeString(row["Name"]),
                        TotalSale = MakeSafe.ToSafeInt32(row["TotalSale"]),
                        Revenue = MakeSafe.ToSafeDecimal(row["Revenue"])
                    });
                }
            }

            #endregion

            #region Monthly Revenue (Table 3)

            model.MonthlyRevenue = new List<MonthlyRevenueItem>();

            if (ds.Tables.Count > 3)
            {
                foreach (DataRow row in ds.Tables[3].Rows)
                {
                    model.MonthlyRevenue.Add(new MonthlyRevenueItem
                    {
                        MonthName = MakeSafe.ToSafeString(row["MonthName"]),
                        TwoyearPlanRevenue = MakeSafe.ToSafeDecimal(row["TwoyearPlanRevenue"]),
                        ThreeyearPlanRevenue = MakeSafe.ToSafeDecimal(row["ThreeyearPlanRevenue"])
                    });
                }
            }

            #endregion

            #region Model Wise Registration (Table 4)

            model.ModelWiseRegistration = new List<ModelWiseRegistrationItem>();

            if (ds.Tables.Count > 4)
            {
                foreach (DataRow row in ds.Tables[4].Rows)
                {
                    model.ModelWiseRegistration.Add(new ModelWiseRegistrationItem
                    {
                        Model = MakeSafe.ToSafeString(row["Model"]),
                        Total = MakeSafe.ToSafeInt32(row["Total"])
                    });
                }
            }

            #endregion

            #region Service Utilization (Table 5)

            model.ServiceUtilization = new List<ServiceUtilizationItem>();

            if (ds.Tables.Count > 5)
            {
                foreach (DataRow row in ds.Tables[5].Rows)
                {
                    model.ServiceUtilization.Add(new ServiceUtilizationItem
                    {
                        Name = MakeSafe.ToSafeString(row["Name"]),
                        TotalUsed = MakeSafe.ToSafeInt32(row["TotalUsed"])
                    });
                }
            }

            #endregion

            #region Top Advisors (Table 6)

            model.TopAdvisors = new List<TopAdvisorItem>();

            if (ds.Tables.Count > 6)
            {
                foreach (DataRow row in ds.Tables[6].Rows)
                {
                    model.TopAdvisors.Add(new TopAdvisorItem
                    {
                        Advisor = MakeSafe.ToSafeString(row["Top"]),
                        PlansSold = MakeSafe.ToSafeInt32(row["PlansSold"]),
                        Revenue = MakeSafe.ToSafeDecimal(row["Revenue"]),
                        ActivePlans = MakeSafe.ToSafeInt32(row["ActivePlans"]),
                        ExpiredPlans = MakeSafe.ToSafeInt32(row["ExpiredPlans"]),
                        Renewals = MakeSafe.ToSafeInt32(row["Renewals"])
                    });
                }
            }

            #endregion

            #region Latest Registrations (Table 7)

            model.LatestRegistrations = new List<LatestRegistrationItem>();

            if (ds.Tables.Count > 7)
            {
                foreach (DataRow row in ds.Tables[7].Rows)
                {
                    model.LatestRegistrations.Add(new LatestRegistrationItem
                    {
                        EntryNo = MakeSafe.ToSafeString(row["EntryNo"]),
                        Customer = MakeSafe.ToSafeString(row["Customer"]),
                        VehicleRegistrationNumber = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]),
                        Plan = MakeSafe.ToSafeString(row["Plan"]),
                        Model = MakeSafe.ToSafeString(row["Model"]),
                        PlanAmount = MakeSafe.ToSafeDecimal(row["PlanAmount"]),
                        EndDate = MakeSafe.ToSafeDateTime(row["EndDate"]),
                        Status = MakeSafe.ToSafeString(row["Status"])
                    });
                }
            }

            #endregion

            #region Service Report

            model.ServiceReport = new List<ServiceReportItem>();

            if (ds.Tables.Count > 8)
            {
                foreach (DataRow row in ds.Tables[8].Rows)
                {
                    model.ServiceReport.Add(new ServiceReportItem
                    {
                        PlanCode = MakeSafe.ToSafeInt32(row["PlanCode"]),
                        PlanName = MakeSafe.ToSafeString(row["Plan"]),
                        MonthCode = MakeSafe.ToSafeInt32(row["MonthCode"]),
                        MonthName = MakeSafe.ToSafeString(row["MonthName"]),
                        ServiceCount = MakeSafe.ToSafeInt32(row["ServiceCount"])
                    });
                }
            }

            #endregion

            #region Upcoming Renewals (Table 9)

            model.UpcomingRenewals = new List<UpcomingRenewalItem>();

            if (ds.Tables.Count > 9)
            {
                foreach (DataRow row in ds.Tables[9].Rows)
                {
                    model.UpcomingRenewals.Add(new UpcomingRenewalItem
                    {
                        Customer = MakeSafe.ToSafeString(row["Customer"]),
                        VehicleRegistrationNumber = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]),
                        Plan = MakeSafe.ToSafeString(row["Plan"]),
                        EndDate = MakeSafe.ToSafeDateTime(row["EndDate"]),
                        RemainingDays = MakeSafe.ToSafeInt32(row["RemainingDays"]),
                        Phone = MakeSafe.ToSafeString(row["Phone"])
                    });
                }
            }

            #endregion
            #region Plan Details (Table 10)

            model.PlanDetails = new List<PlanDetailsItem>();

            if (ds.Tables.Count > 10)
            {
                foreach (DataRow row in ds.Tables[10].Rows)
                {
                    model.PlanDetails.Add(new PlanDetailsItem
                    {
                        PlanCode = MakeSafe.ToSafeInt32(row["PlanCode"]),
                        PlanName = MakeSafe.ToSafeString(row["Plan"]),
                        Total = MakeSafe.ToSafeInt32(row["Total"]),
                        Active = MakeSafe.ToSafeInt32(row["Active"]),
                        Cancelled = MakeSafe.ToSafeInt32(row["Cancelled"]),
                        Expired = MakeSafe.ToSafeInt32(row["Expired"]),
                        Due30D = MakeSafe.ToSafeInt32(row["Due30D"]),
                        ThisMonth = MakeSafe.ToSafeInt32(row["ThisMonth"])
                    });
                }
            }

            #endregion

            return model;
        }

        public async Task<MCareDashBoard> GetMonthlyRevenueData(UserBase user, string monthlyRevenue)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                    new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 
                 new SqlParameter("@MonthlyRevenue",monthlyRevenue),
            };
                var ds = await _sql.GetDataSetAsync("[MCARE].[SP_GET_MCARE_DASHBOARD_MonthlyRevenue]", sqlparameters);
                return RevenueList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private MCareDashBoard RevenueList(DataSet ds)
        {
            MCareDashBoard model = new MCareDashBoard();
            model.MonthlyRevenue = new List<MonthlyRevenueItem>();

            if (ds.Tables.Count == 0)
                return model;

            DataTable table = ds.Tables[0];

            // The Count query returns [Count], the Amount query returns [Amount]
            bool hasCount = table.Columns.Contains("Count");
            bool hasAmount = table.Columns.Contains("Amount");

            foreach (DataRow row in table.Rows)
            {
                model.MonthlyRevenue.Add(new MonthlyRevenueItem
                {
                    // The SP currently aliases MONTH() as "MonthName", so the number comes from that column
                    MonthCode = MakeSafe.ToSafeInt32(row["MonthCode"]),
                    MonthName = MakeSafe.ToSafeString(row["Month"]),
                    PlanName = MakeSafe.ToSafeString(row["Plan"]),
                    Count = hasCount ? MakeSafe.ToSafeInt32(row["Count"]) : 0,
                    Amount = hasAmount ? MakeSafe.ToSafeDecimal(row["Amount"]) : 0
                });
            }

            return model;
        }
        //private MCareDashBoard RevenueList(DataSet ds)
        //{
        //    MCareDashBoard model = new MCareDashBoard();
        //    model.MonthlyRevenue = new List<MonthlyRevenueItem>();

        //    if (ds.Tables.Count > 0)
        //    {
        //        foreach (DataRow row in ds.Tables[0].Rows)
        //        {
        //            // Check if Count columns exist (from Count query) or Revenue columns (from Amount query)
        //            bool isCountData = ds.Tables[0].Columns.Contains("TwoyearPlanCount");

        //            model.MonthlyRevenue.Add(new MonthlyRevenueItem
        //            {
        //                MonthName = MakeSafe.ToSafeString(row["MonthName"]),

        //                // If Count data, map Count columns; otherwise map Revenue columns
        //                TwoyearPlanCount = isCountData ? MakeSafe.ToSafeInt32(row["TwoyearPlanCount"]) : 0,
        //                ThreeyearPlanCount = isCountData ? MakeSafe.ToSafeInt32(row["ThreeyearPlanCount"]) : 0,

        //                TwoyearPlanRevenue = !isCountData ? MakeSafe.ToSafeDecimal(row["TwoyearPlanRevenue"]) : 0,
        //                ThreeyearPlanRevenue = !isCountData ? MakeSafe.ToSafeDecimal(row["ThreeyearPlanRevenue"]) : 0
        //            });
        //        }
        //    }
        //    return model;
        //}

        public async Task<MCareDashBoard> GetTop10Data(UserBase user, string Top,int Region)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
            new SqlParameter("@UserGuid",user.UserGuid),
         new SqlParameter("@CompanyGI",user.CompanyGuid),

         new SqlParameter("@Top",Top),
         new SqlParameter("@Region",Region),
         //new SqlParameter("@SaleOrService",SaleOrService),
    };
                var ds = await _sql.GetDataSetAsync("[MCARE].[SP_GET_MCARE_DASHBOARD_Top10]", sqlparameters);
                return Top10List(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private MCareDashBoard Top10List(DataSet ds)
        {
            MCareDashBoard model = new MCareDashBoard();
            model.TopAdvisors = new List<TopAdvisorItem>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    model.TopAdvisors.Add(new TopAdvisorItem
                    {
                        Advisor = MakeSafe.ToSafeString(row["Top"]),
                        PlansSold = MakeSafe.ToSafeInt32(row["PlansSold"]),
                        Revenue = MakeSafe.ToSafeDecimal(row["Revenue"]),
                        ActivePlans = MakeSafe.ToSafeInt32(row["ActivePlans"]),
                        ExpiredPlans = MakeSafe.ToSafeInt32(row["ExpiredPlans"]),
                        Renewals = MakeSafe.ToSafeInt32(row["Renewals"])
                    });
                }
            }
            return model;
        }

        //public async Task<MCareDashBoard> TotalPopup(UserBase user, int PlanCode)
        //{

        //    IDbDataParameter[] sqlparameters =
        //   {
        //        new SqlParameter("@CompanyGI",user.CompanyGuid),
        //        new SqlParameter("@UserGuid",user.UserGuid),
        //        new SqlParameter("@PlanCode",PlanCode),


        //    };
        //    var ds = await _sql.GetDataSetAsync("[MCARE].[SP_GET_MCARE_DASHBOARD_TOTAL_POPUP]", sqlparameters);

        //    return PopulateTotalPopupDetails(ds);

        //}
        //private MCareDashBoard PopulateTotalPopupDetails(DataSet ds)
        //{

        //    MCareDashBoard model = new MCareDashBoard();
        //    model.PolicyPopup = new List<PolicypopupItem>();

        //    if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
        //    {
        //        foreach (DataRow row in ds.Tables[0].Rows)
        //        {
        //            model.PolicyPopup.Add(new PolicypopupItem
        //            {

        //                EmployeeId = MakeSafe.ToSafeString(row["EmployeeId"]),
        //                EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]),
        //                Customer = MakeSafe.ToSafeString(row["CustomerName"]),
        //                Model = MakeSafe.ToSafeString(row["Model"]),
        //                VehicleRegNo = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]),
        //                RegistrationDate = MakeSafe.ToSafeDateTime(row["RegistrationDate"]),
        //                Amount = MakeSafe.ToSafeDecimal(row["NetAmount"])


        //            });
        //        }
        //    }

        //    return model;
        //}

        //public async Task<MCareDashBoard> PolicyPopup(UserBase user, int PlanCode)
        //{

        //    IDbDataParameter[] sqlparameters =
        //   {
        //        new SqlParameter("@CompanyGI",user.CompanyGuid),
        //        new SqlParameter("@UserGuid",user.UserGuid),
        //        new SqlParameter("@PlanCode",PlanCode),


        //    };
        //    var ds = await _sql.GetDataSetAsync("[MCARE].[SP_GET_MCARE_DASHBOARD_ACTIVE_POPUP]", sqlparameters);

        //    return PopulatePolicyPopupDetails(ds);

        //}
        //private MCareDashBoard PopulatePolicyPopupDetails(DataSet ds)
        //{

        //    MCareDashBoard model = new MCareDashBoard();
        //    model.PolicyPopup = new List<PolicypopupItem>();

        //    if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
        //    {
        //        foreach (DataRow row in ds.Tables[0].Rows)
        //        {
        //            model.PolicyPopup.Add(new PolicypopupItem
        //            {

        //                EmployeeId = MakeSafe.ToSafeString(row["EmployeeId"]),
        //                EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]),
        //                Customer = MakeSafe.ToSafeString(row["CustomerName"]),
        //                Model = MakeSafe.ToSafeString(row["Model"]),
        //                VehicleRegNo = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]),
        //                RegistrationDate = MakeSafe.ToSafeDateTime(row["RegistrationDate"]),
        //                Amount = MakeSafe.ToSafeDecimal(row["NetAmount"])


        //            });
        //        }
        //    }

        //    return model;
        //}


        //public async Task<MCareDashBoard> CancelledPopup(UserBase user, int PlanCode)
        //{

        //    IDbDataParameter[] sqlparameters =
        //   {
        //        new SqlParameter("@CompanyGI",user.CompanyGuid),
        //        new SqlParameter("@UserGuid",user.UserGuid),
        //        new SqlParameter("@PlanCode",PlanCode),


        //    };
        //    var ds = await _sql.GetDataSetAsync("[MCARE].[SP_GET_MCARE_DASHBOARD_CANCELLED_POPUP]", sqlparameters);

        //    return PopulateCancelledPopupDetails(ds);

        //}
        //private MCareDashBoard PopulateCancelledPopupDetails(DataSet ds)
        //{

        //    MCareDashBoard model = new MCareDashBoard();
        //    model.PolicyPopup = new List<PolicypopupItem>();

        //    if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
        //    {
        //        foreach (DataRow row in ds.Tables[0].Rows)
        //        {
        //            model.PolicyPopup.Add(new PolicypopupItem
        //            {
        //                EmployeeId = MakeSafe.ToSafeString(row["EmployeeId"]),
        //                EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]),
        //                Customer = MakeSafe.ToSafeString(row["CustomerName"]),
        //                Model = MakeSafe.ToSafeString(row["Model"]),
        //                VehicleRegNo = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]),
        //                RegistrationDate = MakeSafe.ToSafeDateTime(row["RegistrationDate"]),
        //                Amount = MakeSafe.ToSafeDecimal(row["NetAmount"])

        //            });
        //        }
        //    }

        //    return model;
        //}

        //public async Task<MCareDashBoard> ExpiredPopup(UserBase user, int PlanCode)
        //{

        //    IDbDataParameter[] sqlparameters =
        //   {
        //        new SqlParameter("@CompanyGI",user.CompanyGuid),
        //        new SqlParameter("@UserGuid",user.UserGuid),
        //        new SqlParameter("@PlanCode",PlanCode),


        //    };
        //    var ds = await _sql.GetDataSetAsync("[MCARE].[SP_GET_MCARE_DASHBOARD_EXPIRED_POPUP]", sqlparameters);

        //    return PopulateExpiredPopupDetails(ds);

        //}
        //private MCareDashBoard PopulateExpiredPopupDetails(DataSet ds)
        //{

        //    MCareDashBoard model = new MCareDashBoard();
        //    model.PolicyPopup = new List<PolicypopupItem>();

        //    if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
        //    {
        //        foreach (DataRow row in ds.Tables[0].Rows)
        //        {
        //            model.PolicyPopup.Add(new PolicypopupItem
        //            {
        //                EmployeeId = MakeSafe.ToSafeString(row["EmployeeId"]),
        //                EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]),
        //                Customer = MakeSafe.ToSafeString(row["CustomerName"]),
        //                Model = MakeSafe.ToSafeString(row["Model"]),
        //                VehicleRegNo = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]),
        //                RegistrationDate = MakeSafe.ToSafeDateTime(row["RegistrationDate"]),
        //                Amount = MakeSafe.ToSafeDecimal(row["NetAmount"])

        //            });
        //        }
        //    }

        //    return model;
        //}


        //public async Task<MCareDashBoard> RenewalPopup(UserBase user, int PlanCode)
        //{

        //    IDbDataParameter[] sqlparameters =
        //   {
        //        new SqlParameter("@CompanyGI",user.CompanyGuid),
        //        new SqlParameter("@UserGuid",user.UserGuid),
        //        new SqlParameter("@PlanCode",PlanCode),


        //    };
        //    var ds = await _sql.GetDataSetAsync("[MCARE].[SP_GET_MCARE_DASHBOARD_RENEWED_POPUP]", sqlparameters);

        //    return PopulateRenewalPopupDetails(ds);

        //}
        //private MCareDashBoard PopulateRenewalPopupDetails(DataSet ds)
        //{

        //    MCareDashBoard model = new MCareDashBoard();
        //    model.PolicyPopup = new List<PolicypopupItem>();

        //    if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
        //    {
        //        foreach (DataRow row in ds.Tables[0].Rows)
        //        {
        //            model.PolicyPopup.Add(new PolicypopupItem
        //            {
        //                EmployeeId = MakeSafe.ToSafeString(row["EmployeeId"]),
        //                EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]),
        //                Customer = MakeSafe.ToSafeString(row["CustomerName"]),
        //                Model = MakeSafe.ToSafeString(row["Model"]),
        //                VehicleRegNo = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]),
        //                RegistrationDate = MakeSafe.ToSafeDateTime(row["RegistrationDate"]),
        //                Amount = MakeSafe.ToSafeDecimal(row["NetAmount"])

        //            });
        //        }
        //    }

        //    return model;
        //}

        //public async Task<MCareDashBoard> CurrentplanPopup(UserBase user, int PlanCode)
        //{

        //    IDbDataParameter[] sqlparameters =
        //   {
        //        new SqlParameter("@CompanyGI",user.CompanyGuid),
        //        new SqlParameter("@UserGuid",user.UserGuid),
        //        new SqlParameter("@PlanCode",PlanCode),


        //    };
        //    var ds = await _sql.GetDataSetAsync("[MCARE].[SP_GET_MCARE_DASHBOARD_SALES_POPUP]", sqlparameters);

        //    return PopulateCurrentplanPopupDetails(ds);

        //}
        //private MCareDashBoard PopulateCurrentplanPopupDetails(DataSet ds)
        //{

        //    MCareDashBoard model = new MCareDashBoard();
        //    model.PolicyPopup = new List<PolicypopupItem>();

        //    if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
        //    {
        //        foreach (DataRow row in ds.Tables[0].Rows)
        //        {
        //            model.PolicyPopup.Add(new PolicypopupItem
        //            {
        //                EmployeeId = MakeSafe.ToSafeString(row["EmployeeId"]),
        //                EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]),
        //                Customer = MakeSafe.ToSafeString(row["CustomerName"]),
        //                Model = MakeSafe.ToSafeString(row["Model"]),
        //                VehicleRegNo = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]),
        //                RegistrationDate = MakeSafe.ToSafeDateTime(row["RegistrationDate"]),
        //                Amount = MakeSafe.ToSafeDecimal(row["NetAmount"])

        //            });
        //        }
        //    }

        //    return model;
        //}
        public async Task<MCareDashBoard> Popup(UserBase user, int PlanCode,string Type)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@PlanCode",PlanCode),
                new SqlParameter("@Type",Type),


            };
            var ds = await _sql.GetDataSetAsync("[MCARE].[SP_GET_MCARE_DASHBOARD_PLANDETAILS_POPUP]", sqlparameters);

            return PopulatePopupDetails(ds);

        }
        private MCareDashBoard PopulatePopupDetails(DataSet ds)
        {

            MCareDashBoard model = new MCareDashBoard();
            model.PolicyPopup = new List<PolicypopupItem>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    model.PolicyPopup.Add(new PolicypopupItem
                    {
                        EmployeeId = MakeSafe.ToSafeString(row["EmployeeId"]),
                        EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]),
                        Customer = MakeSafe.ToSafeString(row["CustomerName"]),
                        Model = MakeSafe.ToSafeString(row["Model"]),
                        VehicleRegNo = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]),
                        RegistrationDate = MakeSafe.ToSafeDateTime(row["RegistrationDate"]),
                        Amount = MakeSafe.ToSafeDecimal(row["NetAmount"])

                    });
                }
            }

            return model;
        }
    }
}
//}
