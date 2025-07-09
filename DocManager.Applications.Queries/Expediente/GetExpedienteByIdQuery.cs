using DocManager.Application.Shared.Wrappers;
using DocManager.Applications.Queries.Expediente.Models;
using MediatR;

namespace DocManager.Applications.Queries.Expediente;

public class GetExpedienteByIdQuery : IRequest<Response<GetExpedienteByIdResponseModel>>
{
    public Guid Id { get; set; }
}