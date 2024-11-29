using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Application.PlaceCommentOperations.Queries.GetPlaceComments;
using BilethubApi.Api.Application.PlaceCommentOperations.Commands.CreatePlaceComment;
using BilethubApi.Api.Application.PlaceCommentOperations.Commands.DeletePlaceComment;

namespace BilethubApi.Api.Controllers;

[ApiController]
[Route("Api/Places")]
public class PlaceCommentController : ControllerBase
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public PlaceCommentController(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("{id}/Comments")]
    public IActionResult GetPlaceCommentsByPlace(int id)
    {

        GetPlaceCommentsQuery query = new GetPlaceCommentsQuery(_context, _mapper);
        query.PlaceId = id;

        GetPlaceCommentsQueryValidator validator = new GetPlaceCommentsQueryValidator();
        validator.ValidateAndThrow(query);

        return Ok(query.Handle());
    }

    [HttpPost("Comments")]
    public IActionResult CreatePlaceComment([FromBody] CreatePlaceCommentModel newPlaceComment)
    {
        CreatePlaceCommentCommand command = new CreatePlaceCommentCommand(_context, _mapper);
        command.Model = newPlaceComment;

        CreatePlaceCommentCommandValidator validator = new CreatePlaceCommentCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpDelete("Comments/{id}")]
    public IActionResult DeletePlaceComment(int id)
    {
        DeletePlaceCommentCommand command = new DeletePlaceCommentCommand(_context);
        command.Id = id;

        DeletePlaceCommentCommandValidator validator = new DeletePlaceCommentCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }
}