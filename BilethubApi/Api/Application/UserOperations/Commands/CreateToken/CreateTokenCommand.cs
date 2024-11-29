using AutoMapper;
using BilethubApi.Api.DbOperations;
using BilethubApi.Core.TokenOperations;
using BilethubApi.Core.TokenOperations.Model;

namespace BilethubApi.Api.Application.UserOperations.Commands.CreateToken;

public class CreateTokenCommand
{

    private IBilethubDbContext _context;
    private IConfiguration _configuration;

    public CreateTokenModel Model { get; set; } = null!;

    public CreateTokenCommand(IBilethubDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public Token Handle()
    {
        var user = _context.Users.FirstOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
        if (user is null)
            throw new InvalidOperationException("User is not found!");

        TokenHandler handler = new TokenHandler(_configuration);
        Token token = handler.CreateAccessToken(user);

        user.RefreshToken = token.RefreshToken;
        user.RefreshTokenExpireDate = token.ExpireDate;

        _context.SaveChanges();

        return token;
    }
}