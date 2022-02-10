using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MentorBook.Data.Models;
using MentorBook.Data.Repositories;


namespace MentorBook.Business
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
             _locationRepository = locationRepository;
        }
        public List<Country> GetAllCountries()
        {
            return _locationRepository.GetAllCountries();
        }

        public List<Town> GetCitiesByCountryId(int CountryId)
        {
            return _locationRepository.GetCitiesByCountryId(CountryId);
        }
    }
}
