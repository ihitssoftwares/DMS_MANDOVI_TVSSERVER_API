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
    public class ServiceAccessoriesRepository : IServiceAccessoriesRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public ServiceAccessoriesRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<ServiceAccessories> GetList(UserBase user, int isAssigned)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@isAssigned",isAssigned),
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVIVESACCESSORIES_LIST]", sqlparameters);
                return AccessoriesList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private ServiceAccessories AccessoriesList(DataSet dataSet)
        {
            ServiceAccessories model = new ServiceAccessories();
            List<ServiceAccessories> List = new List<ServiceAccessories>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new ServiceAccessories();
                   
                    item.Group = new Dropdown();

                    item.AccessoriesCode = MakeSafe.ToSafeInt32(row["AccessoriesCode"]);
                    item.Name = MakeSafe.ToSafeString(row["Name"]);
                    
                    item.Group.Code = MakeSafe.ToSafeInt32(row["ServiceAccessoriesGroupCode"]);
                    item.Group.Name = MakeSafe.ToSafeString(row["ServiceAccessoriesGroupName"]);
                   
                    List.Add(item);
                }
                model.List = List;
            }
            return model;

        }

        public async Task<ServiceAccessories> GetPopupDetails(UserBase user, int AccessoriesCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                  new SqlParameter("@AccessoriesCode",AccessoriesCode),


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVIVEACCESSORIESPOPUP_LIST]", sqlparameters);
                return PopupDetails(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private ServiceAccessories PopupDetails(DataSet dataSet)
        {
            ServiceAccessories model = new ServiceAccessories();

            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];


                model.Group = new Dropdown();
               

                model.AccessoriesCode = MakeSafe.ToSafeInt32(row["ServiceAccessoriesCode"]);
                model.Name = MakeSafe.ToSafeString(row["Name"]);
               
                model.Group.Code = MakeSafe.ToSafeInt32(row["GroupCode"]);
                model.Group.Name = MakeSafe.ToSafeString(row["GroupName"]);

                
            }

            return model;

        }

        public async Task<ResponseEntity> PopupSave(UserBase user, ServiceAccessories model)
        {
            try
            {

                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 200, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                // new SqlParameter("@Mode",mode),
                    ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_SERVICEACCESSORIESPOPUP_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
    }
}
