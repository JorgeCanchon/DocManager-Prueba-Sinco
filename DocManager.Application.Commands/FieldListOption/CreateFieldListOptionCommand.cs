using DocManager.Application.Shared.Wrappers;
using MediatR;

namespace DocManager.Application.Commands.FieldListOption;

public record CreateFieldListOptionCommand : IRequest<Response<Guid>>
{
    public Guid CustomFieldId { get; set; }
    public string OptionValue { get; set; } = null!;
}
