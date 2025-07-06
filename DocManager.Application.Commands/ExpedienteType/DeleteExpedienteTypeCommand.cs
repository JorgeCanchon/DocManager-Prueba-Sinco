using DocManager.Application.Shared.Wrappers;
using MediatR;

namespace DocManager.Application.Commands.ExpedienteType;

public record DeleteExpedienteTypeCommand : IRequest<Response<Guid>>
{
    public Guid Id { get; set; }
}