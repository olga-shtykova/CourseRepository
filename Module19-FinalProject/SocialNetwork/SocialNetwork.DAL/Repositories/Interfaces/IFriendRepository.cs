using SocialNetwork.DAL.Entities;
using System.Collections.Generic;

namespace SocialNetwork.DAL.Repositories.Interfaces
{
    public interface IFriendRepository
    {
        int Create(FriendEntity friendEntity);

        IEnumerable<FriendEntity> FindAllByUserId(int userId);

        int Delete(int id);
    }
}
