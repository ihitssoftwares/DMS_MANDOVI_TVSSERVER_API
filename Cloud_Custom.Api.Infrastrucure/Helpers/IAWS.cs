using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Infrastrucure.Helpers
{
 public    interface IAWS
    {
        public Task<Shared.General.File> UploadIformFile(Shared.General.File file, AwsStorage AwsStorage);
        public Task<Shared.General.File> UploadByteArray(Shared.General.File file, AwsStorage AwsStorage);
        public string GetAWS_AbsoluteURI(string awsfile, AwsStorage AWS);
        public void Delete_AWS(string Filename, AwsStorage AwsStorage);
        public Task<bool> Delete_Blob(string Filename);
    }
}
