namespace CommandPattern
{
    public class CommandPattern
    {
        public interface ICommand
        {
            void Execute();
        }
        public class TradingEngine
        {
            public void Buy(string clientId, string asset, int quantity, decimal price)
            {
                Console.WriteLine(
                    $"Executando compra: Cliente={clientId}, Ativo={asset}, Qtd={quantity}, Preço={price}");
            }
        }
        public class BuyOrderCommand : ICommand
        {
            private readonly TradingEngine _engine;
            private readonly string _clientId;
            private readonly string _asset;
            private readonly int _quantity;
            private readonly decimal _price;

            public BuyOrderCommand(
                TradingEngine engine,
                string clientId,
                string asset,
                int quantity,
                decimal price)
            {
                _engine = engine;
                _clientId = clientId;
                _asset = asset;
                _quantity = quantity;
                _price = price;
            }

            public void Execute()
            {
                _engine.Buy(_clientId, _asset, _quantity, _price);
            }
        }

        public class OrderProcessor
        {
            public void Process(ICommand command)
            {
                Console.WriteLine("Registrando auditoria...");
                command.Execute();
                Console.WriteLine("Processamento finalizado.");
            }
        }

        public static void Main()
        {
            var engine = new TradingEngine();

            ICommand command = new BuyOrderCommand(
                engine,
                clientId: "CLIENT-001",
                asset: "PETR4",
                quantity: 100,
                price: 32.50m);

            var processor = new OrderProcessor();

            processor.Process(command);
        }


    }
}
