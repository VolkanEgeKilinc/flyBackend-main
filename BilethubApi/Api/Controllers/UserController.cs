using System.Security.Claims;
using AutoMapper;
using BilethubApi.Api.Application.UserOperations.Commands.CreateToken;
using BilethubApi.Api.Application.UserOperations.Commands.CreateUser;
using BilethubApi.Api.Application.UserOperations.Commands.RefreshToken;
using BilethubApi.Api.Application.UserOperations.Commands.UpdateProfileImage;
using BilethubApi.Api.Application.UserOperations.Queries.GetHomePageStatistics;
using BilethubApi.Api.Application.UserOperations.Queries.GetUserDetail;
using BilethubApi.Api.Application.UserOperations.Queries.GetUsersBySearch;
using BilethubApi.Api.DbOperations;
using BilethubApi.Core.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BilethubApi.Api.Controllers;


[ApiController]
[Route("Api/[controller]s")]
public class UserController : ControllerBase
{
    private IBilethubDbContext _context;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public UserController(IBilethubDbContext context, IMapper mapper, IConfiguration configuration)
    {
        _context = context;
        _mapper = mapper;
        _configuration = configuration;
    }

    [Authorize]
    [HttpGet("Profile")]
    public IActionResult GetUserDetail()
    {
        var claim = User.GetPrimaryClaim(ClaimTypes.Name);
        if (claim is null)
            throw new UnauthorizedAccessException();

        GetUserDetailQuery query = new GetUserDetailQuery(_context, _mapper);
        query.Id = int.Parse(claim.Value);

        GetUserDetailQueryValidator validator = new GetUserDetailQueryValidator();
        validator.ValidateAndThrow(query);

        return Ok(query.Handle());
    }

    [HttpGet("RefreshToken")]
    public IActionResult RefreshToken([FromQuery] string refreshToken)
    {
        RefreshTokenCommand command = new RefreshTokenCommand(_context, _configuration);
        command.RefreshToken = refreshToken;

        return Ok(command.Handle());
    }

    [HttpPost]
    public IActionResult CreateUser(CreateUserModel newUser)
    {
        CreateUserCommand command = new CreateUserCommand(_context, _mapper);
        command.Model = newUser;
        CreateUserCommandValidator validator = new CreateUserCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();

        return Ok();
    }

    [HttpPost("Connect/Token")]
    public IActionResult CreateToken(CreateTokenModel login)
    {
        CreateTokenCommand command = new CreateTokenCommand(_context, _configuration);
        command.Model = login;

        return Ok(command.Handle());
    }

    [HttpPost("ProfileImage")]
    public async Task<IActionResult> UpdateProfileImage(IFormFile file)
    {
        // var claim = User.GetPrimaryClaim(ClaimTypes.Name);
        // if (claim is null)
        //     throw new UnauthorizedAccessException();

        UpdateProfileImageCommand command = new UpdateProfileImageCommand(_context);
        command.Id = 1;//int.Parse(claim.Value);
        command.File = file;
        await command.Handle();

        return Ok();
    }

    [HttpPost("CoverImage")]
    public IActionResult UpdateCoverImage(IFormFile file)
    {
        return Ok();
    }

    // [HttpGet("ProfileImage")]
    // public IActionResult GetImage()
    // {
    //     // var claim = User.GetPrimaryClaim(ClaimTypes.Name);
    //     // if (claim is null)
    //     //     throw new UnauthorizedAccessException();

    //     GetProfileImageQuery query = new GetProfileImageQuery(_context);
    //     query.Id = 1;//int.Parse(claim.Value);

    //     var imagePath = query.Handle();
    //     if (imagePath is null)
    //         return Ok();

    //     var image = System.IO.File.OpenRead(imagePath);
    //     return Ok(File(image, $"image/{imagePath.Split('.').Last()}"));
    // }

    [HttpGet("~/Api/Admin/[controller]s/HomePageStatistics")]
    public IActionResult GetHomePageStatistics(int? limit)
    {
        var claim = User.GetPrimaryClaim(ClaimTypes.Name);
        if (claim is null)
            throw new UnauthorizedAccessException();

        GetHomePageStatisticsQuery query = new GetHomePageStatisticsQuery(_context, _mapper);
        query.UserId = int.Parse(claim.Value);

        GetHomePageStatisticsQueryValidator validator = new GetHomePageStatisticsQueryValidator();
        validator.ValidateAndThrow(query);

        return Ok(query.Handle());
    }

    [HttpGet("Search")]
    public IActionResult Search(string? search)
    {
        GetUsersBySearchQuery query = new GetUsersBySearchQuery(_context, _mapper);
        query.Search = search;

        return Ok(query.Handle());
    }
    
}