using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished."); // Describe what the user is doing

        bool isZero = false; // Declare a boolean variable to close the while loop later

        List<int> numbers = new List<int>(); // Introduce the list with which we will be working

        while (!isZero) // While loop to allow multiple user inputs until user inputs 0
        {
            Console.Write("Enter number: ");
            string userInput = Console.ReadLine();
            int number = int.Parse(userInput);

            if (number != 0)
            {
                numbers.Add(number);
            }
            else if (number == 0)
            {
                isZero = true;
            }
        }

        int sum = 0; // Declare initial sum value

        foreach (int num in numbers)
        {
            // Console.Write(num + " "); // Started on the stretch challenge, didn't follow through
            sum += num; // Finding the sum of the list
        }

        float average = (float)sum / (numbers.Count); // Finding the average of the list

        int largest = numbers.Max(); // Finding the biggest number in the list

        Console.WriteLine(); // Pretty up the program with an extra line here :)
        Console.WriteLine($"The sum of your list is: {sum}"); // Output the sum of the list
        Console.WriteLine($"The average of your list is: {average}"); // Output the average of the list
        Console.WriteLine($"The largest number in your list is: {largest}"); // Output biggest number
    }
}