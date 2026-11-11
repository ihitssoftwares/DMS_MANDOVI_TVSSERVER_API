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
  public   class SalesPositionRepository : ISalesPositionRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public SalesPositionRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<SalesPosition> GetList(UserBase user, string TabIndex)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                  new SqlParameter("@Type",TabIndex)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SALEPOSITION_LIST]", sqlparameters);
                return SalesPositionList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private SalesPosition SalesPositionList(DataSet dataSet)
        {
            SalesPosition model = new SalesPosition();
            List<SalesPosition> List = new List<SalesPosition>();
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
                    var item = new SalesPosition();



                    item.SLno = MakeSafe.ToSafeInt32(row["Slno"]);
                    item.IncentiveCode = MakeSafe.ToSafeInt32(row["IncentiveGroupCode"]);
                    item.Incentivename = MakeSafe.ToSafeString(row["IncentiveGroupName"]);
                    item.DMSCode = MakeSafe.ToSafeString(row["DMSCode"]);
                    item.DepartmentCode = MakeSafe.ToSafeInt32(row["DepartmentTypeCode"]);
                    item.DepartmentName = MakeSafe.ToSafeString(row["DepartmentName"]);
                    item.Active = MakeSafe.ToSafeBool(row["IsActive"]);


                    List.Add(item);
                }
                model.List = List;
            }
            return model;

        }
        public async Task<ResponseEntity> Save(UserBase user, string mode, SalesPosition model)
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
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_SALES_POSITION_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        public async Task<SalesPosition> GetPositionDetails(UserBase User, int IncentiveCode, string mode, string Type)
        {

            IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@IncentiveCode",IncentiveCode),


            };
            var dataSet = await _sql.GetDataSetAsync("[DMS].[SP_SALES_POSITION_DETAILS]", sqlParameters);
            return PopulatepositionDetails(dataSet);

        }

        private SalesPosition PopulatepositionDetails(DataSet dataSet)
        {
            SalesPosition model = new SalesPosition();


            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];


                model.IncentiveCode = MakeSafe.ToSafeInt32(row["IncentiveGroupCode"]);
                model.Incentivename = MakeSafe.ToSafeString(row["IncentiveGroupName"]);

                model.DepartmentCode = MakeSafe.ToSafeInt32(row["DepartmentCode"]);

                model.DepartmentName = MakeSafe.ToSafeString(row["DepartmentName"]);
                model.DMSCode = MakeSafe.ToSafeString(row["DMSCode"]);
                model.Active = MakeSafe.ToSafeBool(row["IsActive"]);
            }

            return model;
        }
        public async Task<ResponseEntity> DeletePostion(UserBase user, SalesPosition model)
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
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_SALES_POSITION_DELETE]", sqlParameters, CommandType.StoredProcedure);
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
