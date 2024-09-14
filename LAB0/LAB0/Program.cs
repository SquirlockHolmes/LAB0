using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int lowNumber = GetNumber("Enter the low number: ");
        int highNumber = GetNumber("Enter the high number: ");

        while (highNumber <= lowNumber)
        {
            Console.WriteLine("High number must be greater than low number.");
            highNumber = GetNumber("Enter the high number: ");
        }

        int difference = highNumber - lowNumber;
        Console.WriteLine($"The difference between {lowNumber} and {highNumber} is {difference}");

        List<int> numbers = new List<int>();
        for (int i = lowNumber; i <= highNumber; i++)
        {
            numbers.Add(i);
        }

        using (StreamWriter writer = new StreamWriter("numbers.txt"))
        {
            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                writer.WriteLine(numbers[i]);
            }
        }

        int sum = 0;
        using (StreamReader reader = new StreamReader("numbers.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                sum += int.Parse(line);
            }
        }

        Console.WriteLine($"The sum of the numbers is {sum}");

        Console.WriteLine("Prime numbers between the given range:");
        foreach (int number in numbers)
        {
            if (IsPrime(number))
            {
                Console.WriteLine(number);
            }
        }
    }

    static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;
        for (int i = 3; i * i <= number; i += 2)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    static int GetNumber(string prompt)
    {
        int number;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}
