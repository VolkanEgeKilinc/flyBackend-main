using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Application.PlaceFollowerOperations.Queries.GetPlaceFollowers;
using BilethubApi.Api.Application.PlaceFollowerOperations.Commands.CreatePlaceFollower;
using BilethubApi.Api.Application.PlaceFollowerOperations.Commands.DeletePlaceFollower;
using BilethubApi.Core.Extensions;
using System.Security.Claims;

namespace BilethubApi.Api.Controllers;

[ApiController]
[Route("Api/Places")]
public class PlaceFollowerController : ControllerBase
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public PlaceFollowerController(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("{id}/Followers")]
    public IActionResult GetPlaceFollowersByPlace(int id)
    {
        GetPlaceFollowersQuery query = new GetPlaceFollowersQuery(_context, _mapper);
        query.PlaceId = id;

        GetPlaceFollowersQueryValidator validator = new GetPlaceFollowersQueryValidator();
        validator.ValidateAndThrow(query);

        return Ok(query.Handle());
    }

    [HttpPost("{id}/Follow")]
    public IActionResult CreatePlaceFollower(int id)
    {
        var claim = User.GetPrimaryClaim(ClaimTypes.Name);
        if (claim is null)
            throw new UnauthorizedAccessException();

        CreatePlaceFollowerCommand command = new CreatePlaceFollowerCommand(_context);
        command.Id = id;
        command.UserId = int.Parse(claim.Value);

        CreatePlaceFollowerCommandValidator validator = new CreatePlaceFollowerCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpDelete("{id}/UnFollow")]
    public IActionResult DeletePlaceFollower(int id)
    {
        var claim = User.GetPrimaryClaim(ClaimTypes.Name);
        if (claim is null)
            throw new UnauthorizedAccessException();

        DeletePlaceFollowerCommand command = new DeletePlaceFollowerCommand(_context);
        command.Id = id;
        command.UserId = int.Parse(claim.Value);

        DeletePlaceFollowerCommandValidator validator = new DeletePlaceFollowerCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }
}