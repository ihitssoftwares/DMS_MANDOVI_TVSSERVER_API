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
    public class OutLetWiseEnquiryReportRepository : IOutLetWiseEnquiryReportRepository
    {

        private readonly ISqlConnectionProvider _sql;
        public OutLetWiseEnquiryReportRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<OutLetWiseEnquiryReport> GetList(UserBase user, int MonthCode, int ModelCode, int EnquiryCode, Filter filter)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                
                    new SqlParameter("@MonthCode",MonthCode),
                     new SqlParameter("@ModelCode",ModelCode),
                      new SqlParameter("@SourceCode",EnquiryCode),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(filter)),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_ENQUIRY_FOLLOW_UP_REPORT_OUTLET_WISE]", sqlparameters);
                return SummeryList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private OutLetWiseEnquiryReport SummeryList(DataSet ds)
        {
            OutLetWiseEnquiryReport model = new OutLetWiseEnquiryReport();
            List<OutLetWiseEnquiryReport> list = new List<OutLetWiseEnquiryReport>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new OutLetWiseEnquiryReport();


                    item.Channel = MakeSafe.ToSafeString(row["Channel"]);

                    item.RegionName = MakeSafe.ToSafeString(row["RegionName"]);
                    item.BranchName = MakeSafe.ToSafeString(row["BranchName"]);

                    item.BranchCode = MakeSafe.ToSafeInt32(row["BranchCode"]);

                    item.LiveEnquiry = MakeSafe.ToSafeInt32(row["LiveEnquiry"]);
                    item.ZeroFollowUp = MakeSafe.ToSafeInt32(row["ZeroFollowUp"]);
                   
                    item.FirstFollowUp = MakeSafe.ToSafeInt32(row["FirstFollowUp"]);
                    item.SecondFollowUp = MakeSafe.ToSafeInt32(row["SecondFollowUp"]);
                    item.MultipleOutlet = MakeSafe.ToSafeInt32(row["MultipleOutlet"]);
                    item.TD = MakeSafe.ToSafeInt32(row["TD"]);
                    item.HomeVisit = MakeSafe.ToSafeInt32(row["HomeVisit"]);
                    

                    item.FollowPct = MakeSafe.ToSafeDecimal(row["FollowPct"]);
                    item.HVPct = MakeSafe.ToSafeDecimal(row["HVPct"]);
                    item.TDPct = MakeSafe.ToSafeDecimal(row["TDPct"]);

                    item.TotalType = MakeSafe.ToSafeString(row["TotalType"]);
             

                    list.Add(item);
                }

                model.List = list;
            }
            model.TotalCount = list.Count;

            return model;
        }

        public async Task<OutLetWiseEnquiryReport> GetPopUpDetails(UserBase user, string ColType, string channel, string regionName, string branchCode, string monthCode, string modelCode, string enquiryCode, string Type)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {

                    new SqlParameter("@ColType",ColType),
                     new SqlParameter("@Channel",channel),
                     new SqlParameter("@RegionName", string.IsNullOrEmpty(regionName) ? DBNull.Value : (object)regionName),

                       new SqlParameter("@BranchCode",branchCode),
                     new SqlParameter("@MonthCode",monthCode),
                      new SqlParameter("@ModelCode",modelCode),
                       new SqlParameter("@EnquiryCode",enquiryCode),
                        new SqlParameter("@Type",Type),
 
                       //new SqlParameter("@JSONDATA",JsonHelper.ToJson(filter)),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_ENQUIRY_FOLLOW_UP_REPORT_OUTLET_WISE_POPUP_DETAILS]", sqlparameters);
                return PopList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();  
                throw new Exception(ErrorMsg, ex);
            }
        }
        private OutLetWiseEnquiryReport PopList(DataSet ds)
        {
            OutLetWiseEnquiryReport model = new OutLetWiseEnquiryReport();
            List<OutLetWiseEnquiryReport> list = new List<OutLetWiseEnquiryReport>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new OutLetWiseEnquiryReport();


                    item.LeadNo = MakeSafe.ToSafeString(row["LeadNo"]);

                    item.Name = MakeSafe.ToSafeString(row["Name"]);
                    item.ModelName = MakeSafe.ToSafeString(row["ModelName"]);

                    item.SourceofEnquiry = MakeSafe.ToSafeString(row["SourceOfEnquiry"]);

                    item.Color = MakeSafe.ToSafeString(row["ColorName"]);
                    item.Variant = MakeSafe.ToSafeString(row["VariantName"]);

                    item.FuelType = MakeSafe.ToSafeString(row["FuelTypeName"]);
                    item.DseName = MakeSafe.ToSafeString(row["DSE"]);


                    list.Add(item);
                }

                model.List = list;
            }
            model.TotalCount = list.Count;

            return model;
        }
    }
}
