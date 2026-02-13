using static FactoryPattern.FactoryPatternSwitch;

namespace FactoryPattern;

public class FactoryPatternPolimorfism
{
    public interface IOrderCreator
    {
        OrderType SupportedType { get; }
        Order Create(string asset, int quantity, decimal? price);
    }
    public class MarketOrderCreator : IOrderCreator
    {
        public OrderType SupportedType => OrderType.Market;

        public Order Create(string asset, int quantity, decimal? price)
            => new MarketOrder(asset, quantity);
    }
    public class LimitOrderCreator : IOrderCreator
    {
        public OrderType SupportedType => OrderType.Limit;

        public Order Create(string asset, int quantity, decimal? price)
            => new LimitOrder(asset, quantity, price!.Value);
    }
    public class StopOrderCreator : IOrderCreator
    {
        public OrderType SupportedType => OrderType.Stop;

        public Order Create(string asset, int quantity, decimal? price)
            => new StopOrder(asset, quantity, price!.Value);
    }


    public class OrderFactory
    {
        private readonly Dictionary<OrderType, IOrderCreator> _creators;

        public OrderFactory(IEnumerable<IOrderCreator> creators)
        {
            _creators = creators.ToDictionary(
                c => c.SupportedType,
                c => c);
        }

        public Order Create(OrderType type, string asset, int quantity, decimal? price)
        {
            if (!_creators.TryGetValue(type, out var creator))
                throw new InvalidOperationException("Tipo inválido.");

            return creator.Create(asset, quantity, price);
        }
    }


}



public enum OrderType
{
    Market,
    Limit,
    Stop
}
