using MentorBook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentorBook.Data.Repositories
{
    public class PostsRepository : BaseDapperRepository, IPostsRepository
    {
        #region Queries
        private const string GET_AGGREGATED_POSTS_OF_FRIENDS =
            @"SELECT U.FirstName
	  ,U.LastName
      ,P.[Id]
      ,P.[UserId]
      ,P.[ParentPostId]
      ,P.[SharedFromPostId]
      ,P.[Title]
      ,P.[Body]
      ,P.[DateCreated]
  FROM [dbo].[Posts] P
LEFT JOIN [dbo].[Users] U ON U.[Id] = P.[UserId]
WHERE P.[ParentPostId] IS NULL
	AND  P.[UserId] IN (
		SELECT [User1Id] FROM [dbo].[Friends]
			WHERE [User2Id] = @userId AND [RequestAcceptedDate] IS NOT NULL
		UNION
		SELECT [User2Id] FROM [dbo].[Friends]
			WHERE [User1Id] = @userId AND [RequestAcceptedDate] IS NOT NULL )
ORDER BY [DateCreated] DESC";
        private const string GET_COMMENTS =
            @"SELECT U.FirstName
	  ,U.LastName
      ,P.[Id]
      ,P.[UserId]
      ,P.[ParentPostId]
      ,P.[SharedFromPostId]
      ,P.[Title]
      ,P.[Body]
      ,P.[DateCreated]
  FROM [dbo].[Posts] P
LEFT JOIN [dbo].[Users] U ON U.[Id] = P.[UserId]
WHERE P.[ParentPostId] IS NOT NULL AND P.[ParentPostId] = @rootPostId
ORDER BY [DateCreated] DESC";
        private const string CREATE_COMMENT = @"
        INSERT INTO [dbo].[Posts]
               ([userID], 
                [parentPostId], 
                [Title],
                [Body],
                [DateCreated])
        VALUES(
            @authorID,
            @postID,
            @placeholderTitle,
            @commContent,
            @dateCreated)";
        private const string GET_POSTS_OF_USER = @"SELECT U.FirstName
      , U.LastName
      ,P.[Id]
      ,P.[UserId]
      ,P.[ParentPostId]
      ,P.[SharedFromPostId]
      ,P.[Title]
      ,P.[Body]
      ,P.[DateCreated]
  FROM[dbo].[Posts] P
LEFT JOIN[dbo].[Users] U ON U.[Id] = P.[UserId]
WHERE P.[UserId] = @userId
ORDER BY [DateCreated] DESC";
        #endregion
        public PostsRepository(string dbConnString) : base(dbConnString)
        {
        }
        public List<Post> GetAggregatedPostsOfFriends(int userId)
        {
            List<Post> result = Query<Post>(GET_AGGREGATED_POSTS_OF_FRIENDS, new { userId });

            return result;
        }

        public List<Post> GetComments(int rootPostId)
        {
            List<Post> result = Query<Post>(GET_COMMENTS, new { rootPostId });

            return result;
        }
        public void CreateComment(int postID, int authorID, string commContent)
        {

            DateTime dateCreated = DateTime.Now;
            // I am adding this because comments do not seem to have titles, yet they are required by the database
            string placeholderTitle = "_"; 
            Execute(CREATE_COMMENT,  new {postID, authorID, placeholderTitle, commContent,dateCreated});
            
        }
        public List<Post> GetPostsOfUser(int userId)
        {
            List<Post> result = Query<Post>(GET_POSTS_OF_USER, new { userId });

            return result;
        }
    }
}
