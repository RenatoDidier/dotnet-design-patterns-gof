namespace MementoPattern
{
    public class MementoPattern
    {
        public class RiskEngine
        {
            public decimal TotalExposure { get; private set; }
            public void ApplyTrade(decimal amount)
            {
                TotalExposure += amount;
                Console.WriteLine($"Exposição atual: {TotalExposure}");
            }
            public RiskMemento Save()
            {
                return new RiskMemento(TotalExposure);
            }
            public void Restore(RiskMemento memento)
            {
                TotalExposure = memento.TotalExposure;
                Console.WriteLine($"Estado restaurado. Exposição: {TotalExposure}");
            }
        }
        public class RiskMemento
        {
            public decimal TotalExposure { get; }
            public RiskMemento(decimal totalExposure)
            {
                TotalExposure = totalExposure;
            }
        }

        public class RiskSimulation
        {
            private readonly Stack<RiskMemento> _history = new();
            public void SaveState(RiskEngine engine)
            {
                _history.Push(engine.Save());
            }
            public void Undo(RiskEngine engine)
            {
                if (_history.Count > 0)
                {
                    var previous = _history.Pop();
                    engine.Restore(previous);
                }
            }
        }

        public static void Main()
        {
            var engine = new RiskEngine();
            var simulation = new RiskSimulation();

            engine.ApplyTrade(100_000m);
            simulation.SaveState(engine);

            engine.ApplyTrade(50_000m);
            simulation.SaveState(engine);

            engine.ApplyTrade(-200_000m);

            Console.WriteLine("Rollback...");
            simulation.Undo(engine);

            Console.WriteLine("Rollback novamente...");
            simulation.Undo(engine);
        }
        /*
            Exposição = 100k
            Snapshot salvo
            Exposição = 150k
            Snapshot salvo
            Exposição = -50k
            Undo → volta para 150k
            Undo → volta para 100k
         */
    }
}
