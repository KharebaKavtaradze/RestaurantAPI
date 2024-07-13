using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Context;
using RestaurantAPI.Entities;
using RestaurantAPI.Repository;

namespace RestaurantAPI.Repository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        public ApplicationDbContext _db { get; set; }
        public RestaurantRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<RestaurantTable> Create(RestaurantTable restaurant)
        {
            _db.Restaurant.Add(restaurant);
            await _db.SaveChangesAsync();
            return restaurant;
        }

        public async Task<List<RestaurantTable>> GetAll()
        {
            var getRestaurants = await _db.Restaurant.ToListAsync();
            return getRestaurants;
        }

        public async Task<RestaurantTable> GetById(int id)
        {
            var restaurant = await _db.Restaurant.FirstOrDefaultAsync(r => r.Id == id);
            return restaurant;
        }

        public async Task<RestaurantTable> Update(RestaurantTable restaurant)
        {
             _db.Restaurant.Update(restaurant);
             await _db.SaveChangesAsync();
             return restaurant;
        }

        public async Task<RestaurantTable> Delete(int id)
        {
            var restaurant= _db.Restaurant.FirstOrDefault(r => r.Id == id);
            _db.Remove(restaurant);
            await _db.SaveChangesAsync();
            return restaurant;
        }
    }
}
