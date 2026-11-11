using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Repository.IRepository.General;
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
    public class MisModelWiseReportRepository : IMisModelWiseReportRepository
    {
        private readonly ISqlConnectionProvider _sql;
        private readonly ICommonRepository _common;

        public MisModelWiseReportRepository(ISqlConnectionProvider sql, ICommonRepository common)
        {
            _sql = sql;
            _common = common;

        }



        public async Task<MisModelWiseReport> GetList(UserBase user, int ReportType, int Branch, int Model, int SourceOfEnq, int Color, int Region,int Channel)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@ReportType",ReportType),

                  new SqlParameter("@BranchCode",Branch),
                 new SqlParameter("@ModelCode",Model),
                 new SqlParameter("@SourceOfEnquiry",SourceOfEnq),
                 new SqlParameter("@Color",Color),
                 new SqlParameter("@Region",Region),
                 new SqlParameter("@Channel",Channel)

        };
                var ds = await _sql.GetDataSetAsync("[DMS].[USP_EBR_PERFORMANCE_OVER_LY]", sqlparameters);
                return BindDashboard(ds );

            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private MisModelWiseReport BindDashboard(DataSet ds)
        {
            MisModelWiseReport model = new MisModelWiseReport();

            model.List = new List<MisModelWiseReport>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    model.List.Add(new MisModelWiseReport
                    {
                        PBKG = MakeSafe.ToSafeInt32(row["PBKG"]),
                        STK = MakeSafe.ToSafeInt32(row["STK"]),
                        ModeName = MakeSafe.ToSafeString(row["Mode"]),
                        EnquiryTY = MakeSafe.ToSafeInt32(row["Enquiry_TY"]),
                        EnquiryLY = MakeSafe.ToSafeInt32(row["Enquiry_LY"]),
                        EnquiryGrowth = MakeSafe.ToSafeDecimal(row["Enquiry_Growth"]),
                        EnquiryLM = MakeSafe.ToSafeInt32(row["Enquiry_LM"]),
                        EnquiryGrowthLM = MakeSafe.ToSafeDecimal(row["Enquiry_Growth_LM"]),


                        BookingTY = MakeSafe.ToSafeInt32(row["Booking_TY"]),
                        BookingLY = MakeSafe.ToSafeInt32(row["Booking_LY"]),
                        BookingGrowth = MakeSafe.ToSafeDecimal(row["Booking_Growth"]),
                        BookingLM = MakeSafe.ToSafeInt32(row["Booking_LM"]),
                        BookingGrowthLM = MakeSafe.ToSafeDecimal(row["Booking_Growth_LM"]),

                        RetailTY = MakeSafe.ToSafeInt32(row["Retail_TY"]),
                        RetailLY = MakeSafe.ToSafeInt32(row["Retail_LY"]),
                        RetailGrowth = MakeSafe.ToSafeDecimal(row["Retail_Growth"]),
                        RetailLM = MakeSafe.ToSafeInt32(row["Retail_LM"]),
                        RetailGrowthLM = MakeSafe.ToSafeDecimal(row["Retail_Growth_LM"]),



                        EnquiryToBookingTY = MakeSafe.ToSafeDecimal(row["EnquiryToBooking_TY"]),
                        BookingToRetailTY = MakeSafe.ToSafeDecimal(row["BookingToRetail_TY"]),
                        EnquiryToRetailTY = MakeSafe.ToSafeDecimal(row["EnquiryToRetail_TY"]),
                        EnquiryToBookingLY = MakeSafe.ToSafeDecimal(row["EnquiryToBooking_LY"]),
                        BookingToRetailLY = MakeSafe.ToSafeDecimal(row["BookingToRetail_LY"]),
                        EnquiryToRetailLY = MakeSafe.ToSafeDecimal(row["EnquiryToRetail_LY"]),
                        NetRetailAmountTY = MakeSafe.ToSafeDecimal(row["NetRetailAmount_TY"]),
                        NetRetailAmountLY = MakeSafe.ToSafeDecimal(row["NetRetailAmount_LY"]),
                        NetRetailGrowth = MakeSafe.ToSafeDecimal(row["NetRetailGrowth"])

                    });
                }
            }

            return model;
        }





        //private MisModelWiseReport BindDashboard(DataSet ds,int TYPE)
        //{
        //    MisModelWiseReport model = new MisModelWiseReport();

        //    model.List = new List<MisModelWiseReport>();

        //    {
        //        if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
        //        {
        //            {
        //                {
        //                    ModeName = MakeSafe.ToSafeString(row["ModeName"]),
        //                    ModeCode = MakeSafe.ToSafeInt32(row["ModeCode"]),
        //                    TYEB = MakeSafe.ToSafeInt32(row["TYEB"]),
        //                    TYBR = MakeSafe.ToSafeInt32(row["TYBR"]),
        //                    TYER = MakeSafe.ToSafeInt32(row["TYER"]),
        //                    LYEB = MakeSafe.ToSafeInt32(row["LYEB"]),
        //                    LYBR = MakeSafe.ToSafeInt32(row["LYBR"]),
        //                    LYER = MakeSafe.ToSafeInt32(row["LYER"]),
        //                    COEB = MakeSafe.ToSafeInt32(row["COEB"]),
        //                    COBR = MakeSafe.ToSafeInt32(row["COBR"]),
        //                    COER = MakeSafe.ToSafeInt32(row["COER"])

        //                });
        //            }
        //        }

        //    }
        //    else 
        //    { 
        //        if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
        //        {
        //            foreach (DataRow row in ds.Tables[0].Rows)
        //            {
        //                model.List.Add(new MisModelWiseReport
        //                {
        //                    ModeName = MakeSafe.ToSafeString(row["ModeName"]),
        //                    ModeCode = MakeSafe.ToSafeInt32(row["ModeCode"]),
        //                    PBKG = MakeSafe.ToSafeInt32(row["PBKG"]),
        //                    STK = MakeSafe.ToSafeInt32(row["STK"]),
        //                    TY = MakeSafe.ToSafeInt32(row["TY"]),
        //                    LY = MakeSafe.ToSafeInt32(row["LY"]),
        //                    GOLY = MakeSafe.ToSafeInt32(row["GOLY"]),
        //                    LM = MakeSafe.ToSafeInt32(row["LM"]),
        //                    GOLM = MakeSafe.ToSafeInt32(row["GOLM"])

        //                });
        //            }
        //        }
        //    }


        //    if (TYPE == 4)
        //    {

        //        if ((ds.Tables.Count > 0) && (ds.Tables[1].Rows.Count > 0))
        //        {
        //            DataRow row = ds.Tables[1].Rows[0];

        //            model.TTYEB = MakeSafe.ToSafeInt32(row["TTYEB"]);
        //            model.TTYBR = MakeSafe.ToSafeInt32(row["TTYBR"]);
        //            model.TTYER = MakeSafe.ToSafeInt32(row["TTYER"]);
        //            model.TLYEB = MakeSafe.ToSafeInt32(row["TLYEB"]);
        //            model.TLYBR = MakeSafe.ToSafeInt32(row["TLYBR"]);
        //            model.TLYER = MakeSafe.ToSafeInt32(row["TLYER"]);

        //            model.TCOEB = MakeSafe.ToSafeInt32(row["TCOEB"]);
        //            model.TCOBR = MakeSafe.ToSafeInt32(row["TCOBR"]);
        //            model.TCOER = MakeSafe.ToSafeInt32(row["TCOER"]);

        //        }





        //    }
        //    else
        //    {
        //        if ((ds.Tables.Count > 0) && (ds.Tables[1].Rows.Count > 0))
        //        {
        //            DataRow row = ds.Tables[1].Rows[0];

        //            model.TotalGOLM = MakeSafe.ToSafeInt32(row["TotalGOLM"]);
        //            model.TotalGOLY = MakeSafe.ToSafeInt32(row["TotalGOLY"]);
        //            model.TotalLM = MakeSafe.ToSafeInt32(row["TotalLM"]);
        //            model.TotalTY = MakeSafe.ToSafeInt32(row["TotalTY"]);
        //            model.TotalTY = MakeSafe.ToSafeInt32(row["TotalTY"]);

        //        }

        //    }



        //        return model;
        //}
    }
}