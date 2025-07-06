using DocManager.Application.Shared.Wrappers;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DocManager.Application.Commands.ExpedienteType;

public record CreateExpedienteTypeCommand : IRequest<Response<Guid>>
{
    [MaxLength(450)]
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}
