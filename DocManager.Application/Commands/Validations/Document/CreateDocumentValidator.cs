using DocManager.Application._Resources;
using DocManager.Application.Commands.Document;
using DocManager.Domain.Services.Persistence;
using FluentValidation;
using ExpedienteEntity = DocManager.Domain.Entities.Expediente;

namespace DocManager.Application.Commands.Validations.Document;

public class CreateDocumentValidator : AbstractValidator<CreateDocumentCommand>
{
    public CreateDocumentValidator(IRepositoryAsync<ExpedienteEntity> expedienteRepositoryAsync)
    {
        RuleFor(c => c.ExpedienteId)
            .NotNull()
            .NotEmpty().WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.ExpedienteId)))
            .MustAsync(async (id, cancellation) =>
            {
                var expediente = await expedienteRepositoryAsync.GetByIdAsync(id, cancellation);
                return expediente is not null;
            }).WithMessage(c => string.Format(ApplicationErrors.EntityNotFound, nameof(ExpedienteEntity), c.ExpedienteId));

        RuleFor(c => c.FormFile)
            .NotNull()
            .NotEmpty().WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.FormFile)));
    }
}
