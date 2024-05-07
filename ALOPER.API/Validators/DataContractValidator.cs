using ALOPER.Service.DTOs;
using FluentValidation;

namespace ALOPER.API.Validators
{
    public class DataContractValidator : AbstractValidator<DataContractRequest>
    {
        public DataContractValidator()
        {
            RuleFor(c => c.FullNameSale)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("{PropertyName} is not null.")
            .NotEmpty().WithMessage("{PropertyName} is not empty.")
            .MaximumLength(20).WithMessage("{PropertyName} is required less than or equal 20 characters.");

            RuleFor(c => c.PassportNumberSale)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.")
             .NotEmpty().WithMessage("{PropertyName} is not empty.")
             .Length(12).WithMessage("{PropertyName} must be 12 characters.");

            RuleFor(c => c.PhoneNumberSale)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.")
             .NotEmpty().WithMessage("{PropertyName} is not empty.")
             .Length(10).WithMessage("{PropertyName} must be 10 characters.");

            RuleFor(c => c.PositionSale)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.")
             .NotEmpty().WithMessage("{PropertyName} is not empty.")
             .MaximumLength(20).WithMessage("{PropertyName} is required less than or equal 20 characters.");

            RuleFor(c => c.FullNameCus)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.")
             .NotEmpty().WithMessage("{PropertyName} is not empty.")
             .MaximumLength(20).WithMessage("{PropertyName} is required less than or equal 20 characters.");

            RuleFor(c => c.PassportNumberCus)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.")
             .NotEmpty().WithMessage("{PropertyName} is not empty.")
             .Length(12).WithMessage("{PropertyName} must be 12 characters.");

            RuleFor(c => c.PhoneNumberCus)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.")
             .NotEmpty().WithMessage("{PropertyName} is not empty.")
             .Length(10).WithMessage("{PropertyName} must be 10 characters.");

            RuleFor(c => c.PlaceCus)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.")
             .NotEmpty().WithMessage("{PropertyName} is not empty.")
             .MaximumLength(50).WithMessage("{PropertyName} is required less than or equal 50 characters.");

            RuleFor(c => c.Address)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.")
             .NotEmpty().WithMessage("{PropertyName} is not empty.")
             .MaximumLength(50).WithMessage("{PropertyName} is required less than or equal 50 characters.");

            RuleFor(c => c.RoomCode)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.")
             .NotEmpty().WithMessage("{PropertyName} is not empty.")
             .MaximumLength(10).WithMessage("{PropertyName} is required less than or equal to 10 characters.");

            RuleFor(c => c.LeaseTerm)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.")
             .NotEmpty().WithMessage("{PropertyName} is not empty.")
             .MaximumLength(10).WithMessage("{PropertyName} is required less than or equal to 10 characters.");

            RuleFor(c => c.RentalFee)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage("{PropertyName} is not null.")
              .GreaterThan(0).WithMessage("{PropertyName} is greater than 0.");

            RuleFor(c => c.CheckinDate)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage("{PropertyName} is not null.");

            RuleFor(c => c.BookingAmount)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage("{PropertyName} is not null.")
              .GreaterThan(0).WithMessage("{PropertyName} is greater than 0.");

            RuleFor(c => c.AdditionalAmount)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage("{PropertyName} is not null.")
              .GreaterThan(0).WithMessage("{PropertyName} is greater than 0.");

            RuleFor(c => c.PaymentDeadline)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.");

            RuleFor(c => c.ElectricityFee)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.")
             .GreaterThan(0).WithMessage("{PropertyName} is greater than 0.");

            RuleFor(c => c.WaterFee)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.")
             .GreaterThan(0).WithMessage("{PropertyName} is greater than 0.");

            RuleFor(c => c.ParkingFee)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.")
             .GreaterThan(0).WithMessage("{PropertyName} is greater than 0.");

            RuleFor(c => c.ManagementFee)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.")
             .GreaterThan(0).WithMessage("{PropertyName} is greater than 0.");

            RuleFor(c => c.SignDate)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.");

            RuleFor(c => c.SignCustomer)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.")
             .NotEmpty().WithMessage("{PropertyName} is not empty.")
             .MaximumLength(20).WithMessage("{PropertyName} is required less than or equal 20 characters.");

            RuleFor(c => c.SignSale)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.")
             .NotEmpty().WithMessage("{PropertyName} is not empty.")
             .MaximumLength(20).WithMessage("{PropertyName} is required less than or equal 20 characters.");
        }
    }
}
