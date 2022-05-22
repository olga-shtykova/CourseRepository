using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.PLL.Views
{
    public class UserOutcomingMessageView
    {
        public void Show(IEnumerable<Message> outcomingMessages)
        {
            Console.WriteLine("Outgoing messages:");

            if (outcomingMessages.Count() == 0)
            {
                Console.WriteLine("There are no outgoing messages.");
                return;
            }

            outcomingMessages.ToList().ForEach(message =>
            {
                Console.WriteLine($"To: {message.RecipientEmail}.\nMessages: {message.Content}");
            });
        }
    }
}
