using AutoMapper;
using DocManager.Application.Commands.ExpedienteType;
using DocManager.Application.Shared.Wrappers;
using ExpedienteTypeEntity = DocManager.Domain.Entities.ExpedienteType;
using DocManager.Domain.Services.Persistence;
using MediatR;

namespace DocManager.Application.Commands.Handlers.ExpedienteType;

public class CreateExpedienteTypeCommandHandler(IRepositoryAsync<ExpedienteTypeEntity> repositoryAsync, IMapper mapper) : IRequestHandler<CreateExpedienteTypeCommand, Response<Guid>>
{
    private readonly IRepositoryAsync<ExpedienteTypeEntity> _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<Response<Guid>> Handle(CreateExpedienteTypeCommand request, CancellationToken cancellationToken)
    {
        ExpedienteTypeEntity? expedienteType = _mapper.Map<ExpedienteTypeEntity>(request);
        await _repositoryAsync.AddAsync(expedienteType, cancellationToken);
        return new Response<Guid>(expedienteType.Id);
    }
}