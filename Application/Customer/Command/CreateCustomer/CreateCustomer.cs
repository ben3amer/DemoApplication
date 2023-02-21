using Application.Common;
using Application.Common.Mapping;
using MediatR;

namespace Application.Customer.Command.CreateCustomer;
public class CustomerCreated : INotification
{
    public int Id { get; set; }
    
    public class CustomerCreatedHandler : INotificationHandler<CustomerCreated>
    {
        private readonly INotificationService _notification;
        
        public CustomerCreatedHandler(INotificationService notification)
        {
            _notification = notification;
        }
        public async Task Handle(CustomerCreated notification, CancellationToken cancellationToken)
        {
            await _notification.SendAsync(new MessageDto());
        }
    }
}