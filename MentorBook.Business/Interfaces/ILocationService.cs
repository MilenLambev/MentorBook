using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MentorBook.Data.Models;
using MentorBook.Data.Repositories;

namespace MentorBook.Business
{
    public interface ILocationService
    {
        List<Country> GetAllCountries();
        List<Town> GetCitiesByCountryId(int countryId);
        public bool CreateCountry(Country country);
    }
}
