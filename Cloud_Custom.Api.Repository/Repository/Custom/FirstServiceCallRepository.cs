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
     public class FirstServiceCallRepository : IFirstServiceCallRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public FirstServiceCallRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<FirstServiceCall> GetList(UserBase user, int ServiceCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@ServiceCode",ServiceCode),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_FIRST_SERVICE_CALL_LIST]", sqlparameters);
                return FirstServiceCallList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private FirstServiceCall FirstServiceCallList(DataSet dataSet)
        {
            FirstServiceCall model = new FirstServiceCall();
            List<FirstServiceCall> List = new List<FirstServiceCall>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {


                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new FirstServiceCall();

                    item.RegistrationCode = MakeSafe.ToSafeInt32(row["RegistrationCode"]);
                    item.OrdertrnCode = MakeSafe.ToSafeInt32(row["OrderTrnCode"]);
                    item.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                    item.Address = MakeSafe.ToSafeString(row["Address"]);
                    item.MobileNo = MakeSafe.ToSafeString(row["MobileNo"]);
                    item.Model = MakeSafe.ToSafeString(row["ModeName"]);
                    item.Varient = MakeSafe.ToSafeString(row["VariantName"]);
                    item.ColorName = MakeSafe.ToSafeString(row["ColorName"]);
                    item.VehicleNo = MakeSafe.ToSafeString(row["VehicleNo"]);
                    item.TransmissionName = MakeSafe.ToSafeString(row["TransmissionTypeName"]);
                    item.FuelName = MakeSafe.ToSafeString(row["FuelTypeName"]);
                    item.EngineNo = MakeSafe.ToSafeString(row["EngineNo"]);
                    item.ChasisNo = MakeSafe.ToSafeString(row["ChassisNo"]);
                    item.NextServicedate = MakeSafe.ToSafeString(row["NextServiceDate"]);
                    item.Deliverydate = MakeSafe.ToSafeString(row["DeliveryDate"]);
                    List.Add(item);
                }

                model.List = List;
            }

            return model;
        }
        public async Task<FirstServiceCall> GetDetails(UserBase User, int RegistrationCode, int OrdertrnCode)
        {

            IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@RegistrationCode",RegistrationCode),
                new SqlParameter("@OrdertrnCode",OrdertrnCode),


            };
            var dataSet = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_CALL_HISTORY_DETAILS]", sqlParameters);
            return PopulateFirstServiceCall(dataSet);

        }

        private FirstServiceCall PopulateFirstServiceCall(DataSet dataSet)
        {
            FirstServiceCall model = new FirstServiceCall();
            List<FirstServiceCall> List = new List<FirstServiceCall>();
            model.CallAttempt = new Dropdown();
            model.CallStatus = new Dropdown();
            model.CallBy = new Dropdown();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {


                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new FirstServiceCall();

                    item.RegistrationCode = MakeSafe.ToSafeInt32(row["RegistrationCode"]);
                    item.Attempt = MakeSafe.ToSafeInt32(row["CallAttempt"]);
                    item.Status = MakeSafe.ToSafeString(row["CallStatus"]);
                    item.ServiceScheduleDate = MakeSafe.ToSafeString(row["ServiceScheduleDate"]);
                    item.ServiceScheduleTime = MakeSafe.ToSafeString(row["ServiceScheduleTime"]);
                    item.Location = MakeSafe.ToSafeString(row["Location"]);
                    item.EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]);
                    item.CallDate = MakeSafe.ToSafeString(row["CallDate"]);
                    List.Add(item);
                }

                model.List = List;
            }

            return model;
        }
        public async Task<ResponseEntity> Save(UserBase user, FirstServiceCall model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
               new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_SERVICE_CALL_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }

    }
}
