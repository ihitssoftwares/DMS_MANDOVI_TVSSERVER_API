using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class ModelvsVariant
    {
        public string modelname { get; set; }
        public string variantname { get; set; }
        public Dropdown Modeldr { get; set; }
        public Dropdown Variant { get; set; }
        public int HDCode { get; set; }
        public int ColorCode { get; set; }
        public string ColorName { get; set; }
        public bool Applicability { get; set; }
        public string AbsoluteUri { get; set; }
        public string FileName { get; set; }

        public int Modelcode { get; set; }
        public int Variantcode { get; set; }

        public Dropdown Month { get; set; }

        public File File { get; set; } = new File();

        public File Attachment1 { get; set; } = new File();
        public File Attachment2 { get; set; } = new File();
        public File Attachment3 { get; set; } = new File();
        public File Attachment4 { get; set; } = new File();
        public File Attachment5 { get; set; } = new File();
        public File Attachment6 { get; set; } = new File();
        public File Attachment7 { get; set; } = new File();
        public File Attachment8 { get; set; } = new File();

        public List<ModelvsVariant> ModelvsVariantList { get; set; } = new List<ModelvsVariant>();
        public List<ModelvsVariant> ColorList { get; set; } = new List<ModelvsVariant>();
        public List<File> FileList { get; set; } = new List<File>();
        public List<ModelvsVariant> ApplicabilityList { get; set; } = new List<ModelvsVariant>();
    }
}
