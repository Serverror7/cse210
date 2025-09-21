using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What was your percentage score? ");
        string percentage = Console.ReadLine();
        string letterGrade = "";
        int number = int.Parse(percentage);
        if (number >= 90)
        {
            letterGrade = "A";
        }
        else if (number >= 80)
        {
            letterGrade = "B";
        }
        else if (number >= 70)
        {
            letterGrade = "C";
        }
        else if (number >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }
        Console.WriteLine($"Your grade is {letterGrade}.");
        if (number >= 70)
        {
            Console.Write("You passed the course! :) Congrats!");
        }
        else
        {
            Console.Write("You did not pass the class. :( Better luck next time!");
        }
    }
}