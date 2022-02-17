using csharp1.Db;
using csharp1.Models;

namespace csharp1.Services
{
    public class ArtistsService
    {
        internal List<Artist> getAll()
        {
            return RealDb.Artists;
        }

        internal Artist getById(string? artistId)
        {
            Artist? foundArtist = RealDb.Artists.Find(a => a.Id == artistId);
            if (foundArtist == null)
            {
                throw new Exception("Invalid Artist");
            }
            return foundArtist;
        }

        internal Artist create(Artist newArtist)
        {
            RealDb.Artists.Add(newArtist);
            return newArtist;
        }

        internal Artist edit(Artist editedArtist, string artistId)
        {
            Artist originalArtist = getById(artistId);
            originalArtist.Name = editedArtist.Name != null ? editedArtist.Name : originalArtist.Name;
            originalArtist.Description = editedArtist.Description != null ? editedArtist.Description : originalArtist.Description;
        }
    }
}