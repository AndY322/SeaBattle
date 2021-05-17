﻿using DomainModel.DTO;
using FluentValidation;

namespace DomainModel.Validators
{
    public class RegistrationModelValidator : AbstractValidator<RegistrationModel>
    {
        RegistrationModelValidator()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Login).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}