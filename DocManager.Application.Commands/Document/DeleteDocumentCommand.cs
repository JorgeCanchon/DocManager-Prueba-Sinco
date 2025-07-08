using DocManager.Application.Shared.Wrappers;
using MediatR;

namespace DocManager.Application.Commands.Document;

public class DeleteDocumentCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}
