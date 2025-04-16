using _60Days.Services;

namespace _60Days;

public class TelegramWorker : BackgroundService
{
    private readonly ILogger<TelegramWorker> _logger;
    
    private readonly UpdateService _updateService;

    public TelegramWorker(ILogger<TelegramWorker> logger, UpdateService updateService)
    {
        _logger = logger;
        _updateService = updateService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Starting Telegram bot...");
        await _updateService.StartBot(); 

        await Task.Delay(-1, stoppingToken);
    }
}