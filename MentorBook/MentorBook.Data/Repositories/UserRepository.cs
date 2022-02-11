using MentorBook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MentorBook.Data.Repositories
{
    public class UserRepository : BaseDapperRepository, IUserRepository
    {
        #region Queries

        private const string GET_ALL_USERS = @"
        SELECT [Id]
              ,[Email]
              ,[FirstName]
              ,[LastName]
              ,[Phone]
              ,[DateOfBirth]
              ,[HomeTownId]
              ,[CurrentTownId]
              ,[DateCreated]
          FROM [dbo].[Users]
        ";

        private const string GET_USER_BY_ID = @"
        SELECT [Id]
              ,[Email]
              ,[FirstName]
              ,[LastName]
              ,[Phone]
              ,[DateOfBirth]
              ,[HomeTownId]
              ,[CurrentTownId]
              ,[DateCreated]
          FROM [dbo].[Users]
          WHERE [Id] = @UserId
        ";

        private const string INSERT_USER = @"
        INSERT INTO [dbo].[Users]
               ([Email]
               ,[FirstName]
               ,[LastName]
               ,[Phone]
               ,[DateOfBirth]
               ,[HomeTownId]
               ,[CurrentTownId]
               ,[DateCreated])
         VALUES
               (@Email
               ,@FirstName
               ,@LastName
               ,@Phone
               ,@DateOfBirth
               ,@HomeTownId
               ,@CurrentTownId
               ,@DateCreated)
        ";

        private const string GET_USER_BY_INFO = @"
        SELECT
         [Id]
              ,[Email]
              ,[FirstName]
              ,[LastName]
              ,[Phone]
              ,[DateOfBirth]
              ,[HomeTownId]
              ,[CurrentTownId]
              ,[DateCreated]
          FROM [dbo].[Users]
         WHERE [FirstName] LIKE CONCAT(@fillteringValue,'%') OR [LastName] LIKE CONCAT(@fillteringValue,'%') OR [Email] LIKE CONCAT(@fillteringValue,'%')
        ";

        private const string GET_USER_BY_EMAIL = @"
        SELECT *
        FROM [dbo].[Users]
        WHERE [Email] = @Email
        ";

        private const string GET_USER_EMAIL = @"
        SELECT [Id],[Email]
        FROM [dbo].[Users]
        WHERE [Email] = @Email
        ";

        //private const string GET

        #endregion

        public UserRepository(string dbConnString) : base(dbConnString) { }

        #region Public Methods

        public List<User> GetAllUsers()
        {
            List<User> result = Query<User>(GET_ALL_USERS);

            return result;
        }

        public User GetUserById(int UserId)
        {
            List<User> result = Query<User>(GET_USER_BY_ID, new { UserId });

            return result.FirstOrDefault();
        }

        public void InsertUser(User user)
        {
            Execute(INSERT_USER, user);
        }

        public User GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User GetUserEmailInfo(string email)
        {
            List<User> result = Query<User>(GET_USER_BY_EMAIL, new { email });

            return result.FirstOrDefault();
        }

        public List<User> GetUserByFilter(string fillteringValue)
        {
            List<User> result = Query<User>(GET_USER_BY_INFO, new { fillteringValue });
            return result;
        }

        public User GetUserEmail(string email)
        {
            List<User> result = Query<User>(GET_USER_EMAIL, new { email });
            return result.FirstOrDefault();
        }
        #endregion
    }
}
