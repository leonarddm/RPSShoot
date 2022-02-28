// See https://aka.ms/new-console-template for more information

using RPSShoot.Console;

var player = new Player();
var computer = new Computer();

bool isValidPick = false;
bool done = false;

List<Choice> Choices = new List<Choice> { 
    new Choice { Id = 0, Key = 'R', Word = "ROCK" },
    new Choice { Id = 1, Key = 'P', Word = "PAPER" },
    new Choice { Id = 2, Key = 'S', Word = "SCISSOR" },
    new Choice { Id = 3, Key = 'X', Word = "SECRET_POTION" }
};

Console.WriteLine("Welcome to Rock, Paper, Scissor! Shoot!\n");

Console.Write("Please enter player name: ");
player.Name = Console.ReadLine();

Console.WriteLine("\nMATCH UP: ");
Console.WriteLine($"\t {player.Name} VS {computer.Name}");


while (!done)
{
    // Check if game is finished or not
    if (player.HP == 0)
    {
        done = true;
        computer.IsWinner = true;
    }
    else if (computer.HP == 0)
    {
        done = true;
        player.IsWinner = true;
    }   
    else
        done = false;

    if (!done)
    {
        //while (!isValidPick)
        //{

        //}

        Console.WriteLine("\nCHOICES: ");
        foreach (var choice in Choices)
        {
            Console.WriteLine($"\t {choice.Key} = {choice.Word}");
        }

        Console.Write("\nEnter your choice: ");
        player.ChoiceKey = char.ToUpper(Console.ReadLine()[0]);

        isValidPick = Choices.Any(c => c.Key == player.ChoiceKey);

        if (!isValidPick)
            Console.WriteLine($"Any entry except R, S, P is not allowed. Please enter valid choice.");
        else
        {
            player.Choice = Choices.Single(c => c.Key == player.ChoiceKey);

            Random pick = new Random();
            computer.ChoiceId = pick.Next(0, 3);
            computer.Choice = Choices.Single(c => c.Id == computer.ChoiceId);

            // 0 = R
            // 1 = P
            // 2 = S
            Console.WriteLine($"\nENTRIES:");
            Console.WriteLine($"\t[{computer.Name} : {computer.Choice.Key} | {computer.Choice.Word}]" +
                $" [{player.Name} : {player.Choice.Key} | {player.Choice.Word}]");

            Console.WriteLine("\nRESULT: ");
            switch (computer.Choice.Id)
            {
                case 0:
                    switch (player.Choice.Id)
                    {
                        case 0:
                            Console.Write("\tDRAW!\n");
                            break;
                        case 1:
                            Console.Write("\tYOU WIN!\n");
                            computer.HP -= 1;
                            break;
                        case 2:
                            Console.Write("\tYOU LOSE!\n");
                            player.HP -= 1;
                            break;
                    }
                    break;

                case 1:
                    switch (player.Choice.Id)
                    {
                        case 0:
                            Console.Write("\tYOU LOSE!\n");
                            player.HP -= 1;
                            break;
                        case 1:
                            Console.Write("\tDRAW!\n");
                            break;
                        case 2:
                            Console.Write("\tYOU WIN!\n");
                            computer.HP -= 1;
                            break;
                    }
                    break;

                case 2:
                    switch (player.Choice.Id)
                    {
                        case 0:
                            Console.Write("\tYOU WIN!\n");
                            computer.HP -= 1;
                            break;
                        case 1:
                            Console.Write("\tYOU LOSE!\n");
                            player.HP -= 1;
                            break;
                        case 2:
                            Console.Write("\tDRAW!\n");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("INVALID ENTRY!");
                    break;
            }

            Console.WriteLine($"\nREMAINING HP: \n\t[{player.Name} : {player.HP}] [{computer.Name} : {computer.HP}]\n\n");
        }
    }
}

if (player.IsWinner)
    Console.WriteLine($"\n\n\t\tHOORAY {player.Name}, YOU WON THE MATCH!");
else if (computer.IsWinner)
    Console.WriteLine($"\n\n\t\tSORRY {player.Name}, YOU LOSE THE MATCH!");

Console.WriteLine("\n\n\t\tTHANK YOU FOR PLAYING!\n\n");






















