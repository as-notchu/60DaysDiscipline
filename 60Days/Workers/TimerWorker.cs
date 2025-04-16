using _60Days.Services;

namespace _60Days;

public class TimerWorker : BackgroundService
{
    private readonly TimerService _timerService;

    public TimerWorker(TimerService timerService)
    {
        _timerService = timerService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _timerService.Start();

        await Task.Delay(-1, stoppingToken);
    }
}