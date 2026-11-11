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
    public class BayRepository : IBayRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public BayRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<Bay> GetList(UserBase user, string TabIndex)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Type",TabIndex)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_BAY_LIST]", sqlparameters);
                return BayList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private Bay BayList(DataSet dataSet)
        {
            Bay model = new Bay();
            List<Bay> List = new List<Bay>();
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
                    var item = new Bay();



                    item.SLno = MakeSafe.ToSafeInt32(row["Slno"]);
                    item.BayCode = MakeSafe.ToSafeInt32(row["BayCode"]);
                    item.BayName = MakeSafe.ToSafeString(row["BayName"]);
                    item.BranchCode = MakeSafe.ToSafeInt32(row["BranchCode"]);
                    item.BayTypeCode = MakeSafe.ToSafeInt32(row["BayTypeCode"]);
                    item.BranchName = MakeSafe.ToSafeString(row["BranchName"]);
                    item.BAYTYPENAME = MakeSafe.ToSafeString(row["BAYTYPENAME"]);
                    item.BayUserCode = MakeSafe.ToSafeString(row["BayUserCode"]);

                    List.Add(item);
                }
                model.List = List;
            }
            return model;

        }
        public async Task<ResponseEntity> Save(UserBase user, string mode, Bay model)
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
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_BAY_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        public async Task<Bay> GetDealershipDetails(UserBase User, int DealerCode, string mode, string Type)
        {

            IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@DealerCode",DealerCode),
                new SqlParameter("@Type",Type),

            };
            var dataSet = await _sql.GetDataSetAsync("[DMS].[SP_BAY_DETAILS]", sqlParameters);
            return PopulateBayDetails(dataSet);

        }

        private Bay PopulateBayDetails(DataSet dataSet)
        {
            Bay model = new Bay();


            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];


                model.BayCode = MakeSafe.ToSafeInt32(row["BAYCODE"]);
                model.BayName = MakeSafe.ToSafeString(row["BAYNAME"]);
                model.Branch = new Dropdown  {
                    Name = MakeSafe.ToSafeString(row["BranchName"]),
                    Code = MakeSafe.ToSafeInt32(row["BRANCHCODE"]) 
                };
                model.BayType = new Dropdown {
                    Name = MakeSafe.ToSafeString(row["BAYTYPENAME"]),
                    Code = MakeSafe.ToSafeInt32(row["BAYTYPECODE"]) };
                model.Active = MakeSafe.ToSafeBool(row["ACTIVE"]);

            }

            return model;
        }
        public async Task<ResponseEntity> DearlerDelete(UserBase User, Bay model)
        {
            try
            {
                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 200, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),

                        ResponseKey,ResponseStatus
                };

                await _sql.ExecuteNonQueryAsync("[DMS].[SP_BAY_DELETE]", sqlParameters, CommandType.StoredProcedure);
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
