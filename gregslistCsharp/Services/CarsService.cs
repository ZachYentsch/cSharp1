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

        internal Car Edit(Car editedCar, string carId)
        {
            Car originalCar = getById(carId);
            originalCar.Make = editedCar.Make != null ? editedCar.Make : originalCar.Make;
            originalCar.Model = editedCar.Model != null ? editedCar.Model : originalCar.Model;
            originalCar.Description = editedCar.Description != null ? editedCar.Description : originalCar.Description;
            originalCar.ImgUrl = editedCar.ImgUrl != null ? editedCar.ImgUrl : originalCar.ImgUrl;
            originalCar.Year = editedCar.Year != 0 ? editedCar.Year : originalCar.Year;
            originalCar.Price = editedCar.Price != 0 ? editedCar.Price : originalCar.Price;
            return originalCar;
        }

        internal Car Remove(string carId)
        {
            Car foundCar = getById(carId);
            RealDb.Cars.Remove(foundCar);
            return foundCar;
        }
    }
}