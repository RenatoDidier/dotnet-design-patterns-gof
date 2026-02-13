namespace BridgePattern
{
    public class BridgePattern
    {
        public interface IOrderExecutionChannel
        {
            void Execute(string asset, int quantity, decimal price);
        }
        public class B3ExecutionChannel : IOrderExecutionChannel
        {
            public void Execute(string asset, int quantity, decimal price)
            {
                Console.WriteLine($"Executando ordem na B3: {asset} - {quantity} - {price}");
            }
        }
        public class ExternalBrokerExecutionChannel : IOrderExecutionChannel
        {
            public void Execute(string asset, int quantity, decimal price)
            {
                Console.WriteLine($"Executando ordem via Corretora Externa: {asset} - {quantity} - {price}");
            }
        }

        public abstract class Order
        {
            protected readonly IOrderExecutionChannel _executionChannel;

            protected Order(IOrderExecutionChannel executionChannel)
            {
                _executionChannel = executionChannel;
            }

            public abstract void Send(string asset, int quantity, decimal price);
        }
        public class MarketOrder : Order
        {
            public MarketOrder(IOrderExecutionChannel executionChannel)
                : base(executionChannel)
            {
            }

            public override void Send(string asset, int quantity, decimal price)
            {
                Console.WriteLine("Validando regras de ordem de mercado...");
                _executionChannel.Execute(asset, quantity, price);
            }
        }
        public class LimitOrder : Order
        {
            public LimitOrder(IOrderExecutionChannel executionChannel)
                : base(executionChannel)
            {
            }

            public override void Send(string asset, int quantity, decimal price)
            {
                Console.WriteLine("Validando regras de ordem limitada...");
                _executionChannel.Execute(asset, quantity, price);
            }
        }

        public class Program
        {
            public static void Main()
            {
                IOrderExecutionChannel b3 = new B3ExecutionChannel();
                IOrderExecutionChannel broker = new ExternalBrokerExecutionChannel();

                Order marketOrder = new MarketOrder(b3);
                marketOrder.Send("PETR4", 100, 32.50m);

                Order limitOrder = new LimitOrder(broker);
                limitOrder.Send("VALE3", 50, 70.00m);
            }
        }


    }
}
