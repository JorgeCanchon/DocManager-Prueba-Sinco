using DocManager.Application._Resources;
using DocManager.Applications.Queries.Document;
using DocManager.Domain.Services.Persistence;
using FluentValidation;
using DocumentEntity = DocManager.Domain.Entities.Document;

namespace DocManager.Application.Queries.Validations.Document;

public class GetDocumentByIdQueryValidator : AbstractValidator<GetDocumentByIdQuery>
{
    public GetDocumentByIdQueryValidator(IRepositoryAsync<DocumentEntity> documentEntityRepositoryAsync)
    {
        RuleFor(c => c.Id)
            .NotNull().WithMessage(c => string.Format(ValidationMessages.IsNotNull, nameof(c.Id)))
            .NotEmpty().WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.Id)))
            .MustAsync(async (id, cancellation) =>
            {
                var document = await documentEntityRepositoryAsync.GetByIdAsync(id, cancellation);
                return document is not null;
            }).WithMessage(c => string.Format(ApplicationErrors.EntityNotFound, nameof(DocumentEntity), c.Id));
    }
}