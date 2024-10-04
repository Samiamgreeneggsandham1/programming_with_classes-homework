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
            Guess.RunGuessNumber(); // Only runs guess_number
        }
        else if (args.Length > 0 && args[0] == "costume")
        {
            Costume nurse = new();
            nurse.headwear = "face mask";
            nurse.gloves = "nitrile gloves";
            nurse.shoes = "orthopedic sneakers";
            nurse.upperGarment = "scrubs";
            nurse.lowerGarment = "scrubs";
            nurse.accessory = "stethoscope";

            Costume detective = new();
            detective.headwear = "fedora";
            detective.gloves = "leather";
            detective.shoes = "loafers";
            detective.upperGarment = "trench coat";
            detective.lowerGarment = "slacks";
            detective.accessory = "magnifying glass";

            Costume rancher = new();
            rancher.headwear = "cowboy hat";
            rancher.gloves = "work";
            rancher.shoes = "boots";
            rancher.upperGarment = "fancy vest";
            rancher.lowerGarment = "jeans";
            rancher.accessory = "lasso";

            nurse.ShowWardrobe();
            detective.ShowWardrobe();
            rancher.ShowWardrobe();
        }
        else
        {
            Console.WriteLine("Hello Sandbox World!");
        }
    }
}