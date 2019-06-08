
using HomeDev.Core.App.Config;
using HomeDev.Core.App.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HomeDev.Core.App
{
    public class ConsoleApp : IConsoleApp
    {
        private ILogger<ConsoleApp> _logger;
        private AppSettings _settings;
        public ConsoleApp(
            ILogger<ConsoleApp> logger,
            IOptions<AppSettings> config
        )
        {
            _logger = logger;
            _settings = config.Value;
        }

        

        public void Run() 
        {
            _logger.LogInformation("Hello Logger!!");
            _logger.LogInformation($"{_settings.Title}");
            _logger.LogWarning($"Appliction Configuration Setting - Pause On Finish : {_settings.PauseOnFinish}");
        }
    }
}