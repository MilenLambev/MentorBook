using MentorBook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MentorBook.Data.Repositories
{
    public class FriendshipRepository : BaseDapperRepository, IFriendshipRepository
    {
        #region Queries
        private const string GET_USER_FRIENDSCOUNT_BY_ID = @"
            SELECT COUNT( user2id ) FROM friends
            WHERE user1id = @UserId;";
        #endregion

        public FriendshipRepository(string dbConnString) : base(dbConnString) { }
        #region Public Methods

        public int GetUserFriendsCountById(int UserId)
        {
            int result = Query<int>(GET_USER_FRIENDSCOUNT_BY_ID, new { UserId }).First();

            return result;
        }

        #endregion
    }
}
