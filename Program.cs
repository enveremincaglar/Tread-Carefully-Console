Random random = new Random();

// Variables
int[] randomNumbers = new int[10];
bool loopStop = false;
int counter = 1;
randomNumbers[0] = random.Next(1, 21);

// Generate Numbers
while (counter <= 10)
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
        randomNumbers[counter] = currentNumber;
        counter++;
    }
}

foreach (int num in randomNumbers)
{
    Console.WriteLine(num);
}

// Game
for (int i = 0; i < 5; i++)
{

    Console.Write($"Enter {i + 1}. Number: ");
    int userInput = Convert.ToInt32(Console.ReadLine());

    loopStop = false;

    foreach (int number in randomNumbers)
    {
        if (number == userInput)
        {

            loopStop = true;
            break;
        }
    }
    if (loopStop)
    {
        break;
    }
}

// Result
if (loopStop)
{
    Console.WriteLine("You Lose.");
    Console.ReadKey();
}
else
{
    Console.WriteLine("You Won");
    Console.ReadKey();
}