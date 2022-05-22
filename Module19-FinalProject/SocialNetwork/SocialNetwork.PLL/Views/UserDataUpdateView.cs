using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;

namespace SocialNetwork.PLL.Views
{
    public class UserDataUpdateView
    {
        UserService _userService;
        public UserDataUpdateView(UserService userService)
        {
            _userService = userService;
        }

        public void Show(User user)
        {
            Console.Write("Firstname: ");
            user.FirstName = Console.ReadLine();

            Console.Write("Lastname: ");
            user.LastName = Console.ReadLine();

            Console.Write("Link to your photo: ");
            user.Photo = Console.ReadLine();

            Console.Write("Favorite movie: ");
            user.FavoriteMovie = Console.ReadLine();

            Console.Write("Favorite book: ");
            user.FavoriteBook = Console.ReadLine();

            _userService.Update(user);

            SuccessMessage.Show("Your profile has been successfully updated!");
        }
    }
}
