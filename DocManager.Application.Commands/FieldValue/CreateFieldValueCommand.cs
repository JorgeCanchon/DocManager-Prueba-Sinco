using DocManager.Application.Shared.Wrappers;
using MediatR;

namespace DocManager.Application.Commands.FieldValue;

public class CreateFieldValueCommand : IRequest<Response<Guid>>
{
    public Guid CustomFieldId { get; set; }
    public string Value { get; set; } = null!;
    public Guid ExpedienteId { get; set; }
}
