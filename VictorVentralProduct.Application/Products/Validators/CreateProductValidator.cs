using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VictorVentralProduct.Application.Products.Dtos;

namespace VictorVentralProduct.Application.Products.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProduct>
    {
        public CreateProductValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("El nombre del producto no puede estar vacío.")
                .MaximumLength(100).WithMessage("El nombre del producto no puede tener más de 100 caracteres.");

            RuleFor(product => product.Description)
                .NotEmpty().WithMessage("La descripción del producto no puede estar vacía.")
                .MaximumLength(500).WithMessage("La descripción del producto no puede tener más de 500 caracteres.");

            RuleFor(product => product.UnitPrice)
                .NotNull().WithMessage("El precio unitario del producto es obligatorio.")
                .GreaterThan(0).WithMessage("El precio unitario del producto debe ser mayor que cero.");

            RuleFor(product => product.Stock)
                .NotNull().WithMessage("El stock del producto es obligatorio.")
                .GreaterThanOrEqualTo(0).WithMessage("El stock del producto no puede ser menor que cero.");

            RuleFor(product => product.Category)
                .NotEmpty().WithMessage("La categoría del producto no puede estar vacía.")
                .MaximumLength(50).WithMessage("La categoría del producto no puede tener más de 50 caracteres.");
        }
    }
}
