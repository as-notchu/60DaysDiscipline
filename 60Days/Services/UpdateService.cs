using _60Days.Options;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace _60Days.Services;

public class UpdateService
{
    private readonly TelegramBotClient  _telegramBotClient;
    
    private readonly IOptions<TelegramOptions> _telegramOptions;

    public UpdateService(TelegramBotClient telegramBotClient, IOptions<TelegramOptions> telegramOptions)
    {
        _telegramBotClient = telegramBotClient;
        _telegramOptions = telegramOptions;
    }


    public async Task StartBot()
    {
        _telegramBotClient.StartReceiving(updateHandler: UpdateHandler, errorHandler: ErrorHandler);
    }

    private Task ErrorHandler(ITelegramBotClient arg1, Exception arg2, HandleErrorSource arg3, CancellationToken arg4)
    {
        return Task.CompletedTask;
    }

    private Task UpdateHandler(ITelegramBotClient arg1, Update arg2, CancellationToken arg3)
    {
        switch (arg2)
        {
            case { Message: {} message }:
                Console.WriteLine(message.Text);
                break;
        }
        return Task.CompletedTask;
    }

    private async Task OnTextMessage(Message message)
    {
       if (!ValidateAccess(message.From.Id)) return;
       
       
    }

    private bool ValidateAccess(long id)
    {
        return id == _telegramOptions.Value.AllowedUser;
    }
}