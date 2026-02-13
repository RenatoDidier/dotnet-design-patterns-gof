namespace IteratorPattern
{
    public class IteratorPattern
    {
        public class Position
        {
            public string Asset { get; }
            public int Quantity { get; }
            public decimal AveragePrice { get; }

            public Position(string asset, int quantity, decimal averagePrice)
            {
                Asset = asset;
                Quantity = quantity;
                AveragePrice = averagePrice;
            }
        }

        public interface IPositionIterator
        {
            bool HasNext();
            Position Next();
        }
        public class PortfolioIterator : IPositionIterator
        {
            private readonly List<Position> _positions;
            private int _index = 0;

            public PortfolioIterator(List<Position> positions)
            {
                _positions = positions;
            }

            public bool HasNext()
            {
                return _index < _positions.Count;
            }

            public Position Next()
            {
                return _positions[_index++];
            }
        }

        public interface IPositionCollection
        {
            IPositionIterator CreateIterator();
        }

        public class Portfolio : IPositionCollection
        {
            private readonly List<Position> _positions = new();

            public void Add(Position position)
            {
                _positions.Add(position);
            }

            public IPositionIterator CreateIterator()
            {
                return new PortfolioIterator(_positions);
            }
        }

        public static void Main()
        {
            var portfolio = new Portfolio();

            portfolio.Add(new Position("PETR4", 100, 32.50m));
            portfolio.Add(new Position("VALE3", 50, 70.00m));

            var iterator = portfolio.CreateIterator();

            while (iterator.HasNext())
            {
                var position = iterator.Next();

                Console.WriteLine($"{position.Asset} - {position.Quantity}");
            }
        }
    }
}
