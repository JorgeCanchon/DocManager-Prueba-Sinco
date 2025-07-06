using DocManager.Application.Commands.Expediente;
using Microsoft.AspNetCore.Mvc;

namespace DocManager.Api.Controllers;

public class ExpedienteController : BaseApiController
{
    //[HttpGet()]
    //public async Task<IActionResult> Get() =>
    //          Ok(await Mediator!.Send(new GetAllExpedienteQuery() { }));

    //[HttpGet("{id}")]
    //public async Task<IActionResult> Get(int id) =>
    //    Ok(await Mediator.Send(new GetExpedienteByIdQuery() { Id = id }));

    [HttpPost]
    public async Task<IActionResult> Post(CreateExpedienteCommand command) =>
        Ok(await Mediator.Send(command));

    //[HttpPut("{id}")]
    //public async Task<IActionResult> Put(int id, UpdateExpedienteCommand command)
    //{
    //    if (id != command.Id)
    //        return BadRequest();
    //    return Ok(await Mediator.Send(command));
    //}

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> Delete(int id) =>
    //    Ok(await Mediator.Send(new DeleteExpedienteCommand() { Id = id }));
}
