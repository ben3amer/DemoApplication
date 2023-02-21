namespace Application.Common;
public interface INotificationService
{
    Task SendAsync(MessageDto message);
}