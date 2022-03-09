using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MentorBook.Data.Models;

namespace MentorBook.Data.Repositories
{
    public interface ILocationRepository
    {
        List<Country> GetAllCountries();
        List<Town> GetCitiesByCountryId( int CountryId);
        Town GetTownById(int TownId);
    }
}
