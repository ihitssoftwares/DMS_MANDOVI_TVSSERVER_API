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
  public  class SalesUpdateRepository : ISalesUpdateRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public SalesUpdateRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<SalesUpdate> GetList(UserBase user, int Month, int Status,int DealerCode)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),


                new SqlParameter("@Month",Month),
                 new SqlParameter("@Status",Status),
                 new SqlParameter("@DealerCode",DealerCode),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_FILE_SALES_UPDATE_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }
        public SalesUpdate PopulateGetList(DataSet ds)
        {
            SalesUpdate model = new SalesUpdate();
            model.SalesUpdateList = new List<SalesUpdate>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new SalesUpdate
                    {
                        HDCODE = MakeSafe.ToSafeInt32(row["HDCODE"]),
                        InvNo = MakeSafe.ToSafeString(row["InvNo"]),
                        Date = MakeSafe.ToSafeString(row["Date"]),
                        StoreOrBranch = MakeSafe.ToSafeString(row["StoreOrBranch"]),
                        Executive = MakeSafe.ToSafeString(row["Executive"]),
                        Model = MakeSafe.ToSafeString(row["Model"]),
                        Variant = MakeSafe.ToSafeString(row["Variant"]),
                        Color = MakeSafe.ToSafeString(row["Color"]),
                        EngineNo = MakeSafe.ToSafeString(row["EngineNo"]),
                        ChasisNo = MakeSafe.ToSafeString(row["ChasisNo"]),
                        CustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
                        CustMob = MakeSafe.ToSafeString(row["CustMob"]),
                        ConsumerDiscount = MakeSafe.ToSafeString(row["ConsumerDiscount"]),
                        CorporateDiscount = MakeSafe.ToSafeString(row["CorporateDiscount"]),
                        NetAmount = MakeSafe.ToSafeString(row["NetAmount"]),
                        ModelCode = MakeSafe.ToSafeInt32(row["ModelCode"]),
                     
                        PlanProfit = MakeSafe.ToSafeDecimal(row["WProfitAmount"]),
                        incProfit = MakeSafe.ToSafeDecimal(row["ProfitInsuranceAmount"]),
                        finProfit = MakeSafe.ToSafeDecimal(row["ProfitFinanceAmount"]),
                        EXbProfit = MakeSafe.ToSafeDecimal(row["ExchamgeBonusAmount"]),
                        gaaprofit = MakeSafe.ToSafeDecimal(row["MGAAmount"]),
                        cpaprofit = MakeSafe.ToSafeDecimal(row["MCPAMOUNT"]),
                        acprofit = MakeSafe.ToSafeDecimal(row["AutoCardAMount"]),
                        odAmt = MakeSafe.ToSafeDecimal(row["OtherDisc"]),
                        ssfamt = MakeSafe.ToSafeDecimal(row["MSSFAmount"]),
                        accprofit = MakeSafe.ToSafeDecimal(row["AccessoriesAmount"]),
                        SaleAmount = MakeSafe.ToSafeDecimal(row["SaleAmount"]),
                


                    };
                     
                    model.SalesUpdateList.Add(item);
                }
            }

            return model;
        }





        public async Task<SalesUpdate> GetEmployeeDetails(UserBase user, int HDCode, int Status,int Model)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),


                new SqlParameter("@HDCode",HDCode),

                new SqlParameter("@Status",Status),
                new SqlParameter("@Model",Model),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_FILE_SALES_UPDATE_EMPLOYEE_DETAILS]", sqlparameters);

            return PopulateGetEmployeeDetails(ds);

        }

        public SalesUpdate PopulateGetEmployeeDetails(DataSet ds)
        {
            SalesUpdate model = new SalesUpdate();

            model.SalesUpdateItem = new SalesUpdateItem();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                model.SalesUpdateItem.Executive = MakeSafe.ToSafeString(row["Executive"]);
                model.SalesUpdateItem.Model = MakeSafe.ToSafeString(row["Model"]);
                model.SalesUpdateItem.StoreOrBranch = MakeSafe.ToSafeString(row["StoreOrBranch"]);
                model.SalesUpdateItem.Varient = MakeSafe.ToSafeString(row["Variant"]);
                model.SalesUpdateItem.color = MakeSafe.ToSafeString(row["Color"]);



                model.SalesUpdateItem.EWAmount = MakeSafe.ToSafeDecimal(row["EWAmount"]);
                model.SalesUpdateItem.MIAmount = MakeSafe.ToSafeDecimal(row["MIAmount"]);
                model.SalesUpdateItem.MGAAmount = MakeSafe.ToSafeDecimal(row["MGAAmount"]);
                model.SalesUpdateItem.MCPAmount = MakeSafe.ToSafeDecimal(row["MCPAmount"]);

                model.SalesUpdateItem.ExchangeStatus = MakeSafe.ToSafeString(row["ExchangeStatus"]);
                model.SalesUpdateItem.FinanceStatus = MakeSafe.ToSafeString(row["FinanceStatus"]);
                model.SalesUpdateItem.NetAmount = MakeSafe.ToSafeDecimal(row["NetAmount"]);
                model.SalesUpdateItem.AutoCardAmount = MakeSafe.ToSafeDecimal(row["AutoCardAmount"]);
                model.SalesUpdateItem.OtherDiscount = MakeSafe.ToSafeDecimal(row["OtherDiscount"]);
                model.SalesUpdateItem.MSSFAmount = MakeSafe.ToSafeDecimal(row["MSSFAmount"]);
                model.SalesUpdateItem.WarrentyAmount = MakeSafe.ToSafeInt32(row["WarrentyAmount"]);
                model.SalesUpdateItem.WProfitAmount = MakeSafe.ToSafeDecimal(row["WProfitAmount"]);
                model.SalesUpdateItem.InsuranceAmount = MakeSafe.ToSafeInt32(row["InsuranceAmount"]);
                model.SalesUpdateItem.ProfitInsuranceAmount = MakeSafe.ToSafeDecimal(row["ProfitInsuranceAmount"]);
                model.SalesUpdateItem.FinanaceAmount = MakeSafe.ToSafeInt32(row["FinanaceAmount"]);
                model.SalesUpdateItem.ProfitFinanceAmount = MakeSafe.ToSafeDecimal(row["ProfitFinanceAmount"]);
                model.SalesUpdateItem.ExchamgeBonusAmount = MakeSafe.ToSafeInt32(row["ExchamgeBonusAmount"]);
                model.SalesUpdateItem.NETPROFITAmount = MakeSafe.ToSafeDecimal(row["NETPROFITAmount"]);
                model.SalesUpdateItem.MCPProfit = MakeSafe.ToSafeDecimal(row["MCPProfit"]);
                model.SalesUpdateItem.AutoCardProfit = MakeSafe.ToSafeDecimal(row["AutoCardProfit"]);
                model.SalesUpdateItem.Varient = MakeSafe.ToSafeString(row["Variant"]);
                model.SalesUpdateItem.color = MakeSafe.ToSafeString(row["Color"]);
                model.SalesUpdateItem.NewVehVIN = MakeSafe.ToSafeString(row["NewVehVIN"]);
                model.SalesUpdateItem.SellingAmount = MakeSafe.ToSafeDecimal(row["AccessorySellingAmount"]);
                model.SalesUpdateItem.CostAmt = MakeSafe.ToSafeInt32(row["CostAmt"]);
                model.SalesUpdateItem.DispatchDate = MakeSafe.ToSafeString(row["DispatchDate"]);
                model.SalesUpdateItem.AccessoryProfitAmount = MakeSafe.ToSafeDecimal(row["AccessoryProfitAmount"]);
                model.MessStatus = MakeSafe.ToSafeInt32(row["Status"]);
                model.Message = MakeSafe.ToSafeString(row["Message"]);
                model.SalesUpdateItem.ValidationMessage = MakeSafe.ToSafeString(row["ValidationMessage"]);
            }

            if ((ds.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = ds.Tables[1].Rows[0];

                model.SalesUpdateItem.Employee = new Dropdown();
                model.SalesUpdateItem.Modell = new Dropdown();
                model.SalesUpdateItem.Branch = new Dropdown();
                model.SalesUpdateItem.Finance = new Dropdown();
                model.SalesUpdateItem.Insurance = new Dropdown();
                model.SalesUpdateItem.Plan = new Dropdown();
                model.SalesUpdateItem.Colors = new Dropdown();
                model.SalesUpdateItem.Varients = new Dropdown();
                model.SalesUpdateItem.ModeOfPayment = new Dropdown();

                model.SalesUpdateItem.Employee.Code =
                    MakeSafe.ToSafeInt32(row["EmployeeCode"]);

                model.SalesUpdateItem.Modell.Code =
                    MakeSafe.ToSafeInt32(row["ModelCode"]);

                model.SalesUpdateItem.Branch.Code =
                    MakeSafe.ToSafeInt32(row["BranchCode"]);
                model.SalesUpdateItem.Finance.Code =
                  MakeSafe.ToSafeInt32(row["FinanceCode"]);
                model.SalesUpdateItem.Insurance.Code =
                  MakeSafe.ToSafeInt32(row["InsuranceCode"]);
                model.SalesUpdateItem.Plan.Code =
                  MakeSafe.ToSafeInt32(row["PlanCode"]);
                model.SalesUpdateItem.Colors.Code =
                MakeSafe.ToSafeInt32(row["ColorCode"]);
                model.SalesUpdateItem.Varients.Code =
                MakeSafe.ToSafeInt32(row["VarientCode"]);
                model.SalesUpdateItem.ModeOfPayment.Code =
                MakeSafe.ToSafeInt32(row["PaymentMode"]);
            }

            if ((ds.Tables.Count > 2) && (ds.Tables[2]?.Rows?.Count ?? 0) > 0)
            {
                model.SalesUpdateItem.AccessoriesList = new List<AccessoriesSales>();

                foreach (DataRow row in ds.Tables[2].Rows)
                {
                    model.SalesUpdateItem.AccessoriesList.Add(new AccessoriesSales
                    {
                        AccessoriesCode = MakeSafe.ToSafeInt32(row["Code"]),
                        Type = MakeSafe.ToSafeString(row["Name"]),
                        AccessoryAmount = MakeSafe.ToSafeInt32(row["Amount"]),
                        SellingAmount = MakeSafe.ToSafeInt32(row["SellingAmount"]),
                        ProfitAmount = MakeSafe.ToSafeDecimal(row["ProfitAmount"]),
                        Applicablity = false
                    });
                }
               
            }
                return model;
        }
        //public SalesUpdate PopulateGetEmployeeDetails(DataSet ds)
        //{
        //    SalesUpdate model = new SalesUpdate();

        //    if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
        //    {

        //        DataRow row = ds.Tables[0].Rows[0];


        //        model = new SalesUpdateItem

        //        {
        //            Executive = MakeSafe.ToSafeString(row["Executive"]),
        //            Model = MakeSafe.ToSafeString(row["Model"]),
        //            StoreOrBranch = MakeSafe.ToSafeString(row["StoreOrBranch"]),
        //            EWAmount = MakeSafe.ToSafeDecimal(row["EWAmount"]),
        //            MIAmount = MakeSafe.ToSafeDecimal(row["MIAmount"]),
        //            MGAAmount = MakeSafe.ToSafeDecimal(row["MGAAmount"]),
        //            MCPAmount = MakeSafe.ToSafeDecimal(row["MCPAmount"]),

        //            ExchangeStatus = MakeSafe.ToSafeString(row["ExchangeStatus"]),
        //            FinanceStatus = MakeSafe.ToSafeString(row["FinanceStatus"]),
        //            AutoCardAmount = MakeSafe.ToSafeDecimal(row["AutoCardAmount"]),
        //            OtherDiscount = MakeSafe.ToSafeDecimal(row["OtherDiscount"]),
        //            MSSFAmount = MakeSafe.ToSafeDecimal(row["MSSFAmount"]),


        //    };
        //    } 
        //    if ((ds.Tables[1]?.Rows?.Count ?? 1) > 0)
        //    {

        //        DataRow row = ds.Tables[1].Rows[0];


        //        model.Modell = new Dropdown();
        //        model.Employee = new Dropdown();
        //        model.Branch = new Dropdown();
        //        {
        //            model.Employee.Code = MakeSafe.ToSafeInt32(row["EmployeeCode"]);
        //            model.Modell.Code = MakeSafe.ToSafeInt32(row["ModelCode"]);
        //            model.Branch.Code = MakeSafe.ToSafeInt32(row["BranchCode"]);


        //        };
        //    }

        //    if ((ds.Tables[2]?.Rows?.Count ?? 0) > 0)
        //    {
        //        model.AccessoriesList = new List<Accessories>();

        //        foreach (DataRow row in ds.Tables[2].Rows)
        //        {
        //            model.AccessoriesList.Add(new Accessories
        //            {
        //                AccessoriesCode = MakeSafe.ToSafeInt32(row["Code"]),
        //                Type = MakeSafe.ToSafeString(row["Name"]),
        //                AccessoryAmount = MakeSafe.ToSafeInt32(row["Amount"]),
        //                Applicablity = false
        //            });
        //        }
        //    }

        //    return model;
        //}

        public async Task<ResponseEntity> EmployeeWiseUpdate(UserBase user, SalesUpdate model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_DMS_EMPLOYEE_SALES_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
        public async Task<ResponseEntity> EmployeeWiseDelete(UserBase user, SalesUpdate model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_DMS_EMPLOYEE_SALES_DELETE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }



        public async Task<SalesUpdate> GetPlanAmount(UserBase user, string Type,int Model, int Code)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),


                new SqlParameter("@Type",Type),
                 new SqlParameter("@Code",Code),
                 new SqlParameter("@Model",Model),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DROPDOWN_PROFIT_VALUES]", sqlparameters);

            return PopulatePlanList(ds);

        }

        public SalesUpdate PopulatePlanList(DataSet ds)
        {
            SalesUpdate model = new SalesUpdate();

            model.SalesUpdateItem = new SalesUpdateItem();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                model.pprofitPercent = MakeSafe.ToSafeDecimal(row["pprofitPercent"]);

                
            }

            return model;
        }

        public async Task<SalesUpdate> GetFinanceAmount(UserBase user, string Type,int Model, int Code)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),


                new SqlParameter("@Type",Type),
                 new SqlParameter("@Code",Code),
                  new SqlParameter("@Model",Model),
            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DROPDOWN_PROFIT_VALUES]", sqlparameters);

            return PopulateFinanceList(ds);

        }

        public SalesUpdate PopulateFinanceList(DataSet ds)
        {
            SalesUpdate model = new SalesUpdate();

            model.SalesUpdateItem = new SalesUpdateItem();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

              

                // If you also have these columns
                model.fprofitPercent = MakeSafe.ToSafeDecimal(row["fprofitPercent"]);
                
            }

            return model;
        }
        public async Task<SalesUpdate> GetInsuranceAmount(UserBase user, string Type,int Model, int Code)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),


                new SqlParameter("@Type",Type),
                 new SqlParameter("@Code",Code),
                  new SqlParameter("@Model",Model),
            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DROPDOWN_PROFIT_VALUES]", sqlparameters);

            return PopulateInsuranceList(ds);

        }

        public SalesUpdate PopulateInsuranceList(DataSet ds)
        {
            SalesUpdate model = new SalesUpdate();

            model.SalesUpdateItem = new SalesUpdateItem();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

               
                model.iprofitPercent = MakeSafe.ToSafeDecimal(row["iprofitPercent"]);
            }

            return model;
        }
    }
}