using DocManager.Application._Resources;
using DocManager.Application.Commands.Expediente;
using FluentValidation;

namespace DocManager.Application.Commands.Validations.Expediente;

public class CreateExpedienteValidator : AbstractValidator<CreateExpedienteCommand>
{
    public CreateExpedienteValidator()
    {
        RuleFor(c => c.UniqueIdentifier)
            .NotNull()
            .NotEmpty().WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.UniqueIdentifier)));

        RuleFor(c => c.FieldValues)
            .NotNull()
            .NotEmpty().WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.FieldValues)));

        RuleFor(c => c.ExpedienteTypeId)
            .NotNull()
            .NotEmpty().WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.FieldValues)));
    }
}
