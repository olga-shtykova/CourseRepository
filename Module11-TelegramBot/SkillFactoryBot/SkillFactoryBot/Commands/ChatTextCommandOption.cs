namespace SkillFactoryBot.Commands
{
    public abstract class ChatTextCommandOption : BaseCommand
    {
        public override bool CheckMessage(string message)
        {
            return message.StartsWith(CommandText);
        }

        public string ClearMessageFromCommand(string message)
        {
            return message.Substring(CommandText.Length + 1);
        }
    }
}
