﻿using MediatR;

using Microsoft.Extensions.Logging;

using Ordering.Domain.Events;

namespace Ordering.Application.Orders.EventHandlers.Domain;
internal class OrderUpdatedEventHandler(ILogger<OrderUpdatedEventHandler> logger) : INotificationHandler<OrderUpdatedEvent>
{
    public Task Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Domain event handled: {notification.order.OrderName}");


        return Task.CompletedTask;
    }
}
