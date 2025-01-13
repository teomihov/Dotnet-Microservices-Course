using BuildingBlocks.CQRS;

using Microsoft.EntityFrameworkCore;

using Ordering.Application.Data;
using Ordering.Application.Extensions;

namespace Ordering.Application.Orders.Queries.GetOrdersByCustomer;

public class GetOrdersByCustomerHandler(IApplicationDbContext dbContext) : IQueryHandler<GetOrdersByCustomerQuery, GetOrdersByCustomerResult>
{
    public async Task<GetOrdersByCustomerResult> Handle(GetOrdersByCustomerQuery request, CancellationToken cancellationToken)
    {
        var orders = await dbContext.Orders
            .Include(x => x.OrderItems)
            .AsNoTracking()
            .Where(x => x.CustomerId == CustomerId.Of(request.CustomerId))
            .OrderBy(x => x.OrderName.Value)
            .ToListAsync();

        return new GetOrdersByCustomerResult(orders.ToOrderDtoList());
    }
}
