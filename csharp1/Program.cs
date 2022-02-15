Console.Clear();

Console.BackgroundColor = ConsoleColor.Blue;
Console.ForegroundColor = ConsoleColor.White;

// List<String> weapon = new List<string>()
// {
//     "rock",
//     "paper",
//     "scissors"
// };

// Console.WriteLine("Choose Weapon - rock, paper, or scissors");
// Console.Write("Your Choice: ");
// var attack = Console.ReadLine();


// var random = new Random();
// Console.Write("Computers Choice: ");
// for (int i = 0; i < weapon.Count; i)
// {
//     Console.WriteLine(weapon[random.Next(0, 3)]);
// };
// Console.Write(weapon[random.Next(0, 3)]);

// // NOTE ROCK
// if (attack == "rock" && computer == "paper")
// {
//     Console.WriteLine(@"Rock Loses to Paper");
// }
// else if (attack == "rock" && computer == "scissors")
// {
//     Console.WriteLine(@"Rock Beats Scissors");

// }
// else
// {
//     Console.WriteLine(@"Tie");
// };


// // NOTE PAPER
// if (attack == "paper" && computer == "rock")
// {
//     Console.WriteLine(@"Paper Beats Rock");
// }
// else if (attack == "rock" && computer == "scissors")
// {
//     Console.WriteLine(@"Paper Loses to Scissors");
// }
// else
// {
//     Console.WriteLine(@"Tie");
// };

// // NOTE SCISSORS
// if (attack == "scissors" && computer == "rock")
// {
//     Console.WriteLine(@"Scissors Loses to Rock");
// }
// else if (attack == "scissors" && computer == "paper")
// {
//     Console.WriteLine(@"Scissors Beats Paper");
// }
// else
// {
//     Console.WriteLine(@"Tie");
// };




// ANCHOR MORNING CHALLENGE 2/15
Dictionary<string, string> users = new Dictionary<string, string>(){
    {"Z6ch", "Password123!"},
    {"Kolt3n", "SpeedRacer1"},
    {"Redline", "BaNg16!"}
};

Console.Write("Username: ");
var gamerTag = Console.ReadLine();

Console.Write(@"Password: ");
var password = Console.ReadLine();

if (gamerTag != null)
{
    Console.WriteLine($@"Welcome {gamerTag}");
}