/*
 * This is a math game containing the 4 basic operations
 * (addition, subtration, multiplication, division) with a
 * main menu to choose operations and record five(configurable)
 * previous games until the application ends.
 */
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;

Random random = new Random();
string? userInput;
int chosenMenu = 0;
bool validInput = false;

// Initialize variables for game history array
string[] gameHistory = new string[5];
string equationToAddToHistory = "";

StartGame();

void StartGame()
{
    // Add a "fancy" loading screen
    for (int i = 0; i < 3; i++)
    {
        Console.Write("Initializing Math Game");
        for (int j = 0; j < 3; j++)
        {
            Console.Write(".");
            Thread.Sleep(240);
        }
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.BufferWidth));
        Console.SetCursorPosition(0, Console.CursorTop);
    }

    while (true)
    {
        chosenMenu = ChooseOperation();

        Console.Clear();
        switch (chosenMenu)
        {
            case 1:
                Console.WriteLine("Player has chosen: Addition\n");
                Addition();
                break;
            case 2:
                Console.WriteLine("Player has chosen: Subtraction\n");
                Subtraction();
                break;
            case 3:
                Console.WriteLine("Player has chosen: Multiplication\n");
                Multiplication();
                break;
            case 4:
                Console.WriteLine("Player has chosen: Division\n");
                Division();
                break;
            case 5:
                Console.WriteLine("Player has chosen: History\n");
                ShowHistory();
                break;
        }
        if (chosenMenu == 6) break;
    }

    Console.WriteLine("\nExiting game...\nPress any key to continue.");
    Console.ReadKey();

}
int ChooseOperation()
{
    int desiredOperation = 0;
    do
    {
        Console.Clear();
        Console.WriteLine("Enter your desired operation using a number: ");
        Console.WriteLine(" 1. Addition\n 2. Subtraction\n 3. Multiplication\n 4. Division\n 5. History\n 6. End Game\n");

        userInput = Console.ReadLine();

        if (userInput != null && int.TryParse(userInput, out desiredOperation))
        {
            if (desiredOperation < 1 || desiredOperation > 6)
            {
                Console.WriteLine("Invalid input.");
                continue;
            }
        }
        validInput = true;
    } while (!validInput);

    return desiredOperation;
}

void Addition()
{
    int randomNumber1 = 0;
    int randomNumber2 = 0;
    int correctAnswer = 0;
    int userAnswer = 0;
    bool isCorrect = false;

    while (true)
    {
        randomNumber1 = random.Next(0, 100);
        randomNumber2 = random.Next(0, 100);
        correctAnswer = randomNumber1 + randomNumber2;

        while (true)
        {
            Console.WriteLine($"What is the sum of {randomNumber1} and {randomNumber2}?");

            userInput = Console.ReadLine();

            if (userInput != null && int.TryParse(userInput, out userAnswer))
            {
                isCorrect = userAnswer == correctAnswer ? true : false;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid answer. Please input a positive integer.");
                continue;
            }
            break;
        }

        if (isCorrect)
            Console.WriteLine("\nYou are correct! Congratulations!");
        else
            Console.WriteLine($"\nToo bad. You are incorrect.\nThe correct answer is {correctAnswer}");

        // Add game to history
        equationToAddToHistory = ($"The sum of {randomNumber1} and {randomNumber2}\nCorrect Answer: {correctAnswer}\t Player Answer: {userAnswer}");
        AddGameToHistory(gameHistory, equationToAddToHistory);

        // Ask user to play again or go back to the main menu
        while (true)
        {
            Console.WriteLine("\nPlay again?\n 1. Yes\n 2. No");
            userInput = Console.ReadLine();
            if (userInput != null && int.TryParse(userInput, out chosenMenu))
            {

                if (chosenMenu != 2 && chosenMenu != 1)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid answer.");
                    continue;
                }
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid answer.");
                continue;
            }

        }
        if (chosenMenu == 1)
        {
            Console.Clear();
            continue;
        }
        break;
    }
}

void Subtraction()
{
    int randomNumber1 = 0;
    int randomNumber2 = 0;
    int biggerNumber = 0;
    int smallerNumber = 0;
    int correctAnswer = 0;
    int userAnswer = 0;
    bool isCorrect = false;

    while (true)
    {
        randomNumber1 = random.Next(0, 100);
        randomNumber2 = random.Next(0, 100);
        biggerNumber = Math.Max(randomNumber1, randomNumber2);
        smallerNumber = Math.Min(randomNumber1, randomNumber2);


        correctAnswer = biggerNumber - smallerNumber;

        while (true)
        {
            Console.WriteLine($"What is the difference of {biggerNumber} and {smallerNumber}?");

            userInput = Console.ReadLine();

            if (userInput != null && int.TryParse(userInput, out userAnswer))
            {
                isCorrect = userAnswer == correctAnswer ? true : false;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid answer. Please input a positive integer.");
                continue;
            }
            break;
        }

        if (isCorrect)
            Console.WriteLine("\nYou are correct! Congratulations!");
        else
            Console.WriteLine($"\nToo bad. You are incorrect.\nThe correct answer is {correctAnswer}");

        // Add game to history
        equationToAddToHistory = ($"The difference of {biggerNumber} and {smallerNumber}\nCorrect Answer: {correctAnswer}\t Player Answer: {userAnswer}");
        AddGameToHistory(gameHistory, equationToAddToHistory);

        // Ask user to play again or go back to the main menu
        while (true)
        {
            Console.WriteLine("\nPlay again?\n 1. Yes\n 2. No");
            userInput = Console.ReadLine();
            if (userInput != null && int.TryParse(userInput, out chosenMenu))
            {

                if (chosenMenu != 2 && chosenMenu != 1)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid answer.");
                    continue;
                }
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid answer.");
                continue;
            }

        }
        if (chosenMenu == 1)
        {
            Console.Clear();
            continue;
        }
        break;
    }
}

void Multiplication()
{
    int randomNumber1 = 0;
    int randomNumber2 = 0;
    int correctAnswer = 0;
    int userAnswer = 0;
    bool isCorrect = false;

    while (true)
    {
        randomNumber1 = random.Next(0, 25);
        randomNumber2 = random.Next(0, 25);


        correctAnswer = randomNumber1 * randomNumber2;

        while (true)
        {
            Console.WriteLine($"What is the product of {randomNumber1} and {randomNumber2}?");

            userInput = Console.ReadLine();

            if (userInput != null && int.TryParse(userInput, out userAnswer))
            {
                isCorrect = userAnswer == correctAnswer ? true : false;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid answer. Please input a positive integer.");
                continue;
            }
            break;
        }

        if (isCorrect)
            Console.WriteLine("\nYou are correct! Congratulations!");
        else
            Console.WriteLine($"\nToo bad. You are incorrect.\nThe correct answer is {correctAnswer}");

        // Add game to history
        equationToAddToHistory = ($"The product of {randomNumber1} and {randomNumber2}\nCorrect Answer: {correctAnswer}\t Player Answer: {userAnswer}");
        AddGameToHistory(gameHistory, equationToAddToHistory);

        // Ask user to play again or go back to the main menu
        while (true)
        {
            Console.WriteLine("\nPlay again?\n 1. Yes\n 2. No");
            userInput = Console.ReadLine();
            if (userInput != null && int.TryParse(userInput, out chosenMenu))
            {

                if (chosenMenu != 2 && chosenMenu != 1)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid answer.");
                    continue;
                }
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid answer.");
                continue;
            }

        }
        if (chosenMenu == 1)
        {
            Console.Clear();
            continue;
        }
        break;
    }
}

void Division()
{
    int randomNumber1 = 0;
    int randomNumber2 = 0;
    int biggerNumber = 0;
    int smallerNumber = 0;
    int correctAnswer = 0;
    int userAnswer = 0;
    bool isCorrect = false;

    while (true)
    {
        // Check for divisibility
        do
        {
            randomNumber1 = random.Next(0, 100);
            randomNumber2 = random.Next(0, 100);
            biggerNumber = Math.Max(randomNumber1, randomNumber2);
            smallerNumber = Math.Min(randomNumber1, randomNumber2);
            
            if (biggerNumber % smallerNumber != 0)
                continue;

            correctAnswer = biggerNumber / smallerNumber;
            break;
        } while (true);

        while (true)
        {
            Console.WriteLine($"What is the quotient of {biggerNumber} and {smallerNumber}?");

            userInput = Console.ReadLine();

            if (userInput != null && int.TryParse(userInput, out userAnswer))
            {
                isCorrect = userAnswer == correctAnswer ? true : false;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid answer. Please input a positive integer.");
                continue;
            }
            break;
        }

        if (isCorrect)
            Console.WriteLine("\nYou are correct! Congratulations!");
        else
            Console.WriteLine($"\nToo bad. You are incorrect.\nThe correct answer is {correctAnswer}");

        // Add game to history
        equationToAddToHistory = ($"The quotient of {biggerNumber} and {smallerNumber}\nCorrect Answer: {correctAnswer}\t Player Answer: {userAnswer}");
        AddGameToHistory(gameHistory, equationToAddToHistory);

        // Ask user to play again or go back to the main menu
        while (true)
        {
            Console.WriteLine("\nPlay again?\n 1. Yes\n 2. No");
            userInput = Console.ReadLine();
            if (userInput != null && int.TryParse(userInput, out chosenMenu))
            {

                if (chosenMenu != 2 && chosenMenu != 1)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid answer.");
                    continue;
                }
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid answer.");
                continue;
            }

        }
        if (chosenMenu == 1)
        {
            Console.Clear();
            continue;
        }
        break;
    }
}

void AddGameToHistory(string[] array, string newHistory)
{
    // if there is space, add newHistory to array
    for (int i = 0; i < array.Length; i++)
    {
        if (string.IsNullOrEmpty(array[i]))
        {
            array[i] = newHistory;
            return;
        }
    }

    // if the array is full, replace from the bottom
    for (int i = 0; i < array.Length - 1; i++)
    {
        array[i] = array[i + 1];
    }
    array[^1] = newHistory;
}

void ShowHistory()
{
    // Show history from new to old
    Array.Reverse(gameHistory);
    foreach (string history in gameHistory)
    {
        if (!string.IsNullOrEmpty(history))
        {
            Console.WriteLine($"{history}\n");
        }
    }
    Array.Reverse(gameHistory);

    Console.WriteLine("Press any key to continue.");
    Console.ReadKey();
}