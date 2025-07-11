using DocManager.Application.Shared.Wrappers;
using DocManager.Applications.Queries.Document;
using DocManager.Applications.Queries.Document.Models;
using DocManager.Domain.Services;
using MediatR;
using DocumentEntity = DocManager.Domain.Entities.Document;

namespace DocManager.Application.Queries.Handlers.Document;

public class GetDocumentByExpedienteIdQueryHandler(IGetDocumentService getDocumentService)
    : IRequestHandler<GetDocumentByExpedienteIdQuery, Response<GetDocumentByExpedienteIdResponseModel>>
{
    public async Task<Response<GetDocumentByExpedienteIdResponseModel>> Handle(GetDocumentByExpedienteIdQuery request, CancellationToken cancellationToken)
    {
        List<DocumentEntity> documents = await getDocumentService.GetDocumentsByExpedienteId(request.Id, cancellationToken);

        return new Response<GetDocumentByExpedienteIdResponseModel>(new GetDocumentByExpedienteIdResponseModel
        {
            Documents = documents
        });
    }
}
