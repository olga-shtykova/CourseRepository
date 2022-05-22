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
            var messageSendingData = new MessageSendingData();

            Console.WriteLine();
            Console.Write("Insert recipient's email: ");
            messageSendingData.RecipientEmail = Console.ReadLine();

            Console.WriteLine("Write a message (must be no longer than 500 symbols): ");
            messageSendingData.Content = Console.ReadLine();

            messageSendingData.SenderId = user.Id;

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
                AlertMessage.Show($"There was an error during the registration: {ex.Message}");
            }
        }
    }
}
