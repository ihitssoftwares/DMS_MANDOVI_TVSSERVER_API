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
 public   class IncentiveSummaryRepository : IIncentiveSummaryRepository
    {

        private readonly ISqlConnectionProvider _sql;
        public IncentiveSummaryRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<IncentiveSummary> GetList(UserBase user, int Month, int Delearship, int Designation, int Branch)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),


                new SqlParameter("@Month",Month),
                 new SqlParameter("@DealershipCode",Delearship),
                 new SqlParameter("@Branch",Branch),
                 new SqlParameter("@SalesDesignationCode",Designation),
            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_INCENTIVE_SUMMARY]", sqlparameters);

            return PopulateGetList(ds);

        }
        public IncentiveSummary PopulateGetList(DataSet ds)
        {
            IncentiveSummary model = new IncentiveSummary();
            model.EmployeeDetailsList = new List<SummaryEmployeeDetails>();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    SummaryEmployeeDetails item = new SummaryEmployeeDetails
                    {
                        TeamLeaderEmployeeCode = MakeSafe.ToSafeInt32(row["TEAMLEADEREMPLOYEECODE"]),
                        TeamLeaderName = MakeSafe.ToSafeString(row["TEAMLEADERNAME"]),

                        EmployeeCode = MakeSafe.ToSafeInt32(row["EMPLOYEECODE"]),
                        EmployeeName = MakeSafe.ToSafeString(row["EMPLOYEENAME"]),

                        BranchName = MakeSafe.ToSafeString(row["BRANCHNAME"]),

                        SalesIncentive = MakeSafe.ToSafeDecimal(row["SALESINCENTIVE"]),
                        EWIncentive = MakeSafe.ToSafeDecimal(row["EWINCENTIVE"]),
                        GASIncentive = MakeSafe.ToSafeDecimal(row["GASINCENTIVE"]),
                        ExchangeIncentive = MakeSafe.ToSafeDecimal(row["EXCHANGEINCENTIVE"]),
                        FinanceIncentive = MakeSafe.ToSafeDecimal(row["FINANCEINCENTIVE"]),
                        InsuranceIncentive = MakeSafe.ToSafeDecimal(row["INSURANCEINCENTIVE"]),
                        MCPIncentive = MakeSafe.ToSafeDecimal(row["MCPINCENTIVE"]),
                        SPOTINCENTIVEMDOELWISE = MakeSafe.ToSafeDecimal(row["SPOTINCENTIVEMDOELWISE"]),
                        SPOTINCENTIVEDATEWISE = MakeSafe.ToSafeDecimal(row["SPOTINCENTIVEDATEWISE"])

                    };

                    model.EmployeeDetailsList.Add(item);
                }
            }

            return model;
        }


        public async Task<IncentiveSummary> GetEmployeeDetails(UserBase user, int Month, int Delearship, int Designation, int EmployeeCode)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),


                new SqlParameter("@Month",Month),
                 new SqlParameter("@DealershipCode",Delearship),
            
                 new SqlParameter("@SalesDesignationCode",Designation),
                 new SqlParameter("@EmployeeCode",EmployeeCode),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_INCENTIVE_SUMMARY_EMPLOYEE_DETAILS]", sqlparameters);

            return PopulateGetEmployeeDetails(ds);

        }
        public IncentiveSummary PopulateGetEmployeeDetails(DataSet ds)
        {
            IncentiveSummary model = new IncentiveSummary();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                model.IncentiveSummaryEmployeeDetails = new IncentiveSummaryEmployeeDetails
                {
                    // Employee Info
                    EmployeeCode = MakeSafe.ToSafeInt32(row["EmployeeCode"]),
                    EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]),
                    BranchName = MakeSafe.ToSafeString(row["BranchName"]),

                    // SALES
                    SalesTarget = MakeSafe.ToSafeInt32(row["SalesTarget"]),
                    SalesAchieved = MakeSafe.ToSafeInt32(row["SalesAchieved"]),
                    SalesMinimumPercentage = MakeSafe.ToSafeDecimal(row["SalesMinimumPercentage"]),
                    SalesAchievedPercentage = MakeSafe.ToSafeDecimal(row["SalesAchievedPercentage"]),
                    SalesIncentiveAmount = MakeSafe.ToSafeDecimal(row["SalesIncentiveAmount"]),

                    // EW
                    EWTarget = MakeSafe.ToSafeInt32(row["EWTarget"]),
                    EWSalesAchieved = MakeSafe.ToSafeInt32(row["EWSalesAchieved"]),
                    EWElligibleSales = MakeSafe.ToSafeInt32(row["EWElligibleSales"]),
                    EWAchievedPercentage = MakeSafe.ToSafeDecimal(row["EWAchievedPercentage"]),
                    EWIncentiveAmount = MakeSafe.ToSafeDecimal(row["EWIncentiveAmount"]),

                    // EXCHANGE
                    ExchangeTarget = MakeSafe.ToSafeInt32(row["ExchangeTarget"]),
                    ExchangeSalesAchieved = MakeSafe.ToSafeInt32(row["ExchangeSalesAchieved"]),
                    ExchangeEligibleSales = MakeSafe.ToSafeInt32(row["ExchangeEligibleSales"]),
                    ExchangeAchievedPercentage = MakeSafe.ToSafeDecimal(row["ExchangeAchievedPercentage"]),
                    ExchangeIncentiveAmount = MakeSafe.ToSafeDecimal(row["ExchangeIncentiveAmount"]),

                    // INSURANCE
                    InsuranceTarget = MakeSafe.ToSafeInt32(row["InsuranceTarget"]),
                    InsuranceSalesAchieved = MakeSafe.ToSafeInt32(row["InsuranceSalesAchieved"]),
                    InsuranceEligibleSales = MakeSafe.ToSafeInt32(row["InsuranceEligibleSales"]),
                    InsuranceAchievedPercentage = MakeSafe.ToSafeDecimal(row["InsuranceAchievedPercentage"]),
                    InsuranceIncentiveAmount = MakeSafe.ToSafeDecimal(row["InsuranceIncentiveAmount"]),

                    // FINANCE
                    FinanceTarget = MakeSafe.ToSafeInt32(row["FinanceTarget"]),
                    FinanceSalesAchieved = MakeSafe.ToSafeInt32(row["FinanceSalesAchieved"]),
                    FinanceEligibleSales = MakeSafe.ToSafeInt32(row["FinanceEligibleSales"]),
                    FinanceAchievedPercentage = MakeSafe.ToSafeDecimal(row["FinanceAchievedPercentage"]),
                    FinanceIncentiveAmount = MakeSafe.ToSafeDecimal(row["FinanceIncentiveAmount"]),

                    // MCP
                    MCPTarget = MakeSafe.ToSafeInt32(row["MCPTarget"]),
                    MCPSalesAchieved = MakeSafe.ToSafeInt32(row["MCPSalesAchieved"]),
                    MCPEligibleSales = MakeSafe.ToSafeInt32(row["MCPEligibleSales"]),
                    MCPAchievedPercentage = MakeSafe.ToSafeDecimal(row["MCPAchievedPercentage"]),
                    MCPIncentiveAmount = MakeSafe.ToSafeDecimal(row["MCPIncentiveAmount"]),

                    // GAS
                    GASTarget = MakeSafe.ToSafeInt32(row["GASTarget"]),
                    GASSalesAchieved = MakeSafe.ToSafeInt32(row["GASSalesAchieved"]),
                    GASEligibleSales = MakeSafe.ToSafeInt32(row["GASEligibleSales"]),
                    GASAchievedPercentage = MakeSafe.ToSafeDecimal(row["GASAchievedPercentage"]),
                    GASIncentiveAmount = MakeSafe.ToSafeDecimal(row["GASIncentiveAmount"]),

                     // MODEL
                    MODELTarget = MakeSafe.ToSafeInt32(row["MODELTarget"]),
                    MODELSalesAchieved = MakeSafe.ToSafeInt32(row["MODELSalesAchieved"]),
                    MODELEligibleSales = MakeSafe.ToSafeInt32(row["MODELEligibleSales"]),
                    MODELAchievedPercentage = MakeSafe.ToSafeDecimal(row["MODELAchievedPercentage"]),
                    MODELIncentiveAmount = MakeSafe.ToSafeDecimal(row["MODELIncentiveAmount"]),


                    // DATE
                    DATETarget = MakeSafe.ToSafeInt32(row["DATETarget"]),
                    DATESalesAchieved = MakeSafe.ToSafeInt32(row["DATESalesAchieved"]),
                    DATEEligibleSales = MakeSafe.ToSafeInt32(row["DATEEligibleSales"]),
                    DATEAchievedPercentage = MakeSafe.ToSafeDecimal(row["DATEAchievedPercentage"]),
                    DATEIncentiveAmount = MakeSafe.ToSafeDecimal(row["DATEIncentiveAmount"])
                };
            }

            return model;
        }



        public async Task<DataSet> SummaryExcel(UserBase user, int Month, int Delearship, int Designation, int Branch)
        {
            IDbDataParameter[] sqlparameters =
         {
               new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                        new SqlParameter("@Branch",Branch),
                new SqlParameter("@Month",Month),
                 new SqlParameter("@DealershipCode",Delearship),

                 new SqlParameter("@SalesDesignationCode",Designation),
            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_INCENTIVE_SUMMARY_EMPLOYEE_DETAILS_EXPORT_TO_EXCEL]", sqlparameters);
         
          
            return (ds);
        }

    }
}
