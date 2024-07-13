using RestaurantAPI.Entities;

namespace RestaurantAPI.Service;
public interface IRestaurantService
{
    Task<RestaurantTable> GetById(int id);
    Task<List<RestaurantTable>> GetAll();
    Task<RestaurantTable> Create(RestaurantTable restaurant);
    Task<RestaurantTable> Update(int id, RestaurantTable restaurant);
    Task<RestaurantTable> Delete(int id);
}
