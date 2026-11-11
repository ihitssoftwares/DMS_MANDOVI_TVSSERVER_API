
using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.MobileApp;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.Repository.MobileApp
{
    public class LeadFollowUpRepository : ILeadFollowUpRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public LeadFollowUpRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<ColdFollowUP> GetList(UserBase user,int TabIndex)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@TabIndex",TabIndex),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_LEAD_FOLLOW_UP_LIST]", sqlparameters);

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
                        FollowupNextDate = MakeSafe.ToSafeString(row["FollowupNextDate"]),
                                
                    };
                   model.ColdFollowUPList.Add(item);
                }
            }

            return model;
        }


        public async Task<ColdFollowUP> GetEmployeePosition(UserBase user)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_IDENTIFY_USER_ROLE]", sqlparameters);

            return PopulateEmployeePosition(ds);

        }

        public ColdFollowUP PopulateEmployeePosition(DataSet ds)
        {
            ColdFollowUP model = new ColdFollowUP();
            model.ColdFollowUPList = new List<ColdFollowUP>();


            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];


                model.EmployeeRole = MakeSafe.ToSafeString(row["EmployeeRole"]);
                model.BranchCode = MakeSafe.ToSafeInt32(row["BranchCode"]);

            }

            return model;
        }


        public async Task<ColdFollowUP> GetMyTeamList(UserBase user, string Type)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@Type",Type),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_LIST_MY_TEAM]", sqlparameters);

            return PopulateGetMyTeam(ds);

        }

        public ColdFollowUP PopulateGetMyTeam(DataSet ds)
        {
            ColdFollowUP model = new ColdFollowUP();
            model.ColdFollowUPList = new List<ColdFollowUP>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new ColdFollowUP
                    {
                        UserGI = MakeSafe.ToSafeGuid(row["UserGI"]),
                        EmpCode = MakeSafe.ToSafeInt32(row["EmpCode"]),
                        EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]),
                        cCount = MakeSafe.ToSafeInt32(row["cCount"]),
                        ReportingName = MakeSafe.ToSafeString(row["ReportingName"]),
                       

                    };
                    model.ColdFollowUPList.Add(item);
                }
            }

            return model;
        }


    }
}
