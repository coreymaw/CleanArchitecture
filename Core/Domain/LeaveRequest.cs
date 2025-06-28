using System.Runtime.CompilerServices;
using Domain.Common;

namespace Domain;

public class LeaveRequest : BaseDomainEntity
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public LeaveType LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public DateTime DateRequested { get; set; }
    public string? RequestComment { get; set; }
    public DateTime DateTimeActioned { get; set; }
    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }
    
}