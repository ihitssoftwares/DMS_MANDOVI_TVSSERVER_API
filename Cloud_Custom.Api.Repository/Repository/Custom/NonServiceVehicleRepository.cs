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
    public class NonServiceVehicleRepository : INonServiceVehicleRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public NonServiceVehicleRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<NonServiceVehicle> GetList(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_NONSERVICEVEHICLE_LIST]", sqlparameters);
                return NonServiceVehicleList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private NonServiceVehicle NonServiceVehicleList(DataSet dataSet)
        {
            NonServiceVehicle model = new NonServiceVehicle();
            List<NonServiceVehicle> List = new List<NonServiceVehicle>();
            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new NonServiceVehicle();

                    item.SLno = MakeSafe.ToSafeInt32(row["Slno"]);
                    item.NonServiceVehicleCode = MakeSafe.ToSafeInt32(row["NonServiceVehicleCode"]);
                    item.RegNo = MakeSafe.ToSafeString(row["RegistrationNo"]);
                    item.Remarks = MakeSafe.ToSafeString(row["Remark"]);

                    List.Add(item);
                }
                model.List = List;
            }
            return model;

        }
        public async Task<ResponseEntity> Save(UserBase user, string mode, NonServiceVehicle model)
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
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_NONSERVICEVEHICLE_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        public async Task<NonServiceVehicle> GetNonServiceVehicleDetails(UserBase User, int NonServiceVehicleCode, string mode)
        {

            IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@NonServiceVehicleCode",NonServiceVehicleCode)

            };
            var dataSet = await _sql.GetDataSetAsync("[DMS].[SP_NONSERVICEVEHICLE_DETAILS]", sqlParameters);
            return PopulateNonServiceVehicleDetails(dataSet);

        }

        private NonServiceVehicle PopulateNonServiceVehicleDetails(DataSet dataSet)
        {
            NonServiceVehicle model = new NonServiceVehicle();


            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];


                model.NonServiceVehicleCode = MakeSafe.ToSafeInt32(row["TrnCode"]);
                model.RegNo = MakeSafe.ToSafeString(row["RegistrationNo"]);
                model.Remarks = MakeSafe.ToSafeString(row["Remark"]);
            }

            return model;
        }

        public async Task<ResponseEntity> NonServiceVehicleDelete(UserBase User, NonServiceVehicle model)
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

                await _sql.ExecuteNonQueryAsync("[DMS].[SP_NONSERVICEVEHICLE_DELETE]", sqlParameters, CommandType.StoredProcedure);
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
