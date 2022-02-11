using MentorBook.Data.Models;
using MentorBook.Data.Repositories;
using System.Collections.Generic;

namespace MentorBook.Data.Repositories
{
    public interface IFriendshipRepository
    {
        int GetUserFriendsCountById(int UserId);
        List<Friend> GetFriendById(int id);
        List<Friend> GetPendingFriend(int id);
    }
}