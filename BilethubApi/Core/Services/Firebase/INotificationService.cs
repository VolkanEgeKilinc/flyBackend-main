using FirebaseAdmin.Messaging;

namespace BilethubApi.Core.Services.Firebase;

public interface INotificationService
{
    public void sendToTopic(string topic, Notification notification, IReadOnlyDictionary<string, string>? data = null);
    public void sendToToken(string token, Notification notification, IReadOnlyDictionary<string, string>? data = null);
}