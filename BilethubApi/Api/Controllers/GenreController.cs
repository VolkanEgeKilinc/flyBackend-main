using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Application.GenreOperations.Queries.GetGenres;
using BilethubApi.Api.Application.GenreOperations.Commands.CreateGenre;
using BilethubApi.Api.Application.GenreOperations.Commands.UpdateGenre;
using BilethubApi.Api.Application.GenreOperations.Commands.DeleteGenre;
using BilethubApi.Api.Application.EventOperations.Queries.GetGenresByEventCategory;

namespace BilethubApi.Api.Controllers;

[ApiController]
[Route("Api/[controller]s")]
public class GenreController : ControllerBase
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public GenreController(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetGenres(int limit = 0)
    {
        GetGenresQuery query = new GetGenresQuery(_context, _mapper);
        query.Limit = limit;

        return Ok(query.Handle());
    }

    [Route("~/Api/EventCategories/{id}/Genres")]
    [HttpGet]
    public IActionResult GetGenresByEventCategory(int id)
    {
        GetGenresByEventCategoryQuery query = new GetGenresByEventCategoryQuery(_context, _mapper);
        query.EventCategoryId = id;

        GetGenresByEventCategoryQueryValidator validator = new GetGenresByEventCategoryQueryValidator();
        validator.ValidateAndThrow(query);

        return Ok(query.Handle());
    }

    [HttpPost]
    public IActionResult CreateGenre([FromBody] CreateGenreModel newGenre)
    {
        CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
        command.Model = newGenre;

        CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel updatedGenre)
    {
        UpdateGenreCommand command = new UpdateGenreCommand(_context);
        command.Id = id;
        command.Model = updatedGenre;

        UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteGenre(int id)
    {
        DeleteGenreCommand command = new DeleteGenreCommand(_context);
        command.Id = id;

        DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }
}