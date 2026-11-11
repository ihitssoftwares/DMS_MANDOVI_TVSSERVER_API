
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;



namespace Cloud_Custom.Api.Infrastructure.Helpers
{
  
    public class Blob :IBlob
    {
        private readonly Shared.General.Storage _storageConfig;
        private readonly CloudBlobClient _cloudBlobClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

     
        public Blob(IOptions<AppSettings> settings, IHttpContextAccessor httpContextAccessor)
        {
            _storageConfig = settings.Value.Storage;
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(_storageConfig.ConnectionString);
            _cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Shared.General.File> UploadToAzureAsync(Shared.General.File file, UserBase user, string PhysicalPath)
        {
            var cloudBlobContainer = _cloudBlobClient.GetContainerReference(_storageConfig.BlobContainer);
            var fileObj = GenerateFileName_Blob(file, user, PhysicalPath);
            if (await cloudBlobContainer.CreateIfNotExistsAsync())
            {
                await cloudBlobContainer.SetPermissionsAsync(new
                    BlobContainerPermissions
                {
                    PublicAccess =
                    BlobContainerPublicAccessType.Blob
                });
            }
            var cloudBlockBlob =
                cloudBlobContainer.GetBlockBlobReference(fileObj.FileName);
            cloudBlockBlob.Properties.ContentType = fileObj.FileData.ContentType; ;

            await
                cloudBlockBlob.UploadFromStreamAsync(fileObj.FileData.OpenReadStream());
            fileObj.AbsoluteUri = cloudBlockBlob.Uri.AbsoluteUri;
            return fileObj;
        }
        private Shared.General.File GenerateFileName_Blob(Shared.General.File file, UserBase user, string PhysicalPath)
        {
            if (user.CompanyGuid != Guid.Empty)
                file.RelativeUri = user.CompanyGuid.ToString() + PhysicalPath;
            else
                file.RelativeUri = Guid.NewGuid().ToString() + PhysicalPath;
            var fileExtension = "";
            var fileName = "";
            if (file.FileData == null)
            {
                fileName = file.FileName;
                fileExtension = file.FileExtension;
            }
            else
            {
                fileName = Path.GetFileName(file.FileData.FileName);
                fileExtension = Path.GetExtension(file.FileData.FileName);
            }

            file.ActualFileName = fileName;
            file.FileExtension = fileExtension;
            file.FileName = $"{file.RelativeUri}{Guid.NewGuid().ToString()}{fileExtension}";
            return file;
        }

    }
}

