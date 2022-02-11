using MentorBook.Data.Models;
using MentorBook.Data.Repositories;
using System;
using System.Collections.Generic;

namespace MentorBook.Business
{
    //public class UserService : IUserService
    //{
    //    private readonly IUserRepository _userRepository;

    //    public UserService(IUserRepository userRepository)
    //    {
    //        _userRepository = userRepository;
    //    }

    //    public List<User> GetAllUsers()
    //    {
    //        return _userRepository.GetAllUsers();
    //    }

    //    public User GetUser(int UserId)
    //    {
    //        return _userRepository.GetUserById(UserId);
    //    }

    //    public bool InsertUser(User user)
    //    {
    //        bool result = false;

    //        // Check if user with the same email already exists
    //        User userWithTheSameEmail = _userRepository.GetUserByEmail(user.Email);

    //        if (userWithTheSameEmail == null)
    //        {
    //            // Add date created to the user
    //            user.DateCreated = DateTime.Now;

    //            // Check if current town id and home town id exists in the database

    //            // Insert user to the database
    //            _userRepository.InsertUser(user);

    //            // Switch result to true
    //            result = true;
    //        }

    //        return result;
    //    }
    //}
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public List<User> GetUserByFilter(string fillteringValue)
        {
            return _userRepository.GetUserByFilter(fillteringValue);
        }

        public User GetUser(int UserId)
        {
            return _userRepository.GetUserById(UserId);
        }

        public User GetUserEmail(string email)
        {
            return _userRepository.GetUserEmail(email);
        }

        public bool InsertUser(User user)
        {
            bool result = false;

            // Check if user with the same email already exists
            User userWithTheSameEmail = _userRepository.GetUserByEmail(user.Email);

            if (userWithTheSameEmail == null)
            {
                // Add date created to the user
                user.DateCreated = DateTime.Now;

                // Check if current town id and home town id exists in the database

                // Insert user to the database
                _userRepository.InsertUser(user);

                // Switch result to true
                result = true;
            }

            return result;
        }

        public List<User> GetUserAdditionalInfoByUserId(int userId)
        {
            return _userRepository.GetUserAdditionalInfoByUserId(userId);
        }
    }
}
