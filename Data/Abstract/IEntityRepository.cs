using System.Collections.Generic;
using System.Threading.Tasks;
using TouristGuide.API.Models;

namespace TouristGuide.API.Data
{
    public interface IEntityRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity);
        bool SaveAll();

        Task<List<City>> GetCities();
        Task<List<Photo>> GetPhotosByCity(int id);
        Task<City> GetCityById(int id);
        Task<Photo> GetPhotos(int id);
    }
}
