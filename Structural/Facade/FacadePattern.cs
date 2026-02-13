namespace FacadePattern
{
    public class FacadePattern
    {
        public class OrderValidator
        {
            public void Validate(string asset, int quantity)
            {
                if (quantity <= 0)
                    throw new ArgumentException("Quantidade inválida.");
            }
        }
        public class BalanceService
        {
            public void EnsureSufficientFunds(decimal requiredAmount)
            {
                decimal availableBalance = 100_000m;

                if (requiredAmount > availableBalance)
                    throw new InvalidOperationException("Saldo insuficiente.");
            }
        }
        public class FeeService
        {
            public decimal CalculateFee(decimal amount)
            {
                return amount * 0.01m;
            }
        }
        public class ExchangeGateway
        {
            public void SendOrder(string asset, int quantity, decimal price)
            {
                Console.WriteLine($"Ordem enviada para bolsa: {asset}");
            }
        }
        public class LedgerService
        {
            public void Register(decimal totalAmount)
            {
                Console.WriteLine($"Lançamento contábil registrado: {totalAmount}");
            }
        }

        public class TradingFacade
        {
            private readonly OrderValidator _validator;
            private readonly BalanceService _balanceService;
            private readonly FeeService _feeService;
            private readonly ExchangeGateway _exchangeGateway;
            private readonly LedgerService _ledgerService;

            public TradingFacade(
                OrderValidator validator,
                BalanceService balanceService,
                FeeService feeService,
                ExchangeGateway exchangeGateway,
                LedgerService ledgerService)
            {
                _validator = validator;
                _balanceService = balanceService;
                _feeService = feeService;
                _exchangeGateway = exchangeGateway;
                _ledgerService = ledgerService;
            }

            public void ExecuteBuyOrder(string asset, int quantity, decimal unitPrice)
            {
                _validator.Validate(asset, quantity);

                var grossAmount = quantity * unitPrice;
                var fee = _feeService.CalculateFee(grossAmount);
                var totalAmount = grossAmount + fee;

                _balanceService.EnsureSufficientFunds(totalAmount);

                _exchangeGateway.SendOrder(asset, quantity, unitPrice);

                _ledgerService.Register(totalAmount);

                Console.WriteLine("Ordem executada com sucesso.");
            }
        }

        public class Program
        {
            public static void Main()
            {
                var facade = new TradingFacade(
                    new OrderValidator(),
                    new BalanceService(),
                    new FeeService(),
                    new ExchangeGateway(),
                    new LedgerService());

                facade.ExecuteBuyOrder("PETR4", 100, 32.50m);
            }
        }
    }
}
