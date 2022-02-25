using MentorBook.Data.Models;
using System.Collections.Generic;

namespace MentorBook.Data.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUserById(int UserId);
        User GetUserByEmail(string email);
        void InsertUser(User user);
        User GetUserEmailInfo(string email);
        List<User> GetUserByFilter(string fillteringVlaue);
        List<UserAdditionalInfoModel> GetUserAdditionalInfoByUserId(int userId);
    }
}
