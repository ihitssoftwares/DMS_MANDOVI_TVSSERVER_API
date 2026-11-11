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
    public class ServiceRepository : IServiceRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public ServiceRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<Services> GetBatteryList(UserBase user, int Month, int Type)
        {

            IDbDataParameter[] sqlparameters =
           {

                new SqlParameter("@User",user.UserGuid),

                     new SqlParameter("@Month",Month),
                    new SqlParameter("@Type",Type),
                    

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_GET_SERVICE_DASHBOARD_BATTERY]", sqlparameters);

            return PopulateGetBatteryList(ds);

        }
        public Services PopulateGetBatteryList(DataSet ds)
        {
            Services model = new Services();

            model.Batteryy = model.Batteryy ?? new Batteryy();

            // 🚨 If dataset is null or empty
            if (ds == null || ds.Tables.Count == 0)
                return model;

            // ─────────────────────────────
            // TABLE 0 : SUMMARY
            // ─────────────────────────────
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                var row = ds.Tables[0].Rows[0];

                model.Batteryy.TotalQty = row["TotalQty"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalQty"]);


                model.Batteryy.TotalRevenue = row["TotalRevenue"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalRevenue"])
                        ;
                model.Batteryy.TotalDDL = row["TotalDDL"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalDDL"]);

                model.Batteryy.AVGPrice = row["AvgPrice"] == DBNull.Value ? 0 : Convert.ToInt32(row["AvgPrice"])
                   ;
            }

            // ─────────────────────────────
            // TABLE 1 : MONTH LIST
            // ─────────────────────────────
            
            // ─────────────────────────────
            // TABLE 3 : LOCATION LIST
            // ─────────────────────────────
            model.Batteryy.LoctionList = new List<Batteryy>();

            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    model.Batteryy.LoctionList.Add(new Batteryy
                    {
                        
                        Branchname = MakeSafe.ToSafeString(row["Name"]),
                        locationRevenue =
                        row.Table.Columns.Contains("cCount")
                    ? Convert.ToInt32(row["cCount"]) : 0,
                    
                    });
                }
            }


            
            return model;
        }
        public async Task<Services> GetCCpList(UserBase user, int Month, int Type)
        {

            IDbDataParameter[] sqlparameters =
           {

                new SqlParameter("@User",user.UserGuid),

                     new SqlParameter("@Month",Month),
                    new SqlParameter("@Type",Type),
                    

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_GET_SERVICE_DASHBOARD_CCP]", sqlparameters);

            return PopulateGetCCPList(ds);

        }
        public Services PopulateGetCCPList(DataSet ds)
        {
            Services model = new Services();

            model.CCPp = model.CCPp ?? new CCPp();

            // 🚨 If dataset is null or empty
            if (ds == null || ds.Tables.Count == 0)
                return model;

            // ─────────────────────────────
            // TABLE 0 : SUMMARY
            // ─────────────────────────────
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                var row = ds.Tables[0].Rows[0];

                model.CCPp.CCPTotalRecords = row["TotalRecords"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalRecords"]);
                model.CCPp.CCPTotalSales = row["TotalSales"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalSales"]);
                model.CCPp.CCPTotalClaimAmount = row["TotalClaimAmount"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalClaimAmount"]);
                model.CCPp.CCPActivePolicies = row["ActivePolicies"] == DBNull.Value ? 0 : Convert.ToInt32(row["ActivePolicies"]);
            }

            // ─────────────────────────────
            // TABLE 1 : MONTH LIST
            // ─────────────────────────────
            model.CCPp.CCPList = new List<CCPp>();

            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    model.CCPp.CCPList.Add(new CCPp
                    {
                        CCPDealername = MakeSafe.ToSafeString(row["Name"]),
                        CCPCount = MakeSafe.ToSafeString(row["cCount"]),
                        

                    });
                }

            }


            return model;
        }
        public async Task<Services> GetEWList(UserBase user, int Month, int Type)
        {

            IDbDataParameter[] sqlparameters =
           {

                    new SqlParameter("@User",user.UserGuid),

                     new SqlParameter("@Month",Month),
                    new SqlParameter("@Type",Type),
                    

                };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_GET_SERVICE_DASHBOARD_EW]", sqlparameters);

            return PopulateGetEWList(ds);

        }
        public Services PopulateGetEWList(DataSet ds)
        {
            Services model = new Services();

            model.EW = model.EW ?? new EW();

            // 🚨 If dataset is null or empty
            if (ds == null || ds.Tables.Count == 0)
                return model;

            // ─────────────────────────────
            // TABLE 0 : SUMMARY
            // ─────────────────────────────
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                var row = ds.Tables[0].Rows[0];

                model.EW.EWTotalPolicies = row["TotalPolicies"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalPolicies"]);
                model.EW.EWTotalRevenue = row["TotalRevenue"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalRevenue"]);
                model.EW.EWTotalDiscount = row["TotalDiscount"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalDiscount"]);
                model.EW.EWAvgPremium = row["AvgPremium"] == DBNull.Value ? 0 : Convert.ToInt32(row["AvgPremium"]);
                model.EW.EWTotalCommission = row["TotalCommission"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalCommission"]);
            }

            // ─────────────────────────────
            // TABLE 1 : MONTH LIST
            // ─────────────────────────────
            model.EW.EWMonthly = new List<EW>();

            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    model.EW.EWMonthly.Add(new EW
                    {
                        EWMonthname = row.Table.Columns.Contains("Name")
                        ? Convert.ToString(row["Name"]) : "",
                        EWRevenue = row.Table.Columns.Contains("cCount")
                        ? Convert.ToInt32(row["cCount"]) : 0

                    });
                }
            }

            //// ─────────────────────────────
            //// TABLE 2 : ADVISOR LIST
            //// ─────────────────────────────
            //model.EW.EWBranchWise = new List<EW>();

            //if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            //{
            //    foreach (DataRow row in ds.Tables[2].Rows)
            //    {
            //        model.EW.EWBranchWise.Add(new EW
            //        {
            //            EWBranch = row.Table.Columns.Contains("Branch")
            //            ? Convert.ToString(row["Branch"]) : "",
            //            EWBranchRevenue = row.Table.Columns.Contains("Revenue")
            //            ? Convert.ToInt32(row["Revenue"]) : 0,

            //            EWPolicies = row.Table.Columns.Contains("Policies")
            //            ? Convert.ToInt32(row["Policies"]) : 0
            //        });
            //    }
            //}

            //// ─────────────────────────────
            //// TABLE 3 : LOCATION LIST
            //// ─────────────────────────────
            //model.EW.EWModelWise = new List<EW>();

            //if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
            //{
            //    foreach (DataRow row in ds.Tables[3].Rows)
            //    {
            //        model.EW.EWModelWise.Add(new EW
            //        {
            //            EWModelDesc = MakeSafe.ToSafeString(row["ModelDesc"]),
            //            EWPolicyCount = MakeSafe.ToSafeInt32(row["PolicyCount"]),

            //        });
            //    }
            //}

            //// ─────────────────────────────
            //// TABLE 4 : PART LIST
            //// ─────────────────────────────
            //model.EW.EWAdvisor = new List<EW>();

            //if (ds.Tables.Count > 4 && ds.Tables[4].Rows.Count > 0)
            //{
            //    foreach (DataRow row in ds.Tables[4].Rows)
            //    {
            //        model.EW.EWAdvisor.Add(new EW
            //        {
            //            EWServiceAdvisor = MakeSafe.ToSafeString(row["serviceAdvisorDSEName"]),
            //            EWAdvisorRevenue = row.Table.Columns.Contains("Revenue")
            //            ? Convert.ToInt32(row["Revenue"]) : 0

            //        });
            //    }
            //}

            //// ─────────────────────────────
            //// TABLE 5 : BATTERY LIST
            //// ─────────────────────────────
            //model.EW.EWList = new List<EW>();

            //if (ds.Tables.Count > 5 && ds.Tables[5].Rows.Count > 0)
            //{
            //    foreach (DataRow row in ds.Tables[5].Rows)
            //    {
            //        model.EW.EWList.Add(new EW
            //        {
            //            EWPolicyNo = MakeSafe.ToSafeString(row["PolicyNo"]),
            //            EWCustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
            //            EWListBranch = MakeSafe.ToSafeString(row["Branch"]),
            //            EWListModelDescri = MakeSafe.ToSafeString(row["ModelDesc"]),
            //            EWPremiumAmount = MakeSafe.ToSafeString(row["PremiumAmount"]),
            //            EWExpiryDate = MakeSafe.ToSafeString(row["ExpiryDate"])

            //        });
            //    }
            //}
            return model;
        }
        public async Task<Services> GetLabourList(UserBase user, int Month, int Type)
        {

            IDbDataParameter[] sqlparameters =
           {

                new SqlParameter("@User",user.UserGuid),

                     new SqlParameter("@MonthCode",Month),
                    new SqlParameter("@Type",Type),
                    


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_GET_SERVICE_DASHBOARD_Labour]", sqlparameters);

            return PopulateGetLabourList(ds);

        }
        public Services PopulateGetLabourList(DataSet ds)
        {
            Services model = new Services();

            model.labour = model.labour ?? new labour();

            // 🚨 If dataset is null or empty
            if (ds == null || ds.Tables.Count == 0)
                return model;

            // ─────────────────────────────
            // TABLE 0 : SUMMARY
            // ─────────────────────────────
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                var row = ds.Tables[0].Rows[0];

                model.labour.LabourTotalJobs = row["TotalJobs"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalJobs"]);
                model.labour.LabourTotalRevenue = row["TotalRevenue"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalRevenue"]);
                model.labour.LabourTotalDiscount = row["TotalDiscount"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalDiscount"]);
                model.labour.LabourAvgBillValue = row["AvgBillValue"] == DBNull.Value ? 0 : Convert.ToInt32(row["AvgBillValue"]);

            }

        
            // ─────────────────────────────
            // TABLE 2 : ADVISOR LIST
            // ─────────────────────────────
            model.labour.labourDealerList = new List<labour>();

            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    model.labour.labourDealerList.Add(new labour
                    {
                        LabourDealerName = MakeSafe.ToSafeString(row["Name"]),
                        LabourDealerRevenue = row["cCount"] == DBNull.Value ? 0 : Convert.ToInt32(row["cCount"]),
                        Code = MakeSafe.ToSafeInt32(row["Code"]),

                    });
                }
            }

            // ─────────────────────────────
            // TABLE 3 : LOCATION LIST
            // ─────────────────────────────
            //model.labour.labourLabourList = new List<labour>();

            //if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
            //{
            //    foreach (DataRow row in ds.Tables[3].Rows)
            //    {
            //        model.labour.labourLabourList.Add(new labour
            //        {
            //            labourlabourCode = MakeSafe.ToSafeString(row["LabourCode"]),
            //            labourlabourDesc = MakeSafe.ToSafeString(row["LabourDesc"]),
            //            labourlabourTotalJobs = row.Table.Columns.Contains("TotalJobss")
            //            ? Convert.ToInt32(row["TotalJobss"]):0,
            //            labourlabourTotallaourAmount = row.Table.Columns.Contains("TotalLabourAmount")
            //            ? Convert.ToInt32(row["TotalLabourAmount"]):0,
            //            labourlabourTotalAvglaourAmount = row.Table.Columns.Contains("AvgLabourAmount")
            //            ? Convert.ToInt32(row["AvgLabourAmount"]):0,
                       

            //        });
            //    }
            //}model.labour.labourList = new List<labour>();

            //if (ds.Tables.Count > 4 && ds.Tables[4].Rows.Count > 0)
            //{
            //    foreach (DataRow row in ds.Tables[4].Rows)
            //    {
            //        model.labour.labourList.Add(new labour
            //        {
            //            LabourDetailJcNum = MakeSafe.ToSafeString(row["JcNum"]),
            //            LabourDetailJcDate = MakeSafe.ToSafeString(row["JcDate"]),
            //            LabourDetailCustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
            //            LabourDetailRegNo = MakeSafe.ToSafeString(row["RegistrationNo"]),
            //            LabourDetailModel = MakeSafe.ToSafeString(row["Model"]),
            //            LabourDetailBillNo = MakeSafe.ToSafeString(row["BillNo"]),
            //            LabourDetailBillAmt = row["BillAmt"] == DBNull.Value ? 0 : Convert.ToInt32(row["BillAmt"]),
            //            LabourBillDate = MakeSafe.ToSafeString(row["BillDate"]),

            //        });
            //    }
            //}


            return model;
            }

        public async Task<Services> GetLoadList(UserBase user, int Month, int Type)
        {

            IDbDataParameter[] sqlparameters =
           {

                    new SqlParameter("@User",user.UserGuid),

                     new SqlParameter("@Month",Month),
                    new SqlParameter("@Type",Type),
                    
                  

                };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_GET_SERVICE_DASHBOARD_Load]", sqlparameters);

            return PopulateGetLoadList(ds);

        }
        public Services PopulateGetLoadList(DataSet ds)
        {
            Services model = new Services();

            model.load = model.load ?? new load();

            // 🚨 If dataset is null or empty
            if (ds == null || ds.Tables.Count == 0)
                return model;

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                var row = ds.Tables[0].Rows[0];

                model.load.LoadTotalJobs = row["TotalJobs"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalJobs"]);
                    model.load.LoadTotalRevenue = row["TotalRevenue"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalRevenue"]);
                    model.load.LoadAvgBilling = row["AvgBilling"] == DBNull.Value ? 0 : Convert.ToInt32(row["AvgBilling"]);
                    model.load.LoadRepeatJobs = row["RepeatJobs"] == DBNull.Value ? 0 : Convert.ToInt32(row["RepeatJobs"]);
                
            }
            //model.load.loadList = new List<load>();

            //if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            //{
            //    foreach (DataRow row in ds.Tables[1].Rows)
            //    {
            //        model.load.loadList.Add(new load
            //        {
            //            LoadlistDealerName = MakeSafe.ToSafeString(row["Name"]),
            //            LoadlistDealerCity = MakeSafe.ToSafeString(row["DealerCity"]),
            //            LoadlistLocation = MakeSafe.ToSafeString(row["Location"]),
            //            LoadlistJobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]),
            //            LoadlistJobDate = MakeSafe.ToSafeString(row["JobDate"]),
            //            LoadlistCustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
            //            LoadlistServiceType = MakeSafe.ToSafeString(row["ServiceType"]),
            //            LoadlistBillAmount = MakeSafe.ToSafeInt32(row["BillAmount"]),
            //            LoadlistStatus = MakeSafe.ToSafeString(row["Status"]),
            //            LoadlistRepeatRevisit = MakeSafe.ToSafeString(row["RepeatRevisit"]),

            //        });
            //    }
            //}
            // ─────────────────────────────
            // TABLE 0 : SUMMARY
            // ─────────────────────────────
           
            // ─────────────────────────────
            // TABLE 1 : MONTH LIST
            // ─────────────────────────────
            model.load.loadDealerList = new List<load>();

            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    model.load.loadDealerList.Add(new load
                    {
                        LoadRevenueDealerName = MakeSafe.ToSafeString(row["Name"]),
                        LoadRevenue = row["Amount"] == DBNull.Value ? 0 : Convert.ToInt32(row["Amount"]),
                        Code = MakeSafe.ToSafeInt32(row["Code"]),
                    });
                }
            }

            // ─────────────────────────────
            // TABLE 2 : ADVISOR LIST
            // ─────────────────────────────
            //model.load.loadServiceList = new List<load>();

            //if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
            //{
            //    foreach (DataRow row in ds.Tables[3].Rows)
            //    {
            //        model.load.loadServiceList.Add(new load
            //        {
            //            LoadServiceTypeName = MakeSafe.ToSafeString(row["ServiceTYpe"]),
            //            LoadJobCount = MakeSafe.ToSafeInt32(row["JobCount"]),


            //        });
            //    }
            //}

            // ─────────────────────────────
            // TABLE 3 : LOCATION LIST
            // ─────────────────────────────
            


            return model;
        }
        public async Task<Services> GetMCPList(UserBase user, int Month, int Type)
        {

            IDbDataParameter[] sqlparameters =
           {

                new SqlParameter("@User",user.UserGuid),


                     new SqlParameter("@Month",Month),
                    new SqlParameter("@Type",Type),
                    

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_GET_SERVICE_DASHBOARD_MCP]", sqlparameters);

            return PopulateGetMCPList(ds);

        }
        public Services PopulateGetMCPList(DataSet ds)
        {
            Services model = new Services();

            model.mcp = model.mcp ?? new Mcp();

            // 🚨 If dataset is null or empty
            if (ds == null || ds.Tables.Count == 0)
                return model;

            // ─────────────────────────────
            // TABLE 0 : SUMMARY
            // ─────────────────────────────
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                var row = ds.Tables[0].Rows[0];

                model.mcp.MCPTotalMCP = row["TotalMCP"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalMCP"]);
                model.mcp.MCPActiveMCP = row["ActiveMCP"] == DBNull.Value ? 0 : Convert.ToInt32(row["ActiveMCP"]);
                model.mcp.MCPExpiredMCP = row["ExpiredMCP"] == DBNull.Value ? 0 : Convert.ToInt32(row["ExpiredMCP"]);
                model.mcp.MCPCancelledMCP = row["CancelledMCP"] == DBNull.Value ? 0 : Convert.ToInt32(row["CancelledMCP"]);

            }

            model.mcp.McpList = new List<Mcp>();
              if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
              {
                    foreach (DataRow row in ds.Tables[1].Rows)
                    {
                        model.mcp.McpList.Add(new Mcp
                        {
                            MCPName = MakeSafe.ToSafeString(row["Name"]),
                            MCPcount = MakeSafe.ToSafeInt32(row["cCount"]),


                        });
                    }
                }


                return model;
        }
        public async Task<Services> GetMGAList(UserBase user, int Month, int Type)
        {

            IDbDataParameter[] sqlparameters =
           {

                     new SqlParameter("@User",user.UserGuid),

                     new SqlParameter("@MonthCode",Month),
                    new SqlParameter("@Type",Type),
                    


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_GET_SERVICE_DASHBOARD_MGA]", sqlparameters);

            return PopulateGetMGAList(ds);

        }
        public Services PopulateGetMGAList(DataSet ds)
        {
            Services model = new Services();

            model.mga = model.mga ?? new Mga();

            // 🚨 If dataset is null or empty
            if (ds == null || ds.Tables.Count == 0)
                return model;

            // ─────────────────────────────
            // TABLE 0 : SUMMARY
            // ─────────────────────────────
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                var row = ds.Tables[0].Rows[0];
               
                model.mga.MgaTotalConsumption = row["TotalConsumption"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalConsumption"]);
                model.mga.MgaTotalLoad = row["TotalLoad"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalLoad"]);
                model.mga.MgaTotalMGA = row["TotalMGA"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalMGA"]);
                model.mga.MgaAvgComnsumption = row["AvgConsumption"] == DBNull.Value ? 0 : Convert.ToInt32(row["AvgConsumption"]);
            }

            model.mga.MgaAdvisorList = new List<Mga>();

            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    model.mga.MgaAdvisorList.Add(new Mga
                    {
                        MgapServiceAdvisor = MakeSafe.ToSafeString(row["Name"]),
                        MgapConsumption = row["cCOUNT"] == DBNull.Value ? 0 : Convert.ToInt32(row["cCOUNT"]),
                        MgaCode = MakeSafe.ToSafeInt32(row["Code"]),


                    });
                }
            }
           
            return model;
        }
        public async Task<Services> GetPMS20List(UserBase user, int Month, int Type)
        {

            IDbDataParameter[] sqlparameters =
           {
                 new SqlParameter("@User",user.UserGuid),
                     new SqlParameter("@Month",Month),
                    new SqlParameter("@Type",Type),
                    
            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_GET_SERVICE_DASHBOARD_PMS20]", sqlparameters);

            return PopulateGetPMS20List(ds);

        }
        public Services PopulateGetPMS20List(DataSet ds)
        {
            Services model = new Services();

            model.pms20 = model.pms20 ?? new Pms20();

            // 🚨 If dataset is null or empty
            if (ds == null || ds.Tables.Count == 0)
                return model;

            // ─────────────────────────────
            // TABLE 0 : SUMMARY
            // ─────────────────────────────
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                var row = ds.Tables[0].Rows[0];

                model.pms20.Pms20TotalJC =row["TotalJC"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalJC"]);
                model.pms20.Pms20TotalRevenue = row["TotalRevenue"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalRevenue"]);
                model.pms20.Pms20LabourRevenue = row["LabourRevenue"] == DBNull.Value ? 0 : Convert.ToInt32(row["LabourRevenue"]);
                model.pms20.Pms20PartsRevenue = row["PartsRevenue"] == DBNull.Value ? 0 : Convert.ToInt32(row["PartsRevenue"]);
                model.pms20.Pms20AvgTAT = row["AvgTAT"] == DBNull.Value ? 0 : Convert.ToInt32(row["AvgTAT"]);
            }

            // ─────────────────────────────
            // TABLE 1 : MONTH LIST
            // ─────────────────────────────
           

            model.pms20.Pms20ServiceList = new List<Pms20>();
            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    model.pms20.Pms20ServiceList.Add(new Pms20
                    {
                        Pms20ServiceType = MakeSafe.ToSafeString(row["Name"]),
                        Pms20TotalCount = MakeSafe.ToSafeInt32(row["cCount"]),


                    });
                }
            }
            


            return model;
        }

        public async Task<Services> GetPMSPartsList(UserBase user, int Month, int Type)
         {

            IDbDataParameter[] sqlparameters =
           {

                 new SqlParameter("@User",user.UserGuid),
                     new SqlParameter("@Month",Month),
                    new SqlParameter("@Type",Type),
                    

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_GET_SERVICE_DASHBOARD_PMS_PARTS]", sqlparameters);

            return PopulateGetPMSPartsList(ds);

        }
        public Services PopulateGetPMSPartsList(DataSet ds)
        {
            Services model = new Services();

            model.pmsparts = model.pmsparts ?? new PmsParts();

            // 🚨 If dataset is null or empty
            if (ds == null || ds.Tables.Count == 0)
                return model;

            // ─────────────────────────────
            // TABLE 0 : SUMMARY
            // ─────────────────────────────

            // ─────────────────────────────
            // TABLE 1 : MONTH LIST
            // ─────────────────────────────
            

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {


                    model.pmsparts.PmsPartsTotalRecords = MakeSafe.ToSafeInt32(row["TotalRecordss"]);
                    model.pmsparts.PmsPartsTotalPMSRequired = MakeSafe.ToSafeInt32(row["TotalPMSRequiredd"]);
                    model.pmsparts.PmsPartsTotalPMSChanged = MakeSafe.ToSafeInt32(row["TotalPMSChangedd"]);
                    model.pmsparts.PmsPartsTotalPMSPercent = row.Table.Columns.Contains("PMSPercentt")
                        ? Convert.ToInt32(row["PMSPercentt"]) : 0;


                    
                }
            }
            
            model.pmsparts.PmsPartsList = new List<PmsParts>();
            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    model.pmsparts.PmsPartsList.Add(new PmsParts
                    {
                   
                        PmsPartsName = MakeSafe.ToSafeString(row["Name"]),
                        
                        PmsPartsCount = MakeSafe.ToSafeInt32(row["cCount"]),
                       


                    });
                }
            }


            return model;
        }
        public async Task<Services> GetSparesList(UserBase user, int Month, int Type)
        {

            IDbDataParameter[] sqlparameters =
           {
                 new SqlParameter("@User",user.UserGuid),
                     new SqlParameter("@Month",Month),
                    new SqlParameter("@Type",Type),
                    

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_GET_SERVICE_DASHBOARD_SPARES]", sqlparameters);

            return PopulateGetSparesList(ds);

        }
        public Services PopulateGetSparesList(DataSet ds)
        {
            Services model = new Services();

            model.spares = model.spares ?? new Spares();

            // 🚨 If dataset is null or empty
            if (ds == null || ds.Tables.Count == 0)
                return model;



            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                var row = ds.Tables[0].Rows[0];

                model.spares.SparesTotalBills = MakeSafe.ToSafeInt32(row["TotalBills"]);
                model.spares.SparesTotalRevenue = row.Table.Columns.Contains("TotalRevenue")
                            ? Convert.ToInt32(row["TotalRevenue"]) : 0;
                model.spares.SparesPartsRevenue = row.Table.Columns.Contains("PartsRevenue")
                            ? Convert.ToInt32(row["PartsRevenue"]) : 0;
                model.spares.SparesLabourRevenue = row.Table.Columns.Contains("LabourRevenue")
                            ? Convert.ToInt32(row["LabourRevenue"]) : 0;
            }
            model.spares.SparesBillList = new List<Spares>();
            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    model.spares.SparesBillList.Add(new Spares
                    {
                        SparesName = MakeSafe.ToSafeString(row["Name"]),
                        SparesCount = MakeSafe.ToSafeInt32(row["cCount"]),




                    }) ;
                }
            }

            


            return model;
        }

        public async Task<Services> GetSyntheticOilList(UserBase user, int Month, int Type)
        {

            IDbDataParameter[] sqlparameters =
           {

                new SqlParameter("@User",user.UserGuid),

                     new SqlParameter("@Month",Month),
                    new SqlParameter("@Type",Type),
                    

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_GET_SERVICE_DASHBOARD_OIL]", sqlparameters);

            return PopulateGetSyntheticOilList(ds);

        }
        public Services PopulateGetSyntheticOilList(DataSet ds)
        {
            Services model = new Services();

            model.syntheticoOil = model.syntheticoOil ?? new SyntheticOil();

            // 🚨 If dataset is null or empty
            if (ds == null || ds.Tables.Count == 0)
                return model;



            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                var row = ds.Tables[0].Rows[0];

                model.syntheticoOil.SyntheticOilTotalRecords = MakeSafe.ToSafeInt32(row["TotalRecords"]);
                model.syntheticoOil.SyntheticOilTotalQty = row["TotalQty"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalQty"]);
                model.syntheticoOil.SyntheticOilTotalServiceLoad = row["TotalServiceLoad"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalServiceLoad"]);
            }

            model.syntheticoOil.SyntheticOilList = new List<SyntheticOil>();
            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    model.syntheticoOil.SyntheticOilList.Add(new SyntheticOil
                    {
                        SyntheticOilName = MakeSafe.ToSafeString(row["NAME"]),
                        SyntheticOilCount = MakeSafe.ToSafeInt32(row["cCOUNT"]),
                        



                    });
                }
            }





            return model;
        }
        public async Task<Services> GetTrueValueList(UserBase user, int Month, int Type)
        {

            IDbDataParameter[] sqlparameters =
           {

                new SqlParameter("@User",user.UserGuid),

                     new SqlParameter("@Month",Month),
                    new SqlParameter("@Type",Type),
                    

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_GET_SERVICE_DASHBOARD_TV]", sqlparameters);

            return PopulateGetTrueValueList(ds);

        }
        public Services PopulateGetTrueValueList(DataSet ds)
        {
            Services model = new Services();

            model.trueValue = model.trueValue ?? new Truevalue();

            // 🚨 If dataset is null or empty
            if (ds == null || ds.Tables.Count == 0)
                return model;



            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                var row = ds.Tables[0].Rows[0];

                model.trueValue.TrueValueTotalEnquiry = MakeSafe.ToSafeInt32(row["TotalEnquiry"]);
                model.trueValue.TrueValueNetBooking = MakeSafe.ToSafeInt32(row["NetBooking"]);
                model.trueValue.TrueValueNetSale = MakeSafe.ToSafeInt32(row["NetSales"]);
                model.trueValue.TrueValueTotalProfit = MakeSafe.ToSafeInt32(row["TotalProfit"]);
            }

            model.trueValue.TruevalueDealerList = new List<Truevalue>();
            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    model.trueValue.TruevalueDealerList.Add(new Truevalue
                    {
                        TrueValueName = MakeSafe.ToSafeString(row["Name"]),
                        TrueValueCount = MakeSafe.ToSafeInt32(row["cCount"]),
                      





                    });
                }
            }
            





            return model;
        }
        public async Task<Services> GetTyreList(UserBase user, int Month, int Type)
        {

            IDbDataParameter[] sqlparameters =
           {

                new SqlParameter("@User",user.UserGuid),

                     new SqlParameter("@Month",Month),
                    new SqlParameter("@Type",Type),
                    

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_GET_SERVICE_DASHBOARD_TYRE]", sqlparameters);

            return PopulateGetTyreList(ds);

        }
        public Services PopulateGetTyreList(DataSet ds)
        {
            Services model = new Services();

            model.tyre = model.tyre ?? new Tyree();

            // 🚨 If dataset is null or empty
            if (ds == null || ds.Tables.Count == 0)
                return model;



            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                var row = ds.Tables[0].Rows[0];

                model.tyre.TyreTotalQty = row["TotalQty"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalQty"]);
                model.tyre.TyreTotalDDL = row["TotalDDL"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalDDL"]);
                model.tyre.TyreTotalSelling = row["TotalSelling"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalSelling"]);
                model.tyre.TyreTotalRecords = row["TotalRecords"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalRecords"]);
            }

            model.tyre.TyreeList = new List<Tyree>();
            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    model.tyre.TyreeList.Add(new Tyree
                    {
                        TyreName = MakeSafe.ToSafeString(row["Name"]),
                        TyreCount = MakeSafe.ToSafeInt32(row["cCount"]),
                        



                    });
                }
            }
           


            return model;
        }







        public async Task<Services> GetLoadPopDetails(UserBase user,Filter filter, string Tab, string Name, int Code, int TypeCode, int Month)
        {

            IDbDataParameter[] sqlparameters =
           {
                 new SqlParameter("@JSONDATA",JsonHelper.ToJson(filter)),
                new SqlParameter("@User",user.UserGuid),

                     new SqlParameter("@Tab",Tab),
                    new SqlParameter("@Name",Name),
                     new SqlParameter("@Code",Code),
                      new SqlParameter("@TypeCode",TypeCode),
                       new SqlParameter("@Month",Month),



            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_LOAD_DRILLDOWN_DETAILS]", sqlparameters);

            return PopulateLoadPopList(ds);

        }
        public Services PopulateLoadPopList(DataSet ds)
        {
            Services model = new Services();
            model.load = new load();
            model.load.PopUpList = new List<load>();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    model.load.PopUpList.Add(new load
                    {
                        Location = MakeSafe.ToSafeString(row["Location"]),
                        JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]),
                        JCDate = MakeSafe.ToSafeDateTime(row["JCDate"]),
                        SA = MakeSafe.ToSafeString(row["SA"]),
                        CustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
                        RegistrationNo = MakeSafe.ToSafeString(row["RegistrationNo"]),
                        CHASISNO = MakeSafe.ToSafeString(row["CHASISNO"]),
                        EnginNo = MakeSafe.ToSafeString(row["EnginNo"]),
                        BillAmount = MakeSafe.ToSafeDecimal(row["BillAmount"]),
                        active = MakeSafe.ToSafeInt32(row["ACTIVE"]),
                        totalRecords = MakeSafe.ToSafeInt32(row["TotalCount"])
                    });
                }
            }

            return model;
        }






        public async Task<Services> GetLabourPopDetails(UserBase user, Filter filter, string Tab, string Name, int Code, int TypeCode, int Month)
        {

            IDbDataParameter[] sqlparameters =
           {
                 new SqlParameter("@JSONDATA",JsonHelper.ToJson(filter)),
                new SqlParameter("@User",user.UserGuid),

                     new SqlParameter("@Tab",Tab),
                    new SqlParameter("@Name",Name),
                     new SqlParameter("@Code",Code),
                      new SqlParameter("@TypeCode",TypeCode),
                       new SqlParameter("@Month",Month),



            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_LABOUR_DRILLDOWN_DETAILS]", sqlparameters);

            return PopulateLabourPopList(ds);

        }
        public Services PopulateLabourPopList(DataSet ds)
        {
            Services model = new Services();
            model.labour = new labour();
            model.labour.PopUpList = new List<labour>();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    model.labour.PopUpList.Add(new labour
                    {
                        Location = MakeSafe.ToSafeString(row["Location"]),
                        JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]),
                        JCDate = MakeSafe.ToSafeDateTime(row["JCDate"]),
                        SA = MakeSafe.ToSafeString(row["SA"]),
                        CustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
                        RegistrationNo = MakeSafe.ToSafeString(row["RegistrationNo"]),
                      
                        BillAmount = MakeSafe.ToSafeDecimal(row["BillAmount"]),
                        active = MakeSafe.ToSafeInt32(row["ACTIVE"]),
                        totalRecords = MakeSafe.ToSafeInt32(row["TotalCount"])
                    });
                }
            }

            return model;
        }


        public async Task<Services> GetMGAPopDetails(UserBase user, Filter filter, string Tab, string Name, int Code, int TypeCode, int Month)
        {

            IDbDataParameter[] sqlparameters =
           {
                 new SqlParameter("@JSONDATA",JsonHelper.ToJson(filter)),
                new SqlParameter("@User",user.UserGuid),

                     new SqlParameter("@Tab",Tab),
                    new SqlParameter("@Name",Name),
                     new SqlParameter("@Code",Code),
                      new SqlParameter("@TypeCode",TypeCode),
                       new SqlParameter("@Month",Month),



            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_MGA_DRILLDOWN_DETAILS]", sqlparameters);

            return PopulateMGAPopList(ds);

        }
        public Services PopulateMGAPopList(DataSet ds)
        {
            Services model = new Services();
            model.mga = new Mga();
            model.mga.MgaPopUpList = new List<Mga>();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    model.mga.MgaPopUpList.Add(new Mga
                    {
                        MgaLocation = MakeSafe.ToSafeString(row["Location"]),

                        MgaSA = MakeSafe.ToSafeString(row["SA"]),
                        MgaConsumption = MakeSafe.ToSafeInt32(row["Consumption"]),
                        MgaLoadValue = MakeSafe.ToSafeInt32(row["LoadValue"]),

                        MgaLoad = MakeSafe.ToSafeInt32(row["MGALoad"]),
                        active = MakeSafe.ToSafeInt32(row["ACTIVE"]),
                        totalRecords = MakeSafe.ToSafeInt32(row["TotalCount"])
                    });
                }
            }

            return model;
        }


    }
}


