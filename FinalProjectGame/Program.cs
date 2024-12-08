using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        bool exitProgram = false;

        while (!exitProgram)
        {
            Console.Clear();

            Console.WriteLine("Menu:\n    1. Continue Story\n    2. Inventory\n    3. Shop\n    4. Load Previous Game\n    5. Save Game\n    6. Quit");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    break;

                case "2":
                    break;
                    
                case "3":
                    break;

                case "4":
                    break;
                
                case "5":
                    break;

                case "6":
                    exitProgram = true;
                    break;

                default:
                    Console.WriteLine("Invaid Choice. Please enter a number between 1 and 6.");
                    break;
            }
        }
    }
}
