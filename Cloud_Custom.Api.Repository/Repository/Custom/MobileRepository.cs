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
    public class MobileRepository : IMobileRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public MobileRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<Mobile> DashBoardDetails(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                {
            new SqlParameter("@CompanyGI", user.CompanyGuid),
            new SqlParameter("@UserGuid", user.UserGuid)
        };

                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_DASHBOARD_GET]", sqlparameters);

                // Map to Mobile model
                return MapDashBoard(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private Mobile MapDashBoard(DataSet dataSet)
        {
            Mobile model = new Mobile();
            DashBoardDetails details = new DashBoardDetails();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                var row = dataSet.Tables[0].Rows[0];

                details.SALES = MakeSafe.ToSafeInt32(row["SALES"]);
                details.ALLOTED = MakeSafe.ToSafeInt32(row["ALLOTED"]);
                details.BOOKING = MakeSafe.ToSafeInt32(row["BOOKING"]);
                details.SALESPROGRESS = MakeSafe.ToSafeString(row["SALESPROGRESS"]);
                details.HOT = MakeSafe.ToSafeInt32(row["HOT"]);
                details.WARM = MakeSafe.ToSafeInt32(row["WARM"]);
                details.COLD = MakeSafe.ToSafeInt32(row["COLD"]);
                details.APPOINTMENTS = MakeSafe.ToSafeInt32(row["APPOINTMENTS"]);
                details.Offers = MakeSafe.ToSafeInt32(row["OFFERS"]);
                model.DashBoardDetails = details;
            }

            return model;
        }


        public async Task<Mobile> SalesDetails(UserBase user, string fromDate, string toDate)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                {
            new SqlParameter("@COMPANYGI", user.CompanyGuid),
            new SqlParameter("@USERGI", user.UserGuid),
            new SqlParameter("@FROMDATE", fromDate),
            new SqlParameter("@TODATE", toDate)
        };

                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_SALES_DETAILS_GET]", sqlparameters);

                return MapSalesDetails(ds);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Mobile> MobileSalesDetails(UserBase user, string fromDate, string toDate, Guid EmployeeUserGI)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                {
            new SqlParameter("@COMPANYGI", user.CompanyGuid),
            //new SqlParameter("@USERGI", user.UserGuid),
            new SqlParameter("@FROMDATE", fromDate),
            new SqlParameter("@TODATE", toDate),
            new SqlParameter("@EmployeeUserGI", EmployeeUserGI)
        };

                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_SALES_DETAILS_GET]", sqlparameters);

                return MapSalesDetails(ds);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private Mobile MapSalesDetails(DataSet dataSet)
        {
            var model = new Mobile();
            model.SalesDetails = new SalesDetails(); 

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                var row = dataSet.Tables[0].Rows[0];

                model.SalesDetails = new SalesDetails
                {
                    TotalSales = MakeSafe.ToSafeInt32(row["TOTALSALES"]),
                    SalesTarget = MakeSafe.ToSafeInt32(row["SALESTARGET"]),
                    TotalSalesAmount = MakeSafe.ToSafeDecimal(row["TOTALSALESAMOUNT"]),
                    InsuranceAchievedQuantity = MakeSafe.ToSafeInt32(row["INSURANCEACHIEVEDQUANTITY"]),
                    InsuranceAchievedPercentage = MakeSafe.ToSafeDecimal(row["INSURANCEACHIEVEDPERCENTAGE"]),
                    ExchangeAchievedQuantity = MakeSafe.ToSafeInt32(row["EXCHANGEACHIEVEDQUANTITY"]),
                    ExchangeAchievedPercentage = MakeSafe.ToSafeDecimal(row["EXCHANGEACHIEVEDPERCENTAGE"]),
                    GAAchievedQuantity = MakeSafe.ToSafeInt32(row["GAACHIEVEDQUANTITY"]),
                    GAAchievedPercentage = MakeSafe.ToSafeDecimal(row["GAACHIEVEDPERCENTAGE"]),
                    SpecialDiscountAmount = MakeSafe.ToSafeDecimal(row["SPECIALDISCOUNTAMOUNT"]),
                    SpecialDiscountPercAmount = MakeSafe.ToSafeDecimal(row["SPECIALDISCOUNTPERCARAMOUNT"]),


                    SalesPercentage = MakeSafe.ToSafeDecimal(row["TOTALSALESPERCENTAGE"]),
                   
                    GAAmount = MakeSafe.ToSafeDecimal(row["GAAMOUNT"]),
                    GAPerCar = MakeSafe.ToSafeDecimal(row["GAPERCAR"]),
                    SpecialDiscountQuantity = MakeSafe.ToSafeInt32(row["SPECIALDISCOUNTNO"]),
                    ExtendedAchievedCount = MakeSafe.ToSafeInt32(row["EXTENDED_WARRANTY_ACHIEVED_COUNT"]),
                    ExtendedAchievedPercentage = MakeSafe.ToSafeDecimal(row["EXTENDED_WARRANTY_ACHIEVED_PERCENTAGE"])                          
         };
            }

            return model;
        }


        public async Task<Mobile> GADetails(UserBase user, string fromDate, string toDate)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                  new SqlParameter("@COMPANYGI", user.CompanyGuid),
            new SqlParameter("@USERGI", user.UserGuid),
            new SqlParameter("@FROMDATE", fromDate),
            new SqlParameter("@TODATE", toDate)


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_GA_DETAILS_GET]", sqlparameters);
                return GAList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private Mobile GAList(DataSet dataSet)
        {
            var model = new Mobile();
            var list = new List<GADetails>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new GADetails
                    {
                        CustomerName = MakeSafe.ToSafeString(row["CUSTOMERNAME"]),
                        MobileNo = MakeSafe.ToSafeString(row["MOBILENO"]),
                        Model = MakeSafe.ToSafeString(row["MODEL"]),
                        Color = MakeSafe.ToSafeString(row["COLOR"]),
                        DeliveryDate = MakeSafe.ToSafeString(row["DELIVERYDATE"]),
                        InvoiceAmount = MakeSafe.ToSafeDecimal(row["INVOICEAMOUNT"]),
                        DiscountAmount = MakeSafe.ToSafeDecimal(row["DISCOUNTAMOUNT"]),
                        NetAmount = MakeSafe.ToSafeDecimal(row["NETAMOUNT"])
                    };

                    list.Add(item);
                }

                model.GADetails = list; 
            }

            return model;
        }


        public async Task<Mobile> BookingDetails(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                  new SqlParameter("@COMPANYGI", user.CompanyGuid),
            new SqlParameter("@USERGI", user.UserGuid),
            


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_BOOKING_DETAILS]", sqlparameters);
                return BookingDetails(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private Mobile BookingDetails(DataSet dataSet)
        {
            var model = new Mobile();
            var list = new List<BookingDetails>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new BookingDetails
                    {
                        CustomerName = MakeSafe.ToSafeString(row["CUSTOMERNAME"]),
                        ModelName = MakeSafe.ToSafeString(row["MODELNAME"]),
                        Variant = MakeSafe.ToSafeString(row["VARIANT"]),
                        MobileNo = MakeSafe.ToSafeString(row["MOBILENO"]),
                        AmountPaid = MakeSafe.ToSafeDecimal(row["AMOUNTPAID"]),
                        BookingDate = MakeSafe.ToSafeDateTime(row["BOOKINGDATE"]),
                        HowManyDaysAgo = MakeSafe.ToSafeString(row["HOWMANYDAYSAGO"]),
                        BalanceAmount = MakeSafe.ToSafeDecimal(row["BalanceAmount"])
                    };

                    list.Add(item);
                }

                model.BookingDetails = list;
            }

            return model;
        }

        public async Task<Mobile> MobileBookingDetails(UserBase user, Guid EmployeeUserGI)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                  new SqlParameter("@COMPANYGI", user.CompanyGuid),
                  //new SqlParameter("@USERGI", user.UserGuid),
                  new SqlParameter("@EmployeeUserGI", EmployeeUserGI),



            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_BOOKING_DETAILS]", sqlparameters);
                return BookingDetails(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }


        public async Task<Mobile> LeadDetails(UserBase user,string Type)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                  new SqlParameter("@COMPANYGI", user.CompanyGuid),
            new SqlParameter("@USERGI", user.UserGuid),
            new SqlParameter("@Type", Type),



            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_LEADS_DETAILS]", sqlparameters);
                 return LeadDetails(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }


        public async Task<Mobile> MobileLeadDetails(UserBase user, string Type, Guid EmployeeUserGI)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                  new SqlParameter("@COMPANYGI", user.CompanyGuid),
                  //new SqlParameter("@USERGI", user.UserGuid),
                  new SqlParameter("@Type", Type),
                  new SqlParameter("@EmployeeUserGI", EmployeeUserGI),



            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_LEADS_DETAILS]", sqlparameters);
                return LeadDetails(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private Mobile LeadDetails(DataSet dataSet)
        {
            var model = new Mobile();
            var list = new List<LeadDetails>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new LeadDetails
                    {
                        CustomerName = MakeSafe.ToSafeString(row["CUSTOMERNAME"]),
                        ModelName = MakeSafe.ToSafeString(row["MODELNAME"]),
                        Variant = MakeSafe.ToSafeString(row["VARIANT"]),
                        MobileNo = MakeSafe.ToSafeString(row["MOBILENO"]),
                        ExecutiveName = MakeSafe.ToSafeString(row["EXECUTIVENAME"]),
                        LastContactDate = MakeSafe.ToSafeString(row["LASTCONTACTDATE"]),
                        HowManyDaysAgo = MakeSafe.ToSafeString(row["HOWMANYDAYSAGO"]),
                        LEADTYPE = MakeSafe.ToSafeString(row["LEADTYPE"])
                    };

                    list.Add(item);
                }

                model.LeadDetails = list;
            }

            return model;
        }


        public async Task<Mobile> BrowseDetails(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                {
            new SqlParameter("@COMPANYGI", user.CompanyGuid),
            new SqlParameter("@USERGI", user.UserGuid),
        };

                var ds = await _sql.GetDataSetAsync("[DMS].[SP_BROWSE_DETAILS]", sqlparameters);
                return VehicleBrowse(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private Mobile VehicleBrowse(DataSet dataSet)
        {
            var model = new Mobile();
            var list = new List<VehicleBrowse>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new VehicleBrowse
                    {
                        VehicleModel = MakeSafe.ToSafeString(row["VehicleModel"]),
                        Variant = MakeSafe.ToSafeString(row["Variant"]),
                        TransmissionType = MakeSafe.ToSafeString(row["TransmissionType"]),
                        FuelType = MakeSafe.ToSafeString(row["FuelType"]),
                        ExShowroomPrice = MakeSafe.ToSafeDecimal(row["ExShowroomPrice"])
                    };

                    list.Add(item);
                }

                model.Vehicles = list;
            }

            return model;
        }



        public async Task<Mobile> Offers(UserBase user,int TabCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                {
            new SqlParameter("@CompanyGI", user.CompanyGuid),
            new SqlParameter("@UserGI", user.UserGuid),
             new SqlParameter("@TabCode", TabCode),
        };

                var ds = await _sql.GetDataSetAsync("[DMS].[SP_GET_SPOT_INCENTIVE_OFFERS]", sqlparameters);
                return Offers(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private Mobile Offers(DataSet dataSet)
        {
            var model = new Mobile();
            var list = new List<Offers>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new Offers
                    {
                        Message = MakeSafe.ToSafeString(row["OfferMessage"]),
                        OfferFromDate = MakeSafe.ToSafeDateTime(row["OfferFromDate"]),
                        OfferToDate = MakeSafe.ToSafeDateTime(row["OfferToDate"]),
                        ExecutiveAmount = MakeSafe.ToSafeDecimal(row["ExecutiveAmount"]),
                        TeamLeaderAmount = MakeSafe.ToSafeDecimal(row["TeamLeaderAmount"]),
                        StoreManagerAmount = MakeSafe.ToSafeDecimal(row["StoreManagerAmount"]),

                    };

                    list.Add(item);
                }

                model.Offers = list;
            }

            return model;
        }
    }
}
