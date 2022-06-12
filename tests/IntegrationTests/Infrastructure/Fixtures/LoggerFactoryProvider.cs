using Microsoft.Extensions.Logging;

namespace IntegrationTests.Infrastructure.Fixtures
{
    public class LoggerFactoryProvider
    {
        public static readonly ILoggerFactory LoggerFactoryInstance = LoggerFactory.Create(builder =>
        {
            builder.AddFilter("Ardalis.Specification.EF", LogLevel.Debug);
            builder.AddConsole();
        });
    }
}
