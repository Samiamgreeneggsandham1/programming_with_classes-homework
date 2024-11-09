using System;
using System.Threading;
using System.Reflection.PortableExecutable;
using System.ComponentModel;

public abstract class Activity
{
    private string _activityName;
    private string _activityDescription;

    public Activity(string name, string description)
    {
        _activityName = name;
        _activityDescription = description;
    }

    public void DisplayStartMessage()
    {
        Console.WriteLine($"\nWelcome to the {_activityName} Activity.\n\n{_activityDescription}\n");
    }

    public void DisplayEndMessage(int duration)
    {
        Console.WriteLine("\nGreat job!");
        DisplaySpinner(2);
        Console.WriteLine($"\nYou have completed another {duration} seconds of the {_activityName} activity!");
        DisplaySpinner(2);
    }

    public abstract void PerformActivity(int duration);


    public static void DisplaySpinner(int durationInSeconds)
    {
        string[] spinnerCharacters = {"|", "\\", "-", "/" };
        int spinnerIndex = 0;
        int totalIterations = (durationInSeconds * 1000) / 250;

        for (int i = 0; i < totalIterations; i++)
        {
            Console.Write(spinnerCharacters[spinnerIndex]);
            Thread.Sleep(250);
            Console.Write("\b \b");

            spinnerIndex = (spinnerIndex + 1) % spinnerCharacters.Length;
        }

    }
    public void StartActivity()
    {
        Console.Write("How long, in seconds, would you like for your session? ");
        if (int.TryParse(Console.ReadLine(), out int duration))
        {
            PerformActivity(duration);
        }
        else
        {
            Console.WriteLine("Invalid duration input. Please enter a valid number.");
        }
    }
}