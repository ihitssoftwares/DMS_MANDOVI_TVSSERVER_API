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
    public class BookedAppointmentRepository : IBookedAppointmentRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public BookedAppointmentRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }

        public async Task<BookedAppointment> GetList(UserBase user,int AppoinmentStatus)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@AppoinmentStatus",AppoinmentStatus),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_BOOKEDAPPOINTMENT_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }

        public BookedAppointment PopulateGetList(DataSet ds)
        {
            BookedAppointment model = new BookedAppointment();
            model.BookedAppointmentList = new List<BookedAppointment>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new BookedAppointment
                    {
                        BookingCode = MakeSafe.ToSafeInt32(row["BookingCode"]),
                        BookingNo = MakeSafe.ToSafeString(row["BookingNo"]),
                        CustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
                        MobileNo = MakeSafe.ToSafeString(row["MobileNo"]),
                        Email = MakeSafe.ToSafeString(row["EmailID"]),
                        RegistrationNo = MakeSafe.ToSafeString(row["RegistrationNo"]),
                        FuelTypes = MakeSafe.ToSafeString(row["FuelType"]),
                        ModelName = MakeSafe.ToSafeString(row["ModelName"]),
                        ServiceTypes = MakeSafe.ToSafeString(row["ServiceType"]),
                        KM = MakeSafe.ToSafeString(row["Odometer"]),
                        Feedbacks = MakeSafe.ToSafeString(row["PickupRequired"]),
                        PreferredDate = MakeSafe.ToSafeDateTime(row["PreferredDate"]),
                        TimeSlots = MakeSafe.ToSafeString(row["PreferredTimeSlot"]),

                    };

                    model.BookedAppointmentList.Add(item);
                }
            }

            return model;
        }




        public async Task<BookedAppointment> GetSearchList(UserBase user, string SearchCustomerName, string SearchCustomerRegisterNo, string SearchPhoneNo)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@SearchCustomerName",SearchCustomerName),
                new SqlParameter("@SearchCustomerRegisterNo",SearchCustomerRegisterNo),
                new SqlParameter("@SearchPhoneNo",SearchPhoneNo),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_SEARCH_CUSTOMER_REPOSITORY_LIST]", sqlparameters);

            return PopulateGetSearchList(ds);

        }


        public BookedAppointment PopulateGetSearchList(DataSet ds)
        {
            BookedAppointment model = new BookedAppointment();
            model.SearchList = new List<BookedAppointmentSearch>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new BookedAppointmentSearch
                    {

                        CustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
                        city = MakeSafe.ToSafeString(row["city"]),
                        Email = MakeSafe.ToSafeString(row["Email"]),
                        RegisterNumber = MakeSafe.ToSafeString(row["RegisterNumber"]),
                        phone = MakeSafe.ToSafeString(row["phone"]),
                        Model = MakeSafe.ToSafeString(row["Model"]),
                        variant = MakeSafe.ToSafeString(row["variant"]),
                       

                    };

                    model.SearchList.Add(item);
                }
            }

            return model;
        }



        public async Task<BookedAppointment> GetSearchDetails(UserBase user, string SearchCustomerName, string SearchCustomerRegisterNo, string SearchPhoneNo)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@SearchCustomerName",SearchCustomerName),
                new SqlParameter("@SearchCustomerRegisterNo",SearchCustomerRegisterNo),
                new SqlParameter("@SearchPhoneNo",SearchPhoneNo),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_SEARCH_CUSTOMER_REPOSITORY_LIST]", sqlparameters);

            return PopulateGetSearchDetails(ds);

        }


        public BookedAppointment PopulateGetSearchDetails(DataSet ds)
        {
            BookedAppointment model = new BookedAppointment();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                model.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                model.city = MakeSafe.ToSafeString(row["city"]);
                model.Email = MakeSafe.ToSafeString(row["Email"]);
                model.RegistrationNo = MakeSafe.ToSafeString(row["RegisterNumber"]);
                model.MobileNo = MakeSafe.ToSafeString(row["phone"]);
                model.ModelName = MakeSafe.ToSafeString(row["Model"]);
                model.variant = MakeSafe.ToSafeString(row["variant"]);
            }

            return model;
        }
    }
}
