using DocManager.Application.Shared.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace DocManager.Application.Commands.Document;

public class CreateDocumentCommand : IRequest<Response<Guid>>
{
    public IFormFile FormFile { get; set; } = null!;
    public Guid ExpedienteId { get; set; }
}
