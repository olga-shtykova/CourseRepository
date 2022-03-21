namespace SkillFactoryBot.Commands.Interfaces
{
    public interface IChatTextCommandWithAction : IChatTextCommand
    {
        bool DoAction(Conversation chat);
    }
}
