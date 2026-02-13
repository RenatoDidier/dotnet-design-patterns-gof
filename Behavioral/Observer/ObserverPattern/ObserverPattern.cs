namespace ObserverPattern
{
    public class ObserverPattern
    {
        public interface IPriceObserver
        {
            void Update(string asset, decimal newPrice);
        }

        public class MarketDataFeed
        {
            private readonly List<IPriceObserver> _observers = new();

            public void Subscribe(IPriceObserver observer)
            {
                _observers.Add(observer);
            }

            public void Unsubscribe(IPriceObserver observer)
            {
                _observers.Remove(observer);
            }

            public void PublishPrice(string asset, decimal price)
            {
                Console.WriteLine($"Novo preço: {asset} = {price}");

                foreach (var observer in _observers)
                {
                    observer.Update(asset, price);
                }
            }
        }

        public class PortfolioService : IPriceObserver
        {
            public void Update(string asset, decimal newPrice)
            {
                Console.WriteLine($"Atualizando valor da carteira para {asset}");
            }
        }
        public class RiskService : IPriceObserver
        {
            public void Update(string asset, decimal newPrice)
            {
                Console.WriteLine($"Recalculando risco para {asset}");
            }
        }
        public class AlertService : IPriceObserver
        {
            public void Update(string asset, decimal newPrice)
            {
                if (newPrice > 100m)
                    Console.WriteLine($"Alerta: {asset} acima de 100!");
            }
        }

        public static void Main()
        {
            var marketFeed = new MarketDataFeed();

            var portfolio = new PortfolioService();
            var risk = new RiskService();
            var alert = new AlertService();

            marketFeed.Subscribe(portfolio);
            marketFeed.Subscribe(risk);
            marketFeed.Subscribe(alert);

            marketFeed.PublishPrice("PETR4", 32.50m);
            marketFeed.PublishPrice("AAPL", 150m);
        }

    }
}
