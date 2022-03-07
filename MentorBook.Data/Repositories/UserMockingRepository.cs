using MentorBook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentorBook.Data.Repositories
{
    public class UserMockingRepository : IUserRepository
    {
        private static List<User> _allUsersInTheUniverse = new List<User>();
        private static List<UserAdditionalInfoModel> _allUserAdditionalInfo = new List<UserAdditionalInfoModel>();
        private static int _userId = 0;

        public List<User> GetAllUsers()
        {
            return _allUsersInTheUniverse;
        }

        public User GetUserById(int UserId)
        {
            return _allUsersInTheUniverse.FirstOrDefault(u => u.Id == UserId);
        }

        public User GetUserByEmail(string email)
        {
            return _allUsersInTheUniverse.FirstOrDefault(u => u.Email == email);
        }

        public void InsertUser(User user)
        {
            _userId = _userId + 1;
            user.Id = _userId;

            _allUsersInTheUniverse.Add(user);
        }

        public User GetUserEmailInfo(string email)
        {
            return _allUsersInTheUniverse.FirstOrDefault(u => u.Email == email);
        }

        public List<User> GetUserByFilter(string fillteringVlaue)
        {
            return _allUsersInTheUniverse;
        }

        public List<UserAdditionalInfoModel> GetUserAdditionalInfoByUserId(int userId)
        {
            return _allUserAdditionalInfo;
        }

        public void CreateUserAdditionalInfoById(UserAdditionalInfoModel userAdditionalInfo)
        {
            _allUserAdditionalInfo.Add(userAdditionalInfo);
        }
    }
}
