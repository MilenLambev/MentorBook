using MentorBook.Data.Models;
using System.Collections.Generic;

namespace MentorBook.Data.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUserById(int UserId);
        void InsertUser(User user);
    }
}