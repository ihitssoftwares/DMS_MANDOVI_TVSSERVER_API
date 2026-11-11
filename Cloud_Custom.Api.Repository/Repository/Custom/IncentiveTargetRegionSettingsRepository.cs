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
    public class IncentiveTargetRegionSettingsRepository : IIncentiveTargetRegionSettingsRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public IncentiveTargetRegionSettingsRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }




        public async Task<IncentiveTargetRegionSettings> GetList(UserBase user, int EmployeeCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@EmployeeCode",EmployeeCode),


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_TARGET_INCENTIVE_REGION_SETTINGS_LIST]", sqlparameters);
                return DesignationVsParameterList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private IncentiveTargetRegionSettings DesignationVsParameterList(DataSet dataSet)
        {
            IncentiveTargetRegionSettings model = new IncentiveTargetRegionSettings();
            List<IncentiveTargetRegionSettings> List = new List<IncentiveTargetRegionSettings>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new IncentiveTargetRegionSettings();



                    item.EmployeeCode = MakeSafe.ToSafeInt32(row["EmployeeCode"]);
                    item.EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]);
                    item.BranchName = MakeSafe.ToSafeString(row["BranchName"]);
                    item.RegionName = MakeSafe.ToSafeString(row["RegionName"]);
                    item.BranchCode = MakeSafe.ToSafeInt32(row["BranchCode"]);
                    item.RegionCode = MakeSafe.ToSafeInt32(row["RegionCode"]);



                    List.Add(item);
                }
                model.List = List;
            }


            //if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            //{

            //    model.Regions = new int[dataSet.Tables[1].Rows.Count];
            //    //model.LocationName = new string[dataSet.Tables[1].Rows.Count];


            //    int i = 0;
            //    foreach (DataRow row in dataSet.Tables[1].Rows)
            //    {


            //        model.Regions[i] = MakeSafe.ToSafeInt32(row["RegionCode"]);
            //        //model.LocationName[i] = MakeSafe.ToSafeString(row["LocationName"]);
            //        i++;


            //    }
            //}
            return model;
        }











        public async Task<ResponseEntity> IncentiveSettingsSave(UserBase user, IncentiveTargetRegionSettings model, int TLEmployeeCode)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                     new SqlParameter("@TLEmployeeCode",TLEmployeeCode),
                     new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_INCENTIVE_TARGET_REGIONS_SETTINGS_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }




        public async Task<IncentiveTargetRegionSettings> GetDetails(UserBase user, int EmployeeCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@EmployeeCode",EmployeeCode),


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_TARGET_INCENTIVE_REGION_SETTINGS_DETAILS]", sqlparameters);
                return BranchSeletcedList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private IncentiveTargetRegionSettings BranchSeletcedList(DataSet dataSet)
        {
            IncentiveTargetRegionSettings model = new IncentiveTargetRegionSettings();
            List<IncentiveTargetRegionSettings> BranchList = new List<IncentiveTargetRegionSettings>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new IncentiveTargetRegionSettings();



                    
                    item.RegionName = MakeSafe.ToSafeString(row["RegionName"]);
                    item.RegionCode = MakeSafe.ToSafeInt32(row["RegionCode"]);
                    item.IsApplicable = MakeSafe.ToSafeBool(row["Applicability"]);




                    BranchList.Add(item);
                }
                model.List = BranchList;
            }



            return model;
        }



    }
}
