namespace Services.Providers
{
    using System;

    public interface IDateTimeProvider
    {
        DateTime Now { get; }
        TimeSpan PresentTime { get; }
    }
}