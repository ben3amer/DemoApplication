using Application.Common;
using Application.Common.Mapping;

namespace Infrastructure;

public class NotificationService : INotificationService
{
    public Task SendAsync(MessageDto message)
    {
        return Task.CompletedTask;
    }
}