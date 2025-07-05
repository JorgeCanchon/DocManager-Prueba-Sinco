using AutoMapper;
using DocManager.Application.Shared.Wrappers;
using DocManager.Domain.Entities;
using DocManager.Domain.Services.Persistence;
using MediatR;

namespace DocManager.Application.Commands.Handlers;

public class CreateExpedienteCommandHandler(IRepositoryAsync<Expediente> documentInstanceRepository, IMapper mapper) 
    : IRequestHandler<CreateExpedienteCommand, Response<Guid>>
{
    private readonly IRepositoryAsync<Expediente> _documentInstanceRepository = documentInstanceRepository ?? throw new ArgumentNullException(nameof(documentInstanceRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<Response<Guid>> Handle(CreateExpedienteCommand request, CancellationToken cancellationToken)
    {
        var ciudad = _mapper.Map<Expediente>(request);
        var data = await _documentInstanceRepository.AddAsync(ciudad, cancellationToken);
        return new Response<Guid>(data.Id);
    }
}
