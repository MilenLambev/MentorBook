﻿using MentorBook.Data.Models;
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
         WHERE [FirstName] LIKE CONCAT(@fillteringVlaue,'%') OR [LastName] LIKE CONCAT(@fillteringVlaue,'%') OR [Email] LIKE CONCAT(@fillteringVlaue,'%')
        ";

        private const string GET_USER_BY_EMAIL = @"
        SELECT *
        FROM [dbo].[Users]
        WHERE [Email] = @email
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

        private const string GET_USER_ADDITIONAL_INFO_BY_USER_ID = @"
        SELECT [UserId]
              ,[Key]
              ,[Value]
              ,[DateCreated]
              ,[DateRemoved]
        FROM [dbo].[UserAdditionalInfo]
        WHERE [UserId] = @UserId AND DateRemoved IS NULL
        ";

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

        public List<User> GetUserByFilter(string fillteringVlaue)
        {
            List<User> result = Query<User>(GET_USER_BY_INFO,new { fillteringVlaue });
            return result;
        }

        public List<UserAdditionalInfoModel> GetUserAdditionalInfoByUserId(int userId)
        {
            List<UserAdditionalInfoModel> result = Query<UserAdditionalInfoModel>(GET_USER_ADDITIONAL_INFO_BY_USER_ID, new { userId });
            return result;
        }

        #endregion
    }
}
