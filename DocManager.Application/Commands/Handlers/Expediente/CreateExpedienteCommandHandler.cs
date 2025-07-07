using AutoMapper;
using DocManager.Application.Commands.Expediente;
using DocManager.Application.Shared.Wrappers;
using ExpedienteEntity = DocManager.Domain.Entities.Expediente;
using DocManager.Domain.Services.Persistence;
using MediatR;

namespace DocManager.Application.Commands.Handlers.Expediente;

public class CreateExpedienteCommandHandler(IRepositoryAsync<ExpedienteEntity> repositoryAsync, IMapper mapper) 
    : IRequestHandler<CreateExpedienteCommand, Response<Guid>>
{
    private readonly IRepositoryAsync<ExpedienteEntity> _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<Response<Guid>> Handle(CreateExpedienteCommand request, CancellationToken cancellationToken)
    {
        ExpedienteEntity? expediente = _mapper.Map<ExpedienteEntity>(request);
        var data = await _repositoryAsync.AddAsync(expediente, cancellationToken);
        return new Response<Guid>(data.Id);
    }
}
