using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Application.SearchOperations.Queries.GetSummary;
using BilethubApi.Api.Application.SearchOperations.Queries.GetSearch;

namespace BilethubApi.Api.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class SearchController : ControllerBase
{
    private IBilethubDbContext _context;
    private IMapper _mapper;

    public SearchController(IBilethubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("Summary")]
    public IActionResult GetSearchSummary()
    {
        GetSummaryQuery query = new GetSummaryQuery(_context, _mapper);
        return Ok(query.Handle());
    }

    [HttpGet]
    public IActionResult GetSearch(string queryText)
    {
        GetSearchQuery query = new GetSearchQuery(_context, _mapper);
        query.QueryText = queryText;
        
        return Ok(query.Handle());
    }
}