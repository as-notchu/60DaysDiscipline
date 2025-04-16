using _60Days;
using _60Days.Options;
using _60Days.Services;
using Serilog;
using Telegram.Bot;

var builder = Host.CreateApplicationBuilder(args);
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()  
    .WriteTo.File(
        $"logs/log-{DateTime.UtcNow:yyyy-MM-dd}.txt",  
        rollingInterval: RollingInterval.Day,  
        retainedFileCountLimit: 14
    )
    .CreateLogger();

builder.Logging.AddSerilog(Log.Logger);
builder.Services.AddHostedService<TelegramWorker>();
builder.Services.AddHostedService<TimerWorker>();
builder.Services.AddSingleton<UpdateService>();
builder.Services.AddTransient<HttpService>();
builder.Services.Configure<TelegramOptions>(builder.Configuration.GetSection(nameof(TelegramOptions)));
builder.Services.Configure<TimeOptions>(builder.Configuration.GetSection(nameof(TimeOptions)));

builder.Services.AddSingleton(services =>
{
    var options = builder.Configuration.GetSection(nameof(TelegramOptions)).Get<TelegramOptions>();
    if (options == null || string.IsNullOrEmpty(options.Token))
    {
        throw new Exception("Telegram bot token not configured");
    }
    return new TelegramBotClient(new TelegramBotClientOptions(options.Token));
});

var host = builder.Build();
host.Run();