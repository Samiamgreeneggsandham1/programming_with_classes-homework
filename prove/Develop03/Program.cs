using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

public class Program
{
    public static void Main(string[] args)
    {
        Scripture scripture = LoadScripture();
        RunMemorizer(scripture);
    }

public static Scripture LoadScripture()
{
    var reference = Reference.CreateFromUserInput();

    Console.Write("Enter the scripture text: ");
    string scriptureText = Console.ReadLine();

    return new Scripture(reference, scriptureText);
}

    public static void RunMemorizer(Scripture scripture)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsFullyHidden())
            {
                Console.WriteLine("All words are hidden! Memorization complete.");
                break;
            }

            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideWords(2); // Adjust the number of words hidden each time as needed.
        }
    }
}