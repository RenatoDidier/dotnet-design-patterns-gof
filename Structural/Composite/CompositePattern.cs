namespace CompositePattern
{
    public class CompositePattern
    {
        public interface IInvestmentComponent
        {
            decimal CalculateValue();
        }
        public class Stock : IInvestmentComponent
        {
            public string Ticker { get; }
            public int Quantity { get; }
            public decimal UnitPrice { get; }

            public Stock(string ticker, int quantity, decimal unitPrice)
            {
                Ticker = ticker;
                Quantity = quantity;
                UnitPrice = unitPrice;
            }

            public decimal CalculateValue()
            {
                return Quantity * UnitPrice;
            }
        }
        public class Portfolio : IInvestmentComponent
        {
            private readonly List<IInvestmentComponent> _components = new();

            public string Name { get; }

            public Portfolio(string name)
            {
                Name = name;
            }

            public void Add(IInvestmentComponent component)
            {
                _components.Add(component);
            }

            public void Remove(IInvestmentComponent component)
            {
                _components.Remove(component);
            }

            public decimal CalculateValue()
            {
                return _components.Sum(c => c.CalculateValue());
            }
        }

        public class Program
        {
            public static void Main()
            {
                var petrobras = new Stock("PETR4", 100, 32.50m);
                var vale = new Stock("VALE3", 50, 70.00m);

                var brazilPortfolio = new Portfolio("Carteira Brasil");
                brazilPortfolio.Add(petrobras);
                brazilPortfolio.Add(vale);

                var internationalStock = new Stock("AAPL", 10, 180.00m);

                var globalPortfolio = new Portfolio("Carteira Global");
                globalPortfolio.Add(brazilPortfolio);
                globalPortfolio.Add(internationalStock);

                Console.WriteLine($"Valor total: {globalPortfolio.CalculateValue()}");
            }
        }


    }
}
