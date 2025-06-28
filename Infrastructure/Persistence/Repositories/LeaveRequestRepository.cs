using Application.Exceptions;
using Application.Persistence.Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    private readonly ApplicationDbContext _context;

    public LeaveRequestRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task UpdateLeaveRequestApproval(LeaveRequest leaveRequest, bool? approve)
    {
        leaveRequest.Approved = approve;
        _context.Entry(leaveRequest).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
    {
        return await _context.LeaveRequests
            .AsNoTracking()
            .Include(x => x.LeaveType)
            .ToListAsync();
        
        
    }
    public async Task<LeaveRequest> GetLeaveRequestWithDetailsById(int id)
    {
        var leaveRequest = await _context.LeaveRequests
            .AsNoTracking()
            .Include(x => x.LeaveType)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (leaveRequest is null)
            throw new NotFoundException("Leave Request", id);

        return leaveRequest;
    }
}