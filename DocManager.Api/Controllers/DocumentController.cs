using DocManager.Application.Commands.Document;
using DocManager.Applications.Queries.Document;
using Microsoft.AspNetCore.Mvc;

namespace DocManager.Api.Controllers;

public class DocumentController(IWebHostEnvironment _env) : BaseApiController
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

    [HttpGet("expediente/{expedienteId}")]
    public async Task<IActionResult> GetByExpedienteId(Guid expedienteId) =>
        Ok(await Mediator.Send(new GetDocumentByExpedienteIdQuery() { Id = expedienteId }));


    [HttpGet("download/{fileName}")]
    public async Task<IActionResult> DownloadFile(string fileName)
    {
        var normalizedFileName = Path.GetFileName(fileName); 
        string _uploadsFolderPath = Path.Combine(_env.ContentRootPath, "uploads");

        var filePath = Path.Combine(_uploadsFolderPath, normalizedFileName);

        if (!System.IO.File.Exists(filePath))
        {
            return NotFound("Archivo no encontrado.");
        }

        string contentType =  Path.GetExtension(fileName).Equals(".pdf", StringComparison.OrdinalIgnoreCase)
            ? "application/pdf" : "application/octet-stream"; 


        var contentDisposition = new System.Net.Mime.ContentDisposition
        {
            FileName = fileName,
            Inline = false, // true para mostrar en navegador, false para descargar
        }.ToString();

        Response.Headers.Add("Content-Disposition", contentDisposition);
        Response.Headers.Add("X-Content-Type-Options", "nosniff"); 

        return PhysicalFile(filePath, contentType, fileName);
    }

}
