using Cloud_Custom.Api.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Cloud_Custom.Api.Repository.IRepository.MobileApp;
using Cloud_Custom.Api.Shared.MobileApp;

namespace Cloud_Custom.Api.Repository.Repository.MobileApp
{
    public class ColdCallEnquireDetailsRepository : IColdCallEnqiureDetailsRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public ColdCallEnquireDetailsRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<ResponseEntity> Save(UserBase user, ColdCallEnquireDetails model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[MOBILE].[SP_DMS_SAVE_COLD_CALL_ENQUIRY_DETAILS]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }

        //public async Task<ColdCallEnquireDetails> GetList(UserBase user)
        //{

        //    IDbDataParameter[] sqlparameters =
        //   {
        //        new SqlParameter("@CompanyGI",user.CompanyGuid),
        //        new SqlParameter("@UserGuid",user.UserGuid),


        //    };
        //    var ds = await _sql.GetDataSetAsync("[MOBILE].[SP_COLD CALL_ENQUIRE_HISTORY_LIST]", sqlparameters);

        //    return PopulateGetList(ds);

        //}
        //public ColdCallEnquireDetails PopulateGetList(DataSet ds)
        //{
        //    ColdCallEnquireDetails model = new ColdCallEnquireDetails();
        //    model.ColdCallEnquireList = new List<ColdCallEnquireDetails>();
           
        //    if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
        //    {
        //        foreach (DataRow row in ds.Tables[0].Rows)

        //        {
          
        //            var item = new ColdCallEnquireDetails
        //            {
                       

        //                EnqTrnCode = MakeSafe.ToSafeInt32(row["LeadTrnCode"]),
        //                LeadTrnCode = MakeSafe.ToSafeInt32(row["LeadTrnCode"]),
        //                CustomerName = MakeSafe.ToSafeString(row["Name"]),
        //                Mobilno = MakeSafe.ToSafeString(row["MobileNo"]),
        //                EmailId = MakeSafe.ToSafeString(row["EmailID"]),
        //                Variant = new Dropdown{  Name = MakeSafe.ToSafeString(row["Variant"])},
        //                Color = new Dropdown { Name = MakeSafe.ToSafeString(row["Color"]) },
        //                SalesExc = new Dropdown { Name = MakeSafe.ToSafeString(row["AssignedTo"]) },
        //                Modell = new Dropdown { Name = MakeSafe.ToSafeString(row["Model"]) },
        //                SourceofENQ = new Dropdown { Name = MakeSafe.ToSafeString(row["SourceOfEnquiry"]) },
        //                Remarks = new Dropdown { Name = MakeSafe.ToSafeString(row["Remarks"]) },
        //                PurchaseTime = new Dropdown { Name = MakeSafe.ToSafeString(row["PurchaseTimeLine"]) },
        //                Transmission = MakeSafe.ToSafeString(row["Transmission"]),
        //                LeadSts = MakeSafe.ToSafeString(row["LeadStatus"]),
        //                ModeOfContract = MakeSafe.ToSafeString(row["ModeOfContract"]),
        //                FuelType = MakeSafe.ToSafeString(row["FuelType"]),
        //                NextDate = MakeSafe.ToSafeString(row["NextFollowUpDate"]),
        //                EnquireDate = MakeSafe.ToSafeString(row["LeadDate"]),

        //            };

        //            model.ColdCallEnquireList.Add(item);
        //        }
        //    }

        //    return model;
        //}


    }
}

