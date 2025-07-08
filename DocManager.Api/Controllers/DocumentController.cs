using DocManager.Application.Commands.Document;
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
}
