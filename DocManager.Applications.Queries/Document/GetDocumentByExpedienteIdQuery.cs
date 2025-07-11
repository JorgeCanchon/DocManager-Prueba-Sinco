using DocManager.Application.Shared.Wrappers;
using DocManager.Applications.Queries.Document.Models;
using MediatR;

namespace DocManager.Applications.Queries.Document;

public class GetDocumentByExpedienteIdQuery : IRequest<Response<GetDocumentByExpedienteIdResponseModel>>
{
    public Guid Id { get; set; }
}
