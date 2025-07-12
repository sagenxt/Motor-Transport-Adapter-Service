using FluentValidation;
using Motor.Transport.Adapter.Models.DTOs.Request.Worker;
using Motor.Transport.Adapter.Service.Validators.BaseValidator;
using Motor.Transport.Adapter.Utility.Constants;

namespace Motor.Transport.Adapter.Service.Validators.Worker
{
    public class WorkerDetailsRequestValidator : BaseValidator<WorkerDetailsRequest>
    {
        public WorkerDetailsRequestValidator()
        {
            //RuleFor(x => x).NotNull()
            //                .WithMessage(ValidationMessages.FirstName_Required);
            RuleFor(x => x.FirstName).NotNull()
                                     .NotEmpty()
                                     .WithMessage(ValidationMessages.FirstName_Required);
            RuleFor(x => x.LastName).NotNull()
                                     .NotEmpty()
                                     .WithMessage(ValidationMessages.LastName_Required);
            RuleFor(x => x.MobileNumber).NotNull()
                                     .NotEmpty()
                                     .WithMessage(ValidationMessages.MobileNumber_Required);
        }
    }
}
