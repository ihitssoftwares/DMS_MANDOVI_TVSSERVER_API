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
    public class McareRegistrationRepository : IMcareRegistrationRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public McareRegistrationRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }

        public async Task<McareRegistration> GetList(UserBase user, int AppoinmentStatus)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@AppoinmentStatus",AppoinmentStatus),


            };
            var ds = await _sql.GetDataSetAsync("[MCARE.[SP_MCARE_REGISTRATION_BOOKED_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }

        public McareRegistration PopulateGetList(DataSet ds)
        {
            McareRegistration model = new McareRegistration();
            model.McareRegistrationList = new List<McareRegistration>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new McareRegistration
                    {
                        EntryNo = MakeSafe.ToSafeString(row["EntryNo"]),
                        StartingDate = MakeSafe.ToSafeDateTime(row["StartDate"]),
                        CustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
                        MobileNo = MakeSafe.ToSafeString(row["phone"]),
                        Email = MakeSafe.ToSafeString(row["Email"]),
                        RegistrationNo = MakeSafe.ToSafeString(row["vehicleRegistrationNumber"]),
                        planname = MakeSafe.ToSafeString(row["planname"]),
                        ModelName = MakeSafe.ToSafeString(row["ModelName"]),
                        VariantName = MakeSafe.ToSafeString(row["VariantName"]),
                        PlanAmount = MakeSafe.ToSafeString(row["Planamount"]),
                        status = MakeSafe.ToSafeString(row["status"]),
                        EntryUser = MakeSafe.ToSafeString(row["Entryuser"]),
                        Advisor = MakeSafe.ToSafeString(row["Advisor"]),
                        EndDate = MakeSafe.ToSafeDateTime(row["EndDate"]),

                    };

                    model.McareRegistrationList.Add(item);
                }
            }

            return model;
        }




        public async Task<McareRegistration> GetSearchList(UserBase user, string SearchCustomerName, string SearchCustomerRegisterNo, string SearchPhoneNo, string VinNo)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@SearchCustomerName",SearchCustomerName),
                new SqlParameter("@SearchCustomerRegisterNo",SearchCustomerRegisterNo),
                new SqlParameter("@SearchPhoneNo",SearchPhoneNo),
                  new SqlParameter("@VinNo",VinNo),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_SEARCH_CUSTOMER_REPOSITORY_LIST]", sqlparameters);

            return PopulateGetSearchList(ds);

        }


        public McareRegistration PopulateGetSearchList(DataSet ds)
        {
            McareRegistration model = new McareRegistration();
            model.SearchList = new List<McareRegistrationSearch>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new McareRegistrationSearch
                    {

                        CustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
                        city = MakeSafe.ToSafeString(row["city"]),
                        Email = MakeSafe.ToSafeString(row["Email"]),
                        RegisterNumber = MakeSafe.ToSafeString(row["RegisterNumber"]),
                        phone = MakeSafe.ToSafeString(row["phone"]),
                        Model = MakeSafe.ToSafeString(row["Model"]),
                        variant = MakeSafe.ToSafeString(row["variant"]),
                        IsValid = MakeSafe.ToSafeBool(row["IsModelValid"]),
                        Message = MakeSafe.ToSafeString(row["ValidationMessage"])
                       


                    };

                    model.SearchList.Add(item);
                }
            }

            return model;
        }



        public async Task<McareRegistration> GetSearchDetails(UserBase user, string SearchCustomerName, string SearchCustomerRegisterNo, string SearchPhoneNo, string VinNo)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@SearchCustomerName",SearchCustomerName),
                new SqlParameter("@SearchCustomerRegisterNo",SearchCustomerRegisterNo),
                new SqlParameter("@SearchPhoneNo",SearchPhoneNo),
                  new SqlParameter("@VinNo",VinNo),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_SEARCH_CUSTOMER_REPOSITORY_LIST]", sqlparameters);

            return PopulateGetSearchDetails(ds);

        }

        public async Task<McareRegistration> GetDetails(UserBase user, string SearchCustomerRegisterNo)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
               
                new SqlParameter("@SearchCustomerRegisterNo",SearchCustomerRegisterNo),
                


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_SEARCH_MCARE_CUSTOMER_REPOSITORY_LIST]", sqlparameters);

            return PopulateGetSearchDetails(ds);

        }


        public McareRegistration PopulateGetSearchDetails(DataSet ds)
        {
            McareRegistration model = new McareRegistration();

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
                model.chasisNo = MakeSafe.ToSafeString(row["ChassisNo"]);
                model.EngineNumber = MakeSafe.ToSafeString(row["Engineno"]);
                model.ModeCode = MakeSafe.ToSafeInt32(row["ModeCode"]);
                model.VariantCode = MakeSafe.ToSafeInt32(row["VariantCode"]);
                model.Address = MakeSafe.ToSafeString(row["Address"]);
                model.VIN = MakeSafe.ToSafeString(row["VINNumber"]);
            }
        

            return model;
        }

        public async Task<ResponseEntity> Save(UserBase User, McareRegistration model)
        {
            try
            {
                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 250, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
                IDbDataParameter[] sqlParameters =
                {
                    new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                    new SqlParameter("@CompanyGI",User.CompanyGuid),
                    new SqlParameter("@UserGI",User.UserGuid),
            ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[MCARE].[SP_MCARE_REGISTRATION_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException EX)
            {
                var ErrorMsg = EX.Message.ToString();
                throw new Exception(ErrorMsg, EX);
            }
        }


        //public async Task<String> GetPlanAmount(UserBase User, int id, int VechicleModel)
        //{
        //    try
        //    {
        //        SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 250, Direction = ParameterDirection.Output };
        //        SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
        //        IDbDataParameter[] sqlParameters =
        //        {
                    
        //            new SqlParameter("@CompanyGI",User.CompanyGuid),
        //            new SqlParameter("@UserGI",User.UserGuid),
        //             new SqlParameter("@PlanTypeCode",id),
        //              new SqlParameter("@VechicleModel",VechicleModel),
        //            ResponseKey
        //    };
        //        await _sql.ExecuteNonQueryAsync("[MCARE].[SP_PLAN_AMOUNT_DETAIL]", sqlParameters, CommandType.StoredProcedure);
        //        return new String(ResponseKey.Value.ToString());
        //    }
        //    catch (SqlException EX)
        //    {
        //        var ErrorMsg = EX.Message.ToString();
        //        throw new Exception(ErrorMsg, EX);
        //    }
        //}



        public async Task<McareRegistration> GetPlanAmount(UserBase User, int id, int VechicleModel, string FromDate)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                new SqlParameter("@UserGuid",User.UserGuid),

                new SqlParameter("@PlanTypeCode",id),
                      new SqlParameter("@VechicleModel",VechicleModel),
                      new SqlParameter("@FromDate",FromDate),



            };
            var ds = await _sql.GetDataSetAsync("[MCARE].[SP_PLAN_AMOUNT_DETAIL]", sqlparameters);

            return PopulateAmountSearchDetails(ds);

        }


        public McareRegistration PopulateAmountSearchDetails(DataSet ds)
        {
            McareRegistration model = new McareRegistration();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                model.PlanAmount = MakeSafe.ToSafeString(row["PlanAmount"]);
                model.EndingDate = MakeSafe.ToSafeInt32(row["EndingDate"]);
               
            }


            return model;
        }



    }
}
