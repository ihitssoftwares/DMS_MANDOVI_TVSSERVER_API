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
    public  class IncentiveGroupVsDesignationRepository : IIncentiveGroupVsDesignationRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public IncentiveGroupVsDesignationRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<IncentiveGroupVsDesignation> GetList(UserBase user, int IncentiveCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@IncentiveCode",IncentiveCode),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_INCENTIVE_VS_DESIGNATION_LIST]", sqlparameters);
                return DesignationVsParameterList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private IncentiveGroupVsDesignation DesignationVsParameterList(DataSet dataSet)
        {
            IncentiveGroupVsDesignation model = new IncentiveGroupVsDesignation();
            List<IncentiveGroupVsDesignation> List = new List<IncentiveGroupVsDesignation>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new IncentiveGroupVsDesignation();


                    item.SLno = MakeSafe.ToSafeInt32(row["Slno"]);
                    item.DesignationCode = MakeSafe.ToSafeInt32(row["DesignationCode"]);
                    item.DesignationName = MakeSafe.ToSafeString(row["DesignationName"]);
                    item.IsApplicable = MakeSafe.ToSafeBool(row["IsApplicable"]);

                    List.Add(item);
                }
                model.List = List;
            }
            return model;

        }
        public async Task<ResponseEntity> Save(IncentiveGroupVsDesignation Model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {
                new SqlParameter("@JSONDATA",JsonHelper.ToJson(Model)),
                ResponseKey,ResponseStatus
            };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_IncentiveGroup_Vs_Designation_Save]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
    }
}
