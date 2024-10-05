using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Welcome to the Journal Program!");

        JournalPrompts journalPrompts = new JournalPrompts();

        bool exitProgram = false;

        while (!exitProgram)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1: Write");
            Console.WriteLine("2: Display");
            Console.WriteLine("3: Load");
            Console.WriteLine("4: Save");
            Console.WriteLine("5: Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt1 = journalPrompts.GetRandomPrompt();
                    Console.WriteLine(prompt1);
                    Console.Write("> ");
                    string response1 = Console.ReadLine();
                    journalPrompts.AddEntry(response1, prompt1);
                    break;

                case "2":
                    journalPrompts.DisplayEntries();
                    break;

                case "3":
                    Console.WriteLine("What is the file name?\n");
                    string loadFileName = Console.ReadLine();
                    Load loader = new Load();
                    loader.LoadEntriesFromFile(loadFileName, journalPrompts);
                    break;

                case "4":
                    Console.WriteLine("What is the file name?\n");
                    string saveFileName = Console.ReadLine();
                    Save saver = new Save();
                    saver.SaveEntriesToFile(saveFileName, journalPrompts);
                    break;

                case "5":
                    exitProgram = true;
                    break;

                default:
                    Console.WriteLine("Choice not valid, please try again.");
                    break;
            }
        }
    }
}