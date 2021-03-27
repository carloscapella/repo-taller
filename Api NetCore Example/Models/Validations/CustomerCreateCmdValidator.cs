using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_NetCore_Example.Models.Validations
{
    public class CustomerCreateCmdValidator : AbstractValidator<CustomerCreateCmd>
    {
        private readonly int _maxIdLength = 5;
        private readonly bool _isIdRepeated;

        public CustomerCreateCmdValidator(bool isIdRepeated)
        {
            _isIdRepeated = isIdRepeated;

            ApplyValidations();
        }

        private void ApplyValidations()
        {
            RuleFor(customer => customer.Id)
                
                .NotNull()
                .WithMessage("El id no puede ser nulo")
                
                .Must(ShouldHave5CharactersLengh)
                .WithMessage("El id no puede superar los 5 caracteres")
                
                .Must(ShouldNotBeRepeated)
                .WithMessage("El id está repetido");
        }

        private bool ShouldNotBeRepeated(string id)
        {
            return !_isIdRepeated;
        }

        private bool ShouldHave5CharactersLengh(string id)
        {
            return id.Trim().Length <= _maxIdLength;
        }
    }
}
