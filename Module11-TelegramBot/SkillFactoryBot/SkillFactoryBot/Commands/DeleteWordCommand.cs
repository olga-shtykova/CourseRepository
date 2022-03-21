using SkillFactoryBot.Commands.Interfaces;

namespace SkillFactoryBot.Commands
{
    public class DeleteWordCommand : ChatTextCommandOption, IChatTextCommandWithAction
    {
        public DeleteWordCommand()
        {
            CommandText = "/deleteword";
        }

        public void DoAction(Conversation chat)
        {
            var message = chat.GetLastMessage();

            var text = ClearMessageFromCommand(message);

            if (chat.dictionary.ContainsKey(text))
            {
                chat.dictionary.Remove(text);
            }

            return;
        }

        public string ReturnText()
        {
            return "Слово успешно удалено!";
        }
    }
}
