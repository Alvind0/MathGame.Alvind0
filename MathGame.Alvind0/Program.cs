/*
 * This is a math game containing the 4 basic operations
 * (addition, subtration, multiplication, division) with a
 * main menu to choose operations and record five(configurable)
 * previous games until the application ends.
 */
char userKeyInput;
string? userStringInput;
int chosenOption = 0, numberOfRounds = 0, difficultyLevel = 0, gameType = 0;

Random random = new Random();
int operandMax = 0;
int[] operands = new int[2];
int answer = 0, userAnswer = 0;
bool isCorrect = false;
string operandType = "", operationResult = "";

DateTime startTime, endTime;
TimeSpan totalTime;

List<string> gameHistory = new List<string>();

InitializeGame();
StartGame();

// Add a "fancy" loading screen
void InitializeGame()
{

    for (int i = 0; i < 3; i++)
    {
        Console.Write("Initializing Math Game");
        for (int j = 0; j < 3; j++)
        {
            Console.Write(".");
            Thread.Sleep(160);
        }
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.BufferWidth));
        Console.SetCursorPosition(0, Console.CursorTop);
    }
    Console.WriteLine("Welcome to the game. Press any key to continue. ");
    Console.ReadKey();
}

void StartGame()
{
    do
    {
        Console.Clear();
        Console.WriteLine(@"Choose a game: 
1. Addition
2. Subtraction
3. Multiplication
4. Division
5. Random Game
6. Game History
7. End Game");

        userKeyInput = Console.ReadKey().KeyChar;

        if (char.IsDigit(userKeyInput))
        {
            chosenOption = int.Parse(userKeyInput.ToString());
            if (chosenOption == 0 || chosenOption > 6) continue;
        }

        if (chosenOption == 6)
        {
            ShowHistory();
            continue;
        }

        PlayGame(chosenOption);
    } while (chosenOption != 7);
}

void PlayGame(int chosenOption, bool isRandom = false)
{
    int score = 0;

    if (chosenOption == 5) isRandom = true;
    else gameType = chosenOption;

    // Ask player for number of games
    while (true)
    {
        Console.Clear();
        Console.WriteLine("How many times would you like to play?");
        userStringInput = Console.ReadLine();

        if (userStringInput != null && int.TryParse(userStringInput, out numberOfRounds))
        {
            break;
        }
    }

    // Ask player for game difficulty
    while (true)
    {
        Console.Clear();
        Console.WriteLine(@"Choose difficulty:
1. Easy
2. Medium
3. Hard");

        userKeyInput = Console.ReadKey().KeyChar;
        if (char.IsDigit(userKeyInput))
        {
            difficultyLevel = int.Parse(userKeyInput.ToString());
            if (difficultyLevel == 0 || difficultyLevel > 3) continue;
            break;
        }
    }

    startTime = DateTime.Now;
    for (int i = 0; i < numberOfRounds; i++)
    {
        Console.Clear();
        if (isRandom)
        {
            gameType = random.Next(1, 5);
        }

        operands = GetOperands(difficultyLevel, gameType);

        switch (gameType)
        {
            case 1:
                answer = operands[1] + operands[0];
                operandType = "Addition";
                operationResult = "Sum";
                break;
            case 2:
                answer = operands[1] - operands[0];
                operandType = "Subtraction";
                operationResult = "Difference";
                break;
            case 3:
                answer = operands[1] * operands[0];
                operandType = "Multiplication";
                operationResult = "Product";
                break;
            case 4:
                answer = operands[1] / operands[0];
                operandType = "Division";
                operationResult = "Quotient";
                break;
        }

        Console.WriteLine($"What is the {operationResult.ToLower()} of {operands[1]} and {operands[0]}");
        userStringInput = Console.ReadLine();
        if (userStringInput != null && int.TryParse(userStringInput, out userAnswer))
        {
            isCorrect = userAnswer == answer;
        }

        if (isCorrect)
        {
            Console.WriteLine("You are correct!");
            score++;
        } else
        {
            Console.WriteLine($"You are incorrect. The answer is {answer}");
        }
        Console.ReadKey();
    }
    
    endTime = DateTime.Now;
    totalTime = endTime - startTime;

    if (isRandom) operandType = "Random";
    gameHistory.Add($"{DateTime.Now} | {totalTime.ToString(@"mm\:ss")} |{operandType}| {score} / {numberOfRounds}");
}

int[] GetOperands(int difficultyLevel, int gameType)
{
    int[] result = new int[2];

    switch (difficultyLevel)
    {
        case 1:
            operandMax = gameType != 4 ? 99 : 9;
            break;
        case 2:
            operandMax = gameType != 4 ? 999 : 99;
            break;
        case 3:
            operandMax = gameType != 4 ? 9999 : 999;
            break;
    }



    if (gameType == 4)
    {
        do
        {
            result[0] = random.Next(1, operandMax);
            result[1] = random.Next(1, operandMax);
            Array.Sort(result);
        } while (result[1] % result[0] != 0);

        return result;
    }


    result[0] = random.Next(1, operandMax);
    result[1] = random.Next(1, operandMax);
    Array.Sort(result);

    return result;

}
void ShowHistory()
{
    Console.Clear();
    if (gameHistory.Count == 0)
    {
        Console.WriteLine("No data yet.");
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