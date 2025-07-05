using DocManager.Application.Shared.Wrappers;
using MediatR;

namespace DocManager.Application.Commands;

public record CreateDocumentInstanceCommand : IRequest<Response<Guid>>
{
}
