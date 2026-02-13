namespace SingletonPattern
{
    public class SingletonPattern
    {
        public interface IMarketCalendar
        {
            bool IsBusinessDay(DateTime date);
            bool IsMarketOpen(DateTime dateTime);
        }

        public class B3MarketCalendar : IMarketCalendar
        {
            private readonly HashSet<DateTime> _holidays;

            public B3MarketCalendar()
            {
                _holidays = new HashSet<DateTime>
        {
            new DateTime(2026, 1, 1),
            new DateTime(2026, 12, 25)
        };
            }

            public bool IsBusinessDay(DateTime date)
            {
                return date.DayOfWeek != DayOfWeek.Saturday
                    && date.DayOfWeek != DayOfWeek.Sunday
                    && !_holidays.Contains(date.Date);
            }

            public bool IsMarketOpen(DateTime dateTime)
            {
                if (!IsBusinessDay(dateTime.Date))
                    return false;

                var open = new TimeSpan(10, 0, 0);
                var close = new TimeSpan(17, 0, 0);

                return dateTime.TimeOfDay >= open
                    && dateTime.TimeOfDay <= close;
            }
        }

        public class TradingService
        {
            private readonly IMarketCalendar _calendar;
            public TradingService(IMarketCalendar calendar)
            {
                _calendar = calendar;
            }
            public void ExecuteOrder(string asset)
            {
                if (!_calendar.IsMarketOpen(DateTime.Now))
                    throw new InvalidOperationException("Mercado fechado.");

                Console.WriteLine($"Executando ordem para {asset}");
            }
        }


    }
}
