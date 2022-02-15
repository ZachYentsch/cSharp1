using System.ComponentModel.DataAnnotations;

namespace gregslistCsharp.Models
{
    public class Job
    {
        public Job(string position, string company, string description, int hours, int pay)
        {
            Id = Guid.NewGuid().ToString();
            Position = position;
            Company = company;
            Description = description;
            Hours = hours;
            Pay = pay;
        }

        public string? Id { get; set; }

        [Required]
        public string? Position { get; set; }
        public string? Company { get; set; }
        public string? Description { get; set; }

        [Required]
        [Range(1, 168)]
        public int Hours { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Pay { get; set; }

    }
}