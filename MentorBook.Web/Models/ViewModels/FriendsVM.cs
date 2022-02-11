using MentorBook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBook.Web.Models.ViewModels
{
    public class FriendsVM
    {
        public FriendsVM(Friends friend)
        {
            Id = friend.Id;
            Email = friend.Email;
            FirstName = friend.FirstName;
            LastName = friend.LastName;
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

