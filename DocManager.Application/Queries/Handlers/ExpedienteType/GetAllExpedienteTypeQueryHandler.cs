using DocManager.Application.Shared.Wrappers;
using DocManager.Applications.Queries.ExpedienteType;
using DocManager.Domain.Services;
using DocManager.Domain.Services.Persistence;
using MediatR;
using ExpedienteTypeEntity = DocManager.Domain.Entities.ExpedienteType;

namespace DocManager.Application.Queries.Handlers.ExpedienteType;

public class GetAllExpedienteTypeQueryHandler(IGetExpedienteTypeService getExpedienteTypeService)
    : IRequestHandler<GetAllExpedienteTypeQuery, Response<List<ExpedienteTypeEntity>>>
{
    public async Task<Response<List<ExpedienteTypeEntity>>> Handle(GetAllExpedienteTypeQuery request, CancellationToken cancellationToken)
    {
        List<ExpedienteTypeEntity> expedienteTypes = await getExpedienteTypeService.GetExpedienteTypeWithCustomFields(cancellationToken);
        return new Response<List<ExpedienteTypeEntity>>(expedienteTypes);
    }
}
