using Application.DTOs.LeaveRequest.Update;
using Domain;

namespace Application.Persistence.Contracts;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
{
    Task UpdateLeaveRequestApproval(LeaveRequest leaveRequest, bool? approve);
    Task <List<LeaveRequest>> GetLeaveRequestWithDetails();
    Task <LeaveRequest> GetLeaveRequestWithDetailsById(int id);
}