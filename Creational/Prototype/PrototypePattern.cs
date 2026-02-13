namespace PrototypePattern
{
    public class PrototypePattern
    {
        public class InstitutionalOrder
        {
            public string Asset { get; private set; }
            public int Quantity { get; private set; }
            public decimal Price { get; private set; }

            public decimal BrokerageFee { get; private set; }
            public string SettlementType { get; private set; }
            public string RiskProfile { get; private set; }

            public InstitutionalOrder(
                string asset,
                int quantity,
                decimal price,
                decimal brokerageFee,
                string settlementType,
                string riskProfile)
            {
                Asset = asset;
                Quantity = quantity;
                Price = price;
                BrokerageFee = brokerageFee;
                SettlementType = settlementType;
                RiskProfile = riskProfile;
            }

            public void UpdateOrder(int quantity, decimal price)
            {
                Quantity = quantity;
                Price = price;
            }

            public InstitutionalOrder Clone()
            {
                return new InstitutionalOrder(
                    Asset,
                    Quantity,
                    Price,
                    BrokerageFee,
                    SettlementType,
                    RiskProfile);
            }
        }

    }
}
