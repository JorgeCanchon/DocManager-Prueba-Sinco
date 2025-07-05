using DocManager.Application.Commands;
using Microsoft.AspNetCore.Mvc;

namespace DocManager.Api.Controllers
{
    public class DocumentFileController : BaseApiController
    {
        //[HttpGet()]
        //public async Task<IActionResult> Get() =>
        //          Ok(await Mediator!.Send(new GetAllCiudadesQuery() { }));

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id) =>
        //    Ok(await Mediator.Send(new GetAllCiudadesByIdQuery() { Id = id }));

        [HttpPost]
        public async Task<IActionResult> Post(CreateDocumentInstanceCommand command) =>
            Ok(await Mediator!.Send(command));

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, UpdateCiudadCommand command)
        //{
        //    if (id != command.Id)
        //        return BadRequest();
        //    return Ok(await Mediator.Send(command));
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id) =>
        //    Ok(await Mediator.Send(new DeleteCiudadCommand() { Id = id }));
    }
}
