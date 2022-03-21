using SkillFactoryBot.Commands.Interfaces;

namespace SkillFactoryBot.Commands
{
    public class SayHiCommand : BaseCommand, IChatTextCommand
    {
        public SayHiCommand()
        {
            CommandText = "/sayhi";
        }

        public string ReturnText()
        {
            return "привет";
        }
    }
}
