﻿using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace HR.LeaveManagement.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LeaveRequestsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveRequestsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<LeaveRequestsController>
    [HttpGet]
    public async Task<ActionResult<List<LeaveRequestListDto>>> Get()
    {
        var leaveRequests = await _mediator.Send(new GetLeaveRequestListRequest());
        return Ok(leaveRequests);
    }

    // GET api/<LeaveRequestsController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveRequestDto>> Get(int id)
    {
        var leaveRequest = await _mediator.Send(new GetLeaveRequestDetailRequest());
        return Ok(leaveRequest);
    }

    // POST api/<LeaveRequestsController>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateLeaveRequestDto leaveRequest)
    {
        var command = new CreateLeaveRequestCommand { LeaveRequestDto = leaveRequest };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    // PUT api/<LeaveRequestsController>/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveRequestDto leaveRequest)
    {
        var command = new UpdateLeaveRequestCommand { Id = id, LeaveRequestDto = leaveRequest };
        var response = _mediator.Send(command);
        return NoContent();
    }

    // PUT api/<LeaveRequestsController>/5
    [HttpPut("changeApproval/{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] ChangeLeaveRequestApprovalDto changeLeaveRequestApproval)
    {
        var command = new UpdateLeaveRequestCommand { Id = id, ChangeLeaveRequestApprovalDto = changeLeaveRequestApproval };
        var response = _mediator.Send(command);
        return NoContent();
    }

    // DELETE api/<LeaveRequestsController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteLeaveRequestCommand { Id = id };
        var response = _mediator.Send(command);
        return NoContent();
    }
}
