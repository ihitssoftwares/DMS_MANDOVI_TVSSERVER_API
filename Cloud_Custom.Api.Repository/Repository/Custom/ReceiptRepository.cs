using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.Repository.Custom
{
  public   class ReceiptRepository : IReceiptRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public ReceiptRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<Receipt> GetList(UserBase user, string TabIndex)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@TabIndex",TabIndex),

            };
                var ds = await _sql.GetDataSetAsync("[MCARE].[MCARE_RECEIPT_PRINT]", sqlparameters);
                return SummeryList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private Receipt SummeryList(DataSet ds)
        {
            Receipt model = new Receipt();
            List<Receipt> List = new List<Receipt>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new Receipt();



                    item.RegEntryCode = MakeSafe.ToSafeInt32(row["RegistrationEntryCode"]);
                    item.EntryNo = MakeSafe.ToSafeString(row["EntryNo"]);
                    item.RegDate = MakeSafe.ToSafeDateTime(row["RegistrationDate"]);
                    item.PlaneName = MakeSafe.ToSafeString(row["PlanName"]);
                    item.PackageDuration = MakeSafe.ToSafeString(row["PackageDuration"]);
                    item.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);

                    item.Phone = MakeSafe.ToSafeString(row["Phone"]);
                    item.VehicleRegNo = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]);
                    item.Model = MakeSafe.ToSafeString(row["Model"]);
                    item.Variant = MakeSafe.ToSafeString(row["Variant"]);
                   
                    item.ChassisNo = MakeSafe.ToSafeString(row["ChassisNo"]);
                    item.EngineNo = MakeSafe.ToSafeString(row["EngineNo"]);
                    item.PlaneAmount = MakeSafe.ToSafeInt32(row["PlanAmount"]);
                    item.StartDate = MakeSafe.ToSafeDateTime(row["StartDate"]);
                    item.EndDate = MakeSafe.ToSafeDateTime(row["EndDate"]);
                    item.Status = MakeSafe.ToSafeString(row["Status"]);

                    List.Add(item);
                }
                model.List = List;
            }

            return model;

        }

 
        public async Task<JObject> ReceiptJSON(string RegGi, int RegCode)
        {
            IDbDataParameter[] sqlparameters =
        {
                 new SqlParameter("@RegGi",RegGi),
                new SqlParameter("@RegCode",RegCode),


            };

            var ds = await _sql.ExecuteJsonAsync("[MCARE].[SP_GET_MCARE_RECEIPT]", sqlparameters);
            return ds;
            //return PopulatePaySlip(ds);

        }

        public async Task<ResponseEntity> Save(UserBase user, Receipt input)
        {
            try
            {

                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@JSONDATA",JsonHelper.ToJson(input)),
                    ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[MCARE].[SP_RECEIPT_SAVE]", sqlParameters, CommandType.StoredProcedure);
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
