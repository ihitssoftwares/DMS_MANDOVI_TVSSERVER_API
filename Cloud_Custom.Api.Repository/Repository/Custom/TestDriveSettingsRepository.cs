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
    public class TestDriveSettingsRepository : ITestDriveSettingsRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public TestDriveSettingsRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<TestDriveSettings> GetList(UserBase user, int Branch, int Model)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Branch", Branch),
                 new SqlParameter("@Model", Model)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_TestDriveSettings_LIST]", sqlparameters);
                return TestDriveSettingsList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private TestDriveSettings TestDriveSettingsList(DataSet dataSet)
        {
            TestDriveSettings model = new TestDriveSettings();
            List<TestDriveSettings> List = new List<TestDriveSettings>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new TestDriveSettings();



                    item.VehicleCode = MakeSafe.ToSafeInt32(row["VehicleCode"]);
                    item.BranchCode = MakeSafe.ToSafeInt32(row["BranchCode"]);
                    item.BranchName = MakeSafe.ToSafeString(row["BranchName"]);
                    item.Name = MakeSafe.ToSafeString(row["Name"]);
                    item.ModelName = MakeSafe.ToSafeString(row["ModelName"]);
                    item.VariantName = MakeSafe.ToSafeString(row["VariantName"]);
                    item.FuelTypeName = MakeSafe.ToSafeString(row["FuelTypeName"]);


                    item.TransmissionTypeName = MakeSafe.ToSafeString(row["TransmissionTypeName"]);
                    item.ColorName = MakeSafe.ToSafeString(row["ColorName"]);
                    item.RegNo = MakeSafe.ToSafeString(row["RegnNo"]);
                    item.ChassisNo = MakeSafe.ToSafeString(row["ChassisNo"]);

                    item.EngineNo = MakeSafe.ToSafeString(row["EngineNo"]);
                    item.YearOfManufacture = MakeSafe.ToSafeString(row["YearOfManufacture"]);
                    item.IsActive = MakeSafe.ToSafeBool(row["IsActive"]);


                    List.Add(item);
                }
                model.List = List;
            }
            return model;

        }
        public async Task<ResponseEntity> Save(UserBase user, string mode, TestDriveSettings input)
        {
            try
            {

                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@JSONDATA",JsonHelper.ToJson(input)),
                 new SqlParameter("@Mode",mode),
                    ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_TestDriveSettings_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        public async Task<TestDriveSettings> GetTestDriveSettingsDetails(UserBase User, int VehicleCode, string mode)
        {

            IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@VehicleCode",VehicleCode),


            };
            var dataSet = await _sql.GetDataSetAsync("[DMS].[SP_TestDriveSettings_DETAILS]", sqlParameters);
            return PopulateTestDriveSettingsDetails(dataSet);

        }

        private TestDriveSettings PopulateTestDriveSettingsDetails(DataSet dataSet)
        {
            TestDriveSettings model = new TestDriveSettings();
            model.Branch = new Dropdown();
            model.ModelCar = new Dropdown();
            model.Variant = new Dropdown();
            model.FuelType = new Dropdown();
            model.Transmission = new Dropdown();
            model.Color = new Dropdown();
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];
                model.VehicleCode= MakeSafe.ToSafeInt32(row["VehicleCode"]);
                model.Branch.Code = MakeSafe.ToSafeInt32(row["BranchCode"]);
                model.Branch.Name = MakeSafe.ToSafeString(row["BranchName"]);
                model.Name = MakeSafe.ToSafeString(row["Name"]);
                model.ModelCar.Code = MakeSafe.ToSafeInt32(row["ModelCode"]);
                model.ModelCar.Name = MakeSafe.ToSafeString(row["ModeName"]);
                model.Variant.Code = MakeSafe.ToSafeInt32(row["VariantCode"]);
                model.Variant.Name = MakeSafe.ToSafeString(row["VariantName"]);
                model.FuelType.Code = MakeSafe.ToSafeInt32(row["FuelTypeCode"]);
                model.FuelType.Name = MakeSafe.ToSafeString(row["FuelTypeName"]);
                model.Transmission.Code = MakeSafe.ToSafeInt32(row["TransmissionTypeCode"]);
                model.Transmission.Name = MakeSafe.ToSafeString(row["TransmissionTypeName"]);
                model.Color.Code = MakeSafe.ToSafeInt32(row["ColorCode"]);
                model.Color.Name = MakeSafe.ToSafeString(row["ColorName"]);
                model.RegNo = MakeSafe.ToSafeString(row["RegnNo"]);
                model.ChassisNo = MakeSafe.ToSafeString(row["ChassisNo"]);
                model.EngineNo = MakeSafe.ToSafeString(row["EngineNo"]);
                model.YearOfManufacture = MakeSafe.ToSafeString(row["ManufacturingYear"]);
                model.IsActive = MakeSafe.ToSafeBool(row["IsActive"]);
                

            }

            return model;
        }
        public async Task<ResponseEntity> DeleteTestDriveSettings(UserBase user, TestDriveSettings model)
        {
            try
            {

                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 200, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),

                    ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_TestDriveSettings_DELETE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
    }
}
