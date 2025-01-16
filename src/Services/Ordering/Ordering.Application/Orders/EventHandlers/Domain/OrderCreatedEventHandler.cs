using MediatR;

using Microsoft.Extensions.Logging;

using Ordering.Domain.Events;

namespace Ordering.Application.Orders.EventHandlers.Domain;
internal class OrderCreatedEventHandler(ILogger<OrderCreatedEventHandler> logger) : INotificationHandler<OrderCreatedEvent>
{
    public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Domain Event handled {notification.order.OrderName}");

        return Task.CompletedTask;
    }
}
