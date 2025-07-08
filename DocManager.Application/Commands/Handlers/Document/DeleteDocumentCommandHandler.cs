using DocManager.Application.Commands.Document;
using DocManager.Application.Shared.Wrappers;
using DocManager.Domain.Services.Persistence;
using MediatR;
using DocumentEntity = DocManager.Domain.Entities.Document;
using static DocManager.Application.Shared.Constants.ApplicationConstants;

namespace DocManager.Application.Commands.Handlers.Document;

public class DeleteDocumentCommandHandler(IRepositoryAsync<DocumentEntity> repositoryAsync) 
    : IRequestHandler<DeleteDocumentCommand, Response<bool>>
{
    private readonly IRepositoryAsync<DocumentEntity> _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));

    public async Task<Response<bool>> Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
    {
        DocumentEntity document = await _repositoryAsync.GetByIdAsync(request.Id, cancellationToken) ?? throw new ArgumentException(nameof(repositoryAsync));
        await _repositoryAsync.DeleteAsync(document, cancellationToken);
        DeleteImage(document.FileName);
        return new Response<bool>(true);
    }

    private static void DeleteImage(string fileName)
    {
        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), FOLDER_PATH);
        var filePath = Path.Combine(uploadsFolder, fileName);
        File.Delete(filePath);
    }
}
