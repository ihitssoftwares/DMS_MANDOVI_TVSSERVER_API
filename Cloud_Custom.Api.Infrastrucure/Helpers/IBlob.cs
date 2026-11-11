using Cloud_Custom.Api.Shared.General;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Infrastructure.Helpers
{
    public interface IBlob
    {

        Task<File> UploadToAzureAsync(File file, UserBase user, string PhysicalPath);

    }
}
