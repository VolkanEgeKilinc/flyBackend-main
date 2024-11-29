using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Application.TicketCategoryOperations.Queries.GetTicketCategories;
using BilethubApi.Api.Application.TicketCategoryOperations.Commands.CreateTicketCategory;
using BilethubApi.Api.Application.TicketCategoryOperations.Commands.UpdateTicketCategory;
using BilethubApi.Api.Application.TicketCategoryOperations.Commands.DeleteTicketCategory;
using BilethubApi.Api.Application.TicketCategoryOperations.Queries.GetEventTicketCategories;
using BilethubApi.Api.Application.TicketCategoryOperations.Queries.GetAdminEventTicketCategories;

namespace BilethubApi.Api.Controllers;

[ApiController]
[Route("Api/TicketCategories")]
public class TicketCategoryController : ControllerBase
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public TicketCategoryController(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetTicketCategories()
    {
        GetTicketCategoriesQuery query = new GetTicketCategoriesQuery(_context, _mapper);
        return Ok(query.Handle());
    }

    [HttpGet("~/Api/Events/{id}/TicketCategories")]
    public IActionResult GetTicketCategoriesByEventId(int id)
    {
        GetEventTicketCategoriesQuery query = new GetEventTicketCategoriesQuery(_context, _mapper);
        query.Id = id;

        GetEventTicketCategoriesQueryValidator validator = new GetEventTicketCategoriesQueryValidator();
        validator.ValidateAndThrow(query);

        return Ok(query.Handle());
    }

    [HttpGet("~/Api/Admin/Events/{id}/TicketCategories")]
    public IActionResult GetAdminTicketCategoriesByEventId(int id)
    {
        GetAdminEventTicketCategoriesQuery query = new GetAdminEventTicketCategoriesQuery(_context, _mapper);
        query.Id = id;

        GetAdminEventTicketCategoriesQueryValidator validator = new GetAdminEventTicketCategoriesQueryValidator();
        validator.ValidateAndThrow(query);

        return Ok(query.Handle());
    }

    [HttpPost]
    public IActionResult CreateTicketCategory([FromBody] CreateTicketCategoryModel newTicketCategory)
    {
        CreateTicketCategoryCommand command = new CreateTicketCategoryCommand(_context, _mapper);
        command.Model = newTicketCategory;

        CreateTicketCategoryCommandValidator validator = new CreateTicketCategoryCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTicketCategory(int id, [FromBody] UpdateTicketCategoryModel updatedTicketCategory)
    {
        UpdateTicketCategoryCommand command = new UpdateTicketCategoryCommand(_context);
        command.Id = id;
        command.Model = updatedTicketCategory;

        UpdateTicketCategoryCommandValidator validator = new UpdateTicketCategoryCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTicketCategory(int id)
    {
        DeleteTicketCategoryCommand command = new DeleteTicketCategoryCommand(_context);
        command.Id = id;

        DeleteTicketCategoryCommandValidator validator = new DeleteTicketCategoryCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }
}