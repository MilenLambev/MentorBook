using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentorBook.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? HomeTownId { get; set; }
        public string HomeTown { get; set; }
        public int? CurrentTownId { get; set; }
        public string CurrentTown { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
