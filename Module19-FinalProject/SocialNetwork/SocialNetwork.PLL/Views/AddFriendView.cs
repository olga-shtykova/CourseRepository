using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;

namespace SocialNetwork.PLL.Views
{
    public class AddFriendView
    {
        UserService _userService;

        public AddFriendView(UserService userService)
        {
            _userService = userService;
        }

        public void Show(User user)
        {
            try
            {
                Console.Write("Insert friend's email: ");

                var friendData = new AddFriendData
                {
                    FriendEmail = Console.ReadLine(),
                    UserId = user.Id
                };

                if (_userService.CheckIfFriendDoesNotExist(friendData, user.Id))
                {
                    _userService.AddFriend(friendData);

                    SuccessMessage.Show("A friend was successfully added!");
                }
                else
                {
                    AlertMessage.Show("This user is already your friend.");
                }               
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
                AlertMessage.Show($"There was an error when adding a friend: {ex.Message}");
            }
        }
    }
}
