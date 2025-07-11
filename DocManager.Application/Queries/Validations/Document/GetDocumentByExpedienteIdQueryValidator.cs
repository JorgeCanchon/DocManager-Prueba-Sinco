using DocManager.Application._Resources;
using DocManager.Applications.Queries.Document;
using DocManager.Domain.Services.Persistence;
using FluentValidation;
using ExpedienteEntity = DocManager.Domain.Entities.Expediente;

namespace DocManager.Application.Queries.Validations.Document;

public class GetDocumentByExpedienteIdQueryValidator : AbstractValidator<GetDocumentByExpedienteIdQuery>
{
    public GetDocumentByExpedienteIdQueryValidator(IRepositoryAsync<ExpedienteEntity> expedienteEntityRepositoryAsync)
    {
        RuleFor(c => c.Id)
            .NotNull().WithMessage(c => string.Format(ValidationMessages.IsNotNull, nameof(c.Id)))
            .NotEmpty().WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.Id)))
            .MustAsync(async (id, cancellation) =>
            {
                var document = await expedienteEntityRepositoryAsync.GetByIdAsync(id, cancellation);
                return document is not null;
            }).WithMessage(c => string.Format(ApplicationErrors.EntityNotFound, nameof(ExpedienteEntity), c.Id));
    }
}