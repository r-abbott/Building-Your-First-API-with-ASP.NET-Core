using CityInfo.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public interface ICityInfoRepository
    {
        IEnumerable<City> GetCities();
        Task<IEnumerable<City>> GetCitiesAsync();
        City GetCity(int cityId, bool includePointsOfInterest);
        Task<City> GetCityAsync(int cityId, bool includePointsOfInterest);
        IEnumerable<PointOfInterest> GetPointsOfInterestForCity(int cityId);
        Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForCityAsync(int cityId);
        PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfInterestId);
        Task<PointOfInterest> GetPointOfInterestForCityAsync(int cityId, int pointOfInterestId);
        bool CityExists(int cityId);
        Task<bool> CityExistsAsync(int cityId);
        void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest);
        Task AddPointOfInterestForCityAsync(int cityId, PointOfInterest pointOfInterest);
        void DeletePointOfInterestForCity(PointOfInterest pointOfInterest);
        bool Save();
        Task<bool> SaveAsync();
    }
}
