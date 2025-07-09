using DocManager.Application._Resources;
using DocManager.Application.Shared.Wrappers;
using DocManager.Applications.Queries.Document;
using DocManager.Applications.Queries.Document.Models;
using DocManager.Domain.Services;
using MediatR;
using DocumentEntity = DocManager.Domain.Entities.Document;

namespace DocManager.Application.Queries.Handlers.Document;

public class GetDocumentByIdQueryHandler(IGetDocumentService getDocumentService) : IRequestHandler<GetDocumentByIdQuery, Response<GetDocumentByIdResponseModel>>
{
    public async Task<Response<GetDocumentByIdResponseModel>> Handle(GetDocumentByIdQuery request, CancellationToken cancellationToken)
    {
        DocumentEntity document = await getDocumentService.GetDocumentById(request.Id, cancellationToken) ?? throw new KeyNotFoundException(ApplicationErrors.RecordNotFound);
        return new Response<GetDocumentByIdResponseModel>(new GetDocumentByIdResponseModel()
        {
            Document = document
        });
    }
}