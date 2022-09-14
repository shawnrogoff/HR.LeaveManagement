using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Persistence.Repositories;
public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    private readonly LeaveManagementDbContext _dbContext;

    public LeaveAllocationRepository(LeaveManagementDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetailsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<LeaveAllocation> GetLeaveAllocationWithDetailsAsync(int id)
    {
        throw new NotImplementedException();
    }
}
