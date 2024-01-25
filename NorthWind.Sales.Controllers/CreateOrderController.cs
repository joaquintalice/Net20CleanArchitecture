namespace NorthWind.Sales.Controllers
{
    public class CreateOrderController : ICreateOrderController
    {
        public readonly ICreateOrderInputPort _inputPort;
        public readonly ICreateOrderPresenter _presenter;

        public CreateOrderController(ICreateOrderInputPort inputPort, ICreateOrderPresenter presenter)
        {
            _inputPort = inputPort;
            _presenter = presenter;
        }

        public async ValueTask<int> CreateOrder(CreateOrderDTO orderDTO)
        {
            await _inputPort.Handle(orderDTO);
            return _presenter.OrderId;
        }
    }
}
