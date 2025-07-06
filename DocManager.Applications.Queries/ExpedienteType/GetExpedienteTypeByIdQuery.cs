using DocManager.Application.Shared.Wrappers;
using ExpedienteTypeEntity = DocManager.Domain.Entities.ExpedienteType;
using MediatR;

namespace DocManager.Applications.Queries.ExpedienteType;

public record GetExpedienteTypeByIdQuery : IRequest<Response<ExpedienteTypeEntity>>
{
    public Guid Id { get; set; }
}