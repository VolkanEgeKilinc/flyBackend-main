using AutoMapper;
using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Entities;
using BilethubApi.Core.Constants;
using BilethubApi.Core.Extensions;

namespace BilethubApi.Api.Application.UserOperations.Commands.UpdateProfileImage;

public class UpdateProfileImageCommand
{

    private IBilethubDbContext _context;

    public int Id { get; set; }
    public IFormFile File { get; set; } = null!;

    public UpdateProfileImageCommand(IBilethubDbContext context)
    {
        _context = context;
    }


    public async Task Handle()
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == Id);
        if (user is null)
            throw new InvalidOperationException("User is not found!");

        user.Image = await File.SaveFile(ApiConstants.ProfileImageFilePath);

        _context.SaveChanges();
    }
}