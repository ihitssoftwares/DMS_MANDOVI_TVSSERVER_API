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
   public  class DMSSalesMisRepository : IDMSSalesMisRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public DMSSalesMisRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<DMSSalesMis> GetTabDetails(UserBase user, int Delearship, string Fromdate, string ToDate)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
              
                new SqlParameter("@Fromdate",Fromdate),
                new SqlParameter("@ToDate",ToDate),
                new SqlParameter("@Delearship",Delearship),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_MIS_TAB_DETAILS]", sqlparameters);

            return PopulateGetTabDetails(ds);

        }
        public DMSSalesMis PopulateGetTabDetails(DataSet ds)
        {
            DMSSalesMis model = new DMSSalesMis();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                model.Sales = MakeSafe.ToSafeInt32(row["Sales"]);
                model.Vahan = MakeSafe.ToSafeInt32(row["Vahan"]);
                model.ExtendedWarranty = MakeSafe.ToSafeInt32(row["ExtendedWarranty"]);
                model.Finance = MakeSafe.ToSafeInt32(row["Finance"]);
                model.Exchange = MakeSafe.ToSafeInt32(row["Exchange"]);
                model.Gas = MakeSafe.ToSafeInt32(row["Gas"]);
                model.Insurance = MakeSafe.ToSafeInt32(row["Insurance"]);
                model.SalesPercentage = MakeSafe.ToSafeDecimal(row["SalesPerc"]);
                model.VahanPercentage = MakeSafe.ToSafeDecimal(row["VahanPerc"]);
                model.ExtendedWarrantyPercentage = MakeSafe.ToSafeDecimal(row["ExtendedWarrantyPerc"]);
                model.FinancePercentage = MakeSafe.ToSafeDecimal(row["FinancePerc"]);
                model.ExchangePercentage = MakeSafe.ToSafeDecimal(row["ExchangePerc"]);
                model.GasPercentage = MakeSafe.ToSafeDecimal(row["GasPerc"]);
                model.InsurancePercentage = MakeSafe.ToSafeDecimal(row["InsurancePerc"]);
                model.Booking = MakeSafe.ToSafeInt32(row["Booking"]);
                model.BookingPercentage = MakeSafe.ToSafeDecimal(row["Bookingperc"]);
                model.Enquiry = MakeSafe.ToSafeInt32(row["Enquiry"]);
                model.EnquiryPercentage = MakeSafe.ToSafeInt32(row["EnquiryPrec"]);
            }

            return model;
        }


        public async Task<DMSSalesMis> GetBranchWiseDetails(UserBase user, int Delearship,  string Fromdate, string ToDate)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                  
                new SqlParameter("@Fromdate",Fromdate),
                new SqlParameter("@ToDate",ToDate),
                new SqlParameter("@Delearship",Delearship),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_BRANCH_WISE_SALES_CHART]", sqlparameters);

            return PopulateGetBranchWiseDetails(ds);

        }
        public DMSSalesMis PopulateGetBranchWiseDetails(DataSet ds)
        {
            DMSSalesMis model = new DMSSalesMis();
            model.DMSSalesMisList = new List<DMSSalesMis>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new DMSSalesMis
                    {
                        SLNO = MakeSafe.ToSafeInt32(row["SLNO"]),
                        BranchName = MakeSafe.ToSafeString(row["BRANCHNAME"]),
                        TotalSales = MakeSafe.ToSafeInt32(row["TOTAL"]),
                        SALESDONE = MakeSafe.ToSafeInt32(row["SALESDONE"]),
                    };

                    model.DMSSalesMisList.Add(item);
                }
            }


            return model;
        }



        public async Task<DMSSalesMis> GetModelWiseDetails(UserBase user, int Delearship, string Fromdate, string ToDate)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                  
                new SqlParameter("@Fromdate",Fromdate),
                new SqlParameter("@ToDate",ToDate),
                new SqlParameter("@Delearship",Delearship),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_MODEL_WISE_SALES_CHART]", sqlparameters);

            return PopulateGetModelWiseDetails(ds);

        }
        public DMSSalesMis PopulateGetModelWiseDetails(DataSet ds)
        {
            DMSSalesMis model = new DMSSalesMis();
            model.ModelList = new List<DMSSalesMis>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new DMSSalesMis
                    {
                        SLNO = MakeSafe.ToSafeInt32(row["SLNO"]),
                        ModelName = MakeSafe.ToSafeString(row["MODELNAME"]),
                        TotalSales = MakeSafe.ToSafeInt32(row["TOTALSALES"]),
                        SALESDONE = MakeSafe.ToSafeInt32(row["SALESDONE"]),
                    };

                    model.ModelList.Add(item);
                }
            }


            return model;
        }



        public async Task<DMSSalesMis> GetTLWiseDetails(UserBase user, int Delearship,   string Fromdate, string ToDate)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                  
                new SqlParameter("@Fromdate",Fromdate),
                new SqlParameter("@ToDate",ToDate),
                new SqlParameter("@Delearship",Delearship),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_TL_WISE_SALES_DETAILS]", sqlparameters);

            return PopulateGetTLWiseDetails(ds);

        }
        public DMSSalesMis PopulateGetTLWiseDetails(DataSet ds)
        {
            DMSSalesMis model = new DMSSalesMis();
            model.TLList = new List<DMSSalesMis>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new DMSSalesMis
                    {
                        SLNO = MakeSafe.ToSafeInt32(row["SLNO"]),
                        EmployeeCode = MakeSafe.ToSafeInt32(row["EMPLOYEECODE"]),
                        TLName = MakeSafe.ToSafeString(row["TLNAME"]),
                        Target = MakeSafe.ToSafeInt32(row["TARGET"]),
                        MinimumAchievement = MakeSafe.ToSafeInt32(row["MINIMUM"]),
                    };

                    model.TLList.Add(item);
                }
            }


            return model;
        }



        public async Task<DMSSalesMis> GetTLVSEMPLOYEEDetails(UserBase user, int Delearship,   string Fromdate, string ToDate, int TLEmployeeCode)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                  
                new SqlParameter("@Fromdate",Fromdate),
                new SqlParameter("@ToDate",ToDate),
                new SqlParameter("@Delearship",Delearship),
                 new SqlParameter("@TLEMPCODE",TLEmployeeCode),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_TLVS_EMPLOYEE_WISE_SALES_DETAILS]", sqlparameters);

            return PopulateGetTLVSEMPLOYEEDetails(ds);

        }
        public DMSSalesMis PopulateGetTLVSEMPLOYEEDetails(DataSet ds)
        {
            DMSSalesMis model = new DMSSalesMis();
            model.TLVSEMPLOYEELIST = new List<DMSSalesMis>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new DMSSalesMis
                    {
                        SLNO = MakeSafe.ToSafeInt32(row["SLNO"]),
                        EmployeeCode = MakeSafe.ToSafeInt32(row["EMPLOYEECODE"]),
                        TLName = MakeSafe.ToSafeString(row["EMPLOYEENAME"]),
                        Target = MakeSafe.ToSafeInt32(row["TARGET"]),
                        MinimumAchievement = MakeSafe.ToSafeInt32(row["MINIMUM"]),
                    };

                    model.TLVSEMPLOYEELIST.Add(item);
                }
            }


            return model;
        }


        public async Task<DMSSalesMis> GetVariantWiseDetails(UserBase user, int Delearship,   string Fromdate, string ToDate)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                  
                new SqlParameter("@Fromdate",Fromdate),
                new SqlParameter("@ToDate",ToDate),
                new SqlParameter("@Delearship",Delearship),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_VARIANT_WISE_SALES_DETAILS]", sqlparameters);

            return PopulateGetVariantWiseDetails(ds);

        }
        public DMSSalesMis PopulateGetVariantWiseDetails(DataSet ds)
        {
            DMSSalesMis model = new DMSSalesMis();
            model.VariantWiseList = new List<DMSSalesMis>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new DMSSalesMis
                    {
                        SLNO = MakeSafe.ToSafeInt32(row["SLNO"]),
                        ModelName = MakeSafe.ToSafeString(row["VARIANT"]),
                      
                        SALESDONE = MakeSafe.ToSafeInt32(row["SALESDONE"]),
                        VariantDes = MakeSafe.ToSafeString(row["VARIANTDESC"]),
                     
                    };

                    model.VariantWiseList.Add(item);
                }
            }


            return model;
        }



        public async Task<DMSSalesMis> GetV1Details(UserBase user, int Branch, string Fromdate, string ToDate, int Model)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),

                new SqlParameter("@Fromdate",Fromdate),
                new SqlParameter("@ToDate",ToDate),
                new SqlParameter("@Branch",Branch),
                 new SqlParameter("@Model",Model),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_SALES_MIS_DASHBOARD_NEW]", sqlparameters);

            return PopulateSalesMISDashboardV1(ds);

        }

        public DMSSalesMis PopulateSalesMISDashboardV1(DataSet ds)
        {
            DMSSalesMis model = new DMSSalesMis();

            model.KPISummaryList = new List<DMSSalesMis>();
            model.PipelineList = new List<DMSSalesMis>();
            model.PipelinePendingList = new List<DMSSalesMis>();
            model.MonthlySalesTrendList = new List<DMSSalesMis>();
            model.EnquiryStatusList = new List<DMSSalesMis>();
            model.ModelWiseEnquiryList = new List<DMSSalesMis>();
            model.ModelWiseSalesList = new List<DMSSalesMis>();
            model.BranchPerformanceList = new List<DMSSalesMis>();
            model.ExecutivePerformanceList = new List<DMSSalesMis>();
            model.SalesExceptionList = new List<DMSSalesMis>();

            //=========================================================
            // Table 0 - KPI Summary
            //=========================================================

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                model.TotalEnquiries = MakeSafe.ToSafeInt32(row["TotalEnquiries"]);
                model.TotalBookings = MakeSafe.ToSafeInt32(row["TotalBookings"]);
                model.TotalSalesCount = MakeSafe.ToSafeInt32(row["TotalSales"]);
                model.SalesValue = MakeSafe.ToSafeDecimal(row["SalesValue"]);
                model.AverageInvoice = MakeSafe.ToSafeDecimal(row["AverageInvoice"]);
                model.BookingConversion = MakeSafe.ToSafeDecimal(row["BookingConversion"]);
                model.InvoiceConversion = MakeSafe.ToSafeDecimal(row["InvoiceConversion"]);
              
            }


            //if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            //{
            //    foreach (DataRow row in ds.Tables[0].Rows)
            //    {
            //        model.KPISummaryList.Add(new DMSSalesMis
            //        {
            //            TotalEnquiries = MakeSafe.ToSafeInt32(row["TotalEnquiries"]),
            //            TotalBookings = MakeSafe.ToSafeInt32(row["TotalBookings"]),
            //            TotalSalesCount = MakeSafe.ToSafeInt32(row["TotalSales"]),
            //            SalesValue = MakeSafe.ToSafeDecimal(row["SalesValue"]),
            //            AverageInvoice = MakeSafe.ToSafeDecimal(row["AverageInvoice"]),
            //            BookingConversion = MakeSafe.ToSafeDecimal(row["BookingConversion"]),
            //            InvoiceConversion = MakeSafe.ToSafeDecimal(row["InvoiceConversion"])
            //        });
            //    }
            //}

            //=========================================================
            // Table 1 - Pipeline
            //=========================================================


            if ((ds.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = ds.Tables[1].Rows[0];

                model.Enquiries = MakeSafe.ToSafeInt32(row["Enquiries"]);
                model.OrderBookings = MakeSafe.ToSafeInt32(row["OrderBookings"]);
                model.Invoices = MakeSafe.ToSafeInt32(row["Invoices"]);
                model.VehiclesInStock = MakeSafe.ToSafeInt32(row["VehiclesInStock"]);
              

            }


            //if ((ds.Tables[1]?.Rows?.Count ?? 0) > 0)
            //{
            //    foreach (DataRow row in ds.Tables[1].Rows)
            //    {
            //        model.PipelineList.Add(new DMSSalesMis
            //        {
            //            Enquiries = MakeSafe.ToSafeInt32(row["Enquiries"]),
            //            OrderBookings = MakeSafe.ToSafeInt32(row["OrderBookings"]),
            //            Invoices = MakeSafe.ToSafeInt32(row["Invoices"]),
            //            VehiclesInStock = MakeSafe.ToSafeInt32(row["VehiclesInStock"])
            //        });
            //    }
            //}

            //=========================================================
            // Table 2 - Pipeline Pending
            //=========================================================
            if ((ds.Tables[2]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = ds.Tables[2].Rows[0];

                model.OrderBookingPending = MakeSafe.ToSafeInt32(row["OrderBookingPending"]);
                model.InvoicePending = MakeSafe.ToSafeInt32(row["InvoicePending"]);
                model.VehiclePending = MakeSafe.ToSafeInt32(row["VehiclePending"]);
                model.AllocationPending = MakeSafe.ToSafeInt32(row["AllocationPending"]);
            }



            //if ((ds.Tables[2]?.Rows?.Count ?? 0) > 0)
            //{
            //    foreach (DataRow row in ds.Tables[2].Rows)
            //    {
            //        model.PipelinePendingList.Add(new DMSSalesMis
            //        {
            //            OrderBookingPending = MakeSafe.ToSafeInt32(row["OrderBookingPending"]),
            //            InvoicePending = MakeSafe.ToSafeInt32(row["InvoicePending"]),
            //            VehiclePending = MakeSafe.ToSafeInt32(row["VehiclePending"]),
            //            AllocationPending = MakeSafe.ToSafeInt32(row["AllocationPending"])
            //        });
            //    }
            //}

            //=========================================================
            // Table 3 - Monthly Trend
            //=========================================================

           


            if ((ds.Tables[3]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[3].Rows)
                {
                    model.MonthlySalesTrendList.Add(new DMSSalesMis
                    {
                        MonthName = MakeSafe.ToSafeString(row["MonthName"]),
                        YearNo = MakeSafe.ToSafeInt32(row["YearNo"]),
                        Enquiries = MakeSafe.ToSafeInt32(row["Enquiries"]),
                        Bookings = MakeSafe.ToSafeInt32(row["Bookings"]),
                        Sales = MakeSafe.ToSafeInt32(row["Sales"])
                    });
                }
            }

            //=========================================================
            // Table 4 - Enquiry Status
            //=========================================================





            if ((ds.Tables[4]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[4].Rows)
                {
                    model.EnquiryStatusList.Add(new DMSSalesMis
                    {
                        EnquiryStatus = MakeSafe.ToSafeString(row["EnquiryStatus"]),
                        TotalCount = MakeSafe.ToSafeInt32(row["TotalCount"])
                    });
                }
            }

            //=========================================================
            // Table 5 - Model Wise Enquiry
            //=========================================================
            if ((ds.Tables[5]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[5].Rows)
                {
                    model.ModelWiseEnquiryList.Add(new DMSSalesMis
                    {
                        ModelName = MakeSafe.ToSafeString(row["ModelName"]),
                        Enquiries = MakeSafe.ToSafeInt32(row["Enquiries"])
                    });
                }
            }

            //=========================================================
            // Table 6 - Model Wise Sales
            //=========================================================
            if ((ds.Tables[6]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[6].Rows)
                {
                    model.ModelWiseSalesList.Add(new DMSSalesMis
                    {
                        ModelName = MakeSafe.ToSafeString(row["ModelName"]),
                        Sales = MakeSafe.ToSafeInt32(row["Sales"])
                    });
                }
            }

            //=========================================================
            // Table 7 - Branch Performance
            //=========================================================
            if ((ds.Tables[7]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[7].Rows)
                {
                    model.BranchPerformanceList.Add(new DMSSalesMis
                    {
                        Branch = MakeSafe.ToSafeString(row["Branch"]),
                        Enquiries = MakeSafe.ToSafeInt32(row["Enquiries"]),
                        Bookings = MakeSafe.ToSafeInt32(row["Bookings"]),
                        Sales = MakeSafe.ToSafeInt32(row["Sales"]),
                        ConversionPercentage = MakeSafe.ToSafeDecimal(row["ConversionPercentage"]),
                        SalesValue = MakeSafe.ToSafeDecimal(row["SalesValue"])
                    });
                }
            }

            //=========================================================
            // Table 8 - Executive Performance
            //=========================================================
            if ((ds.Tables[8]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[8].Rows)
                {
                    model.ExecutivePerformanceList.Add(new DMSSalesMis
                    {
                        Executive = MakeSafe.ToSafeString(row["Executive"]),
                        Branch = MakeSafe.ToSafeString(row["Branch"]),
                        Enquiries = MakeSafe.ToSafeInt32(row["Enquiries"]),
                        Bookings = MakeSafe.ToSafeInt32(row["Bookings"]),
                        Sales = MakeSafe.ToSafeInt32(row["Sales"]),
                        BookingPercentage = MakeSafe.ToSafeDecimal(row["BookingPercentage"]),
                        SalesPercentage = MakeSafe.ToSafeDecimal(row["SalesPercentage"]),
                        SalesValue = MakeSafe.ToSafeDecimal(row["SalesValue"])
                    });
                }
            }

            //=========================================================
            // Table 9 - Sales Exception
            //=========================================================
            if ((ds.Tables[9]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[9].Rows)
                {
                    model.SalesExceptionList.Add(new DMSSalesMis
                    {
                        ExceptionType = MakeSafe.ToSafeString(row["ExceptionType"]),
                        ReferenceNumber = MakeSafe.ToSafeString(row["ReferenceNumber"]),
                        CustomerReference = MakeSafe.ToSafeString(row["CustomerReference"]),
                        CustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
                        Branch = MakeSafe.ToSafeString(row["Branch"]),
                        TransactionDate = MakeSafe.ToSafeDateTime(row["TransactionDate"]),
                        Status = MakeSafe.ToSafeString(row["Status"])
                    });
                }
            }

            return model;
        }


    }
}
