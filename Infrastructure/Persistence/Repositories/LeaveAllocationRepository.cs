using Application.Persistence.Contracts;
using Domain;

namespace Persistence.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    public LeaveAllocationRepository(ApplicationDbContext context) : base(context)
    {
    }

    public Task<List<LeaveAllocation>> GetLeaveAllocationLisWithDetails()
    {
        throw new NotImplementedException();
    }

    public Task<LeaveAllocation> GetLeaveAllocationWithDetailsById(int id)
    {
        throw new NotImplementedException();
    }
}