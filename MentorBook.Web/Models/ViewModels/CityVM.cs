using MentorBook.Data.Models;

namespace MentorBook.Web.Models.ViewModels
{
    public class CityVM
    {
        public CityVM(Town city)
        {
            Id = city.Id;
            Name = city.Name;
            CountryId = city.CountryId; 
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
