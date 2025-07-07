using AutoMapper;
using DocManager.Application.Commands.Document;
using DocManager.Application.Shared.Wrappers;
using DocManager.Domain.Services.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;
using DocumentEntity = DocManager.Domain.Entities.Document;

namespace DocManager.Application.Commands.Handlers.Document;

public class CreateDocumentCommandHandler(IRepositoryAsync<DocumentEntity> repositoryAsync, IMapper mapper) : IRequestHandler<CreateDocumentCommand, Response<Guid>>
{
    private readonly IRepositoryAsync<DocumentEntity> _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<Response<Guid>> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
    {
        DocumentEntity? document = _mapper.Map<DocumentEntity>(request);
        document.FilePath = await SaveFile(request.FormFile);
        var data = await _repositoryAsync.AddAsync(document, cancellationToken);
        return new Response<Guid>(data.Id);
    }

    // Función para guardar archivo físicamente y devolver la ruta
    private static async Task<string> SaveFile(IFormFile file)
    {
        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
        if (!Directory.Exists(uploadsFolder))
            Directory.CreateDirectory(uploadsFolder);

        var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return filePath;
    }
}
