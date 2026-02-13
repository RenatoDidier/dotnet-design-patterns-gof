namespace DecoratorPattern
{
    public class DecoratorPattern
    {
        public interface IOrderPricingService
        {
            decimal Calculate(decimal unitPrice, int quantity);
        }
        public class BaseOrderPricingService : IOrderPricingService
        {
            public decimal Calculate(decimal unitPrice, int quantity)
            {
                return unitPrice * quantity;
            }
        }

        public abstract class OrderPricingDecorator : IOrderPricingService
        {
            protected readonly IOrderPricingService _inner;

            protected OrderPricingDecorator(IOrderPricingService inner)
            {
                _inner = inner;
            }

            public virtual decimal Calculate(decimal unitPrice, int quantity)
            {
                return _inner.Calculate(unitPrice, quantity);
            }
        }
        public class BrokerageFeeDecorator : OrderPricingDecorator
        {
            private readonly decimal _fee;

            public BrokerageFeeDecorator(IOrderPricingService inner, decimal fee)
                : base(inner)
            {
                _fee = fee;
            }

            public override decimal Calculate(decimal unitPrice, int quantity)
            {
                var baseValue = base.Calculate(unitPrice, quantity);
                return baseValue + _fee;
            }
        }
        public class ExchangeFeeDecorator : OrderPricingDecorator
        {
            private readonly decimal _percentage;

            public ExchangeFeeDecorator(IOrderPricingService inner, decimal percentage)
                : base(inner)
            {
                _percentage = percentage;
            }

            public override decimal Calculate(decimal unitPrice, int quantity)
            {
                var baseValue = base.Calculate(unitPrice, quantity);
                var exchangeFee = baseValue * _percentage;

                return baseValue + exchangeFee;
            }
        }
        public class LoggingDecorator : OrderPricingDecorator
        {
            public LoggingDecorator(IOrderPricingService inner)
                : base(inner)
            {
            }

            public override decimal Calculate(decimal unitPrice, int quantity)
            {
                Console.WriteLine("Iniciando cálculo da ordem...");

                var result = base.Calculate(unitPrice, quantity);

                Console.WriteLine($"Valor final calculado: {result}");

                return result;
            }
        }


        public class Program
        {
            public static void Main()
            {
                /*
                    1) LoggingDecorator.Calculate()
                    2) ExchangeFeeDecorator.Calculate()
                    3) BrokerageFeeDecorator.Calculate()
                    4) BaseOrderPricingService.Calculate()

                        A ordem é de dentro para fora. Por mais que ele começa nessa ordem acima,
                    a pipeline vai entrando no método calculate e vai indo até encontrar o BaseOrderPricingService.
                    Ao trazer informações sobre o mesmo, ela vai retornando sobre as outras classes e trazendo os valores
                    das mesmas.
                
                        Request
                          ↓
                        Logging
                          ↓
                        Exchange
                          ↓
                        Brokerage
                          ↓
                        Base
                          ↑
                        Brokerage aplica regra
                          ↑
                        Exchange aplica regra
                          ↑
                        Logging finaliza
                */

                IOrderPricingService pricingService =
                    new LoggingDecorator(
                        new ExchangeFeeDecorator(
                            new BrokerageFeeDecorator(
                                new BaseOrderPricingService(),
                                fee: 5m),
                            percentage: 0.01m));

                var finalValue = pricingService.Calculate(100m, 10);

                Console.WriteLine($"Total da ordem: {finalValue}");
            }
        }



    }
}
