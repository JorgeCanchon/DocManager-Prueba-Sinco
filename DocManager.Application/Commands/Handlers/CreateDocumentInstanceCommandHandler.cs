using AutoMapper;
using DocManager.Application.Shared.Wrappers;
using DocManager.Domain.Entities;
using DocManager.Domain.Services.Persistence;
using MediatR;

namespace DocManager.Application.Commands.Handlers;

public class CreateDocumentInstanceCommandHandler(IRepositoryAsync<DocumentInstance> documentInstanceRepository, IMapper mapper) 
    : IRequestHandler<CreateDocumentInstanceCommand, Response<Guid>>
{
    private readonly IRepositoryAsync<DocumentInstance> _documentInstanceRepository = documentInstanceRepository ?? throw new ArgumentNullException(nameof(documentInstanceRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<Response<Guid>> Handle(CreateDocumentInstanceCommand request, CancellationToken cancellationToken)
    {
        var ciudad = _mapper.Map<DocumentInstance>(request);
        var data = await _documentInstanceRepository.AddAsync(ciudad, cancellationToken);
        return new Response<Guid>(data.Id);
    }
}
