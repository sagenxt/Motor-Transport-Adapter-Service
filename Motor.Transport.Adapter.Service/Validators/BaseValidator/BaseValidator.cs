using FluentValidation;
using FluentValidation.Results;

namespace Motor.Transport.Adapter.Service.Validators.BaseValidator
{
    public abstract class BaseValidator<T> : AbstractValidator<T> where T : class
    {
        public override async Task<ValidationResult> ValidateAsync(ValidationContext<T> context, CancellationToken cancellationToken = default)
        {
            if (context.InstanceToValidate == default)
            {
                return new ValidationResult(new[]
                {
                    new ValidationFailure(typeof(T).Name, "Instance cannot be null")
                });
            }
            return await base.ValidateAsync(context, cancellationToken);
        }
    }
}
