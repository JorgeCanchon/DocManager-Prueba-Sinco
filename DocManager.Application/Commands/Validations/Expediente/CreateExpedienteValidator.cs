using DocManager.Application._Resources;
using DocManager.Application.Commands.Expediente;
using DocManager.Domain.Services.Persistence;
using FluentValidation;
using ExpedienteTypeEntity = DocManager.Domain.Entities.ExpedienteType;

namespace DocManager.Application.Commands.Validations.Expediente;

public class CreateExpedienteValidator : AbstractValidator<CreateExpedienteCommand>
{
    public CreateExpedienteValidator(IRepositoryAsync<ExpedienteTypeEntity> expedienteTypeRepositoryAsync)
    {
        RuleFor(c => c.UniqueIdentifier)
            .NotNull()
            .NotEmpty().WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.UniqueIdentifier)));

        RuleFor(c => c.FieldValues)
            .NotNull()
            .NotEmpty().WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.FieldValues)));//TODO: Validar elementos que existan en db

        RuleFor(c => c.ExpedienteTypeId)
            .NotNull()
            .NotEmpty().WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.FieldValues)))
            .MustAsync(async (id, cancellation) =>
            {
                var expedienteType = await expedienteTypeRepositoryAsync.GetByIdAsync(id, cancellation);
                return expedienteType is not null;
            }).WithMessage(c => string.Format(ApplicationErrors.EntityNotFound, nameof(ExpedienteTypeEntity), c.ExpedienteTypeId));
    }
}
