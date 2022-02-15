using gregslistCsharp.Models;

namespace gregslistCsharp.Db
{
    public class RealDb
    {
        public static List<Car> Cars { get; set; } = new List<Car>()
        {
            new Car("Ford", "Rs200", "Freaky Fast", "", 1986, 250000),
            new Car("Mitsubishi", "Evo VII", "Makes Cool Noises", "", 1996, 50000),
            new Car("Audi", "S4", "Straight 5", "", 1992, 20000),
            new Car("Mazda", "Rx-8", "Blown Apex Seal", "", 2007, 4000),
        };
    }
}