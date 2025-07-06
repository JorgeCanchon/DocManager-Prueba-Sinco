using DocManager.Application._Resources;
using DocManager.Application.Commands.CustomField;
using DocManager.Domain.Services.Persistence;
using FluentValidation;
using ExpedienteTypeEntity = DocManager.Domain.Entities.ExpedienteType;

namespace DocManager.Application.Commands.Validations.CustomField;

public class CreateCustomFieldValidator : AbstractValidator<CreateCustomFieldCommand>
{
    public CreateCustomFieldValidator(IRepositoryAsync<ExpedienteTypeEntity> expedienteTypeRepositoryAsync)
    {
        RuleFor(c => c.FieldName)
            .NotNull()
            .NotEmpty().WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.FieldName)));
        RuleFor(c => c.DataType)
            .NotNull()
            .WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.DataType)));
        RuleFor(c => c.Order)
            .NotNull()
            .WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.Order)));

        RuleFor(c => c.ExpedienteTypeId)
            .NotNull()
            .NotEmpty().WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.ExpedienteTypeId)))
            .MustAsync(async (id, cancellation) =>
            {
                var expedienteType = await expedienteTypeRepositoryAsync.GetByIdAsync(id, cancellation);
                return expedienteType is not null;
            }).WithMessage(c => string.Format(ApplicationErrors.EntityNotFound, nameof(ExpedienteTypeEntity), c.ExpedienteTypeId));
    }
}
