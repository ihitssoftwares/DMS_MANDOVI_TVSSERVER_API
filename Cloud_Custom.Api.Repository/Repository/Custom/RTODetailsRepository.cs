using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using Cloud_Custom.Shared.Custom;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.Repository.Custom
{
  public  class RTODetailsRepository : IRTODetailsRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public RTODetailsRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<RTODetailsRegistration> GetList(UserBase user)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_REGISTRATION_RTO_ENTRY_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }
        public RTODetailsRegistration PopulateGetList(DataSet ds)
        {
            RTODetailsRegistration model = new RTODetailsRegistration();
            model.Registration = new List<Registration>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new Registration
                    {
                        RegistrationCode = MakeSafe.ToSafeInt32(row["RegistrationCode"]),
                        CustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
                        Address = MakeSafe.ToSafeString(row["Address"]),
                        MobileNo = MakeSafe.ToSafeString(row["MobileNo"]),
                        Model = MakeSafe.ToSafeString(row["Model"]),
                        Variant = MakeSafe.ToSafeString(row["Variant"]),
                        ReceiptDate = MakeSafe.ToSafeDateTime(row["PreparedOn"]),


                    };

                    model.Registration.Add(item);
                }
            }

            return model;
        }

        public async Task<RTODetailsRegistration> GetRegistrationDetails(UserBase user, int RegistrationCode)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@RegistrationCode",RegistrationCode),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_REGISTRATION_DETAILS]", sqlparameters);

            return PopulateRegistrationDetails(ds);

        }
        public RTODetailsRegistration PopulateRegistrationDetails(DataSet ds)
        {
            RTODetailsRegistration model = new RTODetailsRegistration();

            if (ds == null || ds.Tables.Count == 0)
                return model;

            // ================= CUSTOMER STATUS =================
            if (ds.Tables[0]?.Rows?.Count > 0)
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
                    TransmissionType = MakeSafe.ToSafeString(row["TRANSMISSIONTYPE"]),
                    ColorName = MakeSafe.ToSafeString(row["COLORNAME"]),
                    DRAFTDONEDATE = MakeSafe.ToSafeDateTime(row["DRAFTDONEDATE"]),
                    FINALSUBMITDATE = MakeSafe.ToSafeDateTime(row["FINALSUBMITDATE"]),
                    VERIFYDATE = MakeSafe.ToSafeDateTime(row["VERIFYDATE"])
                };
            }

            // ================= CUSTOMER DETAILS =================
            if (ds.Tables[1]?.Rows?.Count > 0)
            {
                var row = ds.Tables[1].Rows[0];

                model.CustomerDetails = new CustomerDetails
                {
                    FullName = MakeSafe.ToSafeString(row["FullName"]),
                    FatherName = MakeSafe.ToSafeString(row["FatherName"]),
                    DateOfBirth = MakeSafe.ToSafeDateTime(row["DateOfBirth"]),
                    Gender = MakeSafe.ToSafeString(row["Gender"]),
                    MobileNumber = MakeSafe.ToSafeString(row["MobileNumber"]),
                    EmailAddress = MakeSafe.ToSafeString(row["EmailAddress"]),
                    AddressLine = MakeSafe.ToSafeString(row["AddressLine"]),
                    PostalCode = MakeSafe.ToSafeString(row["PostalCode"]),
                    District = new Dropdown
                    {
                        Code = MakeSafe.ToSafeInt32(row["DistrictCode"]),
                        Name = MakeSafe.ToSafeString(row["DistrictName"])
                    },
                    States = new Dropdown
                    {
                        Code = MakeSafe.ToSafeInt32(row["StateCode"]),
                        Name = MakeSafe.ToSafeString(row["StateName"])
                    }
                };
            }

            // ================= VEHICLE DETAILS =================
            if (ds.Tables[2]?.Rows?.Count > 0)
            {
                var row = ds.Tables[2].Rows[0];

                model.VehicleDetails = new VehicleDetails
                {
                    EngineNumber = MakeSafe.ToSafeString(row["EngineNumber"]),
                    ChassisNumber = MakeSafe.ToSafeString(row["ChassisNumber"]),
                    Model = new Dropdown
                    {
                        Code = MakeSafe.ToSafeInt32(row["ModelCode"]),
                        Name = MakeSafe.ToSafeString(row["ModelName"])
                    },
                    Variant = new Dropdown
                    {
                        Code = MakeSafe.ToSafeInt32(row["VariantCode"]),
                        Name = MakeSafe.ToSafeString(row["VariantName"])
                    },
                    Color = new Dropdown
                    {
                        Code = MakeSafe.ToSafeInt32(row["ColorCode"]),
                        Name = MakeSafe.ToSafeString(row["ColorName"])
                    },
                    FuelType = new Dropdown
                    {
                        Code = MakeSafe.ToSafeInt32(row["FuelTypeCode"]),
                        Name = MakeSafe.ToSafeString(row["FuelTypeName"])
                    },
                    TransmissionType = new Dropdown
                    {
                        Code = MakeSafe.ToSafeInt32(row["TransmissionTypeCode"]),
                        Name = MakeSafe.ToSafeString(row["TransmissionTypeName"])
                    },
                    InvoiceNumber = MakeSafe.ToSafeString(row["InvoiceNumber"]),
                    InvoiceDate = MakeSafe.ToSafeDateTime(row["InvoiceDate"]),
                    ExShowroomPrice = MakeSafe.ToSafeDecimal(row["ExShowroomPrice"])
                };
            }

            // ================= INSURANCE DETAILS =================
            if (ds.Tables[3]?.Rows?.Count > 0)
            {
                var row = ds.Tables[3].Rows[0];

                model.InsuranceDetails = new InsuranceDetails
                {
                    PolicyNumber = MakeSafe.ToSafeString(row["PolicyNumber"]),
                    InsuranceCompanyName = new Dropdown
                    {
                        Code = MakeSafe.ToSafeInt32(row["InsuranceCompanyCode"]),
                        Name = MakeSafe.ToSafeString(row["InsuranceCompanyName"])
                    },
                    PolicyStartDate = MakeSafe.ToSafeDateTime(row["PolicyStartDate"]),
                    PolicyEndDate = MakeSafe.ToSafeDateTime(row["PolicyEndDate"]),
                    InsuredDeclaredValue = MakeSafe.ToSafeDecimal(row["IDV"]),
                    PolicyType = new Dropdown
                    {
                        Code = MakeSafe.ToSafeInt32(row["PolicyTypeCode"]),
                        Name = MakeSafe.ToSafeString(row["PolicyTypeName"])
                    },
                    PremiumAmount = MakeSafe.ToSafeDecimal(row["PremiumAmount"])
                };
            }

            // ================= FINANCE DETAILS =================
            if (ds.Tables[4]?.Rows?.Count > 0)
            {
                var row = ds.Tables[4].Rows[0];

                model.FinanceDetails = new FinanceDetails
                {
                    IsFinanced = MakeSafe.ToSafeBool(row["IsFinanced"]),
                    Financier = new Dropdown
                    {
                        Code = MakeSafe.ToSafeInt32(row["FinancierCode"]),
                        Name = MakeSafe.ToSafeString(row["FinancierName"])
                    },
                    LoanAmount = MakeSafe.ToSafeDecimal(row["LoanAmount"]),
                    TenureInMonths = MakeSafe.ToSafeInt32(row["Tenure"]),
                    LoanAccountNumber = MakeSafe.ToSafeString(row["LoanAccountNumber"])
                };
            }

            // ================= DOCUMENT DETAILS (ALL FILES) =================
            if (ds.Tables[5]?.Rows?.Count > 0)
            {
                model.IdentityDetails ??= new IdentityDetails();
                model.CustomerDetails ??= new CustomerDetails();
                model.InsuranceDetails ??= new InsuranceDetails();
                model.FinanceDetails ??= new FinanceDetails();


                if (ds.Tables.Count > 7 && ds.Tables[7]?.Rows?.Count > 0)
                {
                    var row = ds.Tables[7].Rows[0];
                    model.IdentityDetails.AadhaarNumber = MakeSafe.ToSafeString(row["AadhaarNumber"]);
                    model.IdentityDetails.PanCardNumber = MakeSafe.ToSafeString(row["PanCardNumber"]);
                    model.IdentityDetails.VoterIdNumber = MakeSafe.ToSafeString(row["VoterIdNumber"]);
                    model.IdentityDetails.DrivingLicenseNumber = MakeSafe.ToSafeString(row["DrivingLicenseNumber"]);
                }
                foreach (DataRow row in ds.Tables[5].Rows)
                {
                    var docCode = MakeSafe.ToSafeInt32(row["DocumentCode"]);

                    var file = new File
                    {
                        FileName = MakeSafe.ToSafeString(row["FileName"]),
                        ActualFileName = MakeSafe.ToSafeString(row["ActualFileName"]),
                        AbsoluteUri = MakeSafe.ToSafeString(row["AbsoluteUri"]),

                    };

                    switch (docCode)
                    {
                        case 1: model.IdentityDetails.Aadhaar = file; break;
                        case 2: model.IdentityDetails.PanCard = file; break;
                        case 3: model.CustomerDetails.Photo = file; break;
                        case 4: model.IdentityDetails.BankAccount = file; break;
                        case 6: model.InsuranceDetails.Insurance = file; break;
                        case 7: model.IdentityDetails.Form20 = file; break;
                        case 8: model.IdentityDetails.Form21 = file; break;
                        case 9: model.IdentityDetails.Form22 = file; break;
                        case 10: model.FinanceDetails.Form34 = file; break;
                    }
                }
            }

            // ================= RTO DETAILS =================
            if (ds.Tables[6]?.Rows?.Count > 0)
            {
                var row = ds.Tables[6].Rows[0];

                model.RTODetails = new RTODetails
                {
                    RtoState = new Dropdown
                    {
                        Code = MakeSafe.ToSafeInt32(row["RtoStateCode"]),
                        Name = MakeSafe.ToSafeString(row["RtoStateName"])
                    },
                    RtoDistrict = new Dropdown
                    {
                        Code = MakeSafe.ToSafeInt32(row["RtoDistrictCode"]),
                        Name = MakeSafe.ToSafeString(row["RtoDistrictName"])
                    },
                    RtoOffice = new Dropdown
                    {
                        Code = MakeSafe.ToSafeInt32(row["RtoOfficeCode"]),
                        Name = MakeSafe.ToSafeString(row["RtoOfficeName"])
                    },
                    RegistrationType = new Dropdown
                    {
                        Code = MakeSafe.ToSafeInt32(row["RegistrationTypeCode"]),
                        Name = MakeSafe.ToSafeString(row["RegistrationTypeName"])
                    },
                    RegistrationCategory = new Dropdown
                    {
                        Code = MakeSafe.ToSafeInt32(row["RegistrationCategoryCode"]),
                        Name = MakeSafe.ToSafeString(row["RegistrationCategoryName"])
                    }
                };
            }

            return model;
        }


        public async Task<ResponseEntity> Save(UserBase user, RTODetailsRegistration model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_RTO_REGISTRATION_DETAILS_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }



        public async Task<RTODetailsRegistration> GetRTODetails(UserBase user, int RegistrationCode)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@RegistrationCode",RegistrationCode),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_REGISTRATION_RTO_DETAILS]", sqlparameters);

            return PopulateRegistrationRTODetails(ds);

        }

        public RTODetailsRegistration PopulateRegistrationRTODetails(DataSet ds)
        {
            var model = new RTODetailsRegistration();

            // -----------------------------
            // Table 0: RTO Submission File
            // -----------------------------
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                var row = ds.Tables[0].Rows[0];
                model.RTODetails = new RTODetails();

                // Map RTO submission details
                model.RTODetails.ApplicationNumber = MakeSafe.ToSafeString(row["ApplicationNumber"]);
                model.RTODetails.ApplicationDate = MakeSafe.ToSafeDateTime(row["ApplicationDate"]);
                model.RTODetails.AcknowledgementNumber = MakeSafe.ToSafeString(row["AcknowledgementNumber"]);
                model.RTODetails.OnlinePortalReferenceNo = MakeSafe.ToSafeString(row["OnlinePortalReferenceNo"]);

                // Map the file for submission
                model.RTODetails.RTOAttachmentFile = new File
                {
                    
                    FileExtension = MakeSafe.ToSafeString(row["FileExtension"]),
                    FileName = MakeSafe.ToSafeString(row["FileName"]),
                    ActualFileName = MakeSafe.ToSafeString(row["ActualFileName"]),
                    AbsoluteUri = MakeSafe.ToSafeString(row["AbsoluteUri"])
                };
            }

            // -----------------------------
            // Table 1: Vehicle RTO Details
            // -----------------------------
            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                var row = ds.Tables[1].Rows[0];
                model.RegistrationDetails = new RegistrationDetails
                {
                    RegistrationNumber = MakeSafe.ToSafeString(row["RegistrationNumber"]),
                    RegistrationDate = MakeSafe.ToSafeDateTime(row["RegistrationDate"]),
                    TemporaryRegistrationNumber = MakeSafe.ToSafeString(row["TemporaryRegistrationNumber"]),
                    PermanentRegistrationStatus = new Dropdown
                    {
                        Name = MakeSafe.ToSafeString(row["PermanentRegistrationStatus"])
                    },
                    RoadTaxAmount = MakeSafe.ToSafeDecimal(row["RoadTaxAmount"]),
                    TaxPaidDate = MakeSafe.ToSafeDateTime(row["TaxPaidDate"]),
                    TaxReceiptNumber = MakeSafe.ToSafeString(row["TaxReceiptNumber"]),
                    GreenTax = MakeSafe.ToSafeDecimal(row["GreenTax"]),
                    SmartCardFee = MakeSafe.ToSafeDecimal(row["SmartCardFee"]),
                    HypothecationEntryStatus = MakeSafe.ToSafeString(row["HypothecationEntryStatus"]),
                    BankNOCStatus = MakeSafe.ToSafeString(row["BankNOCStatus"]),
                    HPEndorsementInRC = MakeSafe.ToSafeBool(row["HPEndorsementInRC"])
                };
            }

            // -----------------------------
            // Table 2: RC Details
            // -----------------------------
            if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            {
                var row = ds.Tables[2].Rows[0];
                model.RCDetails = new RCDetails
                {
                    RCIssued = MakeSafe.ToSafeBool(row["RCIssued"]),
                    RCNumber = MakeSafe.ToSafeString(row["RCNumber"]),
                    RCIssueDate = MakeSafe.ToSafeDateTime(row["RCIssueDate"]),
                    RCDispatchStatus = new Dropdown
                    {
                        Name = MakeSafe.ToSafeString(row["RCDispatchStatus"])
                    },
                    TrackingNumber = MakeSafe.ToSafeString(row["TrackingNumber"])
                };
            }

            // -----------------------------
            // Table 3: HSRP Details
            // -----------------------------
            if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
            {
                var row = ds.Tables[3].Rows[0];
                model.HSRPDetails = new HSRPDetails
                {
                    HSRPOrderID = MakeSafe.ToSafeString(row["HSRPOrderID"]),
                    HSRPOrderDate = MakeSafe.ToSafeDateTime(row["HSRPOrderDate"]),
                    HSRPVendorName = MakeSafe.ToSafeString(row["HSRPVendorName"]),
                    HSRPStatus = new Dropdown
                    {
                        Name = MakeSafe.ToSafeString(row["HSRPStatus"])
                    },
                    TrackingNumber = MakeSafe.ToSafeString(row["TrackingNumber"]),
                    CourierName = MakeSafe.ToSafeString(row["CourierName"]),
                    DispatchDate = MakeSafe.ToSafeDateTime(row["DispatchDate"]),
                    ExpectedDeliveryDate = MakeSafe.ToSafeDateTime(row["ExpectedDeliveryDate"]),
                    DeliveredToDealerDate = MakeSafe.ToSafeDateTime(row["DeliveredToDealerDate"])
                };
            }

            // -----------------------------
            // Table 4: RTO Appointment + Fitment
            // -----------------------------
            if (ds.Tables.Count > 4 && ds.Tables[4].Rows.Count > 0)
            {
                var row = ds.Tables[4].Rows[0];

                // Appointment
                model.AppointmentDetails = new AppointmentDetails
                {
                    AppointmentDate = MakeSafe.ToSafeDateTime(row["AppointmentDate"]),
                    TimeSlot = new Dropdown { Code = MakeSafe.ToSafeInt32(row["TimeSlot"]) },
                    FitmentLocation = MakeSafe.ToSafeString(row["FitmentLocation"]),
                    CustomerConfirmation = MakeSafe.ToSafeBool(row["CustomerConfirmation"]),
                    RescheduleCount = MakeSafe.ToSafeInt32(row["RescheduleCount"])
                };

                // Fitment
                model.FitmentDetails = new FitmentDetails
                {
                    FitmentDone = MakeSafe.ToSafeBool(row["FitmentDone"]),
                    FitmentDate = MakeSafe.ToSafeDateTime(row["FitmentDate"]),
                    TechnicianName = MakeSafe.ToSafeString(row["TechnicianName"]),
                    CustomerOTPVerified = MakeSafe.ToSafeBool(row["CustomerOTPVerified"]),
                    InstallationPhotoFile = new File
                    {
                       
                        FileExtension = MakeSafe.ToSafeString(row["FileExtension"]),
                        FileName = MakeSafe.ToSafeString(row["FileName"]),
                        ActualFileName = MakeSafe.ToSafeString(row["ActualFileName"]),
                        AbsoluteUri = MakeSafe.ToSafeString(row["AbsoluteUri"])
                    }
                };
            }

            return model;
        }
    }
}
