using AutoMapper;
using DocManager.Application.Commands.CustomField;
using DocManager.Application.Shared.Wrappers;
using DocManager.Domain.Services.Persistence;
using MediatR;
using CustomFieldEntity = DocManager.Domain.Entities.CustomField;

namespace DocManager.Application.Commands.Handlers.CustomField;

public class CreateCustomFieldCommandHandler(IRepositoryAsync<CustomFieldEntity> repositoryAsync, IMapper mapper) 
    : IRequestHandler<CreateCustomFieldCommand, Response<Guid>>
{
    private readonly IRepositoryAsync<CustomFieldEntity> _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<Response<Guid>> Handle(CreateCustomFieldCommand request, CancellationToken cancellationToken)
    {
        CustomFieldEntity? customField = _mapper.Map<CustomFieldEntity>(request);
        var data = await _repositoryAsync.AddAsync(customField, cancellationToken);
        return new Response<Guid>(data.Id);
    }
}
