using MentorBook.Data.Models;
using MentorBook.Data.Repositories;
using System.Linq;
using System.Collections.Generic;

namespace MentorBook.Business
{ 
    public class FriendshipService : IFriendshipService
    {
        private readonly IFriendshipRepository _friendshipRepository;
        public FriendshipService(IFriendshipRepository friendshipRepository)
        {
            _friendshipRepository = friendshipRepository;
        }

        public List<Friends> GetCommonFriends(int firstFriendId, int secondFriendId)
        {
<<<<<<< HEAD
            return _friendshipRepository.GetCommonFriends(firstFriendId,secondFriendId);
            
=======
            var firstUserFriends = _friendshipRepository.GetFriendsByUserId(firstFriendId);
            var secondUserFriends = _friendshipRepository.GetFriendsByUserId(secondFriendId);

            List<Friends> commonFriends = new List<Friends>();
            foreach(var friend in firstUserFriends)
            {
                if(secondUserFriends.Any(p => p.Id == friend.Id))
                {
                    commonFriends.Add(friend);
                }
            }
            return commonFriends;
>>>>>>> c150c6a14aca269f9b0e085149795ead6cca5890
        }

        public List<Friends> GetFriendsByUserId(int friendId)
        {
            return _friendshipRepository.GetFriendsByUserId(friendId);
        }

        public List<Friends> GetPendingFriendsRequest(int id)
        {
            return _friendshipRepository.GetPendingFriendsRequest(id);
        }

        public int GetUserFriendsCountById(int UserId)
        {
            return _friendshipRepository.GetUserFriendsCountById(UserId);
        }
    }
}