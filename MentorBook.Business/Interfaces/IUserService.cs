using MentorBook.Data.Models;
using MentorBook.Data.Repositories;
using System.Collections.Generic;

namespace MentorBook.Business
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUser(int UserId);
        bool InsertUser(User user);
    }
}