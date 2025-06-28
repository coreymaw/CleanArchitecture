using Application.Exceptions;
using Application.Features.FeatureGroup.Requests.CommandRequests.LeaveTypeCommands;
using Application.Persistence.Contracts;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.FeatureGroup.Handlers.Commands.LeaveTypeCommands;

public class DeleteLeaveTypeCommandHandler : IRequestHandler<DLeaveTypeRequest, Unit>
{
    private readonly ILeaveTypeRepository _repository;
    private readonly IMapper _mapper;

    public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(DLeaveTypeRequest request, CancellationToken cancellationToken)
    {
        var leaveType = await _repository.GetByIdAsync(request.Id);
        if (leaveType == null)
        {
            throw new NotFoundException(nameof(LeaveType), request.Id);
        }

        await _repository.DeleteAsync(leaveType);
        return Unit.Value;
    }
}