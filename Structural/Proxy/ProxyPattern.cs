namespace ProxyPattern
{
    public class ProxyPattern
    {
        public interface ITransactionHistoryService
        {
            IReadOnlyList<string> GetHistory(string clientId);
        }

        public class TransactionHistoryService : ITransactionHistoryService
        {
            public IReadOnlyList<string> GetHistory(string clientId)
            {
                Console.WriteLine("Consultando banco de dados...");

                return new List<string>
        {
            "Compra PETR4",
            "Venda VALE3",
            "Compra ITUB4"
        };
            }
        }
        public class TransactionHistoryProxy : ITransactionHistoryService
        {
            private readonly ITransactionHistoryService _realService;
            private readonly Dictionary<string, IReadOnlyList<string>> _cache = new();

            public TransactionHistoryProxy(ITransactionHistoryService realService)
            {
                _realService = realService;
            }

            public IReadOnlyList<string> GetHistory(string clientId)
            {
                ValidateAccess(clientId);

                if (_cache.ContainsKey(clientId))
                {
                    Console.WriteLine("Retornando histórico do cache.");
                    return _cache[clientId];
                }

                var history = _realService.GetHistory(clientId);

                _cache[clientId] = history;

                LogAccess(clientId);

                return history;
            }

            private void ValidateAccess(string clientId)
            {
                Console.WriteLine($"Validando permissão para cliente {clientId}...");
            }

            private void LogAccess(string clientId)
            {
                Console.WriteLine($"Auditoria registrada para cliente {clientId}.");
            }
        }

        public class Program
        {
            public static void Main()
            {
                ITransactionHistoryService service =
                    new TransactionHistoryProxy(
                        new TransactionHistoryService());

                var history1 = service.GetHistory("CLIENT-001");
                Console.WriteLine("-----");

                var history2 = service.GetHistory("CLIENT-001");
            }
        }

    }
}
