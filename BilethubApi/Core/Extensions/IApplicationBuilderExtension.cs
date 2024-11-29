using BilethubApi.Core.Middleware;

namespace BilethubApi.Core.Extensions;

public static class IApplicationBuilderExtension
{
    public static IApplicationBuilder UseCustomException(this IApplicationBuilder builder) => builder.UseMiddleware<CustomExceptionMiddleware>();
}