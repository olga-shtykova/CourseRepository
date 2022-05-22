using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;

namespace SocialNetwork.PLL.Views
{
    public class RegistrationView
    {
        UserService _userService;

        public RegistrationView(UserService userService)
        {
            _userService = userService;
        }

        public void Show()
        {
            var userRegistrationData = new UserRegistrationData();

            Console.WriteLine("To register please insert:");
            Console.Write("Your firstname: ");
            userRegistrationData.FirstName = Console.ReadLine();

            Console.Write("Your lastname:");
            userRegistrationData.LastName = Console.ReadLine();

            Console.Write("Your password:");
            userRegistrationData.Password = Console.ReadLine();

            Console.Write("Your email:");
            userRegistrationData.Email = Console.ReadLine();

            try
            {
                _userService.Register(userRegistrationData);

                SuccessMessage.Show("Registration was successful. Now you can login using your credentials.");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Please insert correct value.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was an error during the registration: {ex.Message}");
            }
        }
    }
}
