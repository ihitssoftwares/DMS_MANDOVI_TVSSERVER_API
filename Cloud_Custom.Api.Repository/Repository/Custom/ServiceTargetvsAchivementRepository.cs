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
    public class ServiceTargetvsAchivementRepository : IServiceTargetvsAchivementRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public ServiceTargetvsAchivementRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }

        public async Task<ServiceTargetvsAchivement> GetList(UserBase user, int Month, int IncentiveGroup, int Region, int Parameter)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@MonthCode",Month),
                 new SqlParameter("@IncentiveGroupCode",IncentiveGroup),
                 new SqlParameter("@RegionCode",Region),
                 new SqlParameter("@ParameterCode",Parameter),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_TARGET_ACHIEVMENT_REPORT]", sqlparameters);
                return DesignationVsParameterList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private ServiceTargetvsAchivement DesignationVsParameterList(DataSet dataSet)
        {
            ServiceTargetvsAchivement model = new ServiceTargetvsAchivement();
            List<ServiceTargetvsAchivement> List = new List<ServiceTargetvsAchivement>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new ServiceTargetvsAchivement();



                    item.Monthcode = MakeSafe.ToSafeInt32(row["monthCode"]);
                    item.MonthName = MakeSafe.ToSafeString(row["Month"]);
                    item.WorkShopCode = MakeSafe.ToSafeInt32(row["regionCode"]);
                    item.WorkShopName = MakeSafe.ToSafeString(row["Region"]);
                    item.BranchName = MakeSafe.ToSafeString(row["Branch"]);
                    item.ParameterCode = MakeSafe.ToSafeInt32(row["ParameterCode"]);
                    item.ParameterName = MakeSafe.ToSafeString(row["Parameter"]);
                    item.empCode = MakeSafe.ToSafeInt32(row["empCode"]);
                    item.ServiceAdvisor = MakeSafe.ToSafeString(row["Service Advisor"]);
                    item.Achievment = MakeSafe.ToSafeInt32(row["Achievment"]);
                    item.Target = MakeSafe.ToSafeInt32(row["Target"]);
                    item.AbsoluteVariance = MakeSafe.ToSafeInt32(row["Variance (Absolute)"]);
                    item.Variance = MakeSafe.ToSafeDecimal(row["Variance (%)"]);


                    List.Add(item);
                }
                model.List = List;
            }


            if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {

                    model.PendingCount = MakeSafe.ToSafeInt32(row["Count"]);

                }
            }
            return model;
        }


        public async Task<DataSet> GetDetails(UserBase userBase, int months, int IncentiveGroups, int Region, int Parameters, int empCode)
        {
            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",userBase.CompanyGuid),
                new SqlParameter("@UserGI",userBase.UserGuid),
                new SqlParameter("@MonthCode",months),
                new SqlParameter("@IncentiveGroupCode",IncentiveGroups),
                 new SqlParameter("@RegionCode",Region),
                  new SqlParameter("@ParameterCode",Parameters),
                   new SqlParameter("@EmpCode",empCode),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_TARGET_ACHIEVMENT_REPORT_DETAIL]", sqlparameters);
            return ds;
        }




    }
}
