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
  public  class LeadReassignRepository : ILeadReassignRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public LeadReassignRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }

        public async Task<LeadReassign> GetList(UserBase user, Filter filter)
        {

            IDbDataParameter[] sqlparameters =
           {
                  new SqlParameter("@JSONDATA",JsonHelper.ToJson(filter)),
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_LEAD_REASSIGN_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }
       
        public LeadReassign PopulateGetList(DataSet ds)
        {
            LeadReassign model = new LeadReassign();
            model.LeadReassignList = new List<LeadReassign>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new LeadReassign
                    {
                        Trnno = MakeSafe.ToSafeInt32(row["TrnCode"]),
                        LeadNo = MakeSafe.ToSafeString(row["leadCode"]),

                        EnquireDate = MakeSafe.ToSafeString(row["LeadDate"]),
                        CustomerName = MakeSafe.ToSafeString(row["Name"]),
                        Mobilno = MakeSafe.ToSafeString(row["MobileNo"]),
                        IntrestedModel = MakeSafe.ToSafeString(row["InterestedModel"]),
                        OldSalesExecutive = MakeSafe.ToSafeString(row["SalesExecutive"]),
                        SalesExecutive = MakeSafe.ToSafeString(row["NewSalesExe"]),
                        Reason = MakeSafe.ToSafeString(row["Reason"]),
                        UpdatedCount = MakeSafe.ToSafeInt32(row["UpdateCount"]),
                        active = MakeSafe.ToSafeInt32(row["ACTIVE"]),
                        totalRecords = MakeSafe.ToSafeInt32(row["TotalCount"])
                    };

                    model.LeadReassignList.Add(item);
                }
            }

            return model;
        }

        public async Task<LeadReassignItem> GetEmployeeDetails(UserBase user, int Trnno)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@Trnno",Trnno),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_LEAD_REASSIGN_DETAILS]", sqlparameters);

            return PopulateGetEmployeeDetails(ds);

        }
        public LeadReassignItem PopulateGetEmployeeDetails(DataSet ds)
        {

            LeadReassignItem model = new LeadReassignItem();
            model.LeadReassignItemList = new List<LeadReassignItem>();
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {

                DataRow row = ds.Tables[0].Rows[0];

               
                model.SalesExc = new Dropdown();
                
                model = new LeadReassignItem

                {

                    Trnno = MakeSafe.ToSafeInt32(row["TrnCode"]),
                    LeadNo = MakeSafe.ToSafeString(row["leadCode"]),

                    ContactDate = MakeSafe.ToSafeString(row["LeadDate"]),
                    CustomerName = MakeSafe.ToSafeString(row["Name"]),
                    Mobilno = MakeSafe.ToSafeString(row["MobileNo"]),
                    IntrestedModel = MakeSafe.ToSafeString(row["ModeName"]),                 
            
                    EmailId = MakeSafe.ToSafeString(row["EmailId"]),
                    SourceOfEnquiry = MakeSafe.ToSafeString(row["SourceOfEnquiry"]),   
                    ModeOfContract = MakeSafe.ToSafeString(row["ModeOfContact"]),
                    Variant = MakeSafe.ToSafeString(row["Variant"]),
                    Color = MakeSafe.ToSafeString(row["Color"]),
                    FuelType = MakeSafe.ToSafeString(row["FuelType"]),
                    Transmission = MakeSafe.ToSafeString(row["Transmission"]),
                    OldExecutive = MakeSafe.ToSafeString(row["EmployeeName"]),
                    SalesExecCode = MakeSafe.ToSafeInt32(row["EmployeeCode"]),
                    LeadStatus = MakeSafe.ToSafeString(row["LeadStatus"]),
                    NextFollowupDate = MakeSafe.ToSafeString(row["NextFollowUpDate"]),
                    Remarks = MakeSafe.ToSafeString(row["Remarks"]),
                    PurchaseTimes = MakeSafe.ToSafeString(row["TimeLines"]),
               

                };

            }
           

            return model;
        }

        public async Task<ResponseEntity> Save(UserBase user, LeadReassign model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_LEAD_REASSIGN_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
        public async Task<LeadReassign> GetUpdatedDetails(UserBase user, int Trnno)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@Trnno",Trnno),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_UPDATED_POPUP_DETAILS]", sqlparameters);

            return PopulateGetUpdatedDetails(ds);

        }
        public LeadReassign PopulateGetUpdatedDetails(DataSet ds)
        {
            var model = new LeadReassign();
            model.LeadReassignList = new List<LeadReassign>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    model.LeadReassignList.Add(new LeadReassign
                    {
                        LeadNo = MakeSafe.ToSafeString(row["leadCode"]),
                        EnquireDate = MakeSafe.ToSafeString(row["EntryDate"]),
                        OldSalesExecutive = MakeSafe.ToSafeString(row["SalesExecutive"]),
                        SalesExecutive = MakeSafe.ToSafeString(row["NewSalesExe"]),
                        Reason = MakeSafe.ToSafeString(row["Reason"])
                    });
                }
            }

            return model;
        }
    }
}

