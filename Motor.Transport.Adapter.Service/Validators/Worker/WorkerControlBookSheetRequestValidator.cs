using FluentValidation;
using Motor.Transport.Adapter.Models.DTOs.Request.Worker;
using Motor.Transport.Adapter.Service.Validators.BaseValidator;
using Motor.Transport.Adapter.Utility.Constants;

namespace Motor.Transport.Adapter.Service.Validators.Worker
{
    public class WorkerControlBookSheetRequestValidator : BaseValidator<WorkerControlBookSheetRequest>
    {
        public WorkerControlBookSheetRequestValidator()
        {
            RuleFor(x => x.WorkerId).NotNull()
                                    .NotEmpty()
                                    .WithMessage(ValidationMessages.Worker_Id_Required);
        }
    }
}
