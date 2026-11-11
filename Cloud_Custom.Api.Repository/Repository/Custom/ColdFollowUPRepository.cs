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
    public class ColdFollowUPRepository : IColdFollowUPRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public ColdFollowUPRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<ColdFollowUP> GetList(UserBase user, Filter filter)
        {

            IDbDataParameter[] sqlparameters =
           {
                  new SqlParameter("@JSONDATA",JsonHelper.ToJson(filter)),
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_COLD_FFOLLOW_UP_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }
        public ColdFollowUP PopulateGetList(DataSet ds)
        {
            ColdFollowUP model = new ColdFollowUP();
            model.ColdFollowUPList = new List<ColdFollowUP>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new ColdFollowUP
                    {
                        Trnno = MakeSafe.ToSafeInt32(row["TrnCode"]),
                        LeadNo = MakeSafe.ToSafeString(row["leadCode"]),

                        EnquireDate = MakeSafe.ToSafeString(row["LeadDate"]),
                        CustomerName = MakeSafe.ToSafeString(row["Name"]),
                        Mobilno = MakeSafe.ToSafeString(row["MobileNo"]),
                        IntrestedModel = MakeSafe.ToSafeString(row["InterestedModel"]),
                        SalesExecutive = MakeSafe.ToSafeString(row["SalesExecutive"]),
                        Status = MakeSafe.ToSafeString(row["Status"]),
                        active = MakeSafe.ToSafeInt32(row["ACTIVE"]),
                        totalRecords = MakeSafe.ToSafeInt32(row["TotalCount"])
                };

                    model.ColdFollowUPList.Add(item);
                }
            }

            return model;
        }

         public async Task<ColdFollowUPItem> GetEmployeeDetails(UserBase user,string EnqNo, int Trnno)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@EnqCode",EnqNo),
                new SqlParameter("@Trnno",Trnno),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_COLD_FOLLOW_UP_ENQUIRE_DETAILS]", sqlparameters);

            return PopulateGetEmployeeDetails(ds);

        }
        public ColdFollowUPItem PopulateGetEmployeeDetails(DataSet ds)
        {

            ColdFollowUPItem model = new ColdFollowUPItem();
            model.ColdFollowUPDeatilList = new List<ColdFollowUPItem>();
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {

                    DataRow row = ds.Tables[0].Rows[0];

                    model.Modell = new Dropdown();
                    model.SalesExc = new Dropdown();
                    model.SourceofENQ = new Dropdown();
                    model.Variant = new Dropdown();
                    model.Color = new Dropdown();
                    model = new ColdFollowUPItem

                    {

                        Trnno = MakeSafe.ToSafeInt32(row["TrnCode"]),
                        LeadNo = MakeSafe.ToSafeString(row["leadCode"]),
                        EnquireDate = MakeSafe.ToSafeString(row["LeadDate"]),
                        CustomerName = MakeSafe.ToSafeString(row["Name"]),
                        Mobilno = MakeSafe.ToSafeString(row["MobileNo"]),
                        Modell = new Dropdown{Code = MakeSafe.ToSafeInt32(row["InterestedModel"])},
                        SalesExc = new Dropdown{Code = MakeSafe.ToSafeInt32(row["SalesExecutive"])},
                        Variant = new Dropdown { Code = MakeSafe.ToSafeInt32(row["Variant"]) },
                        Color = new Dropdown { Code = MakeSafe.ToSafeInt32(row["Color"]) },
                        FuelType = MakeSafe.ToSafeString(row["FuelType"]),
                        Transmission = MakeSafe.ToSafeString(row["Transmission"]),
                        EmailId = MakeSafe.ToSafeString(row["EmailId"]),
                        SourceofENQ = new Dropdown{Code = MakeSafe.ToSafeInt32(row["SourceCode"])},
                        ModeOfContract = MakeSafe.ToSafeString(row["ModeOfContact"])


                    };
                
            }
            model.ColdFollowUPDeatilList = new List<ColdFollowUPItem>();
            if ((ds.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    var item = new ColdFollowUPItem
                    {
                        ContactDate = MakeSafe.ToSafeString(row["ContactDate"]),
                        ModeofContact = MakeSafe.ToSafeString(row["ModeofContact"]),
                        Remarkss = MakeSafe.ToSafeString(row["Remarks"]),
                        NextFollowupDate = MakeSafe.ToSafeString(row["NextFollowupDate"]),
                        LeadStatus = MakeSafe.ToSafeString(row["LeadStatus"]),
                        PurchaseTimes = MakeSafe.ToSafeString(row["TimeLines"])
                    };

                    model.ColdFollowUPDeatilList.Add(item);
                }
            }

            return model;
        }

        public async Task<ResponseEntity> Save(UserBase user, ColdFollowUP model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_DMS_COLD_FOLLOW_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
    }
}
