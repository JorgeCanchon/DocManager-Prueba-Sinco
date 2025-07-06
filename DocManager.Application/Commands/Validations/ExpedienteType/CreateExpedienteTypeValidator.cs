using DocManager.Application._Resources;
using DocManager.Application.Commands.ExpedienteType;
using FluentValidation;

namespace DocManager.Application.Commands.Validations.ExpedienteType;

public class CreateExpedienteTypeValidator : AbstractValidator<CreateExpedienteTypeCommand>
{
    public CreateExpedienteTypeValidator()
    {
        RuleFor(c => c.Name)
            .NotNull()
            .NotEmpty().WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.Name)))
            .MaximumLength(450).WithMessage(c => string.Format(ValidationMessages.ExceedLimit, nameof(c.Name), 450));

        RuleFor(c => c.Description)
            .NotNull()
            .NotEmpty().WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.Name)));
    }
}
