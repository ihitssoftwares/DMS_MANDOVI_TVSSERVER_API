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
    public class LoadDataUpdateRepository : ILoadDataUpdateRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public LoadDataUpdateRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }

        public async Task<LoadDataUpdate> GetList(UserBase user, string TabIndex)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@TabIndex",TabIndex),



            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_LOAD_UPDATE_SERVICE_LOCATION_LIST]", sqlparameters);
                return DesignationVsParameterList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }


        private LoadDataUpdate DesignationVsParameterList(DataSet dataSet)
        {
            LoadDataUpdate model = new LoadDataUpdate();
            List<LoadDataUpdate> List = new List<LoadDataUpdate>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new LoadDataUpdate();


                    item.ServiceLocationUpdateOrder = MakeSafe.ToSafeInt32(row["ServiceLocationUpdateOrder"]);
                    item.ServiceLocation = MakeSafe.ToSafeString(row["ServiceLocation"]);
                    item.UpdatedUser = MakeSafe.ToSafeString(row["UpdatedUser"]);
                    item.ServiceLocationUpdateTime = MakeSafe.ToSafeString(row["ServiceLocationUpdateTime"]);
                    item.Branch = MakeSafe.ToSafeString(row["Branch"]);
                    item.ServiceLocationCode = MakeSafe.ToSafeInt32(row["ServiceLocationCode"]);
                    item.ServiceAdvisor = MakeSafe.ToSafeString(row["ServiceAdvisor"]);
                    item.ServiceAdvisorUpdateOrder = MakeSafe.ToSafeInt32(row["ServiceAdvisorUpdateOrder"]);
                    item.ServiceAdvisorEmployeeCode = MakeSafe.ToSafeInt32(row["ServiceAdvisorEmployeeCode"]);
                    item.EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]);
                    item.ServiceAdvisorUpdateTime = MakeSafe.ToSafeString(row["ServiceAdvisorUpdateTime"]);
                    item.UpdatedBranchName = MakeSafe.ToSafeString(row["UpdatedBranchName"]);
                    item.Technician = MakeSafe.ToSafeString(row["Technician"]);
                    item.TechnicianUpdateOrder = MakeSafe.ToSafeInt32(row["TechnicianUpdateOrder"]);
                    item.TechnicianEmployeeCode = MakeSafe.ToSafeInt32(row["TechnicianEmployeeCode"]);
                    item.TechnicianUpdateTime = MakeSafe.ToSafeString(row["TechnicianUpdateTime"]);
                    item.EmployeeId = MakeSafe.ToSafeString(row["EmployeeId"]);
                    item.MSPin = MakeSafe.ToSafeString(row["MSPin"]);
                    item.IncentiveGroup = MakeSafe.ToSafeString(row["IncentiveGroup"]);



                    List.Add(item);
                }
                model.List = List;
            }



            return model;
        }



        public async Task<LoadDataUpdate> GetTabList(UserBase user, string TabIndex)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                  new SqlParameter("@Type",TabIndex)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_PROFIT_MARGIN_INSURANCE_FINANACE_LIST]", sqlparameters);
                return SalesPositionList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private LoadDataUpdate SalesPositionList(DataSet dataSet)
        {
            LoadDataUpdate model = new LoadDataUpdate();
            List<LoadDataUpdate> List = new List<LoadDataUpdate>();

            //if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            //{
            //    foreach (DataRow row in dataSet.Tables[0].Rows)
            //    {
            //        var item = new LoadDataUpdate();


            //        item.Code = MakeSafe.ToSafeInt32(row["Code"]);
            //        item.Name = MakeSafe.ToSafeString(row["Name"]);
            //        item.Commission = MakeSafe.ToSafeInt32(row["commission"]);



            //        List.Add(item);
            //    }
            //    model.List = List;
            //}
            return model;

        }



        public async Task<ResponseEntity> SettingsSave(UserBase User, LoadDataUpdate model, int VechicleModel)
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
                    new SqlParameter("@VechicleModel",VechicleModel),
            ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_PROFIT_MARGIN_EXTENDED_WARRANTY_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException EX)
            {
                var ErrorMsg = EX.Message.ToString();
                throw new Exception(ErrorMsg, EX);
            }
        }



        public async Task<ResponseEntity> SavePopup(UserBase User, int BranchCode, string Name, int EmployeeCode, string Tabindex,int Technicianemployee)
        {
            try
            {
                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 250, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
                IDbDataParameter[] sqlParameters =
                {
                    
                    new SqlParameter("@CompanyGI",User.CompanyGuid),
                    new SqlParameter("@UserGI",User.UserGuid),
                    new SqlParameter("@BranchCode",BranchCode),
                     new SqlParameter("@UpdateEmployeeCode",EmployeeCode),
                     new SqlParameter("@Name",Name),
                     new SqlParameter("@Tabindex",Tabindex),
                     new SqlParameter("@Technicianemployee",Technicianemployee),
            ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_DATA_UPLOAD_UPDATE_SAVE]", sqlParameters, CommandType.StoredProcedure);
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
