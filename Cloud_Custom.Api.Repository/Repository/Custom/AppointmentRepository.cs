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
  public   class AppointmentRepository : IAppointmentRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public AppointmentRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<ResponseEntity> AppointmentSave(UserBase user, Appointment model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 500, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_APPOINTMENT_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }



        public async Task<Appointment> GetList(UserBase user, string FromDate, string ToDate)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@FromDate",FromDate),
                new SqlParameter("@ToDate",ToDate),



            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_APPOINTMENT_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }
        public Appointment PopulateGetList(DataSet ds)
        {
            // Create the main model
            Appointment model = new Appointment();
            model.AppointmentList = new List<Appointment>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new Appointment
                    {
                   
                        AppointmentCode = MakeSafe.ToSafeInt32(row["AppointmentCode"]),
                        CustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
                        MobileNo = MakeSafe.ToSafeString(row["MobileNo"]),
                        DOA = MakeSafe.ToSafeString(row["DOA"]),
                        AppointTime = MakeSafe.ToSafeString(row["AppointmentTime"]),
                        //SalesExecutive = new Dropdown
                        //{
                        //    Name = MakeSafe.ToSafeString(row["SalesManNAme"])
                        //},
                        //Model = new Dropdown
                        //{
                        //    Name = MakeSafe.ToSafeString(row["Model"])
                        //},
                        Location = MakeSafe.ToSafeString(row["Location"]),
                        SalesManName = MakeSafe.ToSafeString(row["SalesManNAme"]),
                        ModelName = MakeSafe.ToSafeString(row["Model"]),
                        TimeLine = MakeSafe.ToSafeString(row["TimeLines"]),
                        SourceOfEnquiry = MakeSafe.ToSafeString(row["SourceOfEnquiry"])

                    };

                    model.AppointmentList.Add(item);
                }
            }

            return model;
        }
    }
}
