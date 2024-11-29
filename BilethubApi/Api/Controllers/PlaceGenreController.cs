using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Application.PlaceGenreOperations.Queries.GetPlaceGenres;
using BilethubApi.Api.Application.PlaceGenreOperations.Commands.CreatePlaceGenre;
using BilethubApi.Api.Application.PlaceGenreOperations.Commands.UpdatePlaceGenre;
using BilethubApi.Api.Application.PlaceGenreOperations.Commands.DeletePlaceGenre;

namespace BilethubApi.Api.Controllers;

[ApiController]
[Route("Api/[controller]s")]
public class PlaceGenreController : ControllerBase
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public PlaceGenreController(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetPlaceGenres()
    {
        GetPlaceGenresQuery query = new GetPlaceGenresQuery(_context, _mapper);
        return Ok(query.Handle());
    }

    [HttpPost]
    public IActionResult CreatePlaceGenre([FromBody] CreatePlaceGenreModel newPlaceGenre)
    {
        CreatePlaceGenreCommand command = new CreatePlaceGenreCommand(_context, _mapper);
        command.Model = newPlaceGenre;

        CreatePlaceGenreCommandValidator validator = new CreatePlaceGenreCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePlaceGenre(int id, [FromBody] UpdatePlaceGenreModel updatedPlaceGenre)
    {
        UpdatePlaceGenreCommand command = new UpdatePlaceGenreCommand(_context);
        command.Id = id;
        command.Model = updatedPlaceGenre;

        UpdatePlaceGenreCommandValidator validator = new UpdatePlaceGenreCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePlaceGenre(int id)
    {
        DeletePlaceGenreCommand command = new DeletePlaceGenreCommand(_context);
        command.Id = id;

        DeletePlaceGenreCommandValidator validator = new DeletePlaceGenreCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }
}