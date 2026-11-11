using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
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
    public class ServiceAgeingSummeryRepository : IServiceAgeingSummeryRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public ServiceAgeingSummeryRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<ServiceAgeingSummery>GetList(UserBase user,int Age)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                    new SqlParameter("@Age",Age)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_AGING_SUMMERY_LIST]", sqlparameters);
                return SummeryList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private ServiceAgeingSummery SummeryList(DataSet ds)
        {
            ServiceAgeingSummery model = new ServiceAgeingSummery();
            List<ServiceAgeingSummery> List = new List<ServiceAgeingSummery>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new ServiceAgeingSummery();
                    


                    item.BookingCode = MakeSafe.ToSafeInt32(row["BookingCode"]);
                    item.BookingNo = MakeSafe.ToSafeString(row["BookingNo"]);
                    item.BookingDate = MakeSafe.ToSafeDateTime(row["BookingDate"]);
                    item.BookingStatus = MakeSafe.ToSafeString(row["BookingStatus"]);
                    item.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                    item.MobileNo = MakeSafe.ToSafeString(row["MobileNo"]);
                    item.RegistrationNo = MakeSafe.ToSafeString(row["RegistrationNo"]);
                    item.Model = MakeSafe.ToSafeString(row["Model"]);
                    item.Variant = MakeSafe.ToSafeString(row["Variant"]);
                    item.JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]);
                    item.JCDateTime = MakeSafe.ToSafeDateTime(row["JCDateTime"]);
                    
                    item.CHKIN_DT = MakeSafe.ToSafeDateTime(row["CHKIN_DT"]);
                    item.CHKOUT_DT = MakeSafe.ToSafeDateTime(row["CHKOUT_DT"]);
                    item.ServiceType = MakeSafe.ToSafeString(row["ServiceType"]);
                    item.ServiceAdvisor = MakeSafe.ToSafeString(row["ServiceAdvisor"]);
                    item.Technician = MakeSafe.ToSafeString(row["Technician"]);
                    item.BillAmount = MakeSafe.ToSafeDecimal(row["BillAmount"]);
                    item.BookingAgeingDays = MakeSafe.ToSafeInt32(row["BookingAgeingDays"]);
                    item.WorkshopAgeingDays = MakeSafe.ToSafeInt32(row["WorkshopAgeingDays"]);
                    item.DeliveryDelayDays = MakeSafe.ToSafeInt32(row["DeliveryDelayDays"]);
                    item.VehicleStatus= MakeSafe.ToSafeString(row["VehicleStatus"]);
                    item.AgeingBucket = MakeSafe.ToSafeString(row["AgeingBucket"]);
                    
                    List.Add(item);
                }
                model.List = List;
            }
            
            return model;

        }
    }
}
