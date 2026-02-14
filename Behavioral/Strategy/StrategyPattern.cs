namespace StrategyPattern
{
    public class StrategyPattern
    {
        public interface IFeeCalculationStrategy
        {
            decimal Calculate(decimal orderAmount);
        }
        public class StandardFeeStrategy : IFeeCalculationStrategy
        {
            public decimal Calculate(decimal orderAmount)
                => 10m; 
        }
        public class VipFeeStrategy : IFeeCalculationStrategy
        {
            public decimal Calculate(decimal orderAmount)
                => orderAmount * 0.005m; // 0.5%
        }
        public class InstitutionalFeeStrategy : IFeeCalculationStrategy
        {
            public decimal Calculate(decimal orderAmount)
            {
                if (orderAmount > 1_000_000m)
                    return orderAmount * 0.002m;

                return orderAmount * 0.004m;
            }
        }

        public class OrderFeeCalculator
        {
            private readonly IFeeCalculationStrategy _strategy;

            public OrderFeeCalculator(IFeeCalculationStrategy strategy)
            {
                _strategy = strategy;
            }

            public decimal CalculateFee(decimal orderAmount)
            {
                return _strategy.Calculate(orderAmount);
            }
        }

        public static void Main()
        {
            decimal amount = 100_000m;
            IFeeCalculationStrategy strategy = new VipFeeStrategy();
            var calculator = new OrderFeeCalculator(strategy);
            var fee = calculator.CalculateFee(amount);
            Console.WriteLine($"Taxa calculada: {fee}");
        }
    }
}
