namespace MediatorPattern
{
    public class MediatorPattern
    {
        public interface ITradeMediator
        {
            void Notify(object sender, string @event);
        }

        public class TradingEngine
        {
            private readonly ITradeMediator _mediator;

            public TradingEngine(ITradeMediator mediator)
            {
                _mediator = mediator;
            }

            public void ExecuteOrder()
            {
                Console.WriteLine("Ordem executada.");
                _mediator.Notify(this, "OrderExecuted");
            }
        }

        public class BalanceService
        {
            public void UpdateBalance()
            {
                Console.WriteLine("Saldo atualizado.");
            }
        }
        public class RiskService
        {
            public void RecalculateRisk()
            {
                Console.WriteLine("Risco recalculado.");
            }
        }

        public class TradeMediator : ITradeMediator
        {
            private readonly BalanceService _balanceService;
            private readonly RiskService _riskService;

            public TradeMediator(
                BalanceService balanceService,
                RiskService riskService)
            {
                _balanceService = balanceService;
                _riskService = riskService;
            }

            public void Notify(object sender, string @event)
            {
                if (@event == "OrderExecuted")
                {
                    _balanceService.UpdateBalance();
                    _riskService.RecalculateRisk();
                }
            }
        }

        public static void Main()
        {
            var balanceService = new BalanceService();
            var riskService = new RiskService();

            var mediator = new TradeMediator(balanceService, riskService);

            var engine = new TradingEngine(mediator);

            engine.ExecuteOrder();
        }
    }
}
