
namespace Motor.Transport.Adapter.Models.Data
{
    public class OtpVerification
    {
        public required string MobileNumber { get; set; }
        public required string OtpCode { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime ExpiresAt { get; set; }
    }
}
