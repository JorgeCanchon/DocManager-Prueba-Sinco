using DocManager.Application._Resources;
using DocManager.Applications.Queries.ExpedienteType;
using FluentValidation;

namespace DocManager.Application.Queries.Validations.ExpedienteType;

public class GetExpedienteTypeByIdQueryValidator : AbstractValidator<GetExpedienteTypeByIdQuery>
{
    public GetExpedienteTypeByIdQueryValidator()
    {
        RuleFor(c => c.Id)
            .NotNull()
            .NotEmpty().WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.Id)));
    }
}