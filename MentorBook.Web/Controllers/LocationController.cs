using MentorBook.Business;
using MentorBook.Data.Models;
using MentorBook.Web.Models.QueryModels;
using MentorBook.Web.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBook.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILogger<LocationController> _logger;
        private readonly ILocationService _locationService;

        public LocationController(ILogger<LocationController> logger, ILocationService locationService)
        {
            _logger = logger;
            _locationService = locationService;
        }

        [HttpGet("GetAllCountries")]
        public ActionResult<List<CountryVM>> GetAllCountries()
        {
            List<CountryVM> result = new List<CountryVM>();
            List<Country> allCountries = _locationService.GetAllCountries();

            foreach (Country country in allCountries)
            {
                CountryVM returnToTheClientModel = new CountryVM(country);

                result.Add(returnToTheClientModel);
            }

            return Ok(result);
        }

        [HttpGet("GetCitiesByCountryId")]
        public ActionResult<List<CityVM>> GetCitiesByCountryId(int countryId)
        {
            List<CityVM> result = new List<CityVM>();   
            List<Town> countrysCities = _locationService.GetCitiesByCountryId(countryId);
            
            foreach(Town city in countrysCities)
            {
                CityVM returnToTheClientModel = new CityVM(city);
                result.Add(returnToTheClientModel);
            }

            return Ok(result);
        }

        [HttpPost("CreateCountry")]
        public ActionResult CreateCountry([FromBody] CreateCountryQM country)
        {
            Country dbCountry = new Country();
            dbCountry.Name = country.Name;

            bool result = _locationService.CreateCountry(dbCountry);

            if (result == true)
            {
                return Ok();
            }

            return new StatusCodeResult(400);
        }
    }
}
