namespace AbstractFactoryPattern
{
    public class AbstractFactoryPattern
    {
        /*
            Temos 3 produtos:
                IOrderValidator
                IFeeCalculator
                ISettlementService

            E 2 famílias:
                B3
                NYSE
         */
        public interface IOrderValidator
        {
            void Validate(string asset, int quantity);
        }

        public interface IFeeCalculator
        {
            decimal Calculate(decimal amount);
        }

        public interface ISettlementService
        {
            void Settle(decimal amount);
        }

        public class B3OrderValidator : IOrderValidator
        {
            public void Validate(string asset, int quantity)
            {
                Console.WriteLine("Validação B3 aplicada.");
            }
        }
        public class B3FeeCalculator : IFeeCalculator
        {
            public decimal Calculate(decimal amount)
                => amount * 0.01m;
        }
        public class B3SettlementService : ISettlementService
        {
            public void Settle(decimal amount)
            {
                Console.WriteLine("Liquidação via B3.");
            }
        }

        public class NyseOrderValidator : IOrderValidator
        {
            public void Validate(string asset, int quantity)
            {
                Console.WriteLine("Validação NYSE aplicada.");
            }
        }
        public class NyseFeeCalculator : IFeeCalculator
        {
            public decimal Calculate(decimal amount)
                => amount * 0.02m;
        }
        public class NyseSettlementService : ISettlementService
        {
            public void Settle(decimal amount)
            {
                Console.WriteLine("Liquidação via NYSE.");
            }
        }

        public interface IMarketFactory
        {
            IOrderValidator CreateValidator();
            IFeeCalculator CreateFeeCalculator();
            ISettlementService CreateSettlementService();
        }

        public class B3MarketFactory : IMarketFactory
        {
            public IOrderValidator CreateValidator()
                => new B3OrderValidator();

            public IFeeCalculator CreateFeeCalculator()
                => new B3FeeCalculator();

            public ISettlementService CreateSettlementService()
                => new B3SettlementService();
        }
        public class NyseMarketFactory : IMarketFactory
        {
            public IOrderValidator CreateValidator()
                => new NyseOrderValidator();

            public IFeeCalculator CreateFeeCalculator()
                => new NyseFeeCalculator();

            public ISettlementService CreateSettlementService()
                => new NyseSettlementService();
        }

        public class TradingApplication
        {
            private readonly IOrderValidator _validator;
            private readonly IFeeCalculator _feeCalculator;
            private readonly ISettlementService _settlement;

            public TradingApplication(IMarketFactory factory)
            {
                _validator = factory.CreateValidator();
                _feeCalculator = factory.CreateFeeCalculator();
                _settlement = factory.CreateSettlementService();
            }

            public void Execute(string asset, int quantity, decimal price)
            {
                _validator.Validate(asset, quantity);

                var gross = quantity * price;
                var fee = _feeCalculator.Calculate(gross);

                _settlement.Settle(gross + fee);
            }
        }

    }
}
