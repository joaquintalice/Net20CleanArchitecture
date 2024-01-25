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
            OrderAggregate Order = OrderAggregate.From(orderDTO);

            await _repository.CreateOrder(Order);
            await _repository.SaveChanges();
            await _outputPort.Handle(Order.Id);
        }
    }
}
