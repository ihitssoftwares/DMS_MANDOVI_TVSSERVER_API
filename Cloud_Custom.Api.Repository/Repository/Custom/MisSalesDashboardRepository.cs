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
    public class MisSalesDashboardRepository : IMisSalesDashboardRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public MisSalesDashboardRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<MisSalesDashboard> GetTabDetails(UserBase user, int Month, string Fromdate, string ToDate, int Type,  string Grid, int Region, int PageNo = 1, int PageSize = 10)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),

                new SqlParameter("@From",Fromdate),
                new SqlParameter("@To",ToDate),
                new SqlParameter("@Month",Month),
                new SqlParameter("@Region",Region),
                new SqlParameter("@Type",Type),
                new SqlParameter("@PageNo",PageNo),
                new SqlParameter("@PageSize",PageSize),
                new SqlParameter("@Grid",Grid)

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_SALE_DASHBOARD_DETAILS]", sqlparameters);

            return PopulateGetTabDetails(ds, Grid);

        }
        public MisSalesDashboard PopulateGetTabDetails(DataSet ds, string Grid)
        {
            MisSalesDashboard model = new MisSalesDashboard();
            model.BookingNDRetialList = new List<MisSalesDashboard>();
            model.BookingNDInventoryList = new List<MisSalesDashboard>();
            if (Grid != null && Grid.Trim() == "Execl")
            {
                if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var item = new MisSalesDashboard
                        {
                            Region = MakeSafe.ToSafeString(row["Region"]),
                            TotalbookingList = MakeSafe.ToSafeInt32(row["TotalBooking"]),
                            TotalBookingCanceledList = MakeSafe.ToSafeInt32(row["BookingCanceled"]),
                            NetBooking = MakeSafe.ToSafeInt32(row["NetBooking"]),
                            TotalRetailed = MakeSafe.ToSafeInt32(row["TotalRetail"]),
                            RetailCanceled = MakeSafe.ToSafeInt32(row["RetailCancel"]),
                            NetRetailed = MakeSafe.ToSafeInt32(row["NetRetail"]),
                            PendingBookingLIST = MakeSafe.ToSafeInt32(row["PendingBooking"]),
                        };

                        model.BookingNDRetialList.Add(item);
                    }
                }
                return model;
            }
            if (Grid != null && Grid.Trim() == "InExecl")
            {
                if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var item = new MisSalesDashboard
                        {
                            Model = MakeSafe.ToSafeString(row["model"]),
                            variant = MakeSafe.ToSafeString(row["Variant"]),
                            Colour = MakeSafe.ToSafeString(row["Color"]),
                            pendingBookinging = MakeSafe.ToSafeInt32(row["PendingBooking"]),
                            InstockList = MakeSafe.ToSafeInt32(row["Instock"]),
                            IntransitList = MakeSafe.ToSafeInt32(row["Intransit"]),
                            AllotedList = MakeSafe.ToSafeInt32(row["Allotted"]),
                            FreeStockList = MakeSafe.ToSafeInt32(row["FreeStock"]),
                        };

                        model.BookingNDInventoryList.Add(item);
                    }
                }
                return model;
            }

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                model.Totalbooking = MakeSafe.ToSafeInt32(row["TotalBooking"]);
                model.TotalBookingNotCanceled = MakeSafe.ToSafeInt32(row["TotalBookingNotCancel"]);
                model.TotalBookingCanceled = MakeSafe.ToSafeInt32(row["TotalBookingCancel"]);
                model.Sales = MakeSafe.ToSafeInt32(row["TotalSales"]);
                model.TotalSalesCancel = MakeSafe.ToSafeInt32(row["TotalSalesCanceled"]);
                model.TotalSalesNotCancel = MakeSafe.ToSafeInt32(row["TotalSalesNotCanceled"]);
                model.TotalPendingBooking = MakeSafe.ToSafeInt32(row["TotalPendingBooking"]);
                model.TotalPendingBookingnotCancel = MakeSafe.ToSafeInt32(row["PendingNotCanceled"]);
                model.TotalPendingBookingCancel = MakeSafe.ToSafeInt32(row["PendingBookingCanceled"]);
               
                model.PendingAllotted = MakeSafe.ToSafeInt32(row["TotalPendBooking"]);
                model.PendingBookingNotAlloted = MakeSafe.ToSafeInt32(row["TotalPendBookingNotAllotted"]);
                model.PendingBookingAlloted = MakeSafe.ToSafeInt32(row["TotalPendBookinggAlloted"]);
               
                model.InStock = MakeSafe.ToSafeInt32(row["TotalInstock"]);
                model.InstockAlloted = MakeSafe.ToSafeInt32(row["TotalInstockAlloted"]);
                model.InstockNotAlloted = MakeSafe.ToSafeInt32(row["TotalInstockNotAlloted"]);

                model.InTransit = MakeSafe.ToSafeInt32(row["TotalIntransit"]);
                model.InTransitNotAlloted = MakeSafe.ToSafeInt32(row["TotalIntransitNotAlloted"]);
                model.InTransitAlloted = MakeSafe.ToSafeInt32(row["TotalIntransitAlloted"]);

                model.Total = MakeSafe.ToSafeInt32(row["Total"]);
                model.TotalAlloted = MakeSafe.ToSafeInt32(row["TotalAlloted"]);
                model.TotalNotAllotted = MakeSafe.ToSafeInt32(row["TotalNotAlloted"]);




            }
            model.BookingNDRetialList = new List<MisSalesDashboard>();
            if ((ds.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    var item = new MisSalesDashboard
                    {
                        Region = MakeSafe.ToSafeString(row["Region"]),
                        TotalbookingList = MakeSafe.ToSafeInt32(row["TotalBooking"]),
                        TotalBookingCanceledList = MakeSafe.ToSafeInt32(row["BookingCanceled"]),
                        NetBooking = MakeSafe.ToSafeInt32(row["NetBooking"]),
                        TotalRetailed = MakeSafe.ToSafeInt32(row["TotalRetail"]),
                        RetailCanceled = MakeSafe.ToSafeInt32(row["RetailCancel"]),
                        NetRetailed = MakeSafe.ToSafeInt32(row["NetRetail"]),
                        PendingBookingLIST = MakeSafe.ToSafeInt32(row["PendingBooking"]),
                    };

                    model.BookingNDRetialList.Add(item);
                }
            }

            model.BookingNDInventoryList = new List<MisSalesDashboard>();
            if ((ds.Tables[2]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[2].Rows)
                {
                    var item = new MisSalesDashboard
                    {
                        TotalCount = MakeSafe.ToSafeInt32(row["TotalCount"]),
                        ModelCode = MakeSafe.ToSafeInt32(row["ModelCode"]),
                        VariantCode = MakeSafe.ToSafeInt32(row["VariantCode"]),
                        Colourcode = MakeSafe.ToSafeInt32(row["Colourcode"]),
                        Model = MakeSafe.ToSafeString(row["model"]),
                        variant = MakeSafe.ToSafeString(row["Variant"]),
                        Colour = MakeSafe.ToSafeString(row["Color"]),
                        pendingBookinging = MakeSafe.ToSafeInt32(row["PendingBooking"]),
                        InstockList = MakeSafe.ToSafeInt32(row["Instock"]),
                        IntransitList = MakeSafe.ToSafeInt32(row["Intransit"]),
                        AllotedList = MakeSafe.ToSafeInt32(row["Allotted"]),
                        FreeStockList = MakeSafe.ToSafeInt32(row["FreeStock"]),
                    };

                    model.BookingNDInventoryList.Add(item);
                }
            }




            return model;
        }


        public async Task<MisSalesDashboard> GetList(UserBase user,int Month, string Fromdate, string ToDate, int Type, string Grid,int Region)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@From",Fromdate),
                new SqlParameter("@To",ToDate),
                new SqlParameter("@Month",Month),
                new SqlParameter("@Type",Type),
                new SqlParameter("@Grid",Grid),
                new SqlParameter("@Region",Region)


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DASHBOARD_LIST_BOOKING_SALES]", sqlparameters);

            return PopulateGetBranchWiseDetails(ds);

        }
        public MisSalesDashboard PopulateGetBranchWiseDetails(DataSet ds)
        {
            MisSalesDashboard model = new MisSalesDashboard();
            model.BookingNDRetialList = new List<MisSalesDashboard>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new MisSalesDashboard
                    {
                        Region = MakeSafe.ToSafeString(row["Region"]),
                        TotalbookingList = MakeSafe.ToSafeInt32(row["TotalBooking"]),
                        TotalBookingCanceledList = MakeSafe.ToSafeInt32(row["BookingCanceled"]),
                        NetBooking = MakeSafe.ToSafeInt32(row["NetBooking"]),
                        TotalRetailed = MakeSafe.ToSafeInt32(row["TotalRetail"]),
                        RetailCanceled = MakeSafe.ToSafeInt32(row["RetailCancel"]),
                        NetRetailed = MakeSafe.ToSafeInt32(row["NetRetail"]),
                        PendingBookingLIST = MakeSafe.ToSafeInt32(row["PendingBooking"]),
                    };

                    model.BookingNDRetialList.Add(item);
                }
            }
            

            return model;
        }   
        public async Task<MisSalesDashboard> GetInventoryList(UserBase user,int Month, string Fromdate, string ToDate, int Type, string Grid,int Region, int PageNo = 1, int PageSize = 10)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@From",Fromdate),
                new SqlParameter("@To",ToDate),
                new SqlParameter("@Month",Month),
                new SqlParameter("@Type",Type),
                new SqlParameter("@PageNo",PageNo),
                new SqlParameter("@PageSize",PageSize),
                new SqlParameter("@Region",Region)


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DASHBOARD_LIST_INVENTORY]", sqlparameters);

            return PopulateGetInventoryListDetails(ds);

        }
        public MisSalesDashboard PopulateGetInventoryListDetails(DataSet ds)
        {
            MisSalesDashboard model = new MisSalesDashboard();
            model.BookingNDInventoryList = new List<MisSalesDashboard>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new MisSalesDashboard
                    {
                        TotalCount = MakeSafe.ToSafeInt32(row["TotalCount"]),

                        Model = MakeSafe.ToSafeString(row["model"]),
                        variant = MakeSafe.ToSafeString(row["Variant"]),
                        Colour = MakeSafe.ToSafeString(row["Color"]),
                        pendingBookinging = MakeSafe.ToSafeInt32(row["PendingBooking"]),
                        InstockList = MakeSafe.ToSafeInt32(row["Instock"]),
                        IntransitList = MakeSafe.ToSafeInt32(row["Intransit"]),
                        AllotedList = MakeSafe.ToSafeInt32(row["Allotted"]),
                        FreeStockList = MakeSafe.ToSafeInt32(row["FreeStock"]),
                    };

                    model.BookingNDInventoryList.Add(item);
                }
            }

            return model;
        }

          public async Task<DataSet> GetRetailTabDetails(UserBase user,int Month, string Fromdate, string ToDate,int Region, int Type)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@From",Fromdate),
                new SqlParameter("@To",ToDate),
                new SqlParameter("@Month",Month),
                new SqlParameter("@Type",Type),
               
                new SqlParameter("@Region",Region)


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_RETAIL_TAB_DETAILS]", sqlparameters);
            return ds;

        }
    
  public async Task<DataSet> GetInventoryTabDetails(UserBase user,int Month, string Fromdate, string ToDate,int Region, int Type)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@From",Fromdate),
                new SqlParameter("@To",ToDate),
                new SqlParameter("@Month",Month),
                new SqlParameter("@Type",Type),
               
                new SqlParameter("@Region",Region)


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_INVENTORY_TAB_DETAILS]", sqlparameters);
            return ds;

        }
        public async Task<DataSet> GetInventoryBookingDetails(UserBase user, int Model, int Variant, int Color,int Region)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@Model",Model),
            
                new SqlParameter("@Variant",Variant),
                new SqlParameter("@Color",Color),
                new SqlParameter("@Region",Region),
               
  


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_INVENTORY_BOOKING_DETAILS]", sqlparameters);
            return ds;

        }
    


    }
}
