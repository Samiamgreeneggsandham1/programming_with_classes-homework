using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are some people that you have helped this week?",
        "When have you felt the Holy Ghost this month, or at least recently?",
        "Who are some of your personal heroes?",
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."){}

    public override void PerformActivity(int duration)
    {
        DisplayStartMessage();

        Random random = new Random();

        string chosenPrompt = prompts[random.Next(prompts.Count)];

        Console.WriteLine($"List as many responses as you can to the following prompt:\n{chosenPrompt}\nYou may begin in:");

        Countdown(5);

        int itemCount = 0;
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Enter an item:\n");
            string item = Console.ReadLine();

            if (!string.IsNullOrEmpty(item))
            {
                itemCount++;
            }
        }

        Console.WriteLine($"You listed {itemCount} items!");

        DisplayEndMessage(duration);
    }

    private void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}