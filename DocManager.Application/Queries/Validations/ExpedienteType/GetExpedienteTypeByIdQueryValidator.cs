using DocManager.Application._Resources;
using DocManager.Applications.Queries.ExpedienteType;
using DocManager.Domain.Services.Persistence;
using FluentValidation;
using ExpedienteTypeEntity = DocManager.Domain.Entities.ExpedienteType;

namespace DocManager.Application.Queries.Validations.ExpedienteType;

public class GetExpedienteTypeByIdQueryValidator : AbstractValidator<GetExpedienteTypeByIdQuery>
{
    public GetExpedienteTypeByIdQueryValidator(IRepositoryAsync<ExpedienteTypeEntity> expedienteTypeEntityRepositoryAsync)
    {
        RuleFor(c => c.Id)
            .NotNull().NotNull().WithMessage(c => string.Format(ValidationMessages.IsNotNull, nameof(c.Id)))
            .NotEmpty().WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.Id)))
            .MustAsync(async (id, cancellation) =>
            {
                var expedienteType = await expedienteTypeEntityRepositoryAsync.GetByIdAsync(id, cancellation);
                return expedienteType is not null;
            }).WithMessage(c => string.Format(ApplicationErrors.EntityNotFound, nameof(ExpedienteType), c.Id)); 
    }
}