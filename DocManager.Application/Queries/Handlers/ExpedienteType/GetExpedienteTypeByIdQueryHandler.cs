using DocManager.Application._Resources;
using DocManager.Application.Shared.Wrappers;
using DocManager.Applications.Queries.ExpedienteType;
using DocManager.Applications.Queries.ExpedienteType.Models;
using DocManager.Domain.Services;
using MediatR;
using ExpedienteTypeEntity = DocManager.Domain.Entities.ExpedienteType;

namespace DocManager.Application.Queries.Handlers.ExpedienteType;

public class GetExpedienteTypeByIdQueryHandler(IGetExpedienteTypeService getExpedienteTypeService) 
    : IRequestHandler<GetExpedienteTypeByIdQuery, Response<GetExpedienteTypeByIdResponseModel>>
{
    public async Task<Response<GetExpedienteTypeByIdResponseModel>> Handle(GetExpedienteTypeByIdQuery request, CancellationToken cancellationToken)
    {
        ExpedienteTypeEntity expedienteType = await getExpedienteTypeService.GetExpedienteTypeByIdWithCustomFields(request.Id, cancellationToken) ?? throw new KeyNotFoundException(ApplicationErrors.RecordNotFound);
        return new Response<GetExpedienteTypeByIdResponseModel>(new GetExpedienteTypeByIdResponseModel()
        {
            ExpedienteTypeEntity = expedienteType
        });
    }
}
