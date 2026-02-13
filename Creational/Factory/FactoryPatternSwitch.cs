namespace FactoryPattern
{
    public class FactoryPatternSwitch
    {
        public abstract class Order
        {
            public string Asset { get; }
            public int Quantity { get; }

            protected Order(string asset, int quantity)
            {
                Asset = asset;
                Quantity = quantity;
            }

            public abstract void Validate();
        }
        public class MarketOrder : Order
        {
            public MarketOrder(string asset, int quantity)
                : base(asset, quantity)
            {
            }

            public override void Validate()
            {
                if (Quantity <= 0)
                    throw new InvalidOperationException("Quantidade inválida para Market Order.");
            }
        }
        public class LimitOrder : Order
        {
            public decimal LimitPrice { get; }

            public LimitOrder(string asset, int quantity, decimal limitPrice)
                : base(asset, quantity)
            {
                LimitPrice = limitPrice;
            }

            public override void Validate()
            {
                if (LimitPrice <= 0)
                    throw new InvalidOperationException("Preço limite inválido.");

                if (Quantity <= 0)
                    throw new InvalidOperationException("Quantidade inválida.");
            }
        }
        public class StopOrder : Order
        {
            public decimal StopPrice { get; }

            public StopOrder(string asset, int quantity, decimal stopPrice)
                : base(asset, quantity)
            {
                StopPrice = stopPrice;
            }

            public override void Validate()
            {
                if (StopPrice <= 0)
                    throw new InvalidOperationException("Preço stop inválido.");
            }
        }

        public static class OrderFactory
        {
            public static Order Create(
                string type,
                string asset,
                int quantity,
                decimal? price = null)
            {
                return type switch
                {
                    "Market" => new MarketOrder(asset, quantity),

                    "Limit" when price.HasValue
                        => new LimitOrder(asset, quantity, price.Value),

                    "Stop" when price.HasValue
                        => new StopOrder(asset, quantity, price.Value),

                    _ => throw new ArgumentException("Tipo de ordem inválido.")
                };
            }
        }

        public class Program
        {
            public static void Main()
            {
                var order = OrderFactory.Create(
                    type: "Limit",
                    asset: "PETR4",
                    quantity: 100,
                    price: 32.50m);

                order.Validate();

                Console.WriteLine($"Ordem criada para {order.Asset}");
            }
        }

    }
}
