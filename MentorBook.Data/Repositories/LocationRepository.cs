using MentorBook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentorBook.Data.Repositories
{
    public class LocationRepository : BaseDapperRepository, ILocationRepository
    {
        private readonly ILocationRepository _locationRepository;

        private const string GET_ALL_COUNTRIES = @"
        SELECT [Id]
              ,[Name]
          FROM [dbo].[Countries]
        ";

        private const string GET_CITIES_BY_COUNTRIE_ID = @"
        SELECT [Id]
              ,[Name]
              ,[CountryId]
          FROM [dbo].[Towns]
          WHERE CountryId = @CountryId
        ";

        private const string GET_TOWN_BY_ID = @"
        SELECT [Id]
              ,[Name]
          FROM [dbo].[Towns]
          WHERE Id = @Id
        ";

        public LocationRepository(string dbConnString) : base(dbConnString)
        {
        }

        public List<Country> GetAllCountries()
        {
            List<Country> result = Query<Country>(GET_ALL_COUNTRIES);

            return result;
        }

        public List<Town> GetCitiesByCountryId(int CountryId)
        {
            List<Town> result = Query<Town>(GET_CITIES_BY_COUNTRIE_ID, new { CountryId });

            return result;
        }
        public Town GetTownById(int TownId)
        {
            Town result = Query<Town>(GET_TOWN_BY_ID, new { TownId }).FirstOrDefault();
            return result;
        }
    }
}
