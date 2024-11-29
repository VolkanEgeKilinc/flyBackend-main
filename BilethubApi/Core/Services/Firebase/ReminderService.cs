using BilethubApi.Api.DbOperations;
using BilethubApi.Api.Entities;
using BilethubApi.Api.Enum;
using FirebaseAdmin.Messaging;

namespace BilethubApi.Core.Services.Firebase;

public class ReminderService : IHostedService, IDisposable
{
    private readonly IServiceProvider _services;
    private readonly INotificationService _notificationService;
    private readonly ILogger<ReminderService> _logger;
    private Timer? _timer = null;
    private int executionCount = 0;


    public ReminderService(IServiceProvider services, INotificationService notificationService, ILogger<ReminderService> logger)
    {
        _services = services;
        _notificationService = notificationService;
        _logger = logger;
    }

    public Task StartAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Timed Hosted Notification Service running.");

        _timer = new Timer(DoWork, null, TimeSpan.Zero,
            TimeSpan.FromHours(24));

        return Task.CompletedTask;
    }

    private void DoWork(object? state)
    {
        var count = Interlocked.Increment(ref executionCount);

        using (var scope = _services.CreateScope())
        {
            var context =
                scope.ServiceProvider
                    .GetRequiredService<IBilethubDbContext>();

            var today = DateTime.Now;

            var eventList = context.Events.Where(x => x.Status == EventStatus.Approved && Math.Floor(x.Start.Subtract(today).TotalDays) == 7).ToList();

            for (int i = 0; i < eventList?.Count(); i++)
            {
                var data = eventList[i];

                _notificationService.sendToTopic($"Event_{data.Id}_Reminder", notification: new Notification
                {
                    Title = "Hatırlatma",
                    Body = "Pop Festivali etkinliğine 1 hafta kaldı!"
                });
            }
        }

        _logger.LogInformation("Timed Hosted Notification Service is working. Count: {Count}", count);
    }

    public Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Timed Hosted Notification Service is stopping.");

        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}