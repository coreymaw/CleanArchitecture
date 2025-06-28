using Application.DTOs.Common;

namespace Application.DTOs.LeaveAllocation.Update;

public class UpdateLeaveAllocationDto : BaseDomainEntityDto , ILeaveAllocationDto
{
    public int NumberOfDays { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
}