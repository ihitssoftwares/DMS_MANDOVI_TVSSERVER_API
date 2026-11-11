using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class ModelVsVariantUpload
    {
        public File ImportFromExcel { get; set; }
        public string Message { get; set; }
        public List<ModelVsVariantUploadModel> ModelVsVariantUploadModel { get; set; }
        public List<modelvsvariant> modelvsvariant { get; set; }
        public List<ModelVsVariantUploadModel> ModelVsVariantUploadList { get; set; }
        public Dropdown Month { get; set; }

    }


}
public class ModelVsVariantUploadModel
{
    public int TrnCode { get; set; }

    public string Model { get; set; }

    public string VariantCode { get; set; }

    public string Variant { get; set; }

    public string Color { get; set; }

    public int Total { get; set; }


}
public class modelvsvariant
{
    public int TrnCode { get; set; }
    public string sl { get; set; }

    public string Model { get; set; }

    public string VariantCode { get; set; }

    public string Variant { get; set; }

    public string Color { get; set; }


    public string Total { get; set; }
    public int EntrBy { get; set; }
    public string Message { get; set; }
    public DateTime EntryDate { get; set; }
}


