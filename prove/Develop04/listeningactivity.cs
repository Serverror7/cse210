
using System.Runtime.InteropServices.Marshalling;

public class ListingActivity : Activity
{
    public void ActivityInitialize()
    {
        SetName("Breathing Activity");
         
//The description of this activity should be something like: "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
        SetDescription("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
    }
    public void StartListing()
    { // The activity should begin with the standard starting message 
        DisplayStartingMessage();
        double duration = GetDuration(); // and prompt for the duration that is used by all activities.
        // After the starting message, select a random prompt to show the user such as:

        List<string> prompts = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        Random rand = new Random(); 
        string prompt = prompts[rand.Next(prompts.Count)]; // Select a random prompt

        Console.WriteLine($"Think about the prompt. Answer it. {prompt}"); // Display the prompt
        Timer(3, true); // After displaying the prompt, the program should give them a countdown
        //  of several seconds to begin thinking about the prompt. 
        
        Console.WriteLine("\nGo ahead, list them out:"); // Then, it should prompt them to keep listing items.
        double elapsedTime = 3; // we start here because the timer above takes is 3 seconds long
        int itemCount = 0;
        DateTime currentDateTime = DateTime.Now;
        DateTime endDateTime = DateTime.Now;
        var TimeDifference = DateTime.Now - DateTime.Now;
        while (elapsedTime < duration)
        {
            Console.ReadLine(); // The user lists.... This is a unique challange because the program essentially halts on this readline.
            itemCount = itemCount + 1; // as many items as they can 
            // until they they reach the duration specified by the user at the beginning. 
            endDateTime = DateTime.Now;
            TimeDifference = endDateTime - currentDateTime; // https://www.influxdata.com/blog/current-time-c-guide/
            elapsedTime = TimeDifference.TotalSeconds + elapsedTime; // converts time diference to double and adds it to elapsed time https://www.c-sharpcorner.com/article/get-difference-between-two-dates-in-C-Sharp/
        }

        Console.WriteLine($"You listed {itemCount} items!"); // The activity them displays back the number of items that were entered.

        DisplayEndingMessage();// The activity should conclude with the standard finishing message for all activities.
    }
}


