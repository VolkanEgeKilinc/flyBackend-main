using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Application.EventReminderOperations.Commands.CreateEventReminder;
using BilethubApi.Api.Application.EventReminderOperations.Commands.DeleteEventReminder;
using BilethubApi.Core.Extensions;
using System.Security.Claims;

namespace BilethubApi.Api.Controllers;

[ApiController]
[Route("Api/Events")]
public class EventReminderController : ControllerBase
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public EventReminderController(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost("{id}/Reminder")]
    public IActionResult CreateEventReminder(int id)
    {
        var claim = User.GetPrimaryClaim(ClaimTypes.Name);
        if (claim is null)
            throw new UnauthorizedAccessException();

        CreateEventReminderCommand command = new CreateEventReminderCommand(_context);
        command.Id = id;
        command.UserId = int.Parse(claim.Value);

        CreateEventReminderCommandValidator validator = new CreateEventReminderCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpDelete("{id}/Reminder")]
    public IActionResult DeleteEventReminder(int id)
    {
        var claim = User.GetPrimaryClaim(ClaimTypes.Name);
        if (claim is null)
            throw new UnauthorizedAccessException();

        DeleteEventReminderCommand command = new DeleteEventReminderCommand(_context);
        command.Id = id;
        command.UserId = int.Parse(claim.Value);

        DeleteEventReminderCommandValidator validator = new DeleteEventReminderCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }
}