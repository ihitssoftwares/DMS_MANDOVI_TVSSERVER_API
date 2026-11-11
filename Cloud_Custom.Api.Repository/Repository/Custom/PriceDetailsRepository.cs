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
     public class PriceDetailsRepository : IPriceDetailsRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public PriceDetailsRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<PriceDetails> GetList(UserBase user, int Type, string Fromdate, string ToDate)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Type",Type),
                 new SqlParameter("@Fromdate",Fromdate),
                 new SqlParameter("@ToDate",ToDate),



            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_Price_Details_LIST]", sqlparameters);
                return PriceDetailsList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private PriceDetails PriceDetailsList(DataSet dataSet)
        {
            PriceDetails model = new PriceDetails();
            List<PriceDetails> List = new List<PriceDetails>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                model.Model = new Dropdown(); 

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new PriceDetails();

                    item.SlNo = MakeSafe.ToSafeInt32(row["SlNo"]);
                    item.PriceId = MakeSafe.ToSafeInt32(row["PriceId"]);
                    model.FromDate= MakeSafe.ToSafeDateTime(row["EffectiveFrom"]);
                    model.ToDate = MakeSafe.ToSafeDateTime(row["EffectiveTo"]);
                    model.Model.Code = MakeSafe.ToSafeInt32(row["ModelId"]); 
                    item.ModelName = MakeSafe.ToSafeString(row["ModeName"]);
                    item.VarientName = MakeSafe.ToSafeString(row["VarientName"]);
                    item.Fuelname = MakeSafe.ToSafeString(row["Fuelname"]);
                    item.TransmissionName = MakeSafe.ToSafeString(row["TransmissionTypeName"]);
                    //item.ColorName = MakeSafe.ToSafeString(row["ColorName"]);

                    item.OnShowPrice = MakeSafe.ToSafeDecimal(row["OnShowPrice"]);
                    item.Gst = MakeSafe.ToSafeDecimal(row["Gst"]);
                    item.TCS = MakeSafe.ToSafeDecimal(row["TCS"]);
                    item.Netamount = MakeSafe.ToSafeDecimal(row["Netamount"]);
                    item.WarrantyAmount = MakeSafe.ToSafeInt32(row["WarrantyAmount"]);

                    List.Add(item);
                }

                model.List = List;
            }

            return model;
        }

      
        public async Task<PriceDetails> GetVarientDetails(UserBase User, int PriceId)
        {

            IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@PriceId",PriceId),


            };
            var dataSet = await _sql.GetDataSetAsync("[DMS].[SP_PRICE_DETAILS]", sqlParameters);
            return PopulateVariantDetails(dataSet);

        }

        private PriceDetails PopulateVariantDetails(DataSet dataSet)
        {
            PriceDetails model = new PriceDetails();
            model.Variant = new Dropdown();
            //model.Color = new Dropdown();
            model.FuelType = new Dropdown();
            model.TransmissionType = new Dropdown();
            model.Model = new Dropdown();

            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];
                model.FromDate = MakeSafe.ToSafeDateTime(row["EffectiveFrom"]);
                model.ToDate = MakeSafe.ToSafeDateTime(row["EffectiveTo"]);

                model.PriceId = MakeSafe.ToSafeInt32(row["PriceId"]);
                model.ModelName = MakeSafe.ToSafeString(row["ModelId"]);
                model.VarientName= MakeSafe.ToSafeString(row["VariantId"]);
                model.Fuelname = MakeSafe.ToSafeString(row["FuelTypeId"]);
                model.TransmissionName = MakeSafe.ToSafeString(row["TransmissionTypeId"]);
                //model.ColorName = MakeSafe.ToSafeString(row["ColorId"]);

                model.OnShowPrice = MakeSafe.ToSafeDecimal(row["OnShowPrice"]);
                model.Gst = MakeSafe.ToSafeDecimal(row["Gst"]);
                model.TCS = MakeSafe.ToSafeDecimal(row["TCS"]);
                model.Netamount = MakeSafe.ToSafeDecimal(row["Netamount"]);
                model.WarrantyAmount = MakeSafe.ToSafeInt32(row["WarrantyAmount"]);

            }

            return model;
        }
    }
}
