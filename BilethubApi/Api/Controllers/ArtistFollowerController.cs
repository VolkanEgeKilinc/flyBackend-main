using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Application.ArtistFollowerOperations.Queries.GetArtistFollowers;
using BilethubApi.Api.Application.ArtistFollowerOperations.Commands.CreateArtistFollower;
using BilethubApi.Api.Application.ArtistFollowerOperations.Commands.DeleteArtistFollower;
using BilethubApi.Core.Extensions;
using System.Security.Claims;

namespace BilethubApi.Api.Controllers;

[ApiController]
[Route("Api/Artists")]
public class ArtistFollowerController : ControllerBase
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public ArtistFollowerController(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("{id}/Followers")]
    public IActionResult GetArtistFollowersByArtist(int id)
    {
        GetArtistFollowersQuery query = new GetArtistFollowersQuery(_context, _mapper);
        query.ArtistId = id;

        GetArtistFollowersQueryValidator validator = new GetArtistFollowersQueryValidator();
        validator.ValidateAndThrow(query);

        return Ok(query.Handle());
    }

    [HttpPost("{id}/Follow")]
    public IActionResult CreateArtistFollower(int id)
    {
        var claim = User.GetPrimaryClaim(ClaimTypes.Name);
        if (claim is null)
            throw new UnauthorizedAccessException();

        CreateArtistFollowerCommand command = new CreateArtistFollowerCommand(_context);
        command.Id = id;
        command.UserId = int.Parse(claim.Value);

        CreateArtistFollowerCommandValidator validator = new CreateArtistFollowerCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpDelete("{id}/UnFollow")]
    public IActionResult DeleteArtistFollower(int id)
    {
        var claim = User.GetPrimaryClaim(ClaimTypes.Name);
        if (claim is null)
            throw new UnauthorizedAccessException();

        DeleteArtistFollowerCommand command = new DeleteArtistFollowerCommand(_context);
        command.Id = id;
        command.UserId = int.Parse(claim.Value);

        DeleteArtistFollowerCommandValidator validator = new DeleteArtistFollowerCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }
}