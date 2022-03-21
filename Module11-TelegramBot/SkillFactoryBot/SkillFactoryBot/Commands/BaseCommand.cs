using SkillFactoryBot.Commands.Interfaces;

namespace SkillFactoryBot.Commands
{
    public abstract class BaseCommand : IChatCommand
    {
        public string CommandText;

        public virtual bool CheckMessage(string message)
        {
            return CommandText == message;
        }
    }
}
