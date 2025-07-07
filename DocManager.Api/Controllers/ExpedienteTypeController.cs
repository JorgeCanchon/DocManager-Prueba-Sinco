using DocManager.Application.Commands.ExpedienteType;
using DocManager.Applications.Queries.ExpedienteType;
using Microsoft.AspNetCore.Mvc;

namespace DocManager.Api.Controllers;

public class ExpedienteTypeController : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Post(CreateExpedienteTypeCommand command) =>
        Ok(await Mediator.Send(command));

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, UpdateExpedienteTypeCommand command)
    => id != command.Id ? BadRequest() : Ok(await Mediator.Send(command));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id) =>
        Ok(await Mediator.Send(new DeleteExpedienteTypeCommand() { Id = id }));

    [HttpGet()]
    public async Task<IActionResult> Get() =>
        Ok(await Mediator.Send(new GetAllExpedienteTypeQuery() { }));

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id) =>
        Ok(await Mediator.Send(new GetExpedienteTypeByIdQuery() { Id = id }));
}
