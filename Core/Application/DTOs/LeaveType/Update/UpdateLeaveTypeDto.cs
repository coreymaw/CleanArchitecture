using Application.DTOs.Common;

namespace Application.DTOs.LeaveType.Update;

public class UpdateLeaveTypeDto : BaseDomainEntityDto , ILeaveTypeDto
{
    public string Name { get; set; }
    public int DefaultDays { get; set; }
}