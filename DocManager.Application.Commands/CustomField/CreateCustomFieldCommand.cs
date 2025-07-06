using DocManager.Application.Commands.FieldListOption;
using DocManager.Application.Shared.Wrappers;
using DocManager.Domain.Shared.Enums;
using MediatR;

namespace DocManager.Application.Commands.CustomField;

public record CreateCustomFieldCommand : IRequest<Response<Guid>>
{
    public Guid ExpedienteTypeId { get; set; }
    public string FieldName { get; set; } = null!;
    public DataType DataType { get; set; }
    public bool IsRequired { get; set; }
    public int Order { get; set; } = 0;
    public List<CreateFieldListOptionCommand> Options { get; set; } = [];
}