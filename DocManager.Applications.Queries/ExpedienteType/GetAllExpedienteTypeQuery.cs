using DocManager.Application.Shared.Wrappers;
using DocManager.Applications.Queries.ExpedienteType.Models;
using MediatR;

namespace DocManager.Applications.Queries.ExpedienteType;

public record GetAllExpedienteTypeQuery : IRequest<Response<GetExpedienteTypeResponseModel>>
{
}
