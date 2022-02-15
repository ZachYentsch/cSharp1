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

        internal Car getById(string? carId)
        {
            Car? foundCar = RealDb.Cars.Find(c => c.Id == carId);
            if (foundCar == null)
            {
                throw new Exception("Car not Found!");
            }
            return foundCar;
        }

        internal Car Create(Car newCar)
        {
            RealDb.Cars.Add(newCar);
            return newCar;
        }
    }
}