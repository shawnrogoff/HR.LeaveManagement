﻿using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands;
public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var leaveAllocation = await _leaveAllocationRepository.GetAsync(request.UpdateLeaveAllocationDto.Id);

        _mapper.Map(request.UpdateLeaveAllocationDto, leaveAllocation); // Update from left to right

        await _leaveAllocationRepository.UpdateAsync(leaveAllocation);

        return Unit.Value;
    }
}