using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Entities;
using RestaurantAPI.Service;

namespace RestaurantAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RestaurantController : ControllerBase
{
    public IRestaurantService _service { get; set; }
    public RestaurantController(IRestaurantService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RestaurantTable>> GetById(int id)
    {
        if (id < 0)
        {
            return NotFound();
        }
        var getRestaurant = await _service.GetById(id);
        return Ok(getRestaurant);
    }

    [HttpGet]
    public async Task<ActionResult<List<RestaurantTable>>> GetAll()
    {
        var getAllRestaurants = await _service.GetAll();
        return Ok(getAllRestaurants);
    }

    [HttpPost]
    public async Task<ActionResult<RestaurantTable>> Create(RestaurantTable restaurant)
    {
        var createRestaurant = await _service.Create(restaurant);
        return Ok(createRestaurant);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<RestaurantTable>> Delete(int id)
    {
        if (id < 0)
        {
            return NotFound();
        }
        await _service.Delete(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<RestaurantTable>> Update(int id, RestaurantTable restaurant)
    {
        await _service.Update(id, restaurant);
        return NoContent();
    }
}
