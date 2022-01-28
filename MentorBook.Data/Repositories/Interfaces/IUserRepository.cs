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
    }
}