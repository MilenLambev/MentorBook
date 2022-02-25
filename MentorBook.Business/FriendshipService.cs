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