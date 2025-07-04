using Application.DTOs.LeaveType;

namespace Application.DTOs.LeaveAllocation;

public interface ILeaveAllocationDto
{
    public int NumberOfDays { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
}