using RestaurantAPI.Entities;
using RestaurantAPI.Repository;

namespace RestaurantAPI.Service;
public class RestaurantService : IRestaurantService
{
    public IRestaurantRepository _repository { get; set; }
    public RestaurantService(IRestaurantRepository repository)
    {
        _repository = repository;
    }

    public async Task<RestaurantTable> GetById(int id) => await _repository.GetById(id);

    public async Task<List<RestaurantTable>> GetAll() => await _repository.GetAll();


    public async Task<RestaurantTable> Create(RestaurantTable restaurant)
    {
        var newRestaurant = new RestaurantTable();
        {
            newRestaurant.RestaurantName = restaurant.RestaurantName;
            newRestaurant.TableNumber = restaurant.TableNumber;
            newRestaurant.Location = restaurant.Location;
            newRestaurant.Category = restaurant.Category;
        };
        await _repository.Create(newRestaurant);
        return newRestaurant;
    }


    public async Task<RestaurantTable> Update(int id, RestaurantTable restaurant)
    {
        var updateRestaurant = await _repository.GetById(id);
        updateRestaurant.RestaurantName = restaurant.RestaurantName;
        updateRestaurant.TableNumber = restaurant.TableNumber;
        updateRestaurant.Location = restaurant.Location;
        updateRestaurant.Category = restaurant.Category;
        await _repository.Update(updateRestaurant);
        return updateRestaurant;
    }
    public async Task<RestaurantTable> Delete(int id)
    {
        if (id < 0)
        {
            throw new ArgumentException("Id can not be less than 0");
        }
        var deleteRestaurant = await _repository.Delete(id);
        return deleteRestaurant;
    }
}
