using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    public class CitiesController : Controller
    {
        private readonly ICityInfoRepository _repository;

        public CitiesController(ICityInfoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCitiesAsync()
        {
            var cityEntities = await _repository.GetCitiesAsync();
            var result = Mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityAsync(int id, bool includePointsOfInterest = false)
        {
            var cityEntity = await _repository.GetCityAsync(id, includePointsOfInterest);

            if (cityEntity == null)
            {
                return NotFound();
            }

            if (includePointsOfInterest)
            {
                var result = Mapper.Map<CityDto>(cityEntity);
                return Ok(result);
            }
            else
            {
                var result = Mapper.Map<CityWithoutPointsOfInterestDto>(cityEntity);
                return Ok(result);
            }
            
        }
    }
}
