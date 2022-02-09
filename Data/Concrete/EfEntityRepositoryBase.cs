using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouristGuide.API.Models;

namespace TouristGuide.API.Data.Concrete
{
    public class EfEntityRepositoryBase : IEntityRepository
    {
        private TouristGuideContext _context;

        public EfEntityRepositoryBase(TouristGuideContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
         
        public void Delete<T>(T entity)
        {
            _context.Remove(entity);
        }

        public async Task<List<City>> GetCities()
        {
            var cities = await _context.Cities.Include(c => c.Photos).ToListAsync();

            return cities;
        }

        public async Task<City> GetCityById(int id)
        {
            var city = await _context.Cities.Include(c => c.Photos).FirstOrDefaultAsync(c => c.Id == id);

            return city;
        }

        public async Task<List<Photo>> GetPhotosByCity(int cityId)
        {
            var photos = await _context.Photos.Where(p => p.CityId == cityId).ToListAsync();

            return photos;
        }

        public async Task<Photo> GetPhotos(int id)
        {
            var photo = await _context.Photos.FirstOrDefaultAsync(p => p.Id == id);

            return photo;
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
