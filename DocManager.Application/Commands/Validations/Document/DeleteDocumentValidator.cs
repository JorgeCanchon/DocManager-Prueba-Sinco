using DocManager.Application._Resources;
using DocManager.Application.Commands.Document;
using DocManager.Domain.Services.Persistence;
using FluentValidation;
using DocumentEntity = DocManager.Domain.Entities.Document;

namespace DocManager.Application.Commands.Validations.Document;

public class DeleteDocumentValidator : AbstractValidator<DeleteDocumentCommand>
{
    public DeleteDocumentValidator(IRepositoryAsync<DocumentEntity> documentRepositoryAsync)
    {
        RuleFor(c => c.Id)
            .NotNull()
            .NotEmpty().WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.Id)))
            .MustAsync(async (id, cancellation) =>
            {
                var document = await documentRepositoryAsync.GetByIdAsync(id, cancellation);
                return document is not null;
            }).WithMessage(c => string.Format(ApplicationErrors.EntityNotFound, nameof(DocumentEntity), c.Id));
    }
}
