using DocManager.Application.Commands.Document;
using Microsoft.AspNetCore.Mvc;

namespace DocManager.Api.Controllers;

public class DocumentController : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Post(CreateDocumentCommand command)
    => Ok(await Mediator.Send(command));
}
