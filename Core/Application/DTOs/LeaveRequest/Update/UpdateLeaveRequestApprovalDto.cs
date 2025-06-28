using Application.DTOs.Common;

namespace Application.DTOs.LeaveRequest.Update;

public class UpdateLeaveRequestApprovalDto : BaseDomainEntityDto
{
    public bool? Approved { get; private set; }
}