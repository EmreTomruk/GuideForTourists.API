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

        List<City> GetCities();

        List<Photo> GetPhotosByCity(int id);

        City GetCityAndTheirPhotosById(int id);

        Photo GetPhotos(int id);
    }
}
