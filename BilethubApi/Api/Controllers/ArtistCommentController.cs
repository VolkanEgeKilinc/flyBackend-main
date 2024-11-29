using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Application.ArtistCommentOperations.Queries.GetArtistComments;
using BilethubApi.Api.Application.ArtistCommentOperations.Commands.CreateArtistComment;
using BilethubApi.Api.Application.ArtistCommentOperations.Commands.DeleteArtistComment;

namespace BilethubApi.Api.Controllers;

[ApiController]
[Route("Api/Artists")]
public class ArtistCommentController : ControllerBase
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public ArtistCommentController(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("{id}/Comments")]
    public IActionResult GetArtistCommentsByArtist(int id)
    {

        GetArtistCommentsQuery query = new GetArtistCommentsQuery(_context, _mapper);
        query.ArtistId = id;

        GetArtistCommentsQueryValidator validator = new GetArtistCommentsQueryValidator();
        validator.ValidateAndThrow(query);

        return Ok(query.Handle());
    }

    [HttpPost("Comments")]
    public IActionResult CreateArtistComment([FromBody] CreateArtistCommentModel newArtistComment)
    {
        CreateArtistCommentCommand command = new CreateArtistCommentCommand(_context, _mapper);
        command.Model = newArtistComment;

        CreateArtistCommentCommandValidator validator = new CreateArtistCommentCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpDelete("Comments/{id}")]
    public IActionResult DeleteArtistComment(int id)
    {
        DeleteArtistCommentCommand command = new DeleteArtistCommentCommand(_context);
        command.Id = id;

        DeleteArtistCommentCommandValidator validator = new DeleteArtistCommentCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }
}