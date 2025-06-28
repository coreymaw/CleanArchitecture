using Application.DTOs.LeaveType;
using Application.Features.FeatureGroup.Requests.QueryRequests.LeaveTypeRequests;
using Application.Persistence.Contracts;
using AutoMapper;
using MediatR;

namespace Application.Features.FeatureGroup.Handlers.Queries.LeaveTypeQueries;

public class QGetLeaveTypeHandler : IRequestHandler<QGetLeaveTypeRequest, LeaveTypeDto>
{
    private readonly ILeaveTypeRepository _repository;
    private readonly IMapper _mapper;

    public QGetLeaveTypeHandler(ILeaveTypeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<LeaveTypeDto> Handle(QGetLeaveTypeRequest request, CancellationToken cancellationToken)
    {
        var Leave = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<LeaveTypeDto>(Leave);
    }
}