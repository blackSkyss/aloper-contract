﻿using ALOPER.Service.DTOs;
using FluentValidation;

namespace ALOPER.API.Validators
{
    public class InsertContractValidator : AbstractValidator<InsertContractRequest>
    {
        public InsertContractValidator()
        {
            RuleFor(c => c.Id)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.")
             .NotEmpty().WithMessage("{PropertyName} is not empty.")
             .Length(10).WithMessage("{PropertyName} is required must be 10 characters.");

            RuleFor(c => c.IdRoom)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.")
             .GreaterThan(0).WithMessage("{PropertyName} is greater than 0.");

            RuleFor(c => c.rentalTerm)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.")
             .GreaterThan(0).WithMessage("{PropertyName} is greater than 0.");

            RuleFor(c => c.DepositDate)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.");

            RuleFor(c => c.DepositAmount)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("{PropertyName} is not null.")
            .GreaterThan(0).WithMessage("{PropertyName} is greater than 0.");

            RuleFor(c => c.RentalPrice)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("{PropertyName} is not null.")
            .GreaterThan(0).WithMessage("{PropertyName} is greater than 0.");

            RuleFor(c => c.RentalStartDate)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.");

            RuleFor(c => c.NumberOfPeople)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.")
             .GreaterThan(0).WithMessage("{PropertyName} is greater than 0.");

            RuleFor(c => c.NumberOfVehicle)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.")
             .GreaterThan(0).WithMessage("{PropertyName} is greater than 0.");

            RuleFor(c => c.FullName)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.")
             .NotEmpty().WithMessage("{PropertyName} is not empty.")
             .MaximumLength(20).WithMessage("{PropertyName} is required less than or equal to 20 characters.");

            RuleFor(c => c.PhoneNumber)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.")
             .NotEmpty().WithMessage("{PropertyName} is not empty.")
             .MaximumLength(10).WithMessage("{PropertyName} is required less than or equal to 10 characters.");

            RuleFor(c => c.BirthOfDay)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage("{PropertyName} is not null.");

            RuleFor(c => c.Identification)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage("{PropertyName} is not null.")
              .NotEmpty().WithMessage("{PropertyName} is not empty.")
              .MaximumLength(20).WithMessage("{PropertyName} is required less than or equal to 20 characters.");

            RuleFor(c => c.DateRange)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage("{PropertyName} is not null.");

            RuleFor(c => c.IssuedBy)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.")
             .NotEmpty().WithMessage("{PropertyName} is not empty.")
             .MaximumLength(20).WithMessage("{PropertyName} is required less than or equal to 20 characters.");

            RuleFor(c => c.PermanentAddress)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.")
             .NotEmpty().WithMessage("{PropertyName} is not empty.")
             .MaximumLength(50).WithMessage("{PropertyName} is required less than or equal to 50 characters.");

            RuleFor(c => c.Signature)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.")
             .NotEmpty().WithMessage("{PropertyName} is not empty.")
             .MaximumLength(20).WithMessage("{PropertyName} is required less than or equal to 20 characters.");

            RuleFor(c => c.ContractEndDate)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.");

            RuleFor(c => c.Note)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("{PropertyName} is not null.")
             .NotEmpty().WithMessage("{PropertyName} is not empty.")
             .MaximumLength(100).WithMessage("{PropertyName} is required less than or equal to 100 characters.");

            RuleForEach(c => c.Services)
              .SetValidator(new ServiceValidator());

            RuleForEach(c => c.Furnitures)
              .SetValidator(new FurnitureValidator());
        }
    }
}
