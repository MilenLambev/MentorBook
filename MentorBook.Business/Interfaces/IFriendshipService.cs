using MentorBook.Data.Models;
using MentorBook.Data.Repositories;
using System.Collections.Generic;
 
namespace MentorBook.Business
{
    public interface IFriendshipService
    { 
        int GetUserFriendsCountById(int UserId);
        List<Friend> GetFriendsByUserId(int id);
        List<Friend> GetPendingFriends(int id);
    }
}