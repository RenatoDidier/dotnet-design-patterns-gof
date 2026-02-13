namespace MediatorPattern;

public class MediatorPatternCommon
{
    public interface IRequest<TResponse> { }
    public interface IRequestHandler<TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }

    public class CreateOrderCommand : IRequest<Guid>
    {
        public string Asset { get; set; }
        public int Quantity { get; set; }
    }

    public class CreateOrderHandler
    : IRequestHandler<CreateOrderCommand, Guid>
    {
        public Task<Guid> Handle(CreateOrderCommand request)
        {
            Console.WriteLine("Criando ordem...");
            return Task.FromResult(Guid.NewGuid());
        }
    }

}
