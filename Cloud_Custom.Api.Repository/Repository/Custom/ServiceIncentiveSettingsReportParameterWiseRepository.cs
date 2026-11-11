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
    public class ServiceIncentiveSettingsReportParameterWiseRepository : IServiceIncentiveSettingsReportParameterWiseRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public ServiceIncentiveSettingsReportParameterWiseRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }

        public async Task<ServiceIncentiveSettingsReportParameterWise> GetList(UserBase user, int Month, int ParameterCode, int Region)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Month",Month),
                 new SqlParameter("@ParameterCode",ParameterCode),
                 new SqlParameter("@RegionCode",Region),

                };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_INCENTIVE_SETTINGS_PARAMETER_WISE_REPORT_LIST]", sqlparameters);
                return DesignationVsParameterList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private ServiceIncentiveSettingsReportParameterWise DesignationVsParameterList(DataSet dataSet)
        {
            ServiceIncentiveSettingsReportParameterWise model = new ServiceIncentiveSettingsReportParameterWise();
            List<ServiceIncentiveSettingsReportParameterWise> List = new List<ServiceIncentiveSettingsReportParameterWise>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new ServiceIncentiveSettingsReportParameterWise();



                    item.RegionCode = MakeSafe.ToSafeInt32(row["RegionCode"]);
                    item.WorkShopName = MakeSafe.ToSafeString(row["RegionName"]);
                    item.ParameterCode = MakeSafe.ToSafeInt32(row["ParameterCode"]);
                    item.ParameterName = MakeSafe.ToSafeString(row["ParameterName"]);
                    item.IncentiveGroupName = MakeSafe.ToSafeString(row["IncentiveGroupName"]);
                    item.SlabType = MakeSafe.ToSafeString(row["SlabType"]);
                    item.IncentiveType = MakeSafe.ToSafeString(row["IncentiveType"]);
                    item.SlabFrom = MakeSafe.ToSafeDecimal(row["SlabFrom"]);
                    item.SlabTo = MakeSafe.ToSafeDecimal(row["SlabTo"]);
                    item.Incentive = MakeSafe.ToSafeDecimal(row["Incentive"]);
                    item.Colorcode = MakeSafe.ToSafeString(row["Colorcode"]);
                    item.Target = MakeSafe.ToSafeInt32(row["Target"]);
                    item.BranchName = MakeSafe.ToSafeString(row["BranchName"]);


                    List.Add(item);
                }
                model.List = List;
            }


            
            return model;
        }


       

        

        


        


       

    }
}
