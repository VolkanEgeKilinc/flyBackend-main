using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Application.ArtistOperations.Queries.GetArtists;
using BilethubApi.Api.Application.ArtistOperations.Commands.CreateArtist;
using BilethubApi.Api.Application.ArtistOperations.Commands.UpdateArtist;
using BilethubApi.Api.Application.ArtistOperations.Commands.DeleteArtist;
using BilethubApi.Api.Application.ArtistOperations.Queries.GetArtistDetail;
using BilethubApi.Core.Extensions;
using System.Security.Claims;

namespace BilethubApi.Api.Controllers;

[ApiController]
[Route("Api/[controller]s")]
public class ArtistController : ControllerBase
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public ArtistController(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetArtists()
    {
        GetArtistsQuery query = new GetArtistsQuery(_context, _mapper);
        return Ok(query.Handle());
    }

    [HttpGet("{id}")]
    public IActionResult GetArtistDetail(int id)
    {
        var claim = User.GetPrimaryClaim(ClaimTypes.Name);
        if (claim is null)
            throw new UnauthorizedAccessException();
            
        GetArtistDetailQuery query = new GetArtistDetailQuery(_context, _mapper);
        query.Id = id;
        query.UserId = int.Parse(claim.Value);

        GetArtistDetailQueryValidator validator = new GetArtistDetailQueryValidator();
        validator.ValidateAndThrow(query);

        return Ok(query.Handle());
    }

    [HttpPost]
    public IActionResult CreateArtist([FromBody] CreateArtistModel newArtist)
    {
        CreateArtistCommand command = new CreateArtistCommand(_context, _mapper);
        command.Model = newArtist;

        CreateArtistCommandValidator validator = new CreateArtistCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateArtist(int id, [FromBody] UpdateArtistModel updatedArtist)
    {
        UpdateArtistCommand command = new UpdateArtistCommand(_context);
        command.Id = id;
        command.Model = updatedArtist;

        UpdateArtistCommandValidator validator = new UpdateArtistCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteArtist(int id)
    {
        DeleteArtistCommand command = new DeleteArtistCommand(_context);
        command.Id = id;

        DeleteArtistCommandValidator validator = new DeleteArtistCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }
}