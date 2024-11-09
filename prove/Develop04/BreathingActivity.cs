using System;
using System.Threading;
using System.Security.Cryptography.X509Certificates;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."){}

    public override void PerformActivity(int duration)
    {
        DisplayStartMessage();

        int secondsElapsed = 0;
        int inhaleDuration = 6;
        int exhaleDuration = 9;

        while (secondsElapsed < duration)
        {
            Console.WriteLine("Breathe in...");
            Countdown(inhaleDuration);
            secondsElapsed += inhaleDuration;

            if (secondsElapsed >= duration) break;

            Console.WriteLine("Breathe out...");
            Countdown(exhaleDuration);
            secondsElapsed += exhaleDuration;
        }

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
