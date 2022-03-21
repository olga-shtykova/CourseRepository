using SkillFactoryBot.Commands;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace SkillFactoryBot
{
    public class Messenger
    {
        private ITelegramBotClient botClient;
        private CommandParser parser;

        public Messenger(ITelegramBotClient botClient)
        {
            this.botClient = botClient;
            parser = new CommandParser();

            RegisterCommands();
        }

        public async Task MakeAnswer(Conversation chat, CancellationToken cancellationToken)
        {
            var lastmessage = chat.GetLastMessage();

            if (chat.IsAddingInProcess)
            {
                parser.NextStage(lastmessage, chat);

                return;
            }

            if (parser.IsMessageCommand(lastmessage))
            {
                await ExecCommand(chat, lastmessage, cancellationToken);
            }
            else
            {
                var text = "Такой команды не существует.";
                await SendText(chat, text, cancellationToken);
            }
        }

        public async Task ExecCommand(Conversation chat, string command, CancellationToken cancellationToken)
        {
            if (parser.IsTextCommand(command))
            {
                var text = parser.GetMessageText(command, chat);

                await SendText(chat, text, cancellationToken);
            }

            if (parser.IsAddWordCommand(command))
            {
                chat.IsAddingInProcess = true;
                parser.StartAddingItemsToDictionary(command, chat);
            }

            if (parser.IsDeleteWordCommand(command))
            {
                parser.StartDeleteWord(command, chat);
            }

            if (parser.IsDictionaryCommand(command))
            {
                parser.StartDisplayDictionary(command, chat);
            }
        }

        private void RegisterCommands()
        {            
            parser.AddCommand(new AddWordCommand(botClient));
            parser.AddCommand(new DeleteWordCommand());
            parser.AddCommand(new DictionaryCommand(botClient));
        }

        private async Task SendText(Conversation chat, string text, CancellationToken cancellationToken)
        {
            await botClient.SendTextMessageAsync(
                  chatId: chat.GetId(),
                  text: text,
                  cancellationToken: cancellationToken);
        }
    }
}
