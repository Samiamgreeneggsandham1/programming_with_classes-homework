using System;

class Bond
{
    public static void RunJamesBond()
    {
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        Console.WriteLine();

        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}