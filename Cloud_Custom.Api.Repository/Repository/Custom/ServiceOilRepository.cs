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
    public class ServiceOilRepository : IServiceOilRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public ServiceOilRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<ServiceOil> GetList(UserBase user, int isAssigned)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@isAssigned",isAssigned),
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICEOIL_LIST]", sqlparameters);
                return ServiceOilList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private ServiceOil ServiceOilList(DataSet dataSet)
        {
            ServiceOil model = new ServiceOil();
            List<ServiceOil> List = new List<ServiceOil>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new ServiceOil();

                    item.Group = new Dropdown();

                    item.ServiceOilCode = MakeSafe.ToSafeInt32(row["ServiceOilCode"]);
                    item.Name = MakeSafe.ToSafeString(row["Name"]);

                    item.Group.Code = MakeSafe.ToSafeInt32(row["ServiceOilGroupCode"]);
                    item.Group.Name = MakeSafe.ToSafeString(row["ServiceOilGroupName"]);
                    //item.BSLabour = MakeSafe.ToSafeBool(row["BodyShopLabour"]);
                    //item.SLabour = MakeSafe.ToSafeBool(row["ServiceLabour"]);

                    List.Add(item);
                }
                model.List = List;
            }
            return model;

        }

        public async Task<ServiceOil> GetPopupDetails(UserBase user, int ServiceOilCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                  new SqlParameter("@ServiceOilCode",ServiceOilCode),


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICEOILPOPUP_LIST]", sqlparameters);
                return PopupDetails(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private ServiceOil PopupDetails(DataSet dataSet)
        {
            ServiceOil model = new ServiceOil();

            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];


                model.Group = new Dropdown();


                model.ServiceOilCode = MakeSafe.ToSafeInt32(row["ServiceOilCode"]);
                model.Name = MakeSafe.ToSafeString(row["Name"]);

                model.Group.Code = MakeSafe.ToSafeInt32(row["GroupCode"]);
                model.Group.Name = MakeSafe.ToSafeString(row["GroupName"]);

                //model.BSLabour = MakeSafe.ToSafeBool(row["BodyShopLabour"]);
                //model.SLabour = MakeSafe.ToSafeBool(row["ServiceLabour"]);

            }

            return model;

        }

        public async Task<ResponseEntity> PopupSave(UserBase user, ServiceOil model)
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
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_SERVICEOILPOPUP_SAVE]", sqlParameters, CommandType.StoredProcedure);
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
