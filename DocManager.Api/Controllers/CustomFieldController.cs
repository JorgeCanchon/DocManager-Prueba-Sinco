using DocManager.Application.Commands.CustomField;
using Microsoft.AspNetCore.Mvc;

namespace DocManager.Api.Controllers;

public class CustomFieldController : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Post(CreateCustomFieldCommand command) 
    => Ok(await Mediator.Send(command));
}
