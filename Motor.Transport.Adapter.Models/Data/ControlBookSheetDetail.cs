using Motor.Transport.Adapter.Models.Data.Common;

namespace Motor.Transport.Adapter.Models.Data
{
    public class ControlBookSheetDetail
    {
        public long SheetId { get; set; }
        public long WorkerId { get; set; }
        public DateOnly? WorkDate { get; set; }
        public string? DayOfWeek { get; set; }
        public string? OnDutyOrRest { get; set; }
        public DateOnly? EndingWorkDate { get; set; }
        public int? PeriodOfVehiceIsOnRoad { get; set; }
        public int? PeriodOfInterruption { get; set; }
        public int? RunningTime { get; set; }
        public int? SubsidiaryWorkTime { get; set; }
        public int? PeriodOfMereAttendance { get; set; }
        public int? HoursOfWork { get; set; }
        public int? RestInterval { get; set; }
        public int? OvertimeLengthWorked { get; set; }
        public string? OvertimeLengthWorkedReason { get; set; }
        public string? Remarks { get; set; }
        public CoordinateDetail? Coordinates { get; set; }
    }
}
