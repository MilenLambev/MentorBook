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
        #region Queries
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

        private const string CREATE_COUNTRU= @"
        INSERT INTO [dbo].[Countries]
               [Id]
              ,[Name]    
         VALUES
               (@Id
               ,@Name)
        ";
        #endregion

        public LocationRepository(string dbConnString) : base(dbConnString)
        {
        }

        public void CreateCountry(Country country)
        {
            Execute(CREATE_COUNTRU, country);
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
    }
}
