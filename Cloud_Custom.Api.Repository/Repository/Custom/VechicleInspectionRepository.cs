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
    public class VechicleInspectionRepository : IVechicleInspectionRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public VechicleInspectionRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }

        public async Task<VechicleInspection> GetList(UserBase user)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_VEHICLE_INSPECTION_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }

        public VechicleInspection PopulateGetList(DataSet ds)
        {
            VechicleInspection model = new VechicleInspection();
            model.VechicleInspectionList = new List<VechicleInspection>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new VechicleInspection
                    {
                        HDcode = MakeSafe.ToSafeInt32(row["HDCODE"]),
                        Customeraddress = MakeSafe.ToSafeString(row["Customeraddress"]),
                        CustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
                        MobileNo = MakeSafe.ToSafeString(row["ContactNo"]),
                        Email = MakeSafe.ToSafeString(row["Email"]),
                        RegistrationNo = MakeSafe.ToSafeString(row["RegistrationNumber"]),
                        FuelType = MakeSafe.ToSafeString(row["fueltype"]),
                        ModelName = MakeSafe.ToSafeString(row["ModelName"]),
                        ManufacturerName = MakeSafe.ToSafeString(row["ManufacturerName"]),
                        KM = MakeSafe.ToSafeString(row["KmsDriven"]),
                        VariantName = MakeSafe.ToSafeString(row["VariantName"]),
                        ManufacturedYear = MakeSafe.ToSafeString(row["ManufacturedYear"]),
                        
                        ColourName = MakeSafe.ToSafeString(row["ColourName"]),

                    };

                    model.VechicleInspectionList.Add(item);
                }
            }

            return model;
        }



        public async Task<VechicleInspection> GetInspectionList(UserBase user, int HDcode)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),


                new SqlParameter("@HDcode",HDcode),
                

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_VECHICLE_INSPECTION_LIST]", sqlparameters);

            return PopulateGetInspectionList(ds);

        }
        public VechicleInspection PopulateGetInspectionList(DataSet ds)
        {
            VechicleInspection model = new VechicleInspection();

            model.ParameterList = new List<VechicleInspectionParameter>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new VechicleInspectionParameter
                    {
                        ParameterTypeCode = MakeSafe.ToSafeInt32(row["ParameterTypeCode"]),
                        ParameterTypeName = MakeSafe.ToSafeString(row["ParameterTypeName"]),
                        ParameterCode = MakeSafe.ToSafeInt32(row["ParameterCode"]),
                        ParameterName = MakeSafe.ToSafeString(row["ParameterName"]),
                    };

                    model.ParameterList.Add(item);
                }
            }

            return model;
        }
    }
}
