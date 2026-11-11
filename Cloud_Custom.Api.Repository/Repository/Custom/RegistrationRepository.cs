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
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public RegistrationRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }



        public async Task<Registration> GetList(UserBase user)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
      

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_REGISTRATION_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }
        public Registration PopulateGetList(DataSet ds)
        {
            Registration model = new Registration();
            model.RegistrationList = new List<Registration>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new Registration
                    {
                        OrderTrnCode = MakeSafe.ToSafeInt32(row["OrderTrnCode"]),
                        CustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
                        Address = MakeSafe.ToSafeString(row["Address"]),
                        MobileNo = MakeSafe.ToSafeString(row["MobileNo"]),
                        Model = MakeSafe.ToSafeString(row["Model"]),
                        Variant = MakeSafe.ToSafeString(row["Variant"]),
                        AllotedStatus = MakeSafe.ToSafeString(row["AllotedStatus"]),
                        ReceiptNo = MakeSafe.ToSafeString(row["RECEIPTNO"]),
                        ReceiptDate = MakeSafe.ToSafeDateTime(row["RECEIPTGENERATEDON"]),
                        IsAllotedOrNot = MakeSafe.ToSafeInt32(row["ISALLOTEDORNOT"]),

                    };

                    model.RegistrationList.Add(item);
                }
            }

            return model;
        }



        public async Task<Registration> GetOrderDetails(UserBase user, int OrderTrnCode)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@ORDERTRNCODE",OrderTrnCode),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_REGISTRATION_DRAFT_DETAILS]", sqlparameters);

            return PopulateOrderDetails(ds);

        }

        private Registration PopulateOrderDetails(DataSet ds)
        {
            var model = new Registration();

            // 1. CUSTOMER STATUS
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                var row = ds.Tables[0].Rows[0];

                model.CustomerStatus = new CustomerStatus
                {
                    BookingDate = MakeSafe.ToSafeDateTime(row["BOOKINGDATE"]),
                    InvoiceCompleted = MakeSafe.ToSafeDateTime(row["INVOICECOMPLETED"]),
                    BookingNo = MakeSafe.ToSafeString(row["BOOKINGNO"]),
                    RecieptNo = MakeSafe.ToSafeString(row["RECIEPTNO"]),
                    ModelName = MakeSafe.ToSafeString(row["MODELNAME"]),
                    VariantName = MakeSafe.ToSafeString(row["VARIANTNAME"]),
                    FuelType = MakeSafe.ToSafeString(row["FUELTYPE"]),
                    TransmissionType = MakeSafe.ToSafeString(row["TRANSMISSIONTYPE"])
                    
                };
            }

            // 2. CUSTOMER DETAILS
            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                var row = ds.Tables[1].Rows[0];

                model.CustomerDetails = new CustomerDetails
                {
                    FullName = MakeSafe.ToSafeString(row["FULLNAME"]),
                    MobileNumber = MakeSafe.ToSafeString(row["MOBILENO"]),
                    FatherName = MakeSafe.ToSafeString(row["FATHERSNAME"]),
                    EmailAddress = MakeSafe.ToSafeString(row["EMAIL"]),
                    AddressLine = MakeSafe.ToSafeString(row["ADDRESS"]),
                    PostalCode = MakeSafe.ToSafeString(row["PINCODE"]),

                    Photo = new File
                    {
                        ActualFileName = MakeSafe.ToSafeString(row["PHOTOACTUALFILENAME"]),
                        AbsoluteUri = MakeSafe.ToSafeString(row["PHOTOABSOLUTEURI"])
                    }
                };
            }

            // 3. VEHICLE DETAILS
            if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            {
                var row = ds.Tables[2].Rows[0];

                model.VehicleDetails = new VehicleDetails
                {
                    EngineNumber = MakeSafe.ToSafeString(row["ENGINENO"]),
                    ChassisNumber = MakeSafe.ToSafeString(row["CHASSISNO"]),
                    InvoiceNumber = MakeSafe.ToSafeString(row["INVOICENO"]),
                    InvoiceDate = MakeSafe.ToSafeDateTime(row["INVOICEDATE"]),
                    ExShowroomPrice = MakeSafe.ToSafeDecimal(row["EXSHOWROOMPRICE"]),
                    Model = new Dropdown
                    {
                        Code = MakeSafe.ToSafeInt32(row["MODELCODE"])
                    },
                    Variant = new Dropdown
                    {
                        Code = MakeSafe.ToSafeInt32(row["VARIANTCODE"])
                    },
                    FuelType = new Dropdown
                    {
                        Code = MakeSafe.ToSafeInt32(row["FUELTYPECODE"])
                    },
                    TransmissionType = new Dropdown
                    {
                        Code = MakeSafe.ToSafeInt32(row["TRANSMISSIONTYPECODE"])
                    },
                    Color = new Dropdown
                    {
                        Code = MakeSafe.ToSafeInt32(row["COLORCODE"])
                    },
                };
            }

            // 4. INSURANCE DETAILS
            if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
            {
                var row = ds.Tables[3].Rows[0];

                model.InsuranceDetails = new InsuranceDetails
                {
                    InsuranceCompanyName = new Dropdown
                    {
                        Code = MakeSafe.ToSafeInt32(row["INSURANCECOMPANYCODE"])
                    },
                    PolicyType = new Dropdown
                    {
                        Code = MakeSafe.ToSafeInt32(row["POLICYTYPECODE"])
                    },
                    Insurance = new File
                    {
                        ActualFileName = MakeSafe.ToSafeString(row["INSURANCEACTUALFILENAME"]),
                        AbsoluteUri = MakeSafe.ToSafeString(row["INSURANCEABSOLUTEURI"])
                    }
                };
            }

            // 5. FINANCE DETAILS
            if (ds.Tables.Count > 4 && ds.Tables[4].Rows.Count > 0)
            {
                var row = ds.Tables[4].Rows[0];

                model.FinanceDetails = new FinanceDetails
                {
                    IsFinanced = MakeSafe.ToSafeInt32(row["ISFINANCEREQUIRED"]) == 1,
                    Financier = new Dropdown
                    {
                        Code = MakeSafe.ToSafeInt32(row["FinancierCode"])
                    },
                    LoanAmount = MakeSafe.ToSafeDecimal(row["LOANAMOUNT"]),
                    Form34 = new File
                    {
                        ActualFileName = MakeSafe.ToSafeString(row["FORM34ACTUALFILENAME"]),
                        AbsoluteUri = MakeSafe.ToSafeString(row["FILE34ABSOLUTEURI"])
                    }
                };
            }

            // 6. IDENTITY DETAILS
            if (ds.Tables.Count > 5 && ds.Tables[5].Rows.Count > 0)
            {
                var row = ds.Tables[5].Rows[0];

                model.IdentityDetails = new IdentityDetails
                {
                    AadhaarNumber = MakeSafe.ToSafeString(row["ADHARNO"]),
                    PanCardNumber = MakeSafe.ToSafeString(row["PANNO"]),

                    Aadhaar = new File
                    {
                        ActualFileName = MakeSafe.ToSafeString(row["ADHARACTUALFILENAME"]),
                        AbsoluteUri = MakeSafe.ToSafeString(row["ADHARABSOLUTEURI"])
                    },
                    PanCard = new File
                    {
                        ActualFileName = MakeSafe.ToSafeString(row["PANACTUALFILENAME"]),
                        AbsoluteUri = MakeSafe.ToSafeString(row["PANABSOLUTEURI"])
                    },
                    BankAccount = new File
                    {
                        ActualFileName = MakeSafe.ToSafeString(row["BANKACTUALFILENAME"]),
                        AbsoluteUri = MakeSafe.ToSafeString(row["BANKABSOLUTEURI"])
                    },
                    Form20 = new File
                    {
                        ActualFileName = MakeSafe.ToSafeString(row["Form20ACTUALFILENAME"]),
                        AbsoluteUri = MakeSafe.ToSafeString(row["Form20ABSOLUTEURI"])
                    },
                    Form21 = new File
                    {
                        ActualFileName = MakeSafe.ToSafeString(row["Form21ACTUALFILENAME"]),
                        AbsoluteUri = MakeSafe.ToSafeString(row["Form21ABSOLUTEURI"])
                    },
                    Form22 = new File
                    {
                        ActualFileName = MakeSafe.ToSafeString(row["Form22ACTUALFILENAME"]),
                        AbsoluteUri = MakeSafe.ToSafeString(row["Form22ABSOLUTEURI"])
                    }
                };
            }

            return model;
        }



        public async Task<ResponseEntity> Save(UserBase user, Registration model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_REGISTRATION_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
    }
}
