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
        List<User> GetUserByFilter(string fillteringValue);
        User GetUserEmail(string email);
        List<User> GetUserAdditionalInfoByUserId(int userId);
    }
}