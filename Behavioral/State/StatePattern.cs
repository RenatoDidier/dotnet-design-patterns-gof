namespace StatePattern
{
    public class StatePattern
    {
        public class Order
        {
            private IOrderState _state;

            public string Asset { get; }
            public int Quantity { get; }

            public Order(string asset, int quantity)
            {
                Asset = asset;
                Quantity = quantity;
                _state = new CreatedState();
            }

            public void SetState(IOrderState state)
            {
                _state = state;
            }

            public void Validate() => _state.Validate(this);
            public void SendToExchange() => _state.SendToExchange(this);
            public void Execute() => _state.Execute(this);
            public void Cancel() => _state.Cancel(this);
        }

        public interface IOrderState
        {
            void Validate(Order order);
            void SendToExchange(Order order);
            void Execute(Order order);
            void Cancel(Order order);
        }
        public class CreatedState : IOrderState
        {
            public void Validate(Order order)
            {
                Console.WriteLine("Ordem validada.");
                order.SetState(new ValidatedState());
            }

            public void SendToExchange(Order order)
                => throw new InvalidOperationException("Ordem precisa ser validada primeiro.");

            public void Execute(Order order)
                => throw new InvalidOperationException("Ordem não enviada.");

            public void Cancel(Order order)
            {
                Console.WriteLine("Ordem cancelada.");
                order.SetState(new CancelledState());
            }
        }
        public class ValidatedState : IOrderState
        {
            public void Validate(Order order)
                => throw new InvalidOperationException("Já validada.");

            public void SendToExchange(Order order)
            {
                Console.WriteLine("Ordem enviada para bolsa.");
                order.SetState(new SentState());
            }

            public void Execute(Order order)
                => throw new InvalidOperationException("Ainda não enviada.");

            public void Cancel(Order order)
            {
                Console.WriteLine("Ordem cancelada.");
                order.SetState(new CancelledState());
            }
        }
        public class CancelledState : IOrderState
        {
            public void Validate(Order order)
                => throw new InvalidOperationException("Ordem cancelada não pode ser validada.");

            public void SendToExchange(Order order)
                => throw new InvalidOperationException("Ordem cancelada não pode ser enviada para bolsa.");

            public void Execute(Order order)
                => throw new InvalidOperationException("Ordem cancelada não pode ser executada.");

            public void Cancel(Order order)
                => throw new InvalidOperationException("Ordem já está cancelada.");
        }

        public class SentState : IOrderState
        {
            public void Validate(Order order)
                => throw new InvalidOperationException("Já enviada.");

            public void SendToExchange(Order order)
                => throw new InvalidOperationException("Já enviada.");

            public void Execute(Order order)
            {
                Console.WriteLine("Ordem executada.");
                order.SetState(new ExecutedState());
            }

            public void Cancel(Order order)
                => throw new InvalidOperationException("Não pode cancelar após envio.");
        }
        public class ExecutedState : IOrderState
        {
            public void Validate(Order order)
                => throw new InvalidOperationException("Ordem finalizada.");

            public void SendToExchange(Order order)
                => throw new InvalidOperationException("Ordem finalizada.");

            public void Execute(Order order)
                => throw new InvalidOperationException("Já executada.");

            public void Cancel(Order order)
                => throw new InvalidOperationException("Não pode cancelar ordem executada.");
        }




    }
}
