﻿using SocialNetwork.DAL.Entities;
using System.Collections.Generic;

namespace SocialNetwork.DAL.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        int Create(MessageEntity messageEntity);

        IEnumerable<MessageEntity> FindBySenderId(int senderId);

        IEnumerable<MessageEntity> FindByRecipientId(int recipientId);

        int DeleteById(int messageId);
    }
}
