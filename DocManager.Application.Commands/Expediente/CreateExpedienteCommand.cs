﻿using DocManager.Application.Commands.FieldValue;
using DocManager.Application.Shared.Wrappers;
using MediatR;

namespace DocManager.Application.Commands.Expediente;

public record CreateExpedienteCommand : IRequest<Response<Guid>>
{
    public Guid ExpedienteTypeId { get; set; }
    public List<CreateFieldValueCommand> FieldValues { get; set; } = [];
}
