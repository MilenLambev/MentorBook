using MentorBook.Data.Models;
using MentorBook.Data.Repositories;
using System;
using System.Collections.Generic;

namespace MentorBook.Business
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILocationRepository _locationRepository;

        public UserService(IUserRepository userRepository, ILocationRepository locationRepository)
        {
            _userRepository = userRepository;
            _locationRepository = locationRepository;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public List<User> GetUserByFilter(string fillteringVlaue)
        {
            return _userRepository.GetUserByFilter(fillteringVlaue);
        }

        public User GetUser(int UserId)
        {
            return _userRepository.GetUserById(UserId);
        }

        public User GetUserEmail(string email)
        {
            return _userRepository.GetUserEmailInfo(email);
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

                if (user.CurrentTownId.HasValue)
                {
                    Town existingCurrentTown = _locationRepository.GetTownById(user.CurrentTownId.Value);
                    if(existingCurrentTown == null)
                    {
                        return false;
                    }
                }

                if (user.HomeTownId.HasValue)
                {
                    Town currentHomeTown = _locationRepository.GetTownById(user.HomeTownId.Value);
                    if (currentHomeTown == null)
                    {
                        return false;
                    }
                }

                // Insert user to the database
                _userRepository.InsertUser(user);

                // Switch result to true
                result = true;
            }

            return result;
        }

        public List<UserAdditionalInfoModel> GetUserAdditionalInfoByUserId(int userId)
        {
            return _userRepository.GetUserAdditionalInfoByUserId(userId);
        }

    }
}
