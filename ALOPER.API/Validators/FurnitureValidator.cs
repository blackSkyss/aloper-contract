using ALOPER.Service.DTOs;
using FluentValidation;

namespace ALOPER.API.Validators
{
    public class FurnitureValidator : AbstractValidator<FurnitureRequest>
    {
        public FurnitureValidator()
        {
            RuleFor(f => f.IdFurniture)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.")
             .GreaterThan(0).WithMessage("{PropertyName} is not suitable id in the system.");

            RuleFor(f => f.Price)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("{PropertyName} is not null.")
            .GreaterThan(0).WithMessage("{PropertyName} is not suitable id in the system.");

            RuleFor(f => f.Note)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("{PropertyName} is not null.")
            .NotEmpty().WithMessage("{PropertyName} is not empty.")
            .MaximumLength(100).WithMessage("{PropertyName} is required less than or equal to 100 characters.");

            RuleFor(f => f.Name)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("{PropertyName} is not null.")
            .NotEmpty().WithMessage("{PropertyName} is not empty.")
            .MaximumLength(20).WithMessage("{PropertyName} is required less than or equal to 20 characters.");

            RuleFor(f => f.Status)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("{PropertyName} is not null.")
            .NotEmpty().WithMessage("{PropertyName} is not empty.")
            .MaximumLength(15).WithMessage("{PropertyName} is required less than or equal to 15 characters.");

            RuleFor(f => f.IsActive)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("{PropertyName} is not null.");
        }
    }
}
