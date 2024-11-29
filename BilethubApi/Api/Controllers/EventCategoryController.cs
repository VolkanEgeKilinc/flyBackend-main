using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Application.EventCategoryOperations.Queries.GetEventCategories;
using BilethubApi.Api.Application.EventCategoryOperations.Commands.CreateEventCategory;
using BilethubApi.Api.Application.EventCategoryOperations.Commands.DeleteEventCategory;

namespace BilethubApi.Api.Controllers;

[ApiController]
[Route("Api/EventCategories")]
public class EventCategoryController : ControllerBase
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public EventCategoryController(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetEventCategories(int limit = 0)
    {
        GetEventCategoriesQuery query = new GetEventCategoriesQuery(_context, _mapper);
        query.Limit = limit;

        return Ok(query.Handle());
    }

    [HttpPost]
    public IActionResult CreateEventCategory([FromBody] CreateEventCategoryModel newEventCategory)
    {
        CreateEventCategoryCommand command = new CreateEventCategoryCommand(_context, _mapper);
        command.Model = newEventCategory;

        CreateEventCategoryCommandValidator validator = new CreateEventCategoryCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEventCategory(int id)
    {
        DeleteEventCategoryCommand command = new DeleteEventCategoryCommand(_context);
        command.Id = id;

        DeleteEventCategoryCommandValidator validator = new DeleteEventCategoryCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }
}