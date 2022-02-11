using MentorBook.Data.Models;
using MentorBook.Data.Repositories;
using System.Collections.Generic;

namespace MentorBook.Data.Repositories
{
    public interface IFriendshipRepository
    {
        int GetUserFriendsCountById(int UserId);
        List<Friends> GetFriendByUserId(int id);
        List<Friends> GetPendingFriendsRequest(int id);
    }
}