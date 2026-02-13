namespace ChainResponsabilityPattern
{
    public class ChainResponsabilityPattern
    {
        public class OrderRequest
        {
            public string ClientId { get; }
            public string Asset { get; }
            public int Quantity { get; }
            public decimal UnitPrice { get; }

            public decimal TotalAmount => Quantity * UnitPrice;

            public OrderRequest(string clientId, string asset, int quantity, decimal unitPrice)
            {
                ClientId = clientId;
                Asset = asset;
                Quantity = quantity;
                UnitPrice = unitPrice;
            }
        }

        public abstract class OrderValidationHandler
        {
            private OrderValidationHandler? _next;

            public OrderValidationHandler SetNext(OrderValidationHandler next)
            {
                _next = next;
                return next;
            }

            public void Handle(OrderRequest request)
            {
                Validate(request);

                _next?.Handle(request);
            }

            protected abstract void Validate(OrderRequest request);
        }

        public class MarketOpenValidationHandler : OrderValidationHandler
        {
            protected override void Validate(OrderRequest request)
            {
                var now = DateTime.Now.TimeOfDay;
                var open = new TimeSpan(10, 0, 0);
                var close = new TimeSpan(17, 0, 0);

                if (now < open || now > close)
                    throw new InvalidOperationException("Mercado fechado.");
            }
        }
        public class BalanceValidationHandler : OrderValidationHandler
        {
            protected override void Validate(OrderRequest request)
            {
                decimal availableBalance = 50_000m;

                if (request.TotalAmount > availableBalance)
                    throw new InvalidOperationException("Saldo insuficiente.");
            }
        }
        public class RiskValidationHandler : OrderValidationHandler
        {
            protected override void Validate(OrderRequest request)
            {
                decimal maxAllowed = 100_000m;

                if (request.TotalAmount > maxAllowed)
                    throw new InvalidOperationException("Limite de risco excedido.");
            }
        }

        public static void Main()
        {
            var market = new MarketOpenValidationHandler();
            var balance = new BalanceValidationHandler();
            var risk = new RiskValidationHandler();

            market
                .SetNext(balance)
                .SetNext(risk);

            var order = new OrderRequest(
                clientId: "CLIENT-001",
                asset: "PETR4",
                quantity: 100,
                unitPrice: 32.50m);

            market.Handle(order);

            Console.WriteLine("Ordem validada com sucesso.");
        }


    }
}
