namespace BilethubApi.Core.Services.Logger;

public class DbLogger : ILoggerService
{
    public void Write(string message)
    {
        Console.WriteLine("[DbLogger] - "+message);
    }
}