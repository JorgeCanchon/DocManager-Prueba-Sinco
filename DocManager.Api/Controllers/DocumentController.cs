using DocManager.Application.Commands.Document;
using DocManager.Applications.Queries.Document;
using Microsoft.AspNetCore.Mvc;

namespace DocManager.Api.Controllers;

public class DocumentController : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Post(CreateDocumentCommand command)
    => Ok(await Mediator.Send(command));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id) =>
        Ok(await Mediator.Send(new DeleteDocumentCommand() { Id = id }));

    [HttpGet()]
    public async Task<IActionResult> Get() =>
          Ok(await Mediator!.Send(new GetAllDocumentQuery() { }));

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id) =>
        Ok(await Mediator.Send(new GetDocumentByIdQuery() { Id = id }));
}
