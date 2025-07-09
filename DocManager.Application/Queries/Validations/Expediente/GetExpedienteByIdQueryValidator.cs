using DocManager.Application._Resources;
using DocManager.Applications.Queries.Expediente;
using DocManager.Domain.Services.Persistence;
using FluentValidation;
using ExpedienteEntity = DocManager.Domain.Entities.Expediente;

namespace DocManager.Application.Queries.Validations.Expediente;

public class GetExpedienteByIdQueryValidator : AbstractValidator<GetExpedienteByIdQuery>
{
    public GetExpedienteByIdQueryValidator(IRepositoryAsync<ExpedienteEntity> expedienteEntityRepositoryAsync)
    {
        RuleFor(c => c.Id)
            .NotNull().NotNull().WithMessage(c => string.Format(ValidationMessages.IsNotNull, nameof(c.Id)))
            .NotEmpty().WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.Id)))
            .MustAsync(async (id, cancellation) =>
            {
                var expediente = await expedienteEntityRepositoryAsync.GetByIdAsync(id, cancellation);
                return expediente is not null;
            }).WithMessage(c => string.Format(ApplicationErrors.EntityNotFound, nameof(ExpedienteEntity), c.Id)); 
    }
}
