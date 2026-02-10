namespace AdapterPattern
{
    public class AdapterPattern
    {
        public interface ICotacaoProvider
        {
            decimal ObterPreco(string ticker);
        }

        public class B3CotacaoProvider : ICotacaoProvider
        {
            public decimal ObterPreco(string ticker)
            {
                return 123.45m;
            }
        }
        public class BloombergLegacyService
        {
            public double GetLastPrice(string assetCode)
            {
                return 123.45;
            }
        }

        public class BloombergCotacaoAdapter : ICotacaoProvider
        {
            private readonly BloombergLegacyService _legacyService;

            public BloombergCotacaoAdapter(BloombergLegacyService legacyService)
            {
                _legacyService = legacyService;
            }

            public decimal ObterPreco(string ticker)
            {
                double preco = _legacyService.GetLastPrice(ticker);
                return Convert.ToDecimal(preco);
            }
        }

        public class CalculadoraValorPosicao
        {
            private readonly ICotacaoProvider _cotacaoProvider;

            public CalculadoraValorPosicao(ICotacaoProvider cotacaoProvider)
            {
                _cotacaoProvider = cotacaoProvider;
            }

            public decimal Calcular(string ticker, int quantidade)
            {
                var preco = _cotacaoProvider.ObterPreco(ticker);
                return preco * quantidade;
            }
        }

        /*
            var legacyService = new BloombergLegacyService();
            ICotacaoProvider cotacaoProvider =
                new BloombergCotacaoAdapter(legacyService);

            var calculadora = new CalculadoraValorPosicao(cotacaoProvider);

            var valor = calculadora.Calcular("PETR4", 100);
            Console.WriteLine(valor);
        */

    }
}
