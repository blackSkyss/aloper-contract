using ALOPER.Service.DTOs;
using FluentValidation;

namespace ALOPER.API.Validators
{
    public class ServiceValidator : AbstractValidator<ServiceRequest>
    {
        public ServiceValidator()
        {
            RuleFor(s => s.IdService)
                   .Cascade(CascadeMode.Stop)
                   .NotNull().WithMessage("{PropertyName} is not null.")
                   .GreaterThan(0).WithMessage("{PropertyName} is not suitable id in the system.");

            RuleFor(s => s.PriceService)
                   .Cascade(CascadeMode.Stop)
                   .NotNull().WithMessage("{PropertyName} is not null.")
                   .GreaterThan(0).WithMessage("{PropertyName} is not suitable id in the system.");

            RuleFor(s => s.Dvt)
                   .Cascade(CascadeMode.Stop)
                   .NotNull().WithMessage("{PropertyName} is not null.")
                   .NotEmpty().WithMessage("{PropertyName} is not empty.")
                   .MaximumLength(100).WithMessage("{PropertyName} is required less than or equal to 100 characters.");

            RuleFor(s => s.OldNumber)
                   .Cascade(CascadeMode.Stop)
                   .NotNull().WithMessage("{PropertyName} is not null.")
                   .GreaterThan(0).WithMessage("{PropertyName} is not suitable id in the system.");

            RuleFor(s => s.Name)
                   .Cascade(CascadeMode.Stop)
                   .NotNull().WithMessage("{PropertyName} is not null.")
                   .NotEmpty().WithMessage("{PropertyName} is not empty.")
                   .MaximumLength(20).WithMessage("{PropertyName} is required less than or equal to 20 characters.");
        }
    }
}


