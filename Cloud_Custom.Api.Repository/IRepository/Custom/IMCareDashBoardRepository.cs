using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IMCareDashBoardRepository
    {
        Task<MCareDashBoard> GetList(UserBase user);
        Task<MCareDashBoard> GetMonthlyRevenueData(UserBase user, string monthlyRevenue);
        Task<MCareDashBoard> GetTop10Data(UserBase user, string Top,int Region);
        //Task<MCareDashBoard> TotalPopup(UserBase user, int PlanCode);
        //Task<MCareDashBoard> PolicyPopup(UserBase user, int PlanCode);
        //Task<MCareDashBoard> CancelledPopup(UserBase user, int PlanCode);
        //Task<MCareDashBoard> ExpiredPopup(UserBase user, int PlanCode);
        //Task<MCareDashBoard> RenewalPopup(UserBase user, int PlanCode);
        //Task<MCareDashBoard> CurrentplanPopup(UserBase user, int PlanCode);
        Task<MCareDashBoard> Popup(UserBase user, int PlanCode,string Type);
    }
}
