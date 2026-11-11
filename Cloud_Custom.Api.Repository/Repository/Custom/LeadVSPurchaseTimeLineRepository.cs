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
  public  class LeadVSPurchaseTimeLineRepository : ILeadVSPurchaseTimeLineRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public LeadVSPurchaseTimeLineRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<LeadVSPurchaseTimeLine> GetDetails(UserBase user, int model, string leadType)
        {
            IDbDataParameter[] sqlparameters =
            {
        new SqlParameter("@CompanyGI",user.CompanyGuid),
        new SqlParameter("@UserGI",user.UserGuid),
        new SqlParameter("@MODEL",model),
        new SqlParameter("@LEADTYPE",leadType),
    };

            var ds = await _sql.GetDataSetAsync("[DMS].[SP_LEAD_VS_PURCHASE_TIME_LINE]", sqlparameters);

            return PopulateLeadDashboard(ds);
        }

        public LeadVSPurchaseTimeLine PopulateLeadDashboard(DataSet ds)
        {
            LeadVSPurchaseTimeLine model = new LeadVSPurchaseTimeLine();

            model.FuelTypes = new List<FuelTypeCount>();
            model.Transmissions = new List<TransmissionTypeCount>();
            model.SalesExecutives = new List<SalesExecutiveCount>();
            model.SourceEnquiries = new List<SourceEnquiryChart>();


            //--------------------------------
            // TABLE 0 : MONTHLY LEADS (Single Row)
            //--------------------------------
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                model.MonthlyLeads = new MonthlyLeadCount
                {
                    JANUARY = MakeSafe.ToSafeInt32(row["JANUARY"]),
                    FEBRUARY = MakeSafe.ToSafeInt32(row["FEBRUARY"]),
                    MARCH = MakeSafe.ToSafeInt32(row["MARCH"]),
                    APRIL = MakeSafe.ToSafeInt32(row["APRIL"]),
                    MAY = MakeSafe.ToSafeInt32(row["MAY"]),
                    JUNE = MakeSafe.ToSafeInt32(row["JUNE"]),
                    JULY = MakeSafe.ToSafeInt32(row["JULY"]),
                    AUGUST = MakeSafe.ToSafeInt32(row["AUGUST"]),
                    SEPTEMBER = MakeSafe.ToSafeInt32(row["SEPTEMBER"]),
                    OCTOBER = MakeSafe.ToSafeInt32(row["OCTOBER"]),
                    NOVEMBER = MakeSafe.ToSafeInt32(row["NOVEMBER"]),
                    DECEMBER = MakeSafe.ToSafeInt32(row["DECEMBER"])
                };
            }


            //--------------------------------
            // TABLE 1 : FUEL TYPE
            //--------------------------------
            if ((ds.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    model.FuelTypes.Add(new FuelTypeCount
                    {
                        FuelType = MakeSafe.ToSafeString(row["FuelType"]),
                        TotalCount = MakeSafe.ToSafeInt32(row["TotalCount"])
                    });
                }
            }


            //--------------------------------
            // TABLE 2 : TRANSMISSION TYPE
            //--------------------------------
            if ((ds.Tables[2]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[2].Rows)
                {
                    model.Transmissions.Add(new TransmissionTypeCount
                    {
                        Transmission = MakeSafe.ToSafeString(row["Transmission"]),
                        TotalCount = MakeSafe.ToSafeInt32(row["TotalCount"])
                    });
                }
            }


            //--------------------------------
            // TABLE 3 : SALES EXECUTIVE
            //--------------------------------
            if ((ds.Tables[3]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[3].Rows)
                {
                    model.SalesExecutives.Add(new SalesExecutiveCount
                    {
                        SalesExecutive = MakeSafe.ToSafeString(row["SalesExecutive"]),
                        TotalCount = MakeSafe.ToSafeInt32(row["TotalCount"]),
              RankNo = MakeSafe.ToSafeInt32(row["RankNo"])
                    });
                }
            }


            //--------------------------------
            // TABLE 4 : SOURCE OF ENQUIRY
            //--------------------------------
            if ((ds.Tables[4]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[4].Rows)
                {
                    model.SourceEnquiries.Add(new SourceEnquiryChart
                    {
                        SourceOfEnquiry = MakeSafe.ToSafeString(row["SourceOfEnquiry"]),
                        TotalCount = MakeSafe.ToSafeInt32(row["TotalCount"]),
                        Percentage = MakeSafe.ToSafeDecimal(row["Percentage"])
                    });
                }
            }

            return model;
        }
    }
}
