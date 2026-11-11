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
    public class ServiceParameterListRepository : IServiceParameterListRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public ServiceParameterListRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }

        public async Task<ServiceParameterList> GetList(UserBase user, int IncentiveGroup)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 
                 new SqlParameter("@IncentiveGroupCode",IncentiveGroup),
                

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_INCENTIVE_PARAMETER_LIST]", sqlparameters);
                return DesignationVsParameterList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private ServiceParameterList DesignationVsParameterList(DataSet dataSet)
        {
            ServiceParameterList model = new ServiceParameterList();
            List<ServiceParameterList> List = new List<ServiceParameterList>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new ServiceParameterList();



                    item.ParameterCode = MakeSafe.ToSafeInt32(row["ParameterCode"]);
                    item.ParameterName = MakeSafe.ToSafeString(row["ParameterName"]);
                    item.TargetType = MakeSafe.ToSafeString(row["TargetType"]);
                    item.SlabType = MakeSafe.ToSafeString(row["SlabType"]);
                    item.IncentiveType = MakeSafe.ToSafeString(row["IncentiveType"]);
                    item.ParameterType = MakeSafe.ToSafeString(row["ParameterType"]);
                    item.Colorcode = MakeSafe.ToSafeString(row["Colorcode"]);
                   


                    List.Add(item);
                }
                model.List = List;
            }


            //if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            //{
            //    foreach (DataRow row in dataSet.Tables[1].Rows)
            //    {

            //        model.PendingCount = MakeSafe.ToSafeInt32(row["PendingCount"]);

            //    }
            //}
            return model;
        }




    }
}
