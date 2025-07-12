using Motor.Transport.Adapter.Models.Data;

namespace Motor.Transport.Adapter.Models.DTOs.Response
{
    public class WorkerControlBookSheetDetailsResponse : ControlBookSheetDetail
    {
        public string? Name { get; set; }
        public string? MobileNumber { get; set; }
        public string? EmailId { get; set; }
        public string? OnDutyOrRestDescription { get; set; }
    }
}
