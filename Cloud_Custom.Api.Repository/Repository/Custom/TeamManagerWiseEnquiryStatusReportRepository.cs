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
    public class TeamManagerWiseEnquiryStatusReportRepository : ITeamManagerWiseEnquiryStatusReportRepository
    {
        private readonly ISqlConnectionProvider _sql;


        public TeamManagerWiseEnquiryStatusReportRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;

        }

        public async Task<TeamManagerWiseEnquiryStatusReport> GetList(UserBase userBase, int MonthCode, int ModelCode, int SourceCode, int Channel, int Region, int Team)
        {
            try
            {

              
                IDbDataParameter[] sqlparameters =
                {
                    //new SqlParameter("@CompanyGI",userBase.CompanyGuid),
                    //new SqlParameter("@UserGI",userBase.UserGuid),
                    new SqlParameter("@MonthCode",MonthCode),
                    new SqlParameter("@ModelCode", ModelCode == 0 ? (object)DBNull.Value : ModelCode),
                    new SqlParameter("@SourceCode", SourceCode == 0 ? (object)DBNull.Value : SourceCode),
                    new SqlParameter("@Region", Region == 0 ? (object)DBNull.Value : Region),
                    new SqlParameter("@Channel", Channel == 0 ? (object)DBNull.Value : Channel),
                    new SqlParameter("@Team", Team == 0 ? (object)DBNull.Value : Team),
                  

                };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_ENQUIRY_FOLLOW_UP_REPORT_TEAM_LEADER_WISE]", sqlparameters);
                return EnquiryreportList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }



        private TeamManagerWiseEnquiryStatusReport EnquiryreportList(DataSet dataSet)
        {
            TeamManagerWiseEnquiryStatusReport model = new TeamManagerWiseEnquiryStatusReport();
            List<TeamManagerWiseEnquiryStatusReport> List = new List<TeamManagerWiseEnquiryStatusReport>();
            
            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new TeamManagerWiseEnquiryStatusReport();




                    item.Channel = MakeSafe.ToSafeString(row["Channel"]);
                    item.RegionName = MakeSafe.ToSafeString(row["RegionName"]);
                    item.TeamLeader = MakeSafe.ToSafeString(row["TeamLeader"]);
                    item.TeamLeaderEmployeeCode = MakeSafe.ToSafeInt32(row["TeamLeaderEmployeeCode"]);
                    item.LiveEnquiry = MakeSafe.ToSafeString(row["LiveEnquiry"]);
                    item.MultipleOutLet = MakeSafe.ToSafeString(row["MultipleOutlet"]);
                    item.FirstFollowUp = MakeSafe.ToSafeString(row["FirstFollowUp"]);
                    item.SecondFollowUp = MakeSafe.ToSafeString(row["SecondFollowUp"]);
                    item.TD = MakeSafe.ToSafeString(row["TD"]);
                    item.HomeVisit = MakeSafe.ToSafeString(row["HomeVisit"]);
                    item.ZeroFollowUp = MakeSafe.ToSafeString(row["ZeroFollowUp"]);
                    item.FollowPct = MakeSafe.ToSafeString(row["FollowPct"]);
                    item.HVPct = MakeSafe.ToSafeString(row["HVPct"]);
                    item.TDPct = MakeSafe.ToSafeString(row["TDPct"]);
                    item.TotalType = MakeSafe.ToSafeString(row["TotalType"]);





                    List.Add(item);
                }
                model.List = List;
            }


           
            return model;
        }

      
    }
}


