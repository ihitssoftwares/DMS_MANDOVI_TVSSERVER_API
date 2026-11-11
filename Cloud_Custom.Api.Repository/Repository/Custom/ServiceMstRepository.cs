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
    public class ServiceMstRepository : IServiceMstRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public ServiceMstRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<ServiceMst> GetList(UserBase user,int isAssigned)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@isAssigned",isAssigned),
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_LIST]", sqlparameters);
                return ServiceList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private ServiceMst ServiceList(DataSet dataSet)
        {
            ServiceMst model = new ServiceMst();
            List<ServiceMst> List = new List<ServiceMst>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new ServiceMst();
                    
                    item.Group = new Dropdown();
                    item.Category = new Dropdown();

                    item.ServiceCode = MakeSafe.ToSafeInt32(row["ServiceCode"]);
                    item.Name = MakeSafe.ToSafeString(row["Name"]);
                   
                    item.Group.Code = MakeSafe.ToSafeInt32(row["ServiceGroupCode"]);
                    item.Group.Name = MakeSafe.ToSafeString(row["ServiceGroupName"]);
                    item.Category.Code = MakeSafe.ToSafeInt32(row["CategoryCode"]);
                    item.Category.Name = MakeSafe.ToSafeString(row["CategoryName"]);

                    
                    //item.BSLabour = MakeSafe.ToSafeBool(row["BodyShopLabour"]);
                    //item.SLabour = MakeSafe.ToSafeBool(row["ServiceLabour"]);

                    List.Add(item);
                }
                model.List = List;
            }
            return model;

        }

        public async Task<ServiceMst> GetPopupDetails(UserBase user, int ServiceCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                  new SqlParameter("@ServiceCode",ServiceCode),


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICEPOPUP_LIST]", sqlparameters);
                return PopupDetails(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private ServiceMst PopupDetails(DataSet dataSet)
        {
            ServiceMst model = new ServiceMst();

            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];


                model.Group = new Dropdown();
                model.Category = new Dropdown();

                model.ServiceCode = MakeSafe.ToSafeInt32(row["ServiceCode"]);
                model.Name = MakeSafe.ToSafeString(row["Name"]);
                
                model.Group.Code = MakeSafe.ToSafeInt32(row["GroupCode"]);
                model.Group.Name = MakeSafe.ToSafeString(row["GroupName"]);

                model.Category.Code = MakeSafe.ToSafeInt32(row["CategoryCode"]);
                model.Category.Name = MakeSafe.ToSafeString(row["CategoryName"]);
                //model.BSLabour = MakeSafe.ToSafeBool(row["BodyShopLabour"]);
                //model.SLabour = MakeSafe.ToSafeBool(row["ServiceLabour"]);

            }

            return model;

        }

        public async Task<ResponseEntity> PopupSave(UserBase user, ServiceMst model)
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
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_SERVICEPOPUP_SAVE]", sqlParameters, CommandType.StoredProcedure);
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
