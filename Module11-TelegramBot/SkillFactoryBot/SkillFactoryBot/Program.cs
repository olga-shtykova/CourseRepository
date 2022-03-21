using System;

namespace SkillFactoryBot
{
    // bot name: SkillFactoryBot
    // userName: SkillFactorySkyBot
    // t.me/SkillFactorySkyBot    
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new BotWorker();

            bot.Initialize();
            bot.Start();

            Console.WriteLine("Напишите stop для прекращения работы");
            string key = Console.ReadLine();
            if (key.ToLower() == "stop")
            {
                bot.Stop();
            }
        }
    }
}
