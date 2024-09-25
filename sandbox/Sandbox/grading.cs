using System;

class Grading
{
    public static void RunGradeCalculator()
    {
        Console.Write("What is your grade percentage? ");
        string userInput = Console.ReadLine();
        int number = int.Parse(userInput);

        string letterGrade;

        if (number <= 100 && number >= 90)
        {
            letterGrade = "A";
        }
        else if (number <= 89 && number >= 80)
        {
            letterGrade = "B";
        }
        else if (number <= 79 && number >= 70)
        {
            letterGrade = "C";
        }
        else if (number <= 69 && number >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }
        Console.WriteLine(letterGrade);

        if (number >= 70)
        {
            Console.WriteLine("Good job, you passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time, keep going!");
        }
    }
}