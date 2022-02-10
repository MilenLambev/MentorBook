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

        public List<int> GetUserFriendsCountById(int UserId)
        {
            return _friendshipRepository.GetUserFriendsCountById(UserId);
        }
    }
}