
namespace Motor.Transport.Adapter.Models.DTOs.Request.Worker
{
    public class WorkerLoginRequest
    {
        public required string MobileNumber { get; set; }
        public required string OtpCode { get; set; }
    }
}
