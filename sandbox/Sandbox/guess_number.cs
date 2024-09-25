using System;
using System.Runtime.CompilerServices;

class Guess
{
    public static void RunGuessNumber()
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100);

        bool isCorrect = false;

        while (!isCorrect)
        {
            Console.Write("What is your guess? ");
            string userInput2 = Console.ReadLine();
            int guessNumber = int.Parse(userInput2);

            if (guessNumber > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else if (guessNumber < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guessNumber == magicNumber)
            {
                isCorrect = true; // Set the Boolean thing to be true
                Console.WriteLine("Correct, well played!");
            }
        }
    }
}