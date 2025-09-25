using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is the magic number? ");
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100);
        int numGuess = 0;
        
        while (numGuess != magicNumber)
        {
            Console.Write("What is your guess? ");
            string Guess = Console.ReadLine();
            numGuess = int.Parse(Guess);
            if (numGuess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else if (numGuess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}