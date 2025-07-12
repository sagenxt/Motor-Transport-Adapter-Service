using FluentValidation;
using Motor.Transport.Adapter.Models.DTOs.Request.Worker;
using Motor.Transport.Adapter.Service.Validators.BaseValidator;
using Motor.Transport.Adapter.Utility.Constants;

namespace Motor.Transport.Adapter.Service.Validators.Worker
{
    public class ControlBookSheetDetailsRequestValidator : BaseValidator<WorkerControlBookSheetDetailsRequest>
    {
        public ControlBookSheetDetailsRequestValidator()
        {
            RuleFor(x => x.WorkerId).NotNull()
                                    .NotEmpty()
                                    .WithMessage(ValidationMessages.Worker_Id_Required);
            RuleFor(x => x.WorkDate).NotNull()
                                     .NotEmpty()
                                     .WithMessage(ValidationMessages.Work_Date_Required);
            RuleFor(x => x.DayOfWeek).NotNull()
                                     .NotEmpty()
                                     .WithMessage(ValidationMessages.Created_Date_Required);
            
        }
    }
}
