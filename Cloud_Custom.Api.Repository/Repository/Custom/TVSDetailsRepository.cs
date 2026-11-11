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
    public class TVSDetailsRepository : ITVSDetailsRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public TVSDetailsRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<TVSDetails> GetList(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_TVSDetails_LIST]", sqlparameters);
                return ModelList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private TVSDetails ModelList(DataSet dataSet)
        {
            TVSDetails model = new TVSDetails();
            List<TVSDetails> List = new List<TVSDetails>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new TVSDetails();



                    item.VehRegNo = MakeSafe.ToSafeString(row["VehRegNo"]);
                    item.Model = MakeSafe.ToSafeString(row["Model"]);
                    item.Name = MakeSafe.ToSafeString(row["Name"]);
                    item.Plan = MakeSafe.ToSafeString(row["PlanName"]);
                    item.Expiry = MakeSafe.ToSafeString(row["Expiry"]);
                    item.MobNo = MakeSafe.ToSafeString(row["MobNo"]);
                    item.Mail = MakeSafe.ToSafeString(row["Mail"]);

                    List.Add(item);
                }
                model.List = List;
            }

            return model;

        }
    }
}
