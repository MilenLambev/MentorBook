using MentorBook.Data.Models;
using MentorBook.Data.Repositories;
using System.Collections.Generic;

namespace MentorBook.Business
{
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
    }
}
