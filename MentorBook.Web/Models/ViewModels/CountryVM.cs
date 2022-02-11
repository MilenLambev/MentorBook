using MentorBook.Data.Models;

namespace MentorBook.Web.Models.ViewModels
{
    public class CountryVM
    {
        public CountryVM(Country country)
        {
            Id = country.Id;
            Name = country.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
