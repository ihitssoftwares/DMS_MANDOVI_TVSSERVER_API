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
    public class EmployeePerCarRepository : IEmployeePerCarRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public EmployeePerCarRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<EmployeePerCar> GetList(UserBase user, int Month)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@Month",Month),
               



            };
            var ds = await _sql.GetDataSetAsync("DMS.EMPLOYEE_PER_CAR_LIST", sqlparameters);

            return PopulateGetList(ds);

        }
        public EmployeePerCar PopulateGetList(DataSet ds)
        {

            EmployeePerCar model = new EmployeePerCar();
            List<EmployeePerCar> List = new List<EmployeePerCar>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new EmployeePerCar();
                    

                    item.Employeecode = MakeSafe.ToSafeInt32(row["EmployeeCode"]);
                    
                    item.EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]);
                    item.Store = MakeSafe.ToSafeString(row["Store"]);
                    item.Designation = MakeSafe.ToSafeString(row["Designation"]);
                    item.GrossPay = MakeSafe.ToSafeInt32(row["GrossPay"]);
                    item.IncentiveAmount = MakeSafe.ToSafeInt32(row["IncentiveAmount"]);
                    item.TotalCost = MakeSafe.ToSafeInt32(row["TotalCost"]);
                    item.NumberOfCarsSold = MakeSafe.ToSafeInt32(row["NumberOfCarsSold"]);
                    item.CostPerCar = MakeSafe.ToSafeInt32(row["CostPerCar"]);
                    List.Add(item);

                }

                model.EmployeePerCarList = List;
                return model;
            }
            return model;
        }
    }
}
