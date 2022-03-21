using SkillFactoryBot.Models;
using System.Collections.Generic;
using Telegram.Bot.Types;

namespace SkillFactoryBot
{
    public class Conversation
    {
        private Chat telegramChat;
        private List<Message> telegramMessages;
        public Dictionary<string, Word> dictionary;
        public bool IsAddingInProcess;

        public Conversation(Chat chat)
        {
            telegramChat = chat;
            telegramMessages = new List<Message>();
            dictionary = new Dictionary<string, Word>();
        }

        public void AddMessage(Message message)
        {
            telegramMessages.Add(message);
        }

        public List<string> GetTextMessages()
        {
            var textMessages = new List<string>();

            foreach (var message in telegramMessages)
            {
                if (message.Text != null)
                {
                    textMessages.Add(message.Text);
                }
            }

            return textMessages;
        }

        public long GetId() => telegramChat.Id;

        public string GetLastMessage() => telegramMessages[telegramMessages.Count - 1].Text;
    }
}
