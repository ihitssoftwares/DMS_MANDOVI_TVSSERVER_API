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
    public class IncentiveRepository : IIncentiveRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public IncentiveRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<Incentive> GetList(UserBase user, string TabIndex)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                  new SqlParameter("@Type",TabIndex)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_INCENTIVE_LIST]", sqlparameters);
                return IncentiveList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private Incentive IncentiveList(DataSet dataSet)
        {
            Incentive model = new Incentive();
            List<Incentive> List = new List<Incentive>();
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
                    var item = new Incentive();



                    item.SLno = MakeSafe.ToSafeInt32(row["Slno"]);
                    item.IncentiveCode = MakeSafe.ToSafeInt32(row["IncentiveGroupCode"]);
                    item.Incentivename = MakeSafe.ToSafeString(row["IncentiveGroupName"]);
                    item.DMSCode = MakeSafe.ToSafeString(row["DMSCode"]);
                    item.DepartmentCode = MakeSafe.ToSafeInt32(row["DepartmentTypeCode"]);
                    item.DepartmentName = MakeSafe.ToSafeString(row["DepartmentName"]);
                    item.BasedOnCode = MakeSafe.ToSafeInt32(row["IncentiveBasedOn"]);
                    item.BasedOnName = MakeSafe.ToSafeString(row["BasedOnName"]);
                    //item.Active = MakeSafe.ToSafeBool(row["IsActive"]);


                    List.Add(item);
                }
                model.List = List;
            }
            return model;

        }
        public async Task<ResponseEntity> Save(UserBase user, string mode, Incentive model)
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
               new SqlParameter("@Mode",mode),
                ResponseKey,ResponseStatus
                };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_INCENTIVE_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        public async Task<Incentive> GetIncentiveDetails(UserBase User, int IncentiveCode, string mode, string Type)
        {

            IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@IncentiveCode",IncentiveCode),
                new SqlParameter("@Type",Type),

            };
            var dataSet = await _sql.GetDataSetAsync("[DMS].[SP_INCENTIVE_DETAILS]", sqlParameters);
            return PopulatepositionDetails(dataSet);

        }
        private Incentive PopulatepositionDetails(DataSet dataSet)
        {
            Incentive model = new Incentive();


            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];
                model.Department = new Dropdown();
                model.Incentivebasedon = new Dropdown();


                model.IncentiveCode = MakeSafe.ToSafeInt32(row["IncentiveGroupCode"]);
                model.Incentivename = MakeSafe.ToSafeString(row["IncentiveGroupName"]);

                model.Department.Code = MakeSafe.ToSafeInt32(row["DepartmentCode"]);

                model.DepartmentName = MakeSafe.ToSafeString(row["DepartmentName"]);
                model.DMSCode = MakeSafe.ToSafeString(row["DMSCode"]);
                model.Active = MakeSafe.ToSafeBool(row["IsActive"]);
                model.Incentivebasedon.Code = MakeSafe.ToSafeInt32(row["IncentiveBasedOn"]);
                model.BasedOnName = MakeSafe.ToSafeString(row["BasedOnName"]);

            }

            return model;
        }
        public async Task<ResponseEntity> DeleteIncentive(UserBase user, Incentive model)
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
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_INCENTIVE_DELETE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }


        public async Task<Incentive> GetDepartmentTypeCode(UserBase User, int DepartmentCode)
        {

            IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@DepartmentCode",DepartmentCode),
               

            };
            var dataSet = await _sql.GetDataSetAsync("[DMS].[SP_INCENTIVE_GETDEPARTMENTTYPECODE]", sqlParameters);
            return PopulateDepartmentTypeCode(dataSet);

        }
        private Incentive PopulateDepartmentTypeCode(DataSet dataSet)
        {
            Incentive model = new Incentive();


            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];
   
                model.DepartmentTypeCode = MakeSafe.ToSafeInt32(row["DepartmentTypeCode"]);
      

            }

            return model;
        }
    }
}
