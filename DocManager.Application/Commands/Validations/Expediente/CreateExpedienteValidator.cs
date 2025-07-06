using DocManager.Application._Resources;
using DocManager.Application.Commands.Expediente;
using FluentValidation;

namespace DocManager.Application.Commands.Validations.Expediente;

public class CreateExpedienteValidator : AbstractValidator<CreateExpedienteCommand>
{
    public CreateExpedienteValidator()
    {

    }
}
