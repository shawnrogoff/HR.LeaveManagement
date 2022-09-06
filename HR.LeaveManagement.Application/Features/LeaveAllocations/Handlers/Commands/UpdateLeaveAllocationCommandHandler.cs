using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators;
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
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public UpdateLeaveAllocationCommandHandler(
        ILeaveAllocationRepository leaveAllocationRepository, 
        IMapper mapper, 
        ILeaveTypeRepository leaveTypeRepository )
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateLeaveAllocationDtoValidator(_leaveTypeRepository);

        var validationResults = await validator.ValidateAsync(request.UpdateLeaveAllocationDto);

        if(validationResults.IsValid == false)
        {
            throw new Exception();
        }

        var leaveAllocation = await _leaveAllocationRepository.GetAsync(request.UpdateLeaveAllocationDto.Id);

        _mapper.Map(request.UpdateLeaveAllocationDto, leaveAllocation); // Update from left to right

        await _leaveAllocationRepository.UpdateAsync(leaveAllocation);

        return Unit.Value;
    }
}
