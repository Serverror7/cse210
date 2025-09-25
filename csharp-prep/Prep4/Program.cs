using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int number = -1;
        int sum = 0;
        int largest = 0;
        int i = -1;
        List<int> listylist = new List<int>();
        while (number != 0)
        {
            Console.Write("Enter a number: ");
            string numberString = Console.ReadLine();
            number = int.Parse(numberString);
            if (number > largest)
            {
                largest = number;
            }
            sum = sum + number;
            i = i + 1;
            listylist.Add(number);
        }
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The largest number is: {largest}");
        Console.WriteLine($"The average is: {sum / i}");
        Console.Write("The numbers are: ");
        foreach (int num in listylist)
        {
            Console.WriteLine(num);
        }
    }
}