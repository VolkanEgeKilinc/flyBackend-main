using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Application.PlaceOperations.Queries.GetPlaces;
using BilethubApi.Api.Application.PlaceOperations.Commands.CreatePlace;
using BilethubApi.Api.Application.PlaceOperations.Commands.UpdatePlace;
using BilethubApi.Api.Application.PlaceOperations.Commands.DeletePlace;
using BilethubApi.Api.Application.PlaceOperations.Queries.GetPlaceDetail;
using BilethubApi.Core.Extensions;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace BilethubApi.Api.Controllers;

[ApiController]
[Route("Api/[controller]s")]
public class PlaceController : ControllerBase
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public PlaceController(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetPlaces()
    {
        GetPlacesQuery query = new GetPlacesQuery(_context, _mapper);
        return Ok(query.Handle());
    }

    [Authorize]
    [HttpGet("{id}")]
    public IActionResult GetPlaceDetail(int id)
    {
        var claim = User.GetPrimaryClaim(ClaimTypes.Name);
        if (claim is null)
            throw new UnauthorizedAccessException();
            
        GetPlaceDetailQuery query = new GetPlaceDetailQuery(_context, _mapper);
        query.Id = id;
        query.UserId = int.Parse(claim.Value);

        GetPlaceDetailQueryValidator validator = new GetPlaceDetailQueryValidator();
        validator.ValidateAndThrow(query);

        return Ok(query.Handle());
    }

    [HttpPost]
    public IActionResult CreatePlace([FromBody] CreatePlaceModel newPlace)
    {
        CreatePlaceCommand command = new CreatePlaceCommand(_context, _mapper);
        command.Model = newPlace;

        CreatePlaceCommandValidator validator = new CreatePlaceCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePlace(int id, [FromBody] UpdatePlaceModel updatedPlace)
    {
        UpdatePlaceCommand command = new UpdatePlaceCommand(_context);
        command.Id = id;
        command.Model = updatedPlace;

        UpdatePlaceCommandValidator validator = new UpdatePlaceCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePlace(int id)
    {
        DeletePlaceCommand command = new DeletePlaceCommand(_context);
        command.Id = id;

        DeletePlaceCommandValidator validator = new DeletePlaceCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }
}