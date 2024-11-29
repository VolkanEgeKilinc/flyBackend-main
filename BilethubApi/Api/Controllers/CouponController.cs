using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Application.CouponOperations.Commands.CreateCoupon;
using BilethubApi.Api.Application.CouponOperations.Commands.UpdateCoupon;
using BilethubApi.Core.Extensions;
using System.Security.Claims;
using BilethubApi.Api.Application.CouponOperations.Queries.GetCouponsByEvent;

namespace BilethubApi.Api.Controllers;

[ApiController]
[Route("Api/[controller]s")]
public class CouponController : ControllerBase
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public CouponController(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("~/Api/Events/Coupons")]
    public IActionResult GetCouponsByEvent([FromQuery] int eventId)
    {
        var claim = User.GetPrimaryClaim(ClaimTypes.Name);
        if (claim is null)
            throw new UnauthorizedAccessException();

        GetCouponsByEventQuery query = new GetCouponsByEventQuery(_context, _mapper);
        query.UserId = int.Parse(claim.Value);
        query.EventId = eventId;

        GetCouponsByEventQueryValidator validator = new GetCouponsByEventQueryValidator();
        validator.ValidateAndThrow(query);

        return Ok(query.Handle());
    }

    [HttpPost]
    public IActionResult CreateCoupon([FromBody] CreateCouponModel newCoupon)
    {
        CreateCouponCommand command = new CreateCouponCommand(_context, _mapper);
        command.Model = newCoupon;

        CreateCouponCommandValidator validator = new CreateCouponCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCoupon(int id, [FromBody] UpdateCouponModel updatedCoupon)
    {
        UpdateCouponCommand command = new UpdateCouponCommand(_context);
        command.Id = id;
        command.Model = updatedCoupon;

        UpdateCouponCommandValidator validator = new UpdateCouponCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }
}