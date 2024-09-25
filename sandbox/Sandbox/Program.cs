using System;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length > 0 && args[0] == "grading")
        {
            Grading.RunGradeCalculator(); // Only runs grading.cs
        }
        else if (args.Length > 0 && args[0] == "james_bond")
        {
            Bond.RunJamesBond(); // Only runs james_bond.cs
        }
        else if (args.Length > 0 && args[0] == "guess_number")
        {
            Guess.RunGuessNumber(); // Only runs guess_number.cs
        }
        else
        {
            Console.WriteLine("Hello Sandbox World!");
        }
    }
}