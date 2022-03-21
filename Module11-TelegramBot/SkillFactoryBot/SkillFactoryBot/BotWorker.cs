using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace SkillFactoryBot
{
    public class BotWorker
    {
        private ITelegramBotClient botClient;
        private BotMessageLogic messageLogic;
        CancellationTokenSource cts = new CancellationTokenSource();

        public void Initialize()
        {
            botClient = new TelegramBotClient(BotCredentials.BotToken);
            messageLogic = new BotMessageLogic(botClient);
        }

        public void Start()
        {
            var me = botClient.GetMeAsync().Result;
            Console.WriteLine($"Hello! I'm {me.Username} and I'm your bot!");

            // Bot start receiveing, does not block the caller thread.
            // Receiving is done on the ThreadPool
            var receiverOptions = new ReceiverOptions
            {
                // Receive all update types
                AllowedUpdates = { },
            };

            botClient.StartReceiving(HandleUpdateAsync, HandleErrorAsync,
                    receiverOptions, cts.Token);
        }

        public void Stop()
        {
            cts.Cancel();
        }

        // Answer of the bot to the input
        private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update,
            CancellationToken cancellationToken)
        {
            // Only process message updates: https://core.telegram.org/bots/api#message
            if (update.Type != UpdateType.Message) return;

            // Only process text messages
            if (update.Message.Type != MessageType.Text) return;

            // In case of a bug
            if (update.Message.Text != null)
            {
                await messageLogic.Response(botClient, update, cancellationToken);
            }
        }

        private Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception,
            CancellationToken cancellationToken)
        {
            Console.WriteLine($"Telegram API Error: {exception.Message}");
            return Task.CompletedTask;
        }
    }
}
