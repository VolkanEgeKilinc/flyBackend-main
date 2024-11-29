using BilethubApi.Api.DbOperations;
using BilethubApi.Core.Constants;
using Microsoft.AspNetCore.Mvc;

namespace BilethubApi.Api.Controllers;


[ApiController]
[Route("Api/[controller]s")]
public class FileController : ControllerBase
{
    private IBilethubDbContext _context;

    public FileController(IBilethubDbContext context)
    {
        _context = context;
    }

    [HttpGet("{category}/{fileName}")]
    public IActionResult GetImage(string category, string fileName)
    {
        var rootPath = Path.GetTempPath();
        var folderPath = "";
        switch (category)
        {
            case "UserProfile": folderPath = ApiConstants.ProfileImageFilePath; break;
            case "UserCover": folderPath = ApiConstants.CoverImageFilePath; break;
        }
        var image = System.IO.File.OpenRead(rootPath + folderPath + fileName);
        return Ok(File(image, $"image/{fileName.Split('.').Last()}"));
    }
}