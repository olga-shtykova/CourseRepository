using Moq;
using NUnit.Framework;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories.Interfaces;
using System;

namespace SocialNetwork.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        [TestCase("", "Correro", "tanya@test.com", "12345678")]
        [TestCase("Tanya", "", "tanya@test.com", "12345678")]
        [TestCase("Tanya", "Correro", "", "12345678")]
        [TestCase("Tanya", "Correro", "tanya@test.com", "12345")]
        [TestCase("Tanya", "Correro", "tanya_test.com", "12345678")]
        [TestCase("Tanya", "Correro", "tanya@test.com", "12345678")]
        [Test]
        public void WhenDataIsNullOrEmptyRegisterMustThrowArgumentNullException(
            string firstName, string lastName, string email, string password)
        {
            // Arrrange
            var userRegistrationData = new UserRegistrationData
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
            };

            var userEntity = new UserEntity
            {
                Firstname = "Tanya",
                Lastname = "Sokolova",
                Email = "tanya@test.com",
                Password = "10010034",
            };

            var userRepository = new Mock<IUserRepository>().Setup(rep => rep.FindByEmail(email)).Returns(userEntity);
            var userService = new UserService();

            // Assert
            Assert.Throws<ArgumentNullException>(() => userService.Register(userRegistrationData));
        }
    }
}
