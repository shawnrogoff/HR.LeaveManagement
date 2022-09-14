﻿using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;
public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    private readonly LeaveManagementDbContext _dbContext;

    public LeaveRequestRepository(LeaveManagementDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus)
    {
        leaveRequest.Approved = ApprovalStatus;
        _dbContext.Entry(leaveRequest).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetailsAsync()
    {
        var leaveRequests = await _dbContext.LeaveRequests
                                .Include(q => q.LeaveType)
                                .ToListAsync();
        return leaveRequests;
    }

    public async Task<LeaveRequest> GetLeaveRequestWithDetailsAsync(int id)
    {
        var leaveRequest = await _dbContext.LeaveRequests
                                .Include(q => q.LeaveType)
                                .FirstOrDefaultAsync(q => q.Id == id);
        return leaveRequest;
    }
}
