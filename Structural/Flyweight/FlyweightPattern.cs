namespace FlyweightPattern
{
    public class FlyweightPattern
    {
        public class OrderMetadata
        {
            public string Ticker { get; }
            public string Market { get; }
            public string Currency { get; }
            public string OrderType { get; }

            public OrderMetadata(string ticker, string market, string currency, string orderType)
            {
                Ticker = ticker;
                Market = market;
                Currency = currency;
                OrderType = orderType;
            }
        }
        public class OrderMetadataFactory
        {
            private readonly Dictionary<string, OrderMetadata> _cache = new();

            public OrderMetadata Get(string ticker, string market, string currency, string orderType)
            {
                var key = $"{ticker}-{market}-{currency}-{orderType}";

                if (_cache.ContainsKey(key))
                    return _cache[key];

                var metadata = new OrderMetadata(ticker, market, currency, orderType);
                _cache[key] = metadata;

                return metadata;
            }
        }

        public class TradeOrder
        {
            private readonly OrderMetadata _metadata;

            public int Quantity { get; }
            public decimal Price { get; }
            public string ClientId { get; }

            public TradeOrder(
                OrderMetadata metadata,
                int quantity,
                decimal price,
                string clientId)
            {
                _metadata = metadata;
                Quantity = quantity;
                Price = price;
                ClientId = clientId;
            }

            public void Execute()
            {
                Console.WriteLine(
                    $"Executando {_metadata.OrderType} de {_metadata.Ticker} " +
                    $"para cliente {ClientId}");
            }
        }

        public class Program
        {
            public static void Main()
            {
                var factory = new OrderMetadataFactory();

                var metadata = factory.Get("PETR4", "B3", "BRL", "Market");

                var order1 = new TradeOrder(metadata, 100, 32.50m, "CLIENT-001");
                var order2 = new TradeOrder(metadata, 200, 32.60m, "CLIENT-002");

                order1.Execute();
                order2.Execute();
            }
        }

    }
}
