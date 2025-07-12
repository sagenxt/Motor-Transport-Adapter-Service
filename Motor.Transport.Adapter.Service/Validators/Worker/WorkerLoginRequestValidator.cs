using FluentValidation;
using Motor.Transport.Adapter.Models.DTOs.Request.Worker;
using Motor.Transport.Adapter.Service.Validators.BaseValidator;
using Motor.Transport.Adapter.Utility.Constants;

namespace Motor.Transport.Adapter.Service.Validators.Worker
{
    public class WorkerLoginRequestValidator : BaseValidator<WorkerLoginRequest>
    {
        public WorkerLoginRequestValidator()
        {
            //RuleFor(x => x).NotNull()
            //                .WithMessage(ValidationMessages.FirstName_Required);
            
            RuleFor(x => x.MobileNumber).NotNull()
                                     .NotEmpty()
                                     .WithMessage(ValidationMessages.MobileNumber_Required);
            RuleFor(x => x.OtpCode).NotNull()
                                     .NotEmpty()
                                     .WithMessage(ValidationMessages.Otp_Required);
        }
    }
}
