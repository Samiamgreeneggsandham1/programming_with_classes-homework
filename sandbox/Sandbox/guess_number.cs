using System;

class Guess
{
    public static void RunGuessNumber()
    {
        Console.Write("What is the magic number? ");
        string userInput = Console.ReadLine();
        int magicNumber = int.Parse(userInput);

        Console.Write("What is your guess? ");
        string userInput2 = Console.ReadLine();
        int guessNumber = int.Parse(userInput);

        if (guessNumber > magicNumber)
        {
            Console.WriteLine("Lower");
        }
        else if (guessNumber < magicNumber)
        {
            Console.WriteLine("Higher");
        }
    }
}