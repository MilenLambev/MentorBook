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
            SELECT COUNT(*) AS FriendsCount FROM 
            (
            SELECT * FROM Friends f WHERE RequestAcceptedDate IS NOT NULL AND User1id = @UserId
            UNION 
            SELECT * FROM Friends f WHERE RequestAcceptedDate IS NOT NULL AND User2id = @UserId
            )x";


        private const string GET_FRIEND_BY_ID = @"
        SELECT
	    U1. [Id],[Email],[FirstName],[LastName]
        FROM [dbo].[Friends] F 
        LEFT JOIN [Users] U1 ON U1.Id = F.User1Id 
         WHERE  [User2Id] = @id AND [RequestAcceptedDate] is not NULL
         UNION
        SELECT U2.[Id],[Email],[FirstName],[LastName]
        FROM [dbo].[Friends] F 
        LEFT JOIN [Users] U2 ON U2.Id = F.User2Id
        WHERE  [User1Id] = @id AND [RequestAcceptedDate] is not NULL
        ";
        private const string GET__PENDING_FRIEND_REQUEST_BY_ID = @"
        SELECT
	    U1. [Id],[Email],[FirstName],[LastName]
        FROM [dbo].[Friends] F 
        LEFT JOIN [Users] U1 ON U1.Id = F.User1Id 
         WHERE  [User2Id] = @id AND [RequestAcceptedDate] is  NULL
         UNION
        SELECT U2.[Id],[Email],[FirstName],[LastName]
        FROM [dbo].[Friends] F 
        LEFT JOIN [Users] U2 ON U2.Id = F.User2Id
        WHERE  [User1Id] = @id AND [RequestAcceptedDate] is  NULL
        ";

=======

        #endregion

        public FriendshipRepository(string dbConnString) : base(dbConnString) { }

        public List<Friend> GetFriendById(int id)
        {
            List<Friend> result = Query<Friend>(GET_FRIEND_BY_ID, new { id });

            return result;
        }

        public List<Friend> GetPendingFriend(int id)
        {
            List<Friend> result = Query<Friend>(GET__PENDING_FRIEND_REQUEST_BY_ID, new { id });

            return result;
        }
        #region Public Methods

        public int GetUserFriendsCountById(int UserId)
        {
            int result = Query<int>(GET_USER_FRIENDSCOUNT_BY_ID, new { UserId }).First();

            return result;
        }

        #endregion
    }
}
