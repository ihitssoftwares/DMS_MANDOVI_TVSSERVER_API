using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class UploadedFilesReport
    {


       
            public string Module { get; set; }

            public string Month { get; set; }

            public List<UploadedFilesReportList> List { get; set; }

            public int PythonTotalFiles { get; set; }

            public int TableTotalFiles { get; set; }
    }

        public class UploadedFilesReportList
        {
            public string ServerFileName { get; set; }

            public bool IsFileExists { get; set; }
        }
    }

