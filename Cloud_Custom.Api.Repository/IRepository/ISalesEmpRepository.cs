using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository
{
   public  interface ISalesEmpRepository
    {
        Task<SalesEmp> GetList(UserBase user, Filter filter, int Dealer,int Branch,int SalesDes,int Incentive,int Department,int Region,int SeniorRegManager);
        public Task<ResponseEntity> Save(UserBase user, string mode, SalesEmp input);
        public Task<SalesEmp> GetEmployeeDetails(UserBase User, int EmployeeCode, string mode);
        public Task<ResponseEntity> DeleteSalesEmp(UserBase user, SalesEmp model);


        public Task<ResponseEntity> PopupSave(UserBase user, SalesEmp model);
        Task<SalesEmp> GetPopupList(UserBase user, int EmployeeCode);

        public Task<ResponseEntity> DeletePopup(UserBase user, int EmployeeCode, int DtCode);

        Task<SalesEmp> GetExportToExcel(UserBase userBase, int Dealer, int Branch, int SalesDes, int Incentive, int Department, int Region);
    }
}
