using _60Days.Options;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace _60Days.Services;

public class MessageService
{
    private readonly TelegramBotClient _botClient;
    
    private readonly TelegramOptions _telegramOptions;

    public MessageService(TelegramBotClient botClient, IOptions<TelegramOptions> telegramOptions)
    {
        _botClient = botClient;
        _telegramOptions = telegramOptions.Value;
    }


    public async Task SendMessage(long id, string message)
    {
        await _botClient.SendMessage(chatId: _telegramOptions.AllowedUser, text: message);
    }
    public async Task SendMessage(long id, string message, KeyboardButton button)
    {
        
    }
}