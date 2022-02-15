

using System.ComponentModel.DataAnnotations;

namespace gregslistCsharp.Models
{
    public class House
    {
        public House(string address, string city, string state, int bed, int bath, int sqft)
        {
            Id = Guid.NewGuid().ToString();
            Address = address;
            City = city;
            State = state;
            Bed = bed;
            Bath = bath;
            Sqft = sqft;
        }

        public string? Id { get; set; }

        [Required]
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }

        [Range(1, 50)]
        public int Bed { get; set; }

        [Range(1, 50)]
        public int Bath { get; set; }

        [Range(1, int.MaxValue)]
        public int Sqft { get; set; }

    }
}