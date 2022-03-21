using SkillFactoryBot.Commands.Interfaces;
using System.Threading.Tasks;
using Telegram.Bot;

namespace SkillFactoryBot.Commands
{
    public class DictionaryCommand : BaseCommand
    {
        private ITelegramBotClient botClient;

        public DictionaryCommand(ITelegramBotClient botClient)
        {
            this.botClient = botClient;
            CommandText = "/dictionary";            
        }       

        public async void DisplayDictionary(Conversation chat)
        {
            string text = "";

            foreach (var words in chat.dictionary)
            {
                text += $"{words.Key} - {words.Value.English}" + "\n";
            }

            await SendCommandText(text, chat.GetId());
        }

        private async Task SendCommandText(string text, long chat)
        {
            await botClient.SendTextMessageAsync(chatId: chat, text: text);
        }
    }
}
