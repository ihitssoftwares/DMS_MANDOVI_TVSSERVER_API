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
  public   class MCarePlanRepository : IMCarePlanRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public MCarePlanRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<MCarePlan> GetList(UserBase user, string TabIndex)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Type",TabIndex)
            };
                var ds = await _sql.GetDataSetAsync("MCARE.[SP_MCAREPLAN_LIST]", sqlparameters);
                return MCarePlanList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private MCarePlan MCarePlanList(DataSet dataSet)
        {
            MCarePlan model = new MCarePlan();
            List<MCarePlan> List = new List<MCarePlan>();
            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    model.ActiveCount = MakeSafe.ToSafeInt32(row["ActiveCount"]);
                    model.InactiveCount = MakeSafe.ToSafeInt32(row["InactiveCount"]);


                }
            }
            if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {
                    var item = new MCarePlan();

                   
                    item.DescCode = MakeSafe.ToSafeInt32(row["planCode"]);
                    item.Name = MakeSafe.ToSafeString(row["Name"]);
                    item.shortName = MakeSafe.ToSafeString(row["shortName"]);
                    item.Duration = MakeSafe.ToSafeString(row["McarePackageDurationCode"]);
                    item.Active = MakeSafe.ToSafeBool(row["Active"]);
       

                    List.Add(item);
                }
                model.MCarePlanList = List;
            }
            return model;

        }
        public async Task<ResponseEntity> Save(UserBase user, string mode, MCarePlan model)
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
               new SqlParameter("@Mode",mode),
                ResponseKey,ResponseStatus
                };
                await _sql.ExecuteNonQueryAsync("[MCARE].[SP_MCAREPALAN_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        public async Task<MCarePlan> GetMCarePlanDetails(UserBase User, int MCarePlanCode, string mode, string Type)
        {

            IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@MCarePlanCode",MCarePlanCode),
          

            };
            var dataSet = await _sql.GetDataSetAsync("[MCARE].[SP_MCAREPLAN_DETAILS]", sqlParameters);
            return PopulateMCarePlanDetails(dataSet);

        }

        private MCarePlan PopulateMCarePlanDetails(DataSet dataSet)
        {
            MCarePlan model = new MCarePlan();
            model.DurationDrop = new Dropdown();

            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];


                model.DescCode = MakeSafe.ToSafeInt32(row["DescCode"]);
                model.Name = MakeSafe.ToSafeString(row["Name"]);
                model.shortName = MakeSafe.ToSafeString(row["shortName"]);
                model.DurationDrop.Code = MakeSafe.ToSafeInt32(row["DurationCode"]);
                model.DurationDrop.Name = MakeSafe.ToSafeString(row["Duration"]);

                model.Active = MakeSafe.ToSafeBool(row["IsActive"]);
            }

            return model;
        }

        public async Task<ResponseEntity> Delete(UserBase user, MCarePlan model)
        {
            try
            {

                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),

                    ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[MCARE].[SP_MCAREPLAN_DELETE]", sqlParameters, CommandType.StoredProcedure);
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
