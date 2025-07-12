using FluentValidation;
using Motor.Transport.Adapter.Models.DTOs.Request.Worker;
using Motor.Transport.Adapter.Service.Validators.BaseValidator;
using Motor.Transport.Adapter.Utility.Constants;

namespace Motor.Transport.Adapter.Service.Validators.Worker
{
    public class OtpVerificationRequestValidator : BaseValidator<OtpVerificationRequest>
    {
        public OtpVerificationRequestValidator()
        {
            RuleFor(x => x.MobileNumber).NotNull()
                                     .NotEmpty()
                                     .WithMessage(ValidationMessages.MobileNumber_Required);
            RuleFor(x => x.OtpCode).NotNull()
                                     .NotEmpty()
                                     .WithMessage(ValidationMessages.Otp_Required);
            RuleFor(x => x.CreatedAt).NotNull()
                                     .NotEmpty()
                                     .WithMessage(ValidationMessages.Created_Date_Required);
            RuleFor(x => x.ExpiresAt).NotNull()
                                     .NotEmpty()
                                     .WithMessage(ValidationMessages.Expires_Date_Required);
        }
    }
}
