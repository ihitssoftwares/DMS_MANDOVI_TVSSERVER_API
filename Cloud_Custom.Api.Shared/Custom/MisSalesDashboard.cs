using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
  public   class MisSalesDashboard
    {
        public int PageNo { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalCount { get; set; } 
        public string From { get; set; }
        public string To { get; set; }
        public Dropdown  Month { get; set; }
        public Dropdown dropdownregion { get; set; }
        public int Totalbooking { get; set; }    
        public int TotalBookingNotCanceled { get; set; }
        public int TotalBookingCanceled { get; set; }

        public int Sales { get; set; }
        public int TotalSalesCancel { get; set; }
        public int TotalSalesNotCancel { get; set; }

        public int TotalPendingBooking { get; set; }
        public int TotalPendingBookingCancel { get; set; }
        public int TotalPendingBookingnotCancel { get; set; }


        public string Region { get; set; }
        public int TotalbookingList { get; set; }
        public int TotalBookingCanceledList { get; set; }
        public int NetBooking { get; set; }
        public int TotalRetailed { get; set; }
        public int RetailCanceled { get; set; }
        public int NetRetailed { get; set; }
        public int PendingBookingLIST { get; set; }
        public List<MisSalesDashboard> BookingNDRetialList { get; set; }

        public int PendingAllotted { get; set; }
        public int PendingBookingAlloted { get; set; }
        public int PendingBookingNotAlloted { get; set; }

        public int InStock { get; set; }
        public int InstockAlloted { get; set; }
        public int InstockNotAlloted { get; set; }

        public int InTransit { get; set; }
        public int InTransitAlloted { get; set; }
        public int InTransitNotAlloted { get; set; }


        public int Total{ get; set; }
        public int TotalAlloted { get; set; }
        public int TotalNotAllotted { get; set; }

        public string Model { get; set; }
        public string variant { get; set; }
        public string Colour { get; set; }
        public string Fuel { get; set; }
        public int pendingBookinging { get; set; }
        public int InstockList { get; set; }
        public int IntransitList { get; set; }
        public int AllotedList { get; set; }
        public int FreeStockList { get; set; }
        public int ModelCode { get; set; }
        public int VariantCode { get; set; }
        public int Colourcode { get; set; }
        public List<MisSalesDashboard> BookingNDInventoryList { get; set; }
        public List<MisSalesDashboard> InventoryBookingDetails { get; set; }
        public string Branch { get; set; }
        public string BookingNum { get; set; }
        public string BookingDate { get; set; }
        public string Customer { get; set; }
        public string RetailModel { get; set; }
        public string status { get; set; }
        public string CanceledDate { get; set; }
        public int TotalRetailCount { get; set; }
        public int ActiveCount { get; set; }
        public int CanceledCount { get; set; }
        public List<MisSalesDashboard> RetailTabDetailsList { get; set; }

    }
}
