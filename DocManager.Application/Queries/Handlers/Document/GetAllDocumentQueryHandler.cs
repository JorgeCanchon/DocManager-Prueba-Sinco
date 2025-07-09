using DocManager.Application.Shared.Wrappers;
using DocManager.Applications.Queries.Document;
using DocManager.Applications.Queries.Document.Models;
using DocManager.Domain.Services;
using MediatR;
using DocumentEntity = DocManager.Domain.Entities.Document;

namespace DocManager.Application.Queries.Handlers.Document;

public class GetAllDocumentQueryHandler(IGetDocumentService getDocumentService) : IRequestHandler<GetAllDocumentQuery, Response<GetDocumentResponseModel>>
{
    public async Task<Response<GetDocumentResponseModel>> Handle(GetAllDocumentQuery request, CancellationToken cancellationToken)
    {
        List<DocumentEntity> documents = await getDocumentService.GetDocuments(cancellationToken);

        return new Response<GetDocumentResponseModel>(new GetDocumentResponseModel
        {
            Documents = documents
        });
    }
}