using Application.DTOs.Common;
using Application.DTOs.LeaveType;

namespace Application.DTOs.LeaveRequest.Update;

public class UpdateLeaveRequestDto : BaseDomainEntityDto , ILeaveRequestDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public LeaveTypeDto LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public DateTime DateRequested { get; set; }
    public string? RequestComment { get; set; }
    public DateTime DateTimeActioned { get; set; }
    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }
}