using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.General;
using Cloud_Custom.Api.Repository.IRepository.MobileApp;
using Cloud_Custom.Api.Shared.General;
using Cloud_Custom.Api.Shared.Mobile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.Repository.MobileApp
{
    public class MobileSalesDashboardRepository : IMobileSalesDashboardRepository
    {
        private readonly ISqlConnectionProvider _sql;
        private readonly ICommonRepository _common;

        public MobileSalesDashboardRepository(ISqlConnectionProvider sql, ICommonRepository common)
        {
            _sql = sql;
            _common = common;

        }



        public async Task<MobileSalesDashboard> GetList(UserBase user,int UserCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@EmpCode",UserCode),
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_SALES_DASH_LIST]", sqlparameters);
                return PendingJobsList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private MobileSalesDashboard PendingJobsList(DataSet dataSet)
        {
            MobileSalesDashboard model = new MobileSalesDashboard();

            List<MobileSalesDashboard> GetList = new List<MobileSalesDashboard>();

            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];
                model.UserCode = MakeSafe.ToSafeInt32(row["UserCode"]);
                model.EmpName = MakeSafe.ToSafeString(row["EmpName"]);
                model.EmpID = MakeSafe.ToSafeString(row["EmpID"]);
                model.Target = MakeSafe.ToSafeInt32(row["Target"]);
                model.Achieved = MakeSafe.ToSafeInt32(row["Achieved"]);
                model.AchievedPercent = MakeSafe.ToSafeDecimal(row["AchievedPercent"]);
                model.TotalEnquiry = MakeSafe.ToSafeInt32(row["TotalEnquiry"]);
                model.TotalBooking = MakeSafe.ToSafeInt32(row["TotalBooking"]);
                model.TotalRetail = MakeSafe.ToSafeInt32(row["TotalRetail"]);
                model.Pending = MakeSafe.ToSafeInt32(row["Pending"]);
                model.From = MakeSafe.ToSafeDateTime(row["From"]);
                model.To = MakeSafe.ToSafeDateTime(row["To"]);
                model.IsTL = MakeSafe.ToSafeInt32(row["IsTL"]);
            }



            if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {
                    var item = new MobileSalesDashboard();

                    item.Code = MakeSafe.ToSafeInt32(row["Code"]);
                    
                    item.Name = MakeSafe.ToSafeString(row["Name"]);
                    item.Count = MakeSafe.ToSafeInt32(row["Count"]);
                   

                    GetList.Add(item);
                }

                model.List = GetList;
            }

            return model;
        }




        public async Task<MobileSalesDashboard> GetDetails(UserBase user, int UserCode,string Type)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@EmpCode",UserCode),
                  new SqlParameter("@Type",Type),
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_SALES_DASH_DETAILS]", sqlparameters);
                return DetailsList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private MobileSalesDashboard DetailsList(DataSet dataSet)
        {
            MobileSalesDashboard model = new MobileSalesDashboard();

            List<MobileSalesDashboard> GetList = new List<MobileSalesDashboard>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new MobileSalesDashboard();

                    item.Number = MakeSafe.ToSafeString(row["Number"]);
                    item.Date = MakeSafe.ToSafeDateTime(row["Date"]);
                    item.Branch = MakeSafe.ToSafeString(row["Branch"]);
                    item.Customer = MakeSafe.ToSafeString(row["Customer"]);
                    item.Model = MakeSafe.ToSafeString(row["Model"]);
                    item.Variant = MakeSafe.ToSafeString(row["Variant"]);
                    item.Color = MakeSafe.ToSafeString(row["Color"]);
                    item.Status = MakeSafe.ToSafeString(row["Status"]);
                    item.ModeOfEnquiry = MakeSafe.ToSafeString(row["ModeOfEnquiry"]);
                    item.Amount = MakeSafe.ToSafeInt32(row["Amount"]);
                    GetList.Add(item);
                }

                model.Details = GetList;
            }



            return model;
        }


        public async Task<MobileSalesDashboard> GetTargetAchievement(UserBase user, int UserCode, int MonthCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@EmpCode",UserCode),
                  new SqlParameter("@MonthCode",MonthCode),
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_SALES_TARGET_ACHIEVEMENT_LIST]", sqlparameters);
                return TargetAchievement(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private MobileSalesDashboard TargetAchievement(DataSet dataSet)
        {
            MobileSalesDashboard model = new MobileSalesDashboard();

            List<MobileSalesDashboard> GetList = new List<MobileSalesDashboard>();

            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];
              
                model.Target = MakeSafe.ToSafeInt32(row["Target"]);
                model.Achieved = MakeSafe.ToSafeInt32(row["Achieved"]);
                model.AchievedPercent = MakeSafe.ToSafeDecimal(row["AchievedPercent"]);
                model.WorkDayLeft = MakeSafe.ToSafeInt32(row["WorkDayLeft"]);
                model.DailyRequirment = MakeSafe.ToSafeDecimal(row["DailyRequirment"]);
               
            }


            if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {
                    var item = new MobileSalesDashboard();

                    
                    item.Month = MakeSafe.ToSafeString(row["Month"]);
                    item.MonthCode = MakeSafe.ToSafeInt32(row["MonthCode"]);
                    item.Target = MakeSafe.ToSafeInt32(row["Target"]);
                    item.Achieved = MakeSafe.ToSafeInt32(row["Achieved"]);
                   
                   
                    GetList.Add(item);
                }

                model.Details = GetList;
            }



            return model;
        }




        public async Task<MobileSalesDashboard> GetDetailsTL(UserBase user, int UserCode, string Type)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@EmpCode",UserCode),
                  new SqlParameter("@Type",Type),
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_SALES_DASH_DETAILS_TL]", sqlparameters);
                return TLDetailsList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private MobileSalesDashboard TLDetailsList(DataSet dataSet)
        {
            MobileSalesDashboard model = new MobileSalesDashboard();

            List<MobileSalesDashboard> GetList = new List<MobileSalesDashboard>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new MobileSalesDashboard();

                    item.Number = MakeSafe.ToSafeString(row["Number"]);
                    item.Date = MakeSafe.ToSafeDateTime(row["Date"]);
                    item.Branch = MakeSafe.ToSafeString(row["Branch"]);
                    item.Customer = MakeSafe.ToSafeString(row["Customer"]);
                    item.Model = MakeSafe.ToSafeString(row["Model"]);
                    item.Variant = MakeSafe.ToSafeString(row["Variant"]);
                    item.Color = MakeSafe.ToSafeString(row["Color"]);
                    item.Status = MakeSafe.ToSafeString(row["Status"]);
                    item.ModeOfEnquiry = MakeSafe.ToSafeString(row["ModeOfEnquiry"]);
                    item.Amount = MakeSafe.ToSafeInt32(row["Amount"]);
                    GetList.Add(item);
                }

                model.Details = GetList;
            }

            if (dataSet.Tables.Count > 0 && dataSet.Tables[1].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[1].Rows[0];

                model.TLName = MakeSafe.ToSafeString(row["TLNAME"]);
                

            }

            return model;
        }
    }
}
