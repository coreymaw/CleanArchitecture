using Application.DTOs.Common;
using Application.DTOs.LeaveType;

namespace Application.DTOs.LeaveAllocation;

public class LeaveAllocationDto : BaseDomainEntityDto , ILeaveAllocationDto
{
    public int NumberOfDays { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
}