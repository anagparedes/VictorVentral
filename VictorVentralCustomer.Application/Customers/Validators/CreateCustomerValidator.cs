using FluentValidation;
using VictorVentralCustomer.Application.Customers.Dtos;

namespace VictorVentralCustomer.Application.Customers.Validators
{
    public class CreateCustomerValidator: AbstractValidator<CreateCustomer>
    {
        public CreateCustomerValidator()
        {
            RuleFor(customer => customer.Name).NotEmpty().WithMessage("El nombre no puede estar vacío.");
            RuleFor(customer => customer.LastName).NotEmpty().WithMessage("El apellido no puede estar vacío.");
            RuleFor(customer => customer.Email).EmailAddress().When(customer => !string.IsNullOrWhiteSpace(customer?.Email)).WithMessage("Correo electrónico no válido.");
            RuleFor(customer => customer.PhoneNumber).Matches(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$").When(customer => !string.IsNullOrWhiteSpace(customer?.PhoneNumber)).WithMessage("Número de teléfono no válido.");
            RuleFor(customer => customer.Address).NotEmpty().WithMessage("La dirección no puede estar vacía.");
        }
    }
}
