

namespace Cloud_Custom.Api.Shared.General
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public AppTokens Token { get; set; }
        public OTPSettings OTPSettings { get; set; }
        public string PushNotification { get; set; }
        public string FireBaseProductID { get; set; }
        public Storage Storage { get; set; }
    }
    public class Storage
    {
        public string ConnectionString { get; set; }
        public string BlobContainer { get; set; }
    }
    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
        public string SqlConnection { get; set; }
    }
    public class AppTokens
    {
        public TokenConfigration Login { get; set; }
        public TokenConfigration ResetPassword { get; set; }
        public TokenConfigration MobileLogin { get; set; }
    }
    public class TokenConfigration
    {
        public int Creation { get; set; }
        public int Expiration { get; set; }
        public string TokenSecret { get; set; }
        public string Issuer { get; set; }
        public string  Audience { get; set; }
    }
    public class OTPSettings
    {
        public int Length { get; set; }
    }
    public class AwsStorage
    {
        public string AwsAccessKey { get; set; }
        public string AwsSecretAccessKey { get; set; }
        public string BucketName { get; set; }
        public string Region { get; set; }
        public string PhysicalPath { get; set; }
        public string AccessPointName { get; set; }
    }

}