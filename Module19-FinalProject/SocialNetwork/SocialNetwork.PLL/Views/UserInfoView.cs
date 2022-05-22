using SocialNetwork.BLL.Models;
using System;

namespace SocialNetwork.PLL.Views
{
    public class UserInfoView
    {
        public void Show(User user)
        {
            Console.WriteLine("Profile information:");
            Console.WriteLine($"Id: {user.Id}");
            Console.WriteLine($"Name: {user.FirstName}");
            Console.WriteLine($"Lastname: {user.LastName}");
            Console.WriteLine($"Password: {user.Password}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine($"Link to your photo: {user.Photo}");
            Console.WriteLine($"My favorite movie: {user.FavoriteMovie}");
            Console.WriteLine($"My favorite book: {user.FavoriteBook}");
        }
    }
}
