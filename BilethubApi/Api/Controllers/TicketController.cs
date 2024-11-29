using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Application.TicketOperations.Commands.CreateTicket;
using BilethubApi.Api.Application.TicketOperations.Commands.UpdateTicket;
using BilethubApi.Api.Application.TicketOperations.Commands.DeleteTicket;
using BilethubApi.Api.Application.TicketOperations.Queries.GetTicketsByEvent;
using BilethubApi.Api.Application.TicketOperations.Queries.GetTicketsByUser;
using BilethubApi.Api.Application.TicketOperations.Queries.GetTicketByToken;
using BilethubApi.Core.Extensions;
using System.Security.Claims;
using BilethubApi.Api.Application.TicketOperations.Commands.CreateGuestTicket;
using BilethubApi.Api.Application.TicketOperations.Queries.GetGuestTickets;

namespace BilethubApi.Api.Controllers;

[ApiController]
[Route("Api/[controller]s")]
public class TicketController : ControllerBase
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public TicketController(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpGet("~/Api/Events/{id}/Tickets")]
    public IActionResult GetTicketsByEvent(int id)
    {
        var claim = User.GetPrimaryClaim(ClaimTypes.Name);
        if (claim is null)
            throw new UnauthorizedAccessException();
        GetTicketsByEventQuery query = new GetTicketsByEventQuery(_context, _mapper);
        query.UserId = int.Parse(claim.Value);
        query.EventId = id;

        GetTicketsByEventQueryValidator validator = new GetTicketsByEventQueryValidator();
        validator.ValidateAndThrow(query);

        return Ok(query.Handle());
    }

    [HttpGet("~/Api/Tickets/Purchased")]
    public IActionResult GetTicketsByUser()
    {
        var claim = User.GetPrimaryClaim(ClaimTypes.Name);
        if (claim is null)
            throw new UnauthorizedAccessException();

        GetTicketsByUserQuery query = new GetTicketsByUserQuery(_context, _mapper);
        query.UserId = int.Parse(claim.Value);

        GetTicketsByUserQueryValidator validator = new GetTicketsByUserQueryValidator();
        validator.ValidateAndThrow(query);

        return Ok(query.Handle());
    }

    [HttpGet("Guest")]
    public IActionResult GetGuestTickets([FromQuery] int eventId)
    {
        var claim = User.GetPrimaryClaim(ClaimTypes.Name);
        if (claim is null)
            throw new UnauthorizedAccessException();

        GetGuestTicketsQuery query = new GetGuestTicketsQuery(_context, _mapper);
        query.EventId = eventId;
        query.UserId = int.Parse(claim.Value);

        GetGuestTicketsQueryValidator validator = new GetGuestTicketsQueryValidator();
        validator.ValidateAndThrow(query);

        return Ok(query.Handle());
    }

    [HttpGet("Check")]
    public IActionResult GetTicketsByToken([FromQuery] int eventId, [FromQuery] string token)
    {

        GetTicketByTokenQuery query = new GetTicketByTokenQuery(_context, _mapper);
        query.EventId = eventId;
        query.Token = token;

        GetTicketByTokenQueryValidator validator = new GetTicketByTokenQueryValidator();
        validator.ValidateAndThrow(query);

        return Ok(query.Handle());
    }

    [HttpPost]
    public IActionResult CreateTicket([FromBody] CreateTicketModel newTicket)
    {
        CreateTicketCommand command = new CreateTicketCommand(_context, _mapper);
        command.Model = newTicket;

        CreateTicketCommandValidator validator = new CreateTicketCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpPost("Guest")]
    public IActionResult CreateGuestTicket([FromBody] CreateGuestTicketModel newTicket)
    {
        var claim = User.GetPrimaryClaim(ClaimTypes.Name);
        if (claim is null)
            throw new UnauthorizedAccessException();

        CreateGuestTicketCommand command = new CreateGuestTicketCommand(_context, _mapper);
        command.Model = newTicket;
        command.UserId = int.Parse(claim.Value);

        CreateGuestTicketCommandValidator validator = new CreateGuestTicketCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTicket(int id, [FromBody] UpdateTicketModel updatedTicket)
    {
        UpdateTicketCommand command = new UpdateTicketCommand(_context);
        command.Id = id;
        command.Model = updatedTicket;

        UpdateTicketCommandValidator validator = new UpdateTicketCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTicket(int id)
    {
        DeleteTicketCommand command = new DeleteTicketCommand(_context);
        command.Id = id;

        DeleteTicketCommandValidator validator = new DeleteTicketCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }
}