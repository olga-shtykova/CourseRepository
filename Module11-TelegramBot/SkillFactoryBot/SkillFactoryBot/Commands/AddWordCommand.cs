using SkillFactoryBot.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;

namespace SkillFactoryBot.Commands
{
    public class AddWordCommand : BaseCommand
    {
        private ITelegramBotClient botClient;
        private Dictionary<long, Word> Buffer;

        public AddWordCommand(ITelegramBotClient botClient)
        {
            this.botClient = botClient;
            CommandText = "/addword";  
            Buffer = new Dictionary<long, Word>();
        }

        public async void StartProcessAsync(Conversation chat)
        {
            Buffer.Add(chat.GetId(), new Word());

            var text = "Введите русское значение слова";

            await SendCommandText(text, chat.GetId());
        }

        public async void DoForStageAsync(DictionaryItem dictionaryItem, Conversation chat, string message)
        {
            var word = Buffer[chat.GetId()];
            var text = "";

            switch (dictionaryItem)
            {
                case DictionaryItem.RussianWord:
                    word.Russian = message;                    

                    text = "Введите английское значение слова";
                    break;

                case DictionaryItem.EnglishWord:
                    word.English = message;

                    text = "Введите тематику";
                    break;

                case DictionaryItem.Theme:
                    word.Theme = message;                    

                    if (chat.dictionary.ContainsKey(word.Russian))
                    {
                        text = $"Слово {word.Russian} уже есть в словаре.";
                        Buffer.Remove(chat.GetId());
                        break;
                    }

                    chat.dictionary.Add(word.Russian, word);
                    text = $"Успешно! Слово {word.English} добавлено в словарь.";

                    Buffer.Remove(chat.GetId());
                    break;
            }

            await SendCommandText(text, chat.GetId());
        }

        private async Task SendCommandText(string text, long chat)
        {
            await botClient.SendTextMessageAsync(chatId: chat, text: text);
        }
    }
}
