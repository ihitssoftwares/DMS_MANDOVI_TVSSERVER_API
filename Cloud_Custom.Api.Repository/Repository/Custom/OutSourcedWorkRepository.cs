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
    public class OutSourcedWorkRepository: IOutSourcedWorkRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public OutSourcedWorkRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<OutSourcedWork> GetList(UserBase user, string TabIndex)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Type",TabIndex)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_OUTSOURCEDWORK_LIST]", sqlparameters);
                return OutSourcedWorkList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private OutSourcedWork OutSourcedWorkList(DataSet dataSet)
        {
            OutSourcedWork model = new OutSourcedWork();
            List<OutSourcedWork> List = new List<OutSourcedWork>();
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
                    var item = new OutSourcedWork();

                    item.SLno = MakeSafe.ToSafeInt32(row["Slno"]);
                    item.OutSourcedWorkCode = MakeSafe.ToSafeInt32(row["WorkCode"]);
                    item.OutSourcedWorkName = MakeSafe.ToSafeString(row["Name"]);
       
                    List.Add(item);
                }
                model.List = List;
            }
            return model;

        }

        public async Task<ResponseEntity> Save(UserBase user, string mode, OutSourcedWork model)
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
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_OutSourcedWork_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        public async Task<OutSourcedWork> GetOutSourcedWorkDetails(UserBase User, int Code, string mode, string Type)
        {

            IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@Code",Code),
                 new SqlParameter("@Type",Type),

            };
            var dataSet = await _sql.GetDataSetAsync("[DMS].[SP_OutSourcedWork_DETAILS]", sqlParameters);
            return PopulateOutSourcedWorkDetails(dataSet);

        }

        private OutSourcedWork PopulateOutSourcedWorkDetails(DataSet dataSet)
        {
            OutSourcedWork model = new OutSourcedWork();


            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];


                model.OutSourcedWorkCode = MakeSafe.ToSafeInt32(row["WorkCode"]);
                model.OutSourcedWorkName = MakeSafe.ToSafeString(row["Name"]);
                model.ShortName = MakeSafe.ToSafeString(row["ShortName"]);
               
            }

            return model;
        }
    }
}
