namespace NorthWind.EFCore.Repositories.Repositories
{
    public class NorthWindSalesCommandsRepository : INorthWindSalesCommandsRepository
    {

        public readonly NorthWindSalesContext _context;

        public NorthWindSalesCommandsRepository(NorthWindSalesContext context)
        {
            _context = context;
        }

        public async ValueTask CreateOrder(OrderAggregate order)
        {
            await _context.AddAsync(order);
            foreach (var item in order.OrderDetails)
            {
                await _context.AddAsync(new OrderDetail
                {
                    Order = order,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                });
            }
        }

        public async ValueTask SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
