using Microsoft.Extensions.Logging;
using NLog;
namespace DemoWebApp.Application.Common.Logging
{
    public class LogManager
    {
        private readonly ILogger<LogManager> _logger;

        public LogManager(ILogger<LogManager> logger)
        {
            _logger = logger;
        }

        public void WriteToLogDebug(EventId eventId, string message, params object?[] args)
        {
            _logger.LogDebug(eventId, message, args);
        }
    }
}
