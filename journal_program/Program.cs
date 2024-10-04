using System;

public class Journal;
{
    public static void PresentTheChoice()
    {
        bool wantToClose = false;

        while (!wantToClose)
        {
            Console.WriteLine("ENTER THE LIST OF CHOICES HERE");

            string userInput = Console.ReadLine();
            int user_Choice;

            bool isValidInput = int.TryParse(userInput, out userChoice);

            if (isValidInput)
            {
                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("Aight bet.");
                        break;

                    case 2:
                        Console.WriteLine("Ok, interesting.");
                        break;

                    case 3:
                        Console.WriteLine("Strange choice.");
                        break;

                    case 4:
                        Console.WriteLine("Bussin frfr.");
                        break;

                    case 5:
                        wantToClose = true;
                        break;
                    default:
                        Console.WriteLine("Hey, that ain't a valid input, try it again bucko!");
                        break;
                }
            }
            else ()
            {
                Console.Write("Hey, that ain't a valid input, please enter a number between 1 and 5.");
            }
        }
    }
}
