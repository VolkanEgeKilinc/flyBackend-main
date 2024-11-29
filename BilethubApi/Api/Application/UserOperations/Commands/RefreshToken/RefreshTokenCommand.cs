using BilethubApi.Api.DbOperations;
using BilethubApi.Core.TokenOperations;
using BilethubApi.Core.TokenOperations.Model;

namespace BilethubApi.Api.Application.UserOperations.Commands.RefreshToken;

public class RefreshTokenCommand
{

    private IBilethubDbContext _context;
    private IConfiguration _configuration;

    public string RefreshToken { get; set; } = null!;

    public RefreshTokenCommand(IBilethubDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }


    public Token Handle()
    {
        var user = _context.Users.FirstOrDefault(x => x.RefreshToken == RefreshToken);
        if (user is null)
            throw new InvalidOperationException("Refresh Token is not found!");

        TokenHandler handler = new TokenHandler(_configuration);
        var token = handler.CreateAccessToken(user);

        user.RefreshToken = token.RefreshToken;
        user.RefreshTokenExpireDate = token.ExpireDate;

        _context.SaveChanges();

        return token;
    }
}