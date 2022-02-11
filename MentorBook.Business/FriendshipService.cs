using MentorBook.Data.Models;
using MentorBook.Data.Repositories;
using System;
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

        public List<Friend> GetFriendById(int id)
        {
            return _friendshipRepository.GetFriendById(id);
        }

        public List<Friend> GetPendingFriend(int id)
        {
            return _friendshipRepository.GetPendingFriend(id);
        }

        public int GetUserFriendsCountById(int UserId)
        {
            return _friendshipRepository.GetUserFriendsCountById(UserId);
        }
    }
}