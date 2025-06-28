using System.Runtime.CompilerServices;

namespace Application.DTOs.LeaveType.Create;

public class CreateLeaveTypeDto : ILeaveTypeDto
{
    public string Name { get;  set; }
    public int DefaultDays { get;  set; }
    
}