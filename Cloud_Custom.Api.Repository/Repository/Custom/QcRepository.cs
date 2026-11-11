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
   public  class QcRepository : IQcRepository
    {
         private readonly ISqlConnectionProvider _sql;
            public QcRepository(ISqlConnectionProvider sql)
            {
                _sql = sql;
            }


            public async Task<Qc> GetList(UserBase user, Filter filter,int Region,int Branch)
            {

                IDbDataParameter[] sqlparameters =
               {
                new SqlParameter("@JSONDATA",JsonHelper.ToJson(filter)),
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@Region",Region),
                new SqlParameter("@Branch",Branch),


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_QC_LIST]", sqlparameters);

                 return PopulateGetList(ds);

            }
            public Qc PopulateGetList(DataSet ds)
            {
                Qc model = new Qc();
                model.QcList = new List<Qc>();

                if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var item = new Qc
                        {
                            SalesVehicleCode = MakeSafe.ToSafeInt32(row["SalesVehicleCode"]),
                             DispatchDate= MakeSafe.ToSafeString(row["DispatchDate"]),
                            InvoiceNo = MakeSafe.ToSafeString(row["InvoiceNo"]),
                            InvoiceDate = MakeSafe.ToSafeString(row["InvoiceDate"]),
                            DcNo = MakeSafe.ToSafeString(row["DCNo"]),
                            Modeldetails = MakeSafe.ToSafeString(row["ModelDetails"]),
                            //FuelType = MakeSafe.ToSafeString(row["FuelTypeName"]),
                            TransmissionType = MakeSafe.ToSafeString(row["TransmissionTypeName"]),
                            EnginNo = MakeSafe.ToSafeString(row["EngineNo"]),
                            VehVinNo = MakeSafe.ToSafeString(row["NewVehVin"]),
                            BranchName = MakeSafe.ToSafeString(row["BranchName"]),
                            BasicValue = MakeSafe.ToSafeDecimal(row["BasicValue"]),
                            DiscountSpot = MakeSafe.ToSafeDecimal(row["DiscountSpot"]),
                            DRF = MakeSafe.ToSafeDecimal(row["DRF"]),
                            AssessableValue = MakeSafe.ToSafeDecimal(row["AssessableValue"]),
                            IGST = MakeSafe.ToSafeDecimal(row["IGST"]),
                            Cess = MakeSafe.ToSafeDecimal(row["Cess"]),
                            TCS = MakeSafe.ToSafeDecimal(row["TCS"]),
                            Amount = MakeSafe.ToSafeDecimal(row["Amount"]),
                            Status = MakeSafe.ToSafeString(row["StockStatus"]),

                            active = MakeSafe.ToSafeInt32(row["ACTIVE"]),
                            totalRecords = MakeSafe.ToSafeInt32(row["TotalCount"])


                };

                        model.QcList.Add(item);
                    }
                }

                return model;
            }

            public async Task<QcItem> GetDetails(UserBase user, int SalesVehicleCode)
            {

                IDbDataParameter[] sqlparameters =
               {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@SalesVehicleCode",SalesVehicleCode),


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_QC_DETAILS]", sqlparameters);

                return PopulateGetEmployeeDetails(ds);

            }
            public QcItem PopulateGetEmployeeDetails(DataSet ds)
            {

                QcItem model = new QcItem();
                model.QcItemList = new List<QcItem>();
                if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
                {

                    DataRow row = ds.Tables[0].Rows[0];

                    model.WareHouse = new Dropdown();
                    
                    model = new QcItem

                    {

                        SalesVehicleCode = MakeSafe.ToSafeInt32(row["SalesVehicleCode"]),
                        DispatchDate = MakeSafe.ToSafeString(row["DispatchDate"]),
                        InvoiceNo = MakeSafe.ToSafeString(row["InvoiceNo"]),
                        InvoiceDate = MakeSafe.ToSafeString(row["InvoiceDate"]),
                        DcNo = MakeSafe.ToSafeString(row["DCNo"]),
                        Modeldetails = MakeSafe.ToSafeString(row["ModelDetails"]),
                        //FuelType = MakeSafe.ToSafeString(row["FuelTypeName"]),
                        TransmissionType = MakeSafe.ToSafeString(row["TransmissionTypeName"]),
                        EngineNo = MakeSafe.ToSafeString(row["EngineNo"]),
                        ChassisNo = MakeSafe.ToSafeString(row["ChassisNo"]),
                        Status = MakeSafe.ToSafeString(row["StockStatus"]),
                        Amount = MakeSafe.ToSafeDecimal(row["Amount"]),


                    };

                }
                

                return model;
            }

            public async Task<ResponseEntity> Save(UserBase user, Qc model)
            {
                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
                IDbDataParameter[] sqlParameters =
                {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_QC_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
        }
    }

