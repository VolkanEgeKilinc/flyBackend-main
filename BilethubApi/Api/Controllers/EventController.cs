using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Application.EventOperations.Queries.GetEvents;
using BilethubApi.Api.Application.EventOperations.Commands.CreateEvent;
using BilethubApi.Api.Application.EventOperations.Commands.UpdateEvent;
using BilethubApi.Api.Application.EventOperations.Commands.DeleteEvent;
using BilethubApi.Api.Application.EventOperations.Queries.GetSuggestedEvents;
using BilethubApi.Api.Application.EventOperations.Queries.GetEventDetail;
using BilethubApi.Core.Extensions;
using System.Security.Claims;
using BilethubApi.Api.Application.EventOperations.Queries.GetEventsMonthlyByCategory;
using BilethubApi.Api.Common.Model;
using BilethubApi.Api.Application.EventOperations.Queries.GetEventsByLocation;
using NetTopologySuite.Geometries;
using BilethubApi.Api.Application.EventOperations.Queries.GetAdminEventDetail;
using BilethubApi.Api.Application.EventOperations.Queries.GetUpcomingEvents;

namespace BilethubApi.Api.Controllers;

// [Authorize]
[ApiController]
[Route("Api/[controller]s")]
public class EventController : ControllerBase
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public EventController(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetEvents(int? genreId, int? categoryId, DateTime? startDate)
    {
        GetEventsQuery query = new GetEventsQuery(_context, _mapper);
        query.GenreId = genreId == 0 ? null : genreId;
        query.CategoryId = categoryId == 0 ? null : categoryId;
        query.StartDate = startDate == DateTime.MinValue ? null : startDate;
        return Ok(query.Handle());
    }

    [HttpGet("Location")]
    public IActionResult GetEventsByLocation(double latitude, double longitude)
    {
        GetEventsByLocationQuery query = new GetEventsByLocationQuery(_context, _mapper);
        query.Location = new Point(latitude, longitude);

        return Ok(query.Handle());
    }

    [HttpGet("{id}")]
    public IActionResult GetEventDetail(int id)
    {
        var claim = User.GetPrimaryClaim(ClaimTypes.Name);
        if (claim is null)
            throw new UnauthorizedAccessException();

        GetEventDetailQuery query = new GetEventDetailQuery(_context, _mapper);
        query.Id = id;
        query.UserId = int.Parse(claim.Value);

        GetEventDetailQueryValidator validator = new GetEventDetailQueryValidator();
        validator.ValidateAndThrow(query);

        return Ok(query.Handle());
    }

    [HttpGet("~/Api/Admin/[controller]s/{id}")]
    public IActionResult GetAdminEventDetail(int id)
    {
        var claim = User.GetPrimaryClaim(ClaimTypes.Name);
        if (claim is null)
            throw new UnauthorizedAccessException();

        GetAdminEventDetailQuery query = new GetAdminEventDetailQuery(_context, _mapper);
        query.Id = id;
        query.UserId = int.Parse(claim.Value);

        GetAdminEventDetailQueryValidator validator = new GetAdminEventDetailQueryValidator();
        validator.ValidateAndThrow(query);

        return Ok(query.Handle());
    }

    [HttpGet("Suggestions")]
    public IActionResult GetSuggestedEvents(int limit = 0)
    {
        var claim = User.GetPrimaryClaim(ClaimTypes.Name);
        if (claim is null)
            throw new UnauthorizedAccessException();

        GetSuggestedEventsQuery query = new GetSuggestedEventsQuery(_context, _mapper);
        query.UserId = int.Parse(claim.Value);
        query.Limit = limit;

        GetSuggestedEventsQueryValidator validator = new GetSuggestedEventsQueryValidator();
        validator.ValidateAndThrow(query);

        return Ok(query.Handle());
    }

    [HttpGet("~/Api/Admin/[controller]s/Upcoming")]
    public IActionResult GetUpcomingEvents(int? limit)
    {
        var claim = User.GetPrimaryClaim(ClaimTypes.Name);
        if (claim is null)
            throw new UnauthorizedAccessException();

        GetUpcomingEventsQuery query = new GetUpcomingEventsQuery(_context, _mapper);
        query.UserId = int.Parse(claim.Value);
        query.Limit = limit;

        GetUpcomingEventsQueryValidator validator = new GetUpcomingEventsQueryValidator();
        validator.ValidateAndThrow(query);

        return Ok(query.Handle());
    }

    [HttpGet("~/Api/EventCategories/{id}/FutureEvents")]
    public IActionResult GetMonthlyEventsByCategory(int id, int limit = 0)
    {
        GetEventsMonthlyByCategoryQuery query = new GetEventsMonthlyByCategoryQuery(_context, _mapper);
        query.EventCategoryId = id;
        query.Limit = limit;

        return Ok(query.Handle());
    }

    [HttpPost("~/Api/Admin/[controller]s")]
    public IActionResult CreateEvent([FromBody] CreateEventModel newEvent)
    {
        var claim = User.GetPrimaryClaim(ClaimTypes.Name);
        if (claim is null)
            throw new UnauthorizedAccessException();

        CreateEventCommand command = new CreateEventCommand(_context, _mapper);
        command.UserId = int.Parse(claim.Value);
        command.Model = newEvent;

        CreateEventCommandValidator validator = new CreateEventCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpPut("~/Api/Admin/[controller]s/{id}")]
    public IActionResult UpdateEvent(int id, [FromBody] UpdateEventModel updatedEvent)
    {
        var claim = User.GetPrimaryClaim(ClaimTypes.Name);
        if (claim is null)
            throw new UnauthorizedAccessException();

        UpdateEventCommand command = new UpdateEventCommand(_context);
        command.Id = id;
        command.UserId = int.Parse(claim.Value);
        command.Model = updatedEvent;

        UpdateEventCommandValidator validator = new UpdateEventCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEvent(int id)
    {
        DeleteEventCommand command = new DeleteEventCommand(_context);
        command.Id = id;

        DeleteEventCommandValidator validator = new DeleteEventCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }
}