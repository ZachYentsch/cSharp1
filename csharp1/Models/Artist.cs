using System.ComponentModel.DataAnnotations;

namespace csharp1.Models
{
    public class Artist
    {
        public Artist(string name, string description, string artpiece, string nameOfPiece, int datePainted)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Description = description;
            Artpiece = artpiece;
            NameOfPiece = nameOfPiece;
            DatePainted = datePainted;
        }
        public string? Id { get; set; }

        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Artpiece { get; set; }
        public string NameOfPiece { get; set; }

        [Range(int.MinValue, 2022)]
        public int DatePainted { get; set; }

    }
}