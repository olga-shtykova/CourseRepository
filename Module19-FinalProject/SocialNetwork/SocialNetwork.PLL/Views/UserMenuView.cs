using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;
using System.Linq;

namespace SocialNetwork.PLL.Views
{
    public class UserMenuView
    {
        UserService _userService;
        public UserMenuView(UserService userService)
        {
            _userService = userService;
        }

        public void Show(User user)
        {
            while (true)
            {
                Console.WriteLine($"Incoming messages: {user.IncomingMessages.Count()}");
                Console.WriteLine($"Outgoing messages: {user.OutgoingMessages.Count()}");
                Console.WriteLine($"Friends: {user.Friends.Count()}");
                Console.WriteLine("To see your profile (press 1)");
                Console.WriteLine("To edit your profile (press 2)");
                Console.WriteLine("To add a user to friends (press 3)");
                Console.WriteLine("To send a message (press 4)");
                Console.WriteLine("To see incoming messages (press 5)");
                Console.WriteLine("To see outgoing messages (press 6)");
                Console.WriteLine("To logout (press 7)");

                string keyValue = Console.ReadLine();

                // Logout
                if (keyValue == "7") break;

                switch (keyValue)
                {
                    case "1":
                        {
                            Program._userInfoView.Show(user);
                            break;
                        }
                    case "2":
                        {
                            Program._userDataUpdateView.Show(user);
                            break;
                        }

                    case "3":
                        {
                            Program._addFriendView.Show(user);
                            break;
                        }

                    case "4":
                        {
                            Program._messageSendingView.Show(user);
                            break;
                        }

                    case "5":
                        {

                            Program._userIncomingMessageView.Show(user.IncomingMessages);
                            break;
                        }

                    case "6":
                        {
                            Program._userOutcomingMessageView.Show(user.OutgoingMessages);
                            break;
                        }
                }
            }
        }
    }
}
