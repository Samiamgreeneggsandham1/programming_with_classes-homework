using System;

class Program
{
    static void Main(string[] args)
    {
        Fractions primero = new Fractions();
        Console.WriteLine(primero.TheFraction());
        Console.WriteLine(primero.TheDecimal());

        Fractions segundo = new Fractions(5);
        Console.WriteLine(segundo.TheFraction());
        Console.WriteLine(segundo.TheDecimal());

        Fractions tercero = new Fractions(3, 4);
        Console.WriteLine(tercero.TheFraction());
        Console.WriteLine(tercero.TheDecimal());

        Fractions cuarto = new Fractions(1/3);
        Console.WriteLine(cuarto.TheFraction());
        Console.WriteLine(cuarto.TheDecimal());
    }
}