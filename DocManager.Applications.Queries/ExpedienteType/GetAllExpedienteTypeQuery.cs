using DocManager.Application.Shared.Wrappers;
using ExpedienteTypeEntity = DocManager.Domain.Entities.ExpedienteType;
using MediatR;

namespace DocManager.Applications.Queries.ExpedienteType;

public record GetAllExpedienteTypeQuery : IRequest<Response<List<ExpedienteTypeEntity>>>
{
}
