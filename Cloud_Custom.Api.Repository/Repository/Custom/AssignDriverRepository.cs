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
    public class AssignDriverRepository : IAssignDriverRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public AssignDriverRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }

        public async Task<AssignDriver> GetList(UserBase user, int BranchCode, DateTime PreferredDate, int isAssigned)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI", user.CompanyGuid),
                 new SqlParameter("@UserGuid", user.UserGuid),
                 new SqlParameter("@BranchCode", BranchCode),
                  new SqlParameter("@PreferredDate", PreferredDate),
                   new SqlParameter("@isAssigned", isAssigned),



            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_ASSIGNDRIVER_LIST]", sqlparameters);
                return AssignDriverList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private AssignDriver AssignDriverList(DataSet dataSet)
        {
            AssignDriver model = new AssignDriver();
            List<AssignDriver> List = new List<AssignDriver>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    AssignDriver item = new AssignDriver();

                    item.BookingCode = MakeSafe.ToSafeInt32(row["BookingCode"]);
                    item.BookingNumber = MakeSafe.ToSafeString(row["BookingNo"]);
                    item.BookingDate = MakeSafe.ToSafeDateTime(row["BookingDate"]);
                    item.CustomerCode = MakeSafe.ToSafeInt32(row["CustomerCode"]);
                    item.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                    item.MobileNumber = MakeSafe.ToSafeString(row["MobileNo"]);
                    item.RegistrationNumber = MakeSafe.ToSafeString(row["RegistrationNo"]);
                  
                    item.Model = MakeSafe.ToSafeString(row["Model"]);
                    item.ServiceDueType = MakeSafe.ToSafeString(row["ServiceDueType"]);
                    item.ServiceTypeName = MakeSafe.ToSafeString(row["ServiceType"]);
                
                    item.PickUpAddress = MakeSafe.ToSafeString(row["PickupAddress"]);
                    item.PreferredDate = MakeSafe.ToSafeDateTime(row["PreferredDate"]);
                    item.PreferredTimeSlot = MakeSafe.ToSafeString(row["PreferredTimeSlot"]);
                    item.DriverName = MakeSafe.ToSafeString(row["DriverName"]);





                    List.Add(item);
                }
                model.List = List;
            }

            return model;
        }

        public async Task<AssignDriver> GetCustomerList(UserBase user, int CustomerCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                  new SqlParameter("@CustomerCode",CustomerCode),


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_ASSIGNDRIVERPOPUP_LIST]", sqlparameters);
                return PopupCustomerlist(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private AssignDriver PopupCustomerlist(DataSet dataSet)
        {
            AssignDriver model = new AssignDriver();
            List<AssignDriver> CustomerList = new List<AssignDriver>();
          

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new AssignDriver();




                    item.DriverList = new Dropdown();

                    item.CustomerCode= MakeSafe.ToSafeInt32(row["CustomerCode"]);
                    item.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                    item.PickUpAddress = MakeSafe.ToSafeString(row["PickupAddress"]);
                    item.PreferredDate = MakeSafe.ToSafeDateTime(row["PreferredDate"]);

                    item.PreferredTimeSlot = MakeSafe.ToSafeString(row["PreferredTimeSlot"]);
                  
                    item.DriverList.Code = MakeSafe.ToSafeInt32(row["DriverCode"]);
                    item.DriverList.Name = MakeSafe.ToSafeString(row["DriverName"]);






                    CustomerList.Add(item);
                }
                model.List = CustomerList;
            }
            return model;

        }


        public async Task<ResponseEntity> PopupSave(UserBase user, AssignDriver model,int empcode)
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
                  new SqlParameter("@empcode",empcode),

                // new SqlParameter("@Mode",mode),
                    ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_ASSIGNDRIVERPOPUP_SAVE]", sqlParameters, CommandType.StoredProcedure);
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
