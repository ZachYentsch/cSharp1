using System.ComponentModel.DataAnnotations;

namespace gregslistCsharp.Models
{
    public class Car
    {
        public Car(string make, string model, string description, int year, int price)
        {
            Id = Guid.NewGuid().ToString();
            Make = make;
            Model = model;
            Description = description;
            Year = year;
            Price = price;
        }
        public string? Id { get; set; }

        [Required]
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? Description { get; set; }

        [Required]
        [Range(1904, 2023)]
        public int Year { get; set; }

        [Range(0, int.MaxValue)]
        [Required]
        public int Price { get; set; }


    }
}