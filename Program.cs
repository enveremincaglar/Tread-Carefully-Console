Random random = new Random();
bool retryGame = true;
do
{


    // Variables
    int[] randomNumbers = new int[10];

    int generateCounter = 1;
    int gameLoopCounter = 0;
    bool gameResult = true;
    randomNumbers[0] = random.Next(1, 21);

    // Generate Numbers
    while (generateCounter < 10)
    {
        int currentNumber = random.Next(1, 21);
        bool addCheck = true;

        foreach (int checkNumber in randomNumbers)
        {
            if (checkNumber == currentNumber)
            {
                addCheck = false;
                break;
            }
        }
        if (addCheck)
        {
            randomNumbers[generateCounter] = currentNumber;
            generateCounter++;
        }
    }
    // Game
    int[] previouslyNumbers = new int[5];
    do
    {
        bool numberFound = false;

        Console.Write($"Enter {gameLoopCounter + 1}. Number: ");
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int userInput))
        {
            if (userInput > 0 && userInput < 21 && !previouslyNumbers.Contains(userInput))
            {
                foreach (int checkNumber in randomNumbers)
                {
                    if (checkNumber == userInput)
                    {
                        numberFound = true;
                        gameResult = false;
                        break;
                    }
                }
                previouslyNumbers[gameLoopCounter] = userInput;
                gameLoopCounter++;
            }
            else
            {
                Console.WriteLine("Please enter a number between 1 and 20 or don't use the same numbers you used before.\n");
                continue;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.\n");

            continue; // Hatalı girişte döngünün başına dön
        }
        if (numberFound)
        {
            break;
        }
    } while (gameLoopCounter < 5);

    // Result
    if (!gameResult)
    {
        Console.WriteLine();
        Console.WriteLine("You Lose.");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("You Won");
        Console.ReadKey();
    }

    Console.WriteLine("\nNumbers are: ");

    Array.Sort(randomNumbers);
    foreach (int number in randomNumbers)
    {
        Console.Write(number + " ");
    }

    Console.WriteLine();
    Console.Write("\nThe game will restart. If you want to continue, press any key. If not, press 'q' to exit: ");
    string response = Console.ReadLine();

    if (response == "q")
    {
        break;
    }
    Console.Clear();



} while (retryGame);