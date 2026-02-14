namespace TemplateMethodPattern
{
    public class TemplateMethodPattern
    {
        public abstract class OrderProcessor
        {
            public void Process(string asset, int quantity, decimal price)
            {
                Validate(asset, quantity, price);

                var grossAmount = quantity * price;

                var fee = CalculateFee(grossAmount);

                RegisterLedger(grossAmount + fee);

                NotifyExternalSystems();

                Console.WriteLine("Processamento finalizado.");
            }

            protected virtual void Validate(string asset, int quantity, decimal price)
            {
                if (quantity <= 0)
                    throw new InvalidOperationException("Quantidade inválida.");
            }

            protected abstract decimal CalculateFee(decimal grossAmount);

            protected virtual void RegisterLedger(decimal totalAmount)
            {
                Console.WriteLine($"Lançamento contábil: {totalAmount}");
            }

            protected virtual void NotifyExternalSystems()
            {
                Console.WriteLine("Notificando sistemas externos...");
            }
        }

        public class DomesticOrderProcessor : OrderProcessor
        {
            protected override decimal CalculateFee(decimal grossAmount)
                => grossAmount * 0.01m; 
        }
        public class InternationalOrderProcessor : OrderProcessor
        {
            protected override decimal CalculateFee(decimal grossAmount)
                => grossAmount * 0.02m; 
        }

        public static void Main()
        {
            OrderProcessor processor = new DomesticOrderProcessor();

            processor.Process("PETR4", 100, 32.50m);
        }
    }
}
