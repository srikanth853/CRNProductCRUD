using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(x => x.ProductName)
            .NotEmpty()
            .MaximumLength(255);

        RuleFor(x => x.CreatedBy)
            .NotEmpty();
    }
}