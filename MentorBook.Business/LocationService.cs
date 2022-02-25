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

        public bool CreateCountry(Country country)
        {
            bool result = false;
            bool check = false;

            List<Country> allCountries = _locationRepository.GetAllCountries();

            foreach (Country checkCountry in allCountries)
            {
                if (country.Name == checkCountry.Name)
                {
                    check = true;
                }
            }
            if (check == false)
            {
                _locationRepository.CreateCountry(country);
                result = true;
            }

            return result;
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
