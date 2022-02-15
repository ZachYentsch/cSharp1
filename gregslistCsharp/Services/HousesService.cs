using gregslistCsharp.Db;
using gregslistCsharp.Models;

namespace gregslistCsharp.Services
{
    public class HousesService
    {
        internal List<House> getAll()
        {
            return RealDb.Houses;
        }

        internal House getById(string? houseId)
        {
            House? foundHouse = RealDb.Houses.Find(h => h.Id == houseId);
            if (foundHouse == null)
            {
                throw new Exception("House not Found!");
            }
            return foundHouse;
        }

        internal House Create(House newHouse)
        {
            RealDb.Houses.Add(newHouse);
            return newHouse;
        }

        internal House Edit(House editedHouse, string houseId)
        {
            House originalHouse = getById(houseId);
            originalHouse.Address = editedHouse.Address != null ? editedHouse.Address : originalHouse.Address;
            originalHouse.City = editedHouse.City != null ? editedHouse.City : originalHouse.City;
            originalHouse.State = editedHouse.State != null ? editedHouse.State : originalHouse.State;
            originalHouse.Bed = editedHouse.Bed != 0 ? editedHouse.Bed : originalHouse.Bed;
            originalHouse.Bath = editedHouse.Bath != 0 ? editedHouse.Bath : originalHouse.Bath;
            originalHouse.Sqft = editedHouse.Sqft != 0 ? editedHouse.Sqft : originalHouse.Sqft;
            return originalHouse;
        }

        internal House Remove(string houseId)
        {
            House foundHouse = getById(houseId);
            RealDb.Houses.Remove(foundHouse);
            return foundHouse;
        }

    }
}