using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;

namespace SocialNetwork.PLL.Views
{
    public class AuthenticationView
    {
        UserService _userService;

        public AuthenticationView(UserService userService)
        {
            _userService = userService;
        }

        public void Show()
        {
            var authenticationData = new UserAuthenticationData();

            Console.WriteLine("Insert email:");
            authenticationData.Email = Console.ReadLine();

            Console.WriteLine("Insert password:");
            authenticationData.Password = Console.ReadLine();

            try
            {
                var user = _userService.Authenticate(authenticationData);

                SuccessMessage.Show("You successfully logged into Social Network!");
                SuccessMessage.Show($"Welcome, {user.FirstName}.");

                Program._userMenuView.Show(user);
            }

            catch (WrongPasswordException)
            {
                AlertMessage.Show("Incorrect password!");
            }

            catch (UserNotFoundException)
            {
                AlertMessage.Show("User was not found!");
            }
        }
    }
}
