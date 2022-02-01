using MentorBook.Data.Models;

namespace MentorBook.Web.Models.ViewModels
{
    public class UserShortDataVM
    {
        public UserShortDataVM(User user)
        {
            this.Id = user.Id;
            this.Name = $"{user.FirstName} {user.LastName}";
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
