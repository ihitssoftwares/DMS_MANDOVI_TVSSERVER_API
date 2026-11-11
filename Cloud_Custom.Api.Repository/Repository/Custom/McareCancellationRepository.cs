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
  public  class McareCancellationRepository : IMcareCancellationRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public McareCancellationRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<McareCancellation> GetList(UserBase user,int PlanCode,int EntryCode)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@PlanCode",PlanCode),
                new SqlParameter("@EntryCode",EntryCode),


            };
            var ds = await _sql.GetDataSetAsync("[MCARE].[MCARE_CANCELLATION_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }
        public McareCancellation PopulateGetList(DataSet ds)
        {
            McareCancellation model = new McareCancellation();
            model.CancellationList = new List<McareCancellation>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new McareCancellation
                    {

                        RegistrationEntryCode = MakeSafe.ToSafeInt32(row["RegistrationEntryCode"]),
                        EntryNo = MakeSafe.ToSafeString(row["EntryNo"]),
                        RegistrationDate = MakeSafe.ToSafeString(row["RegistrationDate"]),
                        PlanName = MakeSafe.ToSafeString(row["PlanName"]),
                        PackageDuration = MakeSafe.ToSafeString(row["PackageDuration"]),
                        CustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
                        Phone = MakeSafe.ToSafeString(row["Phone"]),
                        VehicleRegistrationNumber = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]),
                        Model = MakeSafe.ToSafeString(row["Model"]),
                        Variant = MakeSafe.ToSafeString(row["Variant"]),
                        Colour = MakeSafe.ToSafeString(row["Colour"]),
                        ChassisNo = MakeSafe.ToSafeString(row["ChassisNo"]),
                        EngineNo = MakeSafe.ToSafeString(row["EngineNo"]),
                        PlanAmount = MakeSafe.ToSafeDecimal(row["PlanAmount"]),
                        StartDate = MakeSafe.ToSafeString(row["StartDate"]),
                        EndDate = MakeSafe.ToSafeString(row["EndDate"]),
                        BenefitUtilized = MakeSafe.ToSafeString(row["BenefitUtilized"]),
                        CancellationEligibility = MakeSafe.ToSafeString(row["CancellationEligibility"]),
                        RefundPercentage = MakeSafe.ToSafeInt32(row["RefundPercentage"]),
                        RefundAmount = MakeSafe.ToSafeDecimal(row["RefundAmount"])

                    };

                    model.CancellationList.Add(item);
                }
            }

            return model;
        }
        public async Task<ResponseEntity> Save(UserBase user, McareCancellation model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[MCARE].[SP_MCARE_CANCELLATION_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }

    }
}
