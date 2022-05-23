using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SocialNetwork.BLL.Services
{
    public class UserService
    {
        MessageService _messageService;
        IUserRepository _userRepository;
        IFriendRepository _friendRepository;

        public UserService()
        {
            _messageService = new MessageService();
            _userRepository = new UserRepository();
            _friendRepository = new FriendRepository();
        }

        public void Register(UserRegistrationData userRegistrationData)
        {
            if (string.IsNullOrEmpty(userRegistrationData.FirstName))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(userRegistrationData.LastName))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(userRegistrationData.Password))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(userRegistrationData.Email))
                throw new ArgumentNullException();

            if (userRegistrationData.Password.Length < 8)
                throw new ArgumentNullException();

            if (!new EmailAddressAttribute().IsValid(userRegistrationData.Email))
                throw new ArgumentNullException();

            if (_userRepository.FindByEmail(userRegistrationData.Email) != null)
                throw new ArgumentNullException();

            var userEntity = new UserEntity()
            {
                Firstname = userRegistrationData.FirstName,
                Lastname = userRegistrationData.LastName,
                Password = userRegistrationData.Password,
                Email = userRegistrationData.Email,
            };

            if (_userRepository.Create(userEntity) == 0)
                throw new Exception();
        }

        public User Authenticate(UserAuthenticationData userAuthenticationData)
        {
            var findUserEntity = _userRepository.FindByEmail(userAuthenticationData.Email);

            if (findUserEntity is null) throw new UserNotFoundException();

            if (findUserEntity.Password != userAuthenticationData.Password)
                throw new WrongPasswordException();

            return ConstructUserModel(findUserEntity);
        }

        public User FindByEmail(string email)
        {
            var findUserEntity = _userRepository.FindByEmail(email);

            if (findUserEntity is null) throw new UserNotFoundException();

            return ConstructUserModel(findUserEntity);
        }

        public User FindById(int id)
        {
            var findUserEntity = _userRepository.FindById(id);

            if (findUserEntity is null) throw new UserNotFoundException();

            return ConstructUserModel(findUserEntity);
        }

        public void Update(User user)
        {
            var updatableUserEntity = new UserEntity()
            {
                Id = user.Id,
                Firstname = user.FirstName,
                Lastname = user.LastName,
                Password = user.Password,
                Email = user.Email,
                Photo = user.Photo,
                Favorite_movie = user.FavoriteMovie,
                Favorite_book = user.FavoriteBook,
            };

            if (_userRepository.Update(updatableUserEntity) == 0)
                throw new Exception();
        }

        public IEnumerable<User> GetFriendsByUserId(int userId)
        {
            return _friendRepository.FindAllByUserId(userId)
               .Select(friend => FindById(friend.Friend_id));
        }

        public void AddFriend(AddFriendData friendData)
        {
            var friendUserEntity = FindByEmail(friendData.FriendEmail);

            if (friendUserEntity is null) throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                User_id = friendData.UserId,
                Friend_id = friendUserEntity.Id
            };

            if (_friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }

        public bool CheckIfFriendDoesNotExist(AddFriendData friendData, int userId)
        {
            var friendUserEntity = FindByEmail(friendData.FriendEmail);

            var friend = GetFriendsByUserId(userId).Where(user => user.Id == friendUserEntity.Id);

            return friend.Count() == 0;
        }

        private User ConstructUserModel(UserEntity userEntity)
        {
            var incomingMessages = _messageService.GetIncomingMessagesByUserId(userEntity.Id);

            var outgoingMessages = _messageService.GetOutcomingMessagesByUserId(userEntity.Id);

            var friends = GetFriendsByUserId(userEntity.Id);

            return new User(userEntity.Id,
                          userEntity.Firstname,
                          userEntity.Lastname,
                          userEntity.Password,
                          userEntity.Email,
                          userEntity.Photo,
                          userEntity.Favorite_movie,
                          userEntity.Favorite_book,
                          incomingMessages,
                          outgoingMessages,
                          friends);
        }
    }
}
