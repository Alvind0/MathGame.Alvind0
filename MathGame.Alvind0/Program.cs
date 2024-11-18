/*
* This is a math game containing the 4 basic games
* (addition, subtration, multiplication, division) + random
* with a game history made with List<string>
*/

// TODO:
// 1. make a game mode with random operations in ChooseGame()
// 2. add a timer(cosmetic)
// 3. add a difficulty option in ChooseGame()

// Initialize game variables
string? userStringInput;
char userKeyInput, chosenOption;
int userAnswer = 0;

int difficultyRangeMin = 0;
int difficultyRangeMax = 100;

Random random = new Random();
int[] equationComponents = new int[2];
int correctAnswer = 0;

List<string> gameHistory = new List<string>();

Console.WriteLine("Welcome. Press any key to continue.");
Console.ReadKey();
Console.Clear();

do
{
    Console.Clear();
    chosenOption = ChooseGame();
    switch (chosenOption)
    {
        case '1':
        case '2':
        case '3':
        case '4':
            StartGame();
            break;
        case '5':
            // 1
            break;
        case '6':
            ShowGameHistory();
            break;
        case '7':
            break;
    }
} while (chosenOption != '7');
Console.WriteLine("The code ends here.");

char ChooseGame()
{
    while (true)
    {
        Console.WriteLine(@"Choose game by pressing a number: 
1. Addition
2. Subtraction
3. Multiplication
4. Division
5. Random Game
6. View Previous Games
7. End Game");

        userKeyInput = Console.ReadKey().KeyChar;
        Console.Clear();
        if (!char.IsDigit(userKeyInput))
        {
            Console.WriteLine("Invalid Input.\n");
            continue;
        }
        else return userKeyInput;
    }
}

void StartGame()
{
    string gameResultName = "";
    string gameName = "";
    int numberOfRounds = 0;
    int score = 0;

    while (true)
    {
        Console.WriteLine("How many times would you like to play?");
        userStringInput = Console.ReadLine();
        if (userStringInput != null)
        {
            int.TryParse(userStringInput, out numberOfRounds);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Please answer with a number.");
            continue;
        }
        break;
    }

    // Play the game the amount of time the user inputs 
    for (int i = 0; i < numberOfRounds; i++)
    {
        do
        {
            equationComponents[0] = random.Next(difficultyRangeMin, difficultyRangeMax);
            equationComponents[1] = random.Next(difficultyRangeMin, difficultyRangeMax);

            Array.Sort(equationComponents);
            Array.Reverse(equationComponents);


            switch (chosenOption)
            {
                case '1':
                    correctAnswer = equationComponents[0] + equationComponents[1];
                    gameResultName = "sum";
                    gameName = "Addition";
                    break;
                case '2':
                    correctAnswer = equationComponents[0] - equationComponents[1];
                    gameResultName = "difference";
                    gameName = "Subtraction";
                    break;
                case '3':
                    correctAnswer = equationComponents[0] * equationComponents[1];
                    gameResultName = "product";
                    gameName = "Multiplication";
                    break;
                case '4':
                    if (equationComponents[0] % equationComponents[1] != 0)
                        continue;

                    correctAnswer = equationComponents[0] / equationComponents[1];

                    gameResultName = "quoient";
                    gameName = "Division";
                    break;
            }
            break;
        } while (true);

        while (true)
        {
            Console.WriteLine($"What is the {gameResultName} of {equationComponents[0]} and {equationComponents[1]}?");

            userStringInput = Console.ReadLine();
            if (userStringInput != null && int.TryParse(userStringInput, out userAnswer))
            {
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please answer with a number.");
            }
        }

        if (userAnswer == correctAnswer)
        {
            Console.WriteLine("Your answer was correct!");
            score++;
        }
        else
        {
            Console.WriteLine("Your answer was incorrect.");
        }
    }

    // Add the game to history
    gameHistory.Add($"{gameHistory.Count+1}. {gameName} | Score {score}/{numberOfRounds}");

    Console.WriteLine($@"Game over. Your final score is {score}/{numberOfRounds}");
    Console.WriteLine("Press any key to go back to main menu.");
    Console.ReadKey();
}

void ShowGameHistory()
{
    Console.Clear();

    if (gameHistory.Count == 0)
    {
        Console.WriteLine("No data yet. Go and play!!");
        Console.WriteLine("Press any key to go back to main menu.");
        Console.ReadKey();
        return;
    }

    Console.WriteLine("Game History\n");

    foreach (string game in gameHistory)
    {
        Console.WriteLine(game);
    }

    Console.WriteLine("Press any key to go back to main menu.");
    Console.ReadKey();
}