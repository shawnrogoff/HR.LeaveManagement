using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Persistence.Contracts;

public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
{
    Task<LeaveAllocation> GetLeaveAllocationWithDetailsAsync(int id);
    Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetailsAsync();
}
