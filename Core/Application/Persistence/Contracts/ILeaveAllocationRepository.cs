using Application.DTOs;
using Domain;

namespace Application.Persistence.Contracts;

public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
{
    Task<List<LeaveAllocation>> GetLeaveAllocationLisWithDetails();
    Task<LeaveAllocation> GetLeaveAllocationWithDetailsById(int id);
}