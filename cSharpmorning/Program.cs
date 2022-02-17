// See https://aka.ms/new-console-template for more information
bool running = true;
while (running)
{
    Console.WriteLine("Again? (Y/N)");
    var roll = Console.ReadKey().KeyChar;
    if (roll == 'n')
    {
        running = false;
        Console.WriteLine("GameOver Man!");
    }
}
Console.WriteLine("Welcome to the Game");
Console.WriteLine("ROll THE DICE: ");
Console.WriteLine("Y / N");
var throwDice = Console.ReadKey().KeyChar;
// Random dice1 = random.Next(6);
// Random die2 = random.Next(6);
int score = 0;
Random die = new Random();
for (int i = 0; i < 3; i++)
{
    int roll1 = die.Next(1, 7);
    int roll2 = die.Next(1, 7);
    score += roll1 + roll2;
    Console.WriteLine(roll1 + " " + roll2);
    if (roll1 == roll2)
    {
        score = 0;
        Console.WriteLine("break");
        break;
    }
    Console.WriteLine("Score: " + score);
    Console.Clear();

}

