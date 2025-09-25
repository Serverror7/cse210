using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep5 World!");
        Program program = new Program();
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int birthYear = PromtUserBirthYear();
        int squaredNumber = SquareNumber(number);
        int age = CalculateAge(birthYear);
        DisplayResult(name, number, squaredNumber, age);
    }



    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();
        return userName;
    }
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string userNumber = Console.ReadLine();
        int number = int.Parse(userNumber);
        return number;
    }

    static int PromtUserBirthYear()
    {
        Console.Write("Please enter your birth year: ");
        string birthYear = Console.ReadLine();
        int birthYearInt = int.Parse(birthYear);
        return birthYearInt;
    }
    static int SquareNumber(int number)
    {
        int squaredNumber = number * number;
        return squaredNumber;
    }
    static int CalculateAge(int birthYear)
    {
        int currentYear = 2025;
        int age = currentYear - birthYear;
        return age;
    }
    static void DisplayResult(string name, int number, int squaredNumber, int age)
    {
        Console.WriteLine($"Hello {name}, your favorite number is {number}, its square is {squaredNumber}, and you will turn {age} this year!");
    }
}