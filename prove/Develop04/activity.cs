using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public abstract class Activity{
    private string _name;
    private string _description;
    private double _duration;
    public void SetName(string name)
    {
        _name = name; // setters and getters because it says I cant edit these private variables in the other activities.
    }
    public string GetName()
    {
        return _name;
    }
    public void SetDescription(string description)
    {
        _description = description;
    }
    public string GetDescription()
    {
        return _description;
    }
    public void SetDuration(double duration)
    {
        _duration = duration;
    }
    public double GetDuration()
    {
        return _duration;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name}!\n {_description} \n How long would you like this activtity to last? (seconds)\n"); 
        _duration = Convert.ToDouble(Console.ReadLine()); // Source: https://stackoverflow.com/questions/24443827/reading-an-integer-from-user-input
    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine($"Well done!\n");
        Timer(3, true); // pause for a few seconds + countdown
        Console.WriteLine($"Thank you for participating in the {_name}!\n"); 
    } 
    public void Timer(double duration) // This converts seconds to a countdown timer
    {
        for (double i = duration; i > 0; i--)
        {
            Console.Write("+");

            Thread.Sleep(1000); // Pause for 1 second

            Console.Write("\b \b"); // Erase the + character
            Console.Write("-"); // Replace it with the - character
        }
    }
    public void Timer(double duration, bool isCounter) // This converts seconds to a countdown timer without a spindown
    {
        if (isCounter == true)
        {
            string DoubleAsString;
            int SpacesToDelete = 0;
            for (double i = duration; i > 0; i--)
            {
                Console.Write(i);
                DoubleAsString = i.ToString();
                SpacesToDelete = DoubleAsString.Length;

                Thread.Sleep(1000); // Pause for 1 second
                for (int f = SpacesToDelete;f > 0; f--) // for each space in the length,
                {
                    Console.Write("\b"); // Erase the character
                }
            }
        }
        else
        {
            for (double i = duration; i > 0; i--)
            {
                Console.Write(i);

                Thread.Sleep(1000); // Pause for 1 second

                Console.Write("\b \b"); // Erase the + character
                Console.Write("-"); // Replace it with the - character
            }
        }
            
    }
}