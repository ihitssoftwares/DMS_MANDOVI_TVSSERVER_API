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
    public class ServicePreprocessingRepository : IServicePreprocessingRepository
    {
        private readonly ISqlConnectionProvider _sql;


        public ServicePreprocessingRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;

        }



        public async Task<ServicePreprocessing> GetProcessList(UserBase userBase, int MonthCode, int Region)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                {
                    new SqlParameter("@CompanyGI",userBase.CompanyGuid),
                    new SqlParameter("@UserGuid",userBase.UserGuid),
                    new SqlParameter("@MonthCode",MonthCode),
                    new SqlParameter("@RegionCode",Region),
                   

                };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_INCENTIVE_PREPROCESS_ACHIEVMENT]", sqlparameters);
                return ParameterList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        public async Task<ResponseEntity> GetProcess(UserBase userBase, int MonthCode, int Region)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {       new SqlParameter("@CompanyGI",userBase.CompanyGuid),
                    new SqlParameter("@UserGuid",userBase.UserGuid),
                    new SqlParameter("@MonthCode",MonthCode),
                    new SqlParameter("@regionCode",Region),

                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_SERVICE_INCENTIVE_PREPROCESS_ACHIEVMENT]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }



        private ServicePreprocessing ParameterList(DataSet dataSet)
        {
            ServicePreprocessing model = new ServicePreprocessing();
            List<ServicePreprocessing> List = new List<ServicePreprocessing>();
            List<ServicePreprocessing> List2 = new List<ServicePreprocessing>();

            //if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            //{
            //    foreach (DataRow row in dataSet.Tables[0].Rows)
            //    {
            //        var item = new ServicePreprocessing();



            //        item.EmployeeCode = MakeSafe.ToSafeInt32(row["EmployeeCode"]);
            //        item.Employee = MakeSafe.ToSafeString(row["Employee"]);
            //        item.Branch = MakeSafe.ToSafeString(row["Branch"]);
            //        item.IncentiveGroup = MakeSafe.ToSafeString(row["IncentiveGroup"]);
            //        item.TotalIncentive = MakeSafe.ToSafeDecimal(row["TotalIncentive"]);






            //        List.Add(item);
            //    }
            //    if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            //    {
            //        foreach (DataRow row in dataSet.Tables[1].Rows)
            //        {
            //            var item = new ServicePreprocessing();

            //            item.Target = MakeSafe.ToSafeInt32(row["Target"]);
            //            item.Employee = MakeSafe.ToSafeString(row["Employee"]);
            //            item.Branch = MakeSafe.ToSafeString(row["Branch"]);
            //            item.Parameter = MakeSafe.ToSafeString(row["Parameter"]);
            //            item.IncentiveGroup = MakeSafe.ToSafeString(row["IncentiveGroup"]);
            //            item.ParameterType = MakeSafe.ToSafeString(row["ParameterType"]);
            //            item.Achievment = MakeSafe.ToSafeInt32(row["Achievment"]);
            //            item.IncentiveAmount = MakeSafe.ToSafeDecimal(row["IncentiveAmount"]);
            //            item.TotalIncentive = MakeSafe.ToSafeDecimal(row["TotalIncentive"]);
            //            item.Slab = MakeSafe.ToSafeString(row["Slab"]);
            //            item.Incentive = MakeSafe.ToSafeString(row["Incentive"]);

            //            List2.Add(item);
            //        }
            //    }


            //    model.List2 = List2;
            //    model.List1 = List;
            //}



            return model;
        }
    }
}
