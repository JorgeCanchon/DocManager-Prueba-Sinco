using DocManager.Application._Resources;
using DocManager.Application.Shared.Wrappers;
using DocManager.Applications.Queries.ExpedienteType;
using DocManager.Domain.Services;
using DocManager.Domain.Services.Persistence;
using MediatR;
using ExpedienteTypeEntity = DocManager.Domain.Entities.ExpedienteType;

namespace DocManager.Application.Queries.Handlers.ExpedienteType;

public class GetExpedienteTypeByIdQueryHandler(IGetExpedienteTypeService getExpedienteTypeService) 
    : IRequestHandler<GetExpedienteTypeByIdQuery, Response<ExpedienteTypeEntity>>
{
    public async Task<Response<ExpedienteTypeEntity>> Handle(GetExpedienteTypeByIdQuery request, CancellationToken cancellationToken)
    {
        ExpedienteTypeEntity expedienteType = await getExpedienteTypeService.GetExpedienteTypeByIdWithCustomFields(request.Id, cancellationToken) ?? throw new KeyNotFoundException(ApplicationErrors.RecordNotFound);
        return new Response<ExpedienteTypeEntity>(expedienteType);
    }
}
