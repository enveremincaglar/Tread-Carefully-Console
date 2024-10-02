Random random = new Random();

// Variables
int[] randomNumbers = new int[10];
bool loopStop = false;
int counter = 0;
int startNumber = random.Next(1, 21);

// Generate Numbers
while (counter < 10)
{
    int currentNumber = random.Next(1, 21);

    if (currentNumber != startNumber)
    {
        randomNumbers[counter] = currentNumber;
        counter++;
    }

}

// Game
for (int i = 0; i <= 4; i++)
{

    Console.Write($"Enter {i + 1}. Number: ");
    int userInput = Convert.ToInt32(Console.ReadLine());

    foreach (int number in randomNumbers)
    {
        if (number == userInput)
        {

            loopStop = true;
            break;
        }
    }
    if (loopStop == true)
    {
        break;
    }
}

// Result
if (loopStop == true)
{
    Console.WriteLine("You Lose.");
}
else
{
    Console.WriteLine("You Won");
}