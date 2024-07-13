using RestaurantAPI.Entities;

namespace RestaurantAPI.Repository
{
    public interface IRestaurantRepository
    {
        Task<RestaurantTable> GetById(int id);
        Task<List<RestaurantTable>> GetAll();
        Task<RestaurantTable> Create(RestaurantTable restaurant);
        Task<RestaurantTable> Update(RestaurantTable restaurant);
        Task<RestaurantTable> Delete(int id);
    }
}
