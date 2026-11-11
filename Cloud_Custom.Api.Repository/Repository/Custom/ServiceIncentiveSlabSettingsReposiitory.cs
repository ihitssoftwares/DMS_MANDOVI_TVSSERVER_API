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
 public   class ServiceIncentiveSlabSettingsReposiitory : IServiceIncentiveSlabSettingsRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public ServiceIncentiveSlabSettingsReposiitory(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<ServiceIncentiveSlabSettings> GetList(UserBase user, string Branch, string Designation, string WEFDate)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                new SqlParameter("@Branch",Branch),
                new SqlParameter("@Designation",Designation),
                new SqlParameter("@WEFDate",WEFDate),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_INCENTIVE_SLAB_SETTING]", sqlparameters);

            return PopulateGetList(ds);

        }
        public ServiceIncentiveSlabSettings PopulateGetList(DataSet ds)
        {
            ServiceIncentiveSlabSettings model = new ServiceIncentiveSlabSettings();
            model.ServiceIncentiveList = new List<ServiceIncentiveSlabSettings>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new ServiceIncentiveSlabSettings
                    {

                        Branch = MakeSafe.ToSafeString(row["Location"]),

                        ParameterCode = MakeSafe.ToSafeInt32(row["ParameterCode"]),
                        Parameter = MakeSafe.ToSafeString(row["Parameter"]),
                        Target = MakeSafe.ToSafeString(row["Target"]),
                        Slab = MakeSafe.ToSafeString(row["Slab"]),
                        incentive = MakeSafe.ToSafeString(row["Incentive"]),
                       

                    };

                    model.ServiceIncentiveList.Add(item);
                }
            }

            return model;
        }
        public async Task<SlabItem> GetParameterDetails(UserBase user, int ParameterCode)

        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                new SqlParameter("@ParameterCode",ParameterCode),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_INCENTIVE_SLAB_SETTING_DETAILS]", sqlparameters);

            return PopulateGetParameterDetails(ds);

        }
        public SlabItem PopulateGetParameterDetails(DataSet ds)
        {

            SlabItem model = new SlabItem();
            model.slabList = new List<SlabItem>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                var item = new SlabItem
                {

                   
                    BranchCode = MakeSafe.ToSafeInt32(row["BranchCode"]),
                    Branch = MakeSafe.ToSafeString(row["BranchName"]),
                    Target = MakeSafe.ToSafeString(row["Target"]),
                    DesignationCode= MakeSafe.ToSafeInt32(row["DesignationCode"]),
                    ParameterCode=MakeSafe.ToSafeInt32(row["ParameterCode"]),
                    SlabFrom = MakeSafe.ToSafeString(row["SlabFrom"]),
                    SlabTo = MakeSafe.ToSafeString(row["SlabTo"]),
                    Incentive = MakeSafe.ToSafeString(row["Incentive"]),
                    Applicablity = MakeSafe.ToSafeBool(row["Applicability"]), 
                    


                };
                model.slabList.Add(item);
            }

            return model;
        }

        public async Task<ResponseEntity> ServiceSave(UserBase user, ServiceIncentiveSlabSettings model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_SERVICE_INCENTIVE_SETTING_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
    }
}
