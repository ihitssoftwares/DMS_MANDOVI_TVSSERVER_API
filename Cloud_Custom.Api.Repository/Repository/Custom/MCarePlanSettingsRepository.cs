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
    public class MCarePlanSettingsRepository : IMCarePlanSettingsRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public MCarePlanSettingsRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }

        public async Task<MCarePlanSettings> GetList(UserBase user,int PlanCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
             new SqlParameter("@CompanyGI",user.CompanyGuid),
             new SqlParameter("@UserGuid",user.UserGuid),
             new SqlParameter("@PlanCode",PlanCode)

        };
                var ds = await _sql.GetDataSetAsync("[MCARE].[SP_MPLAN_SETTINGS_LIST]", sqlparameters);
                return MCarePlanSettingsList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private MCarePlanSettings MCarePlanSettingsList(DataSet dataSet)
        {
            MCarePlanSettings model = new MCarePlanSettings();
            List<MCarePlanSettings> List = new List<MCarePlanSettings>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new MCarePlanSettings();
                    item.SLno = MakeSafe.ToSafeInt32(row["Slno"]);
                    item.Code = MakeSafe.ToSafeInt32(row["HdCode"]);
                   // item.DtCode = MakeSafe.ToSafeInt32(row["DtCode"]);
                    item.PlanName = MakeSafe.ToSafeString(row["PlanName"]);
                    item.ModelName = MakeSafe.ToSafeString(row["ModelName"]);
                    item.Amount = MakeSafe.ToSafeString(row["Amount"]);
                    item.NoofServices = MakeSafe.ToSafeInt32(row["NoOfServices"]);
                    List.Add(item);
                }
                model.List = List;
            }
            return model;
        }
        public async Task<MCarePlanSettings> GetDetails(UserBase user, int Type)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
             new SqlParameter("@CompanyGI",user.CompanyGuid),
             new SqlParameter("@UserGuid",user.UserGuid),
             //new SqlParameter("@Segment",Segment),
             new SqlParameter("@Type",Type)

        };
                var ds = await _sql.GetDataSetAsync("[MCARE].[SP_MPLAN_SETTINGS_DETAILS]", sqlparameters);
                return MCarePlanSettingsGetDetailsList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private MCarePlanSettings MCarePlanSettingsGetDetailsList(DataSet dataSet)
        {
            MCarePlanSettings model = new MCarePlanSettings();
            List<MCarePlanSettings> List = new List<MCarePlanSettings>();
            List<MCarePlanSettings> List1 = new List<MCarePlanSettings>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new MCarePlanSettings();

                    item.ModelCode = MakeSafe.ToSafeInt32(row["ModelCode"]);
                    item.ModelName = MakeSafe.ToSafeString(row["ModelName"]);
                    item.GroupName = MakeSafe.ToSafeString(row["GroupName"]);
            
                    List.Add(item);
                }
                model.List = List;
            }

            if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {
                    var item = new MCarePlanSettings();

                    item.ServiceCode = MakeSafe.ToSafeInt32(row["ServiceCode"]);
                    item.ServiceName = MakeSafe.ToSafeString(row["ServiceName"]);
                    
                    List1.Add(item);
                }
                model.ServiceList = List1;
            }
            return model;
        }
        public async Task<MCarePlanSettings> GetEditDetails(UserBase user, int Code, int DtCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
             new SqlParameter("@CompanyGI",user.CompanyGuid),
             new SqlParameter("@UserGuid",user.UserGuid),
             new SqlParameter("@Code",Code),
             new SqlParameter("@DtCode",DtCode)

        };
                var ds = await _sql.GetDataSetAsync("[MCARE].[SP_MPLAN_SETTINGS_EDIT_DETAILS]", sqlparameters);
                return PlanSettingsGetEditDetailsList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private MCarePlanSettings PlanSettingsGetEditDetailsList(DataSet dataSet)
        {
            MCarePlanSettings model = new MCarePlanSettings();
            model.Plan = new Dropdown();
            model.Model = new Dropdown();
            model.Mode = "Edit";
            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];
                model.Code = MakeSafe.ToSafeInt32(row["Code"]);
                model.Plan.Code = MakeSafe.ToSafeInt32(row["PlanCode"]);
                model.Model.Code = MakeSafe.ToSafeInt32(row["ModelCode"]);
                model.Amount = MakeSafe.ToSafeString(row["Amount"]);
                model.PlanName = MakeSafe.ToSafeString(row["PlanName"]);
                model.ModelName = MakeSafe.ToSafeString(row["ModelName"]);
            }
            model.ServiceList = new List<MCarePlanSettings>();
            if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {
                    model.ServiceList.Add(new MCarePlanSettings
                    {
                        ServiceCode = MakeSafe.ToSafeInt32(row["ServiceCode"]),
                        ServiceName = MakeSafe.ToSafeString(row["ServiceName"]),
                        Limit = MakeSafe.ToSafeString(row["Limit"]),
                        Percentage = MakeSafe.ToSafeInt32(row["Percentage"])
                    });
                }
            }
            model.DescList = new List<MCarePlanSettings>();
            if ((dataSet.Tables[2]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[2].Rows)
                {
                    model.DescList.Add(new MCarePlanSettings
                    {
                        ServiceDescription = MakeSafe.ToSafeString(row["Description"]),
                        Details = MakeSafe.ToSafeString(row["Details"])
                    });
                }
            }
            return model;
        }
        public async Task<ResponseEntity> Save(UserBase user, MCarePlanSettings model)
        {
            try
            {
                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 200, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
           new SqlParameter("@CompanyGI",user.CompanyGuid),
           new SqlParameter("@UserGuid",user.UserGuid),
           new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
            ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[MCARE].[SP_MCARE_PLAN_SETTINGS_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        public async Task<ResponseEntity> SaveSettings(UserBase user, MCarePlanSettings model)
        {
            try
            {
                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 200, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
           new SqlParameter("@CompanyGI",user.CompanyGuid),
           new SqlParameter("@UserGuid",user.UserGuid),
           new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
            ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[MCARE].[SP_MCARE_PLAN_MULTIPLE_SETTINGS_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
    }
    
}
