using SkillFactoryBot.Commands;
using SkillFactoryBot.Commands.Interfaces;
using System.Collections.Generic;

namespace SkillFactoryBot
{
    public class CommandParser
    {
        private List<IChatCommand> Command;

        private DictionaryController addingController;

        public CommandParser()
        {
            Command = new List<IChatCommand>();
            addingController = new DictionaryController();
        }

        public void AddCommand(IChatCommand chatCommand)
        {
            Command.Add(chatCommand);
        }

        public bool IsMessageCommand(string message)
        {
            return Command.Exists(x => x.CheckMessage(message));
        }

        public bool IsTextCommand(string message)
        {
            var command = Command.Find(x => x.CheckMessage(message));

            return command is IChatTextCommand;
        }

        public string GetMessageText(string message, Conversation chat)
        {
            var command = Command.Find(x => x.CheckMessage(message)) as IChatTextCommand;

            if (command is IChatTextCommandWithAction)
            {
                if (!(command as IChatTextCommandWithAction).DoAction(chat))
                {
                    return "Ошибка выполнения команды!";
                };
            }

            return command.ReturnText();
        }

        public bool IsAddWordCommand(string message)
        {
            var command = Command.Find(x => x.CheckMessage(message));

            return command is AddWordCommand;
        }

        public void StartAddingItemsToDictionary(string message, Conversation chat)
        {
            var command = Command.Find(x => x.CheckMessage(message)) as AddWordCommand;

            addingController.AddFirstItem(chat);
            command.StartProcessAsync(chat);
        }

        public void NextStage(string message, Conversation chat)
        {
            var command = Command.Find(x => x is AddWordCommand) as AddWordCommand;
            var thisChat = chat.GetId();

            command.DoForStageAsync(addingController.GetStage(chat), chat, message);

            addingController.NextStage(chat);
        }

        public bool IsDeleteWordCommand(string message)
        {
            var command = Command.Find(x => x.CheckMessage(message));

            return command is DeleteWordCommand;
        }

        public void StartDeleteWord(string message, Conversation chat)
        {
            var command = Command.Find(x => x.CheckMessage(message)) as DeleteWordCommand;
            command.DoAction(chat);
        }

        public bool IsDictionaryCommand(string message)
        {
            var command = Command.Find(x => x.CheckMessage(message));

            return command is DictionaryCommand;
        }

        public void StartDisplayDictionary(string message, Conversation chat)
        {
            var command = Command.Find(x => x.CheckMessage(message)) as DictionaryCommand;
            command.DisplayDictionary(chat);
        }
    }
}
