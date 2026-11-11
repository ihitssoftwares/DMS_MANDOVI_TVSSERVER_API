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
     public class LeadStatusRepository: ILeadStatusRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public LeadStatusRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<LeadStatus> GetList(UserBase user, string Type, string Fromdate, string ToDate, string Groupby)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                    new SqlParameter("@Type",Type),
                    new SqlParameter("@From",Fromdate),
                    new SqlParameter("@To",ToDate),
                    new SqlParameter("@Groupby",Groupby),
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_LEAD_STATUS_LIST]", sqlparameters);
                return ModelList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private LeadStatus ModelList(DataSet dataSet)
        {
            LeadStatus model = new LeadStatus();
            List<LeadStatus> LeadStatusList = new List<LeadStatus>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new LeadStatus();
                   


                   
                    item.StoreName = MakeSafe.ToSafeString(row["Particular"]);
          
                    item.RB = MakeSafe.ToSafeInt32(row["RB"]);
                    item.lead = MakeSafe.ToSafeInt32(row["Lead"]);
                    item.Booked = MakeSafe.ToSafeInt32(row["Booked"]);
                    item.Alloted = MakeSafe.ToSafeInt32(row["Alloted"]);
                    item.Billed = MakeSafe.ToSafeInt32(row["Billed"]);
                    item.Delivered = MakeSafe.ToSafeInt32(row["Delivered"]);
                    item.Exchanged = MakeSafe.ToSafeInt32(row["Exchanged"]);
                    item.Registration = MakeSafe.ToSafeInt32(row["Registration"]);
                    item.LtoB = MakeSafe.ToSafeInt32(row["LtoB"]);
                    item.LtoR = MakeSafe.ToSafeInt32(row["LtoR"]);
                    item.BtoR = MakeSafe.ToSafeInt32(row["BtoR"]);
                    item.LDH = MakeSafe.ToSafeInt32(row["LDH"]);

                    LeadStatusList.Add(item);

                }
                model.LeadStatusList = LeadStatusList;
            }
            
            return model;

        }
    }
}
