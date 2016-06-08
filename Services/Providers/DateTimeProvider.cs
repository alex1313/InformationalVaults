namespace Services.Providers
{
    using System;

    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;
        public TimeSpan PresentTime => DateTime.Now.TimeOfDay;
    }
}