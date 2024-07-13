using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Entities
{
    //No need to add DTO since there are no navigation properties or objects.
    public class RestaurantTable
    {
        [Key]
        public int Id { get; set; }
        public string? RestaurantName { get; set; }
        public int TableNumber { get; set; }
        public string? Location { get;set; }
        public string? Category { get;set; }
       
    }
}
