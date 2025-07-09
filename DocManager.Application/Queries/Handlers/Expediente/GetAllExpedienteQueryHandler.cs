using DocManager.Application.Shared.Wrappers;
using DocManager.Applications.Queries.Expediente;
using DocManager.Applications.Queries.Expediente.Models;
using DocManager.Domain.Services;
using MediatR;
using ExpedienteEntity = DocManager.Domain.Entities.Expediente;

namespace DocManager.Application.Queries.Handlers.Expediente;

public class GetAllExpedienteQueryHandler(IGetExpedienteService getExpedienteService) : IRequestHandler<GetAllExpedienteQuery, Response<GetExpedienteResponseModel>>
{
    public async Task<Response<GetExpedienteResponseModel>> Handle(GetAllExpedienteQuery request, CancellationToken cancellationToken)
    {
        List<ExpedienteEntity> expedientes = await getExpedienteService.GetExpedienteWithFieldsAndValues(cancellationToken);

        return new Response<GetExpedienteResponseModel>(new GetExpedienteResponseModel
        {
            Expedientes = expedientes
        });
    }
}
