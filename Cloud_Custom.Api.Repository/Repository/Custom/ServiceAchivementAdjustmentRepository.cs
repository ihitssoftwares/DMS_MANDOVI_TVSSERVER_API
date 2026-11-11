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
    public class ServiceAchivementAdjustmentRepository : IServiceAchivementAdjustmentRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public ServiceAchivementAdjustmentRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }

        public async Task<ServiceAchivementAdjustment> GetList(UserBase user, int Month, int IncentiveGroup, int BranchCode, int Parameter)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Month",Month),
                 new SqlParameter("@IncentiveGroupCode",IncentiveGroup),
                 new SqlParameter("@BranchCode",BranchCode),
                 new SqlParameter("@Parameter",Parameter),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_ACHIEVMENT_ADJUSTMENT_LIST]", sqlparameters);
                return DesignationVsParameterList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private ServiceAchivementAdjustment DesignationVsParameterList(DataSet dataSet)
        {
            ServiceAchivementAdjustment model = new ServiceAchivementAdjustment();
            List<ServiceAchivementAdjustment> List = new List<ServiceAchivementAdjustment>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new ServiceAchivementAdjustment();



                    item.Employecode = MakeSafe.ToSafeInt32(row["Employecode"]);
                    item.EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]);
                    item.ParameterCode = MakeSafe.ToSafeInt32(row["ParameterCode"]);
                    item.ParameterName = MakeSafe.ToSafeString(row["ParameterName"]);
                    item.IncentiveGroupCode = MakeSafe.ToSafeInt32(row["IncentiveGroupCode"]);
                    item.AchievmentOriginal = MakeSafe.ToSafeDecimal(row["AchievmentOriginal"]);
                    item.AchievmentActual = MakeSafe.ToSafeDecimal(row["AchievmentActual"]);
                    item.SlabType = MakeSafe.ToSafeString(row["SlabType"]);
                    item.Target = MakeSafe.ToSafeInt32(row["Target"]);
                    item.IncentiveSlab = MakeSafe.ToSafeString(row["IncentiveSlab"]);
                    item.branchcode = MakeSafe.ToSafeInt32(row["branchcode"]);
                    item.monthcode = MakeSafe.ToSafeInt32(row["monthcode"]);


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




        public async Task<ResponseEntity> SettingsSave(UserBase User, ServiceAchivementAdjustment model, int ParameterCode, int IncentiveGroupCode, int monthcode, int Employecode, decimal ActualValue)
        {
            try
            {
                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 250, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
                IDbDataParameter[] sqlParameters =
                {
                    new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                    new SqlParameter("@CompanyGI",User.CompanyGuid),
                    new SqlParameter("@UserGI",User.UserGuid),
                    new SqlParameter("@ParameterCode",ParameterCode),
                     new SqlParameter("@IncentiveGroupCode",IncentiveGroupCode),
                      new SqlParameter("@monthcode",monthcode),
                       new SqlParameter("@Employecode",Employecode),
                        new SqlParameter("@ActualValue",ActualValue),
            ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_SERVICE_ACHIEVMENT_ADJUSTMENT_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException EX)
            {
                var ErrorMsg = EX.Message.ToString();
                throw new Exception(ErrorMsg, EX);
            }
        }







    }
}
