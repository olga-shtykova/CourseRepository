using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.BLL.Services
{
    public class MessageService
    {
        IMessageRepository _messageRepository;
        IUserRepository _userRepository;

        public MessageService()
        {
            _messageRepository = new MessageRepository();
            _userRepository = new UserRepository();            
        }

        public IEnumerable<Message> GetIncomingMessagesByUserId(int recipientId)
        {
            var messages = new List<Message>();

            _messageRepository.FindByRecipientId(recipientId).ToList().ForEach(m =>
            {
                var senderUserEntity = _userRepository.FindById(m.Sender_id);
                var recipientUserEntity = _userRepository.FindById(m.Recipient_id);

                messages.Add(new Message(m.Id, m.Content, senderUserEntity.Email, recipientUserEntity.Email));
            });

            return messages;
        }

        public IEnumerable<Message> GetOutcomingMessagesByUserId(int senderId)
        {
            var messages = new List<Message>();

            _messageRepository.FindBySenderId(senderId).ToList().ForEach(m =>
            {
                var senderUserEntity = _userRepository.FindById(m.Sender_id);
                var recipientUserEntity = _userRepository.FindById(m.Recipient_id);

                messages.Add(new Message(m.Id, m.Content, senderUserEntity.Email, recipientUserEntity.Email));
            });

            return messages;
        }

        public void SendMessage(MessageSendingData messageSendingData)
        {
            if (string.IsNullOrEmpty(messageSendingData.Content))
                throw new ArgumentNullException();

            if (messageSendingData.Content.Length > 5000)
                throw new ArgumentOutOfRangeException();

            var findUserEntity = _userRepository.FindByEmail(messageSendingData.RecipientEmail);
            if (findUserEntity is null) throw new UserNotFoundException();

            var messageEntity = new MessageEntity()
            {
                Content = messageSendingData.Content,
                Sender_id = messageSendingData.SenderId,
                Recipient_id = findUserEntity.Id,
            };

            if (_messageRepository.Create(messageEntity) == 0)
                throw new Exception();
        }
    }
}
