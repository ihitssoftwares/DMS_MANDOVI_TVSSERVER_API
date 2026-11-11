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
    public class VehicleGateRepository : IVehicleGateRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public VehicleGateRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<VehicleGate> GetList(UserBase user, int Branch,DateTime InDateTime)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@Branch",Branch),
                 new SqlParameter("@InDateTime",InDateTime),
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_VEHICLEGATE_LIST]", sqlparameters);
                return VehicleList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private VehicleGate VehicleList(DataSet dataSet)
        {
            VehicleGate model = new VehicleGate();
            List<VehicleGate> List = new List<VehicleGate>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new VehicleGate();



                    item.RegNumber = MakeSafe.ToSafeString(row["RegistrationNumber"]);
                    item.Model = MakeSafe.ToSafeString(row["Model"]);

                    item.Variant = MakeSafe.ToSafeString(row["Variant"]);
                    item.Customer = MakeSafe.ToSafeString(row["Customer"]);
                    item.Address = MakeSafe.ToSafeString(row["Address"]);
                    item.Phone = MakeSafe.ToSafeString(row["Phone"]);
                    item.Email = MakeSafe.ToSafeString(row["Email"]);
                    item.InTime = MakeSafe.ToSafeString(row["InTime"]);
                    item.OutTime = MakeSafe.ToSafeString(row["OutTime"]);
                    item.TotalMinute = MakeSafe.ToSafeString(row["TotalMinutesInside"]);
                  
                    List.Add(item);
                }
                model.List = List;
            }
            return model;

        }
    }
}
