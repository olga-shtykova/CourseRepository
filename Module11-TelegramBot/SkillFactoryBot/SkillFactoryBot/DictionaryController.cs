using SkillFactoryBot.Models;
using System.Collections.Generic;

namespace SkillFactoryBot
{
    public class DictionaryController
    {
        private Dictionary<long, DictionaryItem> Dictionary;

        public DictionaryController()
        {
            Dictionary = new Dictionary<long, DictionaryItem>();
        }

        public void AddFirstItem(Conversation chat)
        {
            Dictionary.Add(chat.GetId(), DictionaryItem.RussianWord);
        }

        public void NextStage(Conversation chat)
        {
            var currentstate = Dictionary[chat.GetId()];
            Dictionary[chat.GetId()] = currentstate + 1;

            if (Dictionary[chat.GetId()] == DictionaryItem.Finish)
            {
                chat.IsAddingInProcess = false;
                Dictionary.Remove(chat.GetId());
            }
        }

        public DictionaryItem GetStage(Conversation chat)
        {
            return Dictionary[chat.GetId()];
        }
    }
}
