using System.Web.Http.ExceptionHandling;
using Serilog;
using Serilog.Core;

namespace CityWeather.Api
{
    public class SerilogExceptionLogger : ExceptionLogger
    {
        private readonly Logger _logger;

        public SerilogExceptionLogger()
        {
            _logger = new LoggerConfiguration()
                .WriteTo.RollingFile("log-{Date}.txt")
                .CreateLogger();
        }
        public override void Log(ExceptionLoggerContext context)
        {
            _logger.Error(context.Exception.Message, "An unhandled exception occured."); 
        }
    }
}