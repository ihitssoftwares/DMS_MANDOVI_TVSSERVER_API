using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Mobile
{
    public class InvoiceDetailsAI
    {
        public File File { get; set; }

        public int InvoiceEntryCode { get; set; }

        public string AIResponse { get; set; }

        public string Status { get; set; }

        public UserBase User { get; set; }
    }
    public class InvoiceDetailsResponse
    {
        public int InvoiceEntryCode { get; set; }

        public string Status { get; set; }

        public string AbsoluteUri { get; set; }

        public string InvoiceNo { get; set; }

        public string InvoiceDate { get; set; }

        public string JobCardNo { get; set; }

        public string RegNo { get; set; }

        public decimal NetPayableAmount { get; set; }
    }
}
