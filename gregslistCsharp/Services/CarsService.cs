using gregslistCsharp.Db;
using gregslistCsharp.Models;

namespace gregslistCsharp.Services
{
    public class CarsService
    {
        internal List<Car> getAll()
        {
            return RealDb.Cars;
        }
    }
}