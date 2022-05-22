using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.PLL.Views
{
    public class UserIncomingMessageView
    {
        public void Show(IEnumerable<Message> incomingMessages)
        {
            Console.WriteLine("Incoming messages:");

            if (incomingMessages.Count() == 0)
            {
                Console.WriteLine("There are no incoming messages.");
                return;
            }

            incomingMessages.ToList().ForEach(message =>
            {
                Console.WriteLine($"From: {message.SenderEmail}.\nMessage: {message.Content}");
            });
        }
    }
}
