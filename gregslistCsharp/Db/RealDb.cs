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

        public static List<House> Houses { get; set; } = new List<House>()
        {
            new House("3325 Las Vegas Blvd", "Las Vegas", "Nevada", 50, 50, 7000000),
            new House("1 Lodge St", "Asheville", "North Carolina", 35, 43, 178926),
            new House("22907 E 8th Ave", "Liberty Lake", "Washington", 6, 7, 32775),
        };

        public static List<Job> Jobs { get; set; } = new List<Job>()
        {
            new Job("CEO", "RzR International", "Bossman", 40, 2000000),
            new Job("Vice President Of Sales", "Apple", "Movin on up", 80, 20000),
            new Job("Sous Chef", "Barbacoa", "Makes yummy food", 75, 80000),
        };
    }
}