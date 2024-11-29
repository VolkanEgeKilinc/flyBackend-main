using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Application.OrganizerOperations.Queries.GetOrganizers;
using BilethubApi.Api.Application.OrganizerOperations.Commands.CreateOrganizer;
using BilethubApi.Api.Application.OrganizerOperations.Commands.DeleteOrganizer;

namespace BilethubApi.Api.Controllers;

[ApiController]
[Route("Api/[controller]s")]
public class OrganizerController : ControllerBase
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public OrganizerController(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetOrganizers()
    {
        GetOrganizersQuery query = new GetOrganizersQuery(_context, _mapper);
        return Ok(query.Handle());
    }


    [HttpPost("{userId}")]
    public IActionResult CreateOrganizer(int userId)
    {
        CreateOrganizerCommand command = new CreateOrganizerCommand(_context, _mapper);
        command.UserId = userId;

        CreateOrganizerCommandValidator validator = new CreateOrganizerCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteOrganizer(int id)
    {
        DeleteOrganizerCommand command = new DeleteOrganizerCommand(_context);
        command.Id = id;

        DeleteOrganizerCommandValidator validator = new DeleteOrganizerCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }
}