using FirebaseAdmin.Messaging;

namespace BilethubApi.Core.Services.Firebase;

public class NotificationService : INotificationService
{
    public async void sendToTopic(string topic, Notification notification, IReadOnlyDictionary<string, string>? data = null)
    {
        var message = new Message()
        {
            Data = data ?? new Dictionary<string, string>(),
            Topic = topic,
            Notification = notification,
            Android = new AndroidConfig()
            {
                Notification = new AndroidNotification
                {
                    ClickAction = "FLUTTER_NOTIFICATION_CLICK"
                },
            }
        };

        string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);

        Console.WriteLine("Successfully sent message: " + response);
    }

    public async void sendToToken(string token, Notification notification, IReadOnlyDictionary<string, string>? data = null)
    {
        var message = new Message()
        {
            Data = data ?? new Dictionary<string, string>(),
            Token = token,
            Notification = notification,
            Android = new AndroidConfig()
            {
                Notification = new AndroidNotification
                {
                    ClickAction = "FLUTTER_NOTIFICATION_CLICK"
                },
            }
        };

        string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);

        Console.WriteLine("Successfully sent message: " + response);
    }

    // private async Task<bool> sendNotification(string? to, string title, string body)
    // {
    //     string authorizationKey = string.Format("key={0}", "");

    //     using (var client = new HttpClient())
    //     {
    //         client.BaseAddress = new Uri("https://fcm.googleapis.com");

    //         client.DefaultRequestHeaders.Clear();
    //         client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    //         client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authorizationKey);

    //         var content = new
    //         {
    //             notification = new
    //             {
    //                 title = title,
    //                 body = body,
    //             },
    //             priority = "high",
    //             data = new
    //             {
    //                 click_action = "FLUTTER_NOTIFICATION_CLICK",
    //             },
    //             to = to
    //         };

    //         string jsonContent = JsonConvert.SerializeObject(content);

    //         StringContent stringContent = new StringContent(jsonContent);

    //         HttpResponseMessage Res = await client.PostAsync("fcm/send", stringContent);

    //         return Res.IsSuccessStatusCode;
    //     }
    // }
}