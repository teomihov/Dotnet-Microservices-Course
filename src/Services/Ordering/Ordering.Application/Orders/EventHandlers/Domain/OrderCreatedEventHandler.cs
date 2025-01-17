using MassTransit;

using MediatR;

using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;

using Ordering.Domain.Events;

namespace Ordering.Application.Orders.EventHandlers.Domain;

internal class OrderCreatedEventHandler(IPublishEndpoint publishEndpoint, IFeatureManager featureManager, ILogger<OrderCreatedEventHandler> logger) : INotificationHandler<OrderCreatedEvent>
{
    public async Task Handle(OrderCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Domain Event handled {domainEvent.order.OrderName}");

        if (await featureManager.IsEnabledAsync("OrderFullfilment"))
        {
            var orderCreatedEvent = domainEvent.order.ToOrderDto();
            await publishEndpoint.Publish(orderCreatedEvent, cancellationToken);
        }
    }
}
