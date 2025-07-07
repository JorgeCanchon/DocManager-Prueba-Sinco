using DocManager.Application._Resources;
using DocManager.Application.Commands.Document;
using FluentValidation;

namespace DocManager.Application.Commands.Validations.Document;

public class CreateDocumentValidator : AbstractValidator<CreateDocumentCommand>
{
    public CreateDocumentValidator()
    {
        RuleFor(c => c.ExpedienteId)
            .NotNull()
            .NotEmpty().WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.ExpedienteId)));

        RuleFor(c => c.FormFile)
            .NotNull()
            .NotEmpty().WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.FormFile)));
    }
}
