using DocManager.Application.Shared.Wrappers;
using DocManager.Applications.Queries.ExpedienteType;
using DocManager.Applications.Queries.ExpedienteType.Models;
using DocManager.Domain.Services;
using MediatR;
using ExpedienteTypeEntity = DocManager.Domain.Entities.ExpedienteType;

namespace DocManager.Application.Queries.Handlers.ExpedienteType;

public class GetAllExpedienteTypeQueryHandler(IGetExpedienteTypeService getExpedienteTypeService)
    : IRequestHandler<GetAllExpedienteTypeQuery, Response<GetExpedienteTypeResponseModel>>
{
    public async Task<Response<GetExpedienteTypeResponseModel>> Handle(GetAllExpedienteTypeQuery request, CancellationToken cancellationToken)
    {
        List<ExpedienteTypeEntity> expedienteTypes = await getExpedienteTypeService.GetExpedienteTypeWithCustomFields(cancellationToken);

        return new Response<GetExpedienteTypeResponseModel>(new GetExpedienteTypeResponseModel
        {
            ExpedienteTypes = expedienteTypes
        });
    }
}
