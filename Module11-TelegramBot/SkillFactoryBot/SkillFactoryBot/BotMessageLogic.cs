using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SkillFactoryBot
{
    public class BotMessageLogic
    {
        private ITelegramBotClient botClient;
        private Messenger messenger;
        private Dictionary<long, Conversation> chatList;

        public BotMessageLogic(ITelegramBotClient botClient)
        {
            this.botClient = botClient;
            messenger = new Messenger(botClient);
            chatList = new Dictionary<long, Conversation>();
        }

        public async Task Response(ITelegramBotClient botClient, Update update,
            CancellationToken cancellationToken)
        {
            var chatId = update.Message.Chat.Id;

            if (!chatList.ContainsKey(chatId))
            {
                var newchat = new Conversation(update.Message.Chat);

                chatList.Add(chatId, newchat);
            }

            var chat = chatList[chatId];

            chat.AddMessage(update.Message);

            await SendTextMessage(chat, cancellationToken);
        }

        private async Task SendTextMessage(Conversation chat, CancellationToken cancellationToken)
        {
            await messenger.MakeAnswer(chat, cancellationToken);
        }
    }
}
