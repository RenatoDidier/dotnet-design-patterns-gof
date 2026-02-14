namespace VisitorPattern
{
    public class VisitorPattern
    {
        public interface IFinancialAsset
        {
            void Accept(IFinancialAssetVisitor visitor);
        }
        public interface IFinancialAssetVisitor
        {
            void Visit(Stock stock);
            void Visit(Bond bond);
        }


        public class Stock : IFinancialAsset
        {
            public string Ticker { get; }
            public int Quantity { get; }
            public decimal UnitPrice { get; }

            public Stock(string ticker, int quantity, decimal unitPrice)
            {
                Ticker = ticker;
                Quantity = quantity;
                UnitPrice = unitPrice;
            }

            public decimal MarketValue => Quantity * UnitPrice;

            public void Accept(IFinancialAssetVisitor visitor)
                => visitor.Visit(this);
        }
        public class Bond : IFinancialAsset
        {
            public string Name { get; }
            public decimal FaceValue { get; }
            public decimal InterestRate { get; }

            public Bond(string name, decimal faceValue, decimal interestRate)
            {
                Name = name;
                FaceValue = faceValue;
                InterestRate = interestRate;
            }

            public void Accept(IFinancialAssetVisitor visitor)
                => visitor.Visit(this);
        }

        public class TaxCalculationVisitor : IFinancialAssetVisitor
        {
            public decimal TotalTax { get; private set; }

            public void Visit(Stock stock)
            {
                var tax = stock.MarketValue * 0.15m;
                TotalTax += tax;
            }

            public void Visit(Bond bond)
            {
                var tax = bond.FaceValue * 0.10m;
                TotalTax += tax;
            }
        }

        public class ReportVisitor : IFinancialAssetVisitor
        {
            public void Visit(Stock stock)
            {
                Console.WriteLine(
                    $"Stock - {stock.Ticker} - Valor: {stock.MarketValue}");
            }

            public void Visit(Bond bond)
            {
                Console.WriteLine(
                    $"Bond - {bond.Name} - Valor: {bond.FaceValue}");
            }
        }

        public static void Main()
        {
            var portfolio = new List<IFinancialAsset>
        {
            new Stock("PETR4", 100, 32.50m),
            new Bond("Tesouro Selic", 10_000m, 0.12m)
        };

            // Visitor de relatório
            var reportVisitor = new ReportVisitor();

            foreach (var asset in portfolio)
                asset.Accept(reportVisitor);

            // Visitor de imposto
            var taxVisitor = new TaxCalculationVisitor();

            foreach (var asset in portfolio)
                asset.Accept(taxVisitor);

            Console.WriteLine($"Imposto total: {taxVisitor.TotalTax}");
        }
    }
}
