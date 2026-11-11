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
    public class ColdFollowUpReportRepository : IColdFollowUpReportRepository
    {

        private readonly ISqlConnectionProvider _sql;
        public ColdFollowUpReportRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<ColdFollowUpReport> GetList(UserBase user, Filter filter, string FromDate, string ToDate, int Region, int Branch, string Status)
        {

            IDbDataParameter[] sqlparameters =
           {
                  new SqlParameter("@JSONDATA",JsonHelper.ToJson(filter)),
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@FromDate",FromDate),
                new SqlParameter("@ToDate",ToDate),
                new SqlParameter("@Region",Region),
                new SqlParameter("@Branch",Branch),
                new SqlParameter("@Status",Status),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_COLD_FOLLOW_UP__REPORTLIST]", sqlparameters);

            return PopulateGetList(ds);

        }
        public ColdFollowUpReport PopulateGetList(DataSet ds)
        {
            ColdFollowUpReport model = new ColdFollowUpReport();
            model.ColdFollowUPList = new List<ColdFollowUpReport>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new ColdFollowUpReport
                    {
                        Trnno = MakeSafe.ToSafeInt32(row["TrnCode"]),
                        LeadNo = MakeSafe.ToSafeString(row["leadCode"]),

                        EnquireDate = MakeSafe.ToSafeString(row["LeadDate"]),
                        SourceOfEnquiry = MakeSafe.ToSafeString(row["SourceOfEnquiry"]),
                        CustomerName = MakeSafe.ToSafeString(row["Name"]),
                        Mobilno = MakeSafe.ToSafeString(row["MobileNo"]),
                        IntrestedModel = MakeSafe.ToSafeString(row["InterestedModel"]),
                        SalesExecutive = MakeSafe.ToSafeString(row["SalesExecutive"]),
                        PurchaseTimelines = MakeSafe.ToSafeString(row["Timelines"]),
                        LeadSts = MakeSafe.ToSafeString(row["LeadStatus"]),
                        TestDriveDate = MakeSafe.ToSafeString(row["TestDriveDate"]),
                        active = MakeSafe.ToSafeInt32(row["ACTIVE"]),
                    totalRecords = MakeSafe.ToSafeInt32(row["TotalCount"])

                };

                    model.ColdFollowUPList.Add(item);
                }
            }

            return model;
        }

        public async Task<ColdFollowUPItems> GetEmployeeDetails(UserBase user, int Trnno)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@Trnno",Trnno),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_COLD_FOLLOW_UP_ENQUIRE_REPORT_DETAILS]", sqlparameters);

            return PopulateGetEmployeeDetails(ds);

        }
        public ColdFollowUPItems PopulateGetEmployeeDetails(DataSet ds)
        {

            ColdFollowUPItems model = new ColdFollowUPItems();
            model.ColdFollowUPDeatilList = new List<ColdFollowUPItems>();
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                      var item = new ColdFollowUPItems
                    {
                        Trnno = MakeSafe.ToSafeInt32(row["TrnCode"]),
                        LeadNo = MakeSafe.ToSafeString(row["leadCode"]),
                        CustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
                       
                        EnquireDate = MakeSafe.ToSafeString(row["ContactDate"]),
                          ModelDetails = MakeSafe.ToSafeString(row["ModelDetails"]),
                          SalesExecutive = MakeSafe.ToSafeString(row["SalesExecutive"]),
                        ModeOfContract = MakeSafe.ToSafeString(row["ModeOfContact"]),
                        NextDate = MakeSafe.ToSafeString(row["NextDate"]),
                        Remarkss = MakeSafe.ToSafeString(row["Remarks"]),
                        Status = MakeSafe.ToSafeString(row["Status"]),

                    };

                    model.ColdFollowUPDeatilList.Add(item);
                }
               
            }
            return model;
        }

    }
}
