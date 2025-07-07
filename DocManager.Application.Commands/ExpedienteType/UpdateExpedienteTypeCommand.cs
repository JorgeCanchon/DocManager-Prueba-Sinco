using DocManager.Application.Shared.Wrappers;
using MediatR;

namespace DocManager.Application.Commands.ExpedienteType;

public record UpdateExpedienteTypeCommand : IRequest<Response<Guid>>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}
