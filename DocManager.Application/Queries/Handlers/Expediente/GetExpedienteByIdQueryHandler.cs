using DocManager.Application._Resources;
using DocManager.Application.Shared.Wrappers;
using DocManager.Applications.Queries.Expediente;
using DocManager.Applications.Queries.Expediente.Models;
using DocManager.Domain.Services;
using MediatR;
using ExpedienteEntity = DocManager.Domain.Entities.Expediente;

namespace DocManager.Application.Queries.Handlers.Expediente;

public class GetExpedienteByIdQueryHandler(IGetExpedienteService getExpedienteService) : IRequestHandler<GetExpedienteByIdQuery, Response<GetExpedienteByIdResponseModel>>
{
    public async Task<Response<GetExpedienteByIdResponseModel>> Handle(GetExpedienteByIdQuery request, CancellationToken cancellationToken)
    {
        ExpedienteEntity expediente = await getExpedienteService.GetExpedienteByIdWithFieldsAndValues(request.Id, cancellationToken) ?? throw new KeyNotFoundException(ApplicationErrors.RecordNotFound);
        return new Response<GetExpedienteByIdResponseModel>(new GetExpedienteByIdResponseModel()
        {
            Expediente = expediente
        });
    }
}
