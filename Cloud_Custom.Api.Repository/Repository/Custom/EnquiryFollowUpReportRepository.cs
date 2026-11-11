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
    public class EnquiryFollowUpReportRepository : IEnquiryFollowUpReportRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public EnquiryFollowUpReportRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }

        public async Task<EnquiryFollowUpReport> GetList(UserBase user, int Month, int Region,int Branch)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@monthCode",Month),
                 new SqlParameter("@RegionCode",Region),
                 new SqlParameter("@BranchCode",Branch)



                };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_ENQUIRY_FOLLOW_UP_REPORT_CUSTOMER_WISE]", sqlparameters);
                return DesignationVsParameterList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private EnquiryFollowUpReport DesignationVsParameterList(DataSet dataSet)
        {
            EnquiryFollowUpReport model = new EnquiryFollowUpReport();
            List<EnquiryFollowUpReport> List = new List<EnquiryFollowUpReport>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new EnquiryFollowUpReport();



                    item.Months = MakeSafe.ToSafeString(row["Month"]);
                    item.SalesDealerCode = MakeSafe.ToSafeString(row["Sales Dealer Code"]);
                    item.EnquiryNum = MakeSafe.ToSafeString(row["Enquiry Num"]);
                    item.EnquiryDate = MakeSafe.ToSafeString(row["Enquiry Date"]);
                    item.ProspectName = MakeSafe.ToSafeString(row["Prospect Name"]);
                    item.EnquirySource = MakeSafe.ToSafeString(row["Enquiry Source"]);

                    item.Model = MakeSafe.ToSafeString(row["Model"]);
                    item.Variant = MakeSafe.ToSafeString(row["Variant"]);
                    item.Colour = MakeSafe.ToSafeString(row["Colour"]);
                    item.FuelType = MakeSafe.ToSafeString(row["Fuel Type"]);
                    item.Transmission = MakeSafe.ToSafeString(row["Transmission"]);

                    item.TLName = MakeSafe.ToSafeString(row["TL Name"]);
                    item.DSEName = MakeSafe.ToSafeString(row["DSE Name"]);
                    item.NewCarEnquiryStatus = MakeSafe.ToSafeString(row["New Car Enquiry Status"]);

                    item.TestDriveDate = MakeSafe.ToSafeString(row["Test Drive Date"]);
                    item.HomeVisitDate = MakeSafe.ToSafeString(row["Home Visit Date"]);

                    item.NumOfFollowUp = MakeSafe.ToSafeString(row["Num of Follow-up"]);

                    item.EvaluatorMSPINNo = MakeSafe.ToSafeString(row["Evaluator MSPIN No"]);
                    item.EvaluatorName = MakeSafe.ToSafeString(row["Evaluator Name"]);
                    item.EvaluationDate = MakeSafe.ToSafeString(row["Evaluation Date"]);

                    item.DSEMSPINNo = MakeSafe.ToSafeString(row["DSE MSPIN No"]);

                    item.MultipleOutletVisitCount = MakeSafe.ToSafeString(row["Multiple Outlet Visit Count"]);
                    item.MultipleEvaluationsCount = MakeSafe.ToSafeString(row["Multiple Evaluations Count"]);
                    item.EvaluationGapFlag = MakeSafe.ToSafeString(row["Evaluation Gap Flag"]);

                    item.Enquiry = MakeSafe.ToSafeString(row["Enquiry"]);
                    item.CarConfigurationSaved = MakeSafe.ToSafeString(row["Car Configuration Saved"]);
                    item.ConfiguratorQuotationSentDate = MakeSafe.ToSafeString(row["Configurator Quotation Sent Date"]);

                    item.NextFollowupPlannedDate = MakeSafe.ToSafeString(row["Next Followup Planned Date"]);

                    item.TestDrive = MakeSafe.ToSafeString(row["Test Drive"]);
                    item.LiveEnquiry = MakeSafe.ToSafeString(row["Live Enquiry"]);
                    item.TD = MakeSafe.ToSafeString(row["TD"]);
                    item.HomeVisit = MakeSafe.ToSafeString(row["Home Visit"]);
                    item.MultipleOutlet = MakeSafe.ToSafeString(row["Multiple Outlet"]);
                    item.Evaluation = MakeSafe.ToSafeString(row["Evaluation"]);

                    item.TrnCode = MakeSafe.ToSafeInt32(row["TrnCode"]);
                    item.EnqTranCode = MakeSafe.ToSafeInt32(row["EnqTranCode"]);
                    item.LeadStatus = MakeSafe.ToSafeString(row["LeadStatus"]);
                    item.ModeOfContact = MakeSafe.ToSafeString(row["ModeOfContact"]);
                    item.Remarks = MakeSafe.ToSafeInt32(row["Remarks"]);
                    item.PurchaseTimeline = MakeSafe.ToSafeInt32(row["PurchaseTimeline"]);
                    item.MDMSEnquiryCode = MakeSafe.ToSafeString(row["MDMSEnquiryCode"]);
                    item.MDMSEnquiryDate = MakeSafe.ToSafeString(row["MDMSEnquiryDate"]);
                    item.Employee = MakeSafe.ToSafeInt32(row["Employee"]);
                    item.BranchCode = MakeSafe.ToSafeString(row["BranchCode"]);
                    item.DealerCode = MakeSafe.ToSafeString(row["DealerCode"]);




                    List.Add(item);
                }
                model.List = List;
            }

            return model;

        }






    }
}
