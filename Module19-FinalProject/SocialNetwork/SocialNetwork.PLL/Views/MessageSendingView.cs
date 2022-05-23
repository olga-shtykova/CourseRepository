using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;

namespace SocialNetwork.PLL.Views
{
    public class MessageSendingView
    {
        UserService _userService;
        MessageService _messageService;

        public MessageSendingView(MessageService messageService, UserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }

        public void Show(User user)
        {
            Console.Write("Insert recipient's email: ");

            var messageSendingData = new MessageSendingData
            {
                RecipientEmail = Console.ReadLine(),
                SenderId = user.Id,
            };

            Console.WriteLine("Write a message (no longer than 500 symbols).");
            messageSendingData.Content = Console.ReadLine();

            try
            {
                _messageService.SendMessage(messageSendingData);

                SuccessMessage.Show("Message has been sent!");

                user = _userService.FindById(user.Id);
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("There is no such user!");
            }
            catch (ArgumentNullException)
            {
                AlertMessage.Show("Insert correct value!");
            }
            catch (Exception ex)
            {
                AlertMessage.Show($"There was an error when sending a message: {ex.Message}");
            }
        }
    }
}
