do
{
    PlayGame();
} while (AskToPlayAgain());

static void PlayGame()
{
    Console.Clear();
    Random randomGenerator = new Random();
    Dictionary<int, bool> mineStatues = new Dictionary<int, bool>();
    List<int> userInputs = new List<int>();
    List<int> trueSteps = new List<int>(); 

    
    for (int i = 1; i < 21; i++)
    {
        mineStatues[i] = false;
    }

    for (int i = 1; i < 21; i += 4)
    {
        mineStatues[randomGenerator.Next(i, i + 4)] = true;
    }

    Console.WriteLine("\t/----------------------[Start]---------------------\\");
    for (int tableNumber = 1; tableNumber < 21; tableNumber++)
    {
        Console.Write($"\t {tableNumber} \t");

        if (tableNumber % 4 == 0)
        {
            Console.WriteLine();
        }
    }
    Console.WriteLine("\t\\----------------------[Finish]--------------------/");

    Console.WriteLine();

    for (int repeatCount = 0; repeatCount < 5; repeatCount++) 
    {
        int checkedInput;
        int lowerBound = repeatCount * 4 + 1; 
        int upperBound = lowerBound + 3; 

        while (true)
        {
            Console.Write($"\t{repeatCount + 1}. Choose which number your next step will be [ {lowerBound} - {upperBound} ]: ");
            string inputStep = Console.ReadLine();
            int step;

            if (int.TryParse(inputStep, out step))
            {
                if (step >= lowerBound && step <= upperBound)
                {
                    checkedInput = step;
                    break;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"\tPlease enter a number between {lowerBound} and {upperBound}.\n");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\tInvalid input, please enter an integer.\n");
                Console.ResetColor();
            }
        }
        Console.Clear();

        
        userInputs.Add(checkedInput);

        if (mineStatues[checkedInput] == true)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"\tYou hit a mine at {checkedInput}!");
            Console.ResetColor();
            DisplayFinalTable(mineStatues, userInputs);
            Console.WriteLine("\tGame Over! You lost.");
            return; 
        }
        else
        {
            
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.ResetColor();
            trueSteps.Add(checkedInput); 
        }

        
        if (trueSteps.Count == 5)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\tCongratulations! You've won the game!");
            Console.ResetColor();
            DisplayFinalTable(mineStatues, userInputs);
            return; 
        }

        Console.WriteLine("\t/----------------------[Start]---------------------\\");
        for (int i = 1; i < 21; i++)
        {
            if (trueSteps.Contains(i))
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($"\t {i} \t");
                Console.ResetColor();
            }
            else if (i == checkedInput && mineStatues[checkedInput] == true)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($"\t {checkedInput} \t");
                Console.ResetColor();
            }
            else if (i == checkedInput)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($"\t {checkedInput} \t");
                Console.ResetColor();
            }
            else
            {
                Console.Write($"\t {i} \t");
            }

            if (i % 4 == 0)
            {
                Console.WriteLine();
            }
        }
        Console.WriteLine("\t\\----------------------[Finish]--------------------/");
    }

    if (trueSteps.Count == 5)
    {
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("\tCongratulations! You've won the game!");
        Console.ResetColor();
        DisplayFinalTable(mineStatues, userInputs);
    }
}

static void DisplayFinalTable(Dictionary<int, bool> mineStatues, List<int> userInputs)
{
    Console.WriteLine("\n\t/----------------------[Final Table]---------------------\\");
    for (int i = 1; i < 21; i++)
    {
        if (userInputs.Contains(i))
        {
            if (mineStatues[i])
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($"\t {i}* \t");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($"\t {i} \t");
            }
            Console.ResetColor();
        }
        else
        {
            Console.Write($"\t {i} \t");
        }

        if (i % 4 == 0)
        {
            Console.WriteLine();
        }
    }
    Console.WriteLine("\t\\----------------------[Finish]--------------------/\n");
}

static bool AskToPlayAgain()
{
    Console.Write("\nWould you like to play again? (y/n): ");
    string response = Console.ReadLine();
    return response?.Trim().ToLower() == "y";
}