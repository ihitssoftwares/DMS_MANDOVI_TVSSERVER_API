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
  public   class ColdCallEnquireReportRepository : IColdCallEnquireReportRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public ColdCallEnquireReportRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<ColdCallEnquireReport> GetList(UserBase user, string FromDate, string ToDate, string Status)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@FromDate",FromDate),
                new SqlParameter("@ToDate",ToDate),
                new SqlParameter("@Status",Status)


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_COLD CALL_ENQUIRE__REPORT_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }
        public ColdCallEnquireReport PopulateGetList(DataSet ds)
        {
            ColdCallEnquireReport model = new ColdCallEnquireReport();
            model.ColdCallEnquireList = new List<ColdCallEnquireReport>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new ColdCallEnquireReport
                    {
                        ColdCallNo = MakeSafe.ToSafeString(row["EnqNo"]),

                        EnquireDate = MakeSafe.ToSafeString(row["EnquiryDate"]),
                        SourceOfEnquiry = MakeSafe.ToSafeString(row["SourceOfEnquiry"]),
                        CustomerName = MakeSafe.ToSafeString(row["Name"]),
                        Mobilno = MakeSafe.ToSafeString(row["MobileNo"]),
                        IntrestedModel = MakeSafe.ToSafeString(row["InterestedModel"]),
                        Status = MakeSafe.ToSafeString(row["LeadStatus"]),

                    };

                    model.ColdCallEnquireList.Add(item);
                }
            }

            return model;
        }


    }
}
