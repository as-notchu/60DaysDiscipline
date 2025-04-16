using _60Days.Options;
using Microsoft.Extensions.Options;

namespace _60Days.Services;

public class TimerService
{
    private Timer _timer;
    private readonly ILogger<TimerService> _logger;
    
    private readonly MessageService _messageService;

    private readonly TimeOptions _timeOptions;

    public TimerService(ILogger<TimerService> logger, IOptions<TimeOptions> timeOptions, MessageService messageService)
    {
        _logger = logger;
        _messageService = messageService;
        _timeOptions = timeOptions.Value;
    }


    public async Task Start()
    {
        ValidateActions();
    }

    private void ValidateActions()
    {
        var currentTime = DateTime.Now;
        switch (currentTime.TimeOfDay)
        {
            case var time when time + TimeSpan.FromMinutes(15) < _timeOptions.Morning:
                var timeLeft = _timeOptions.Morning - time + TimeSpan.FromMinutes(15);
                _timer = new Timer(CallBack,string.Empty, timeLeft, Timeout.InfiniteTimeSpan);
                break;
        }
    }

    private void CallBack(object? state)
    {
        if (state is string msg)
        {
            _ = SendMessage(msg);
        }
    }

    private async Task SendMessage(string message)
    {
        
    }

}