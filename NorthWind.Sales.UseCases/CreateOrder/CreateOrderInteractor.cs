namespace NorthWind.Sales.UseCases.CreateOrder
{
    public class CreateOrderInteractor : ICreateOrderInputPort
    {
        readonly ICreateOrderOutputPort _outputPort;
        readonly INorthWindSalesCommandsRepository _repository;

        public CreateOrderInteractor(ICreateOrderOutputPort outputPort, INorthWindSalesCommandsRepository repository)
        {
            _outputPort = outputPort;
            _repository = repository;
        }

        public async ValueTask Handle(CreateOrderDTO orderDTO)
        {
            OrderAggregate Order = new OrderAggregate()
            {
                CustomerId = orderDTO.CustomerId,
                ShipAddress = orderDTO.ShipAddress,
                ShipCity = orderDTO.ShipCity,
                ShipCountry = orderDTO.ShipCountry,
                ShipPostalCode = orderDTO.ShipPostalCode
            };

            foreach (var item in orderDTO.OrderDetails)
            {
                Order.AddDetail(item.ProductId, item.UnitPrice, item.Quantity);
            }

            await _repository.CreateOrder(Order);
            await _repository.SaveChanges();
            await _outputPort.Handle(Order.Id);
        }
    }
}
