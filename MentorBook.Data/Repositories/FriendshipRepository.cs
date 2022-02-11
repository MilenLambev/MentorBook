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
            SELECT COUNT(*) AS FriendsCount FROM (
                SELECT
                    U1.*
                FROM [dbo].[Friends] F
                LEFT JOIN [Users] U1 ON U1.Id = F.User1Id
                WHERE  [User2Id] = @UserId
                UNION
                SELECT U2.*
                FROM [dbo].[Friends] F
                LEFT JOIN [Users] U2 ON U2.Id = F.User2Id
                WHERE  [User1Id] = @UserId
        )x";
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
