using System.Runtime.InteropServices;

public class BreathingActivity : Activity
{
    // The activity should begin with the standard starting message and prompt for the duration that is used by all activities.
    // this is inherited

    public void ActivityInitialize()
    {
        SetName("Breathing Activity"); // setters so that we can edit the private variables
        // The description of this activity should be something like: "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing."
        SetDescription("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
    }

    public void Breath(int Time = 12)
    {
        Console.WriteLine("Breathe in...");
        Timer(Time/2, true); // countdown timer for 4 seconds
        Console.Write("\b \b"); // Erase breathe in...
        Console.WriteLine("Breathe out...");
        Timer(Time/2, true); // countdown timer for 6 seconds
        Console.Write("\b \b"); // Erase breathe out... source: https://stackoverflow.com/questions/5195692/is-there-a-way-to-delete-a-character-that-has-just-been-written-using-console-wr
    }
    public void StartBreathing(int Time = 12)
    {
        // After the starting message, 
        DisplayStartingMessage();
        double duration = GetDuration();
        // the user is shown a series of messages alternating between "Breathe in..." and "Breathe out..."
        double elapsedTime = 0;
        for (elapsedTime = 0; elapsedTime < duration; )
        {
            Breath(Time);
            elapsedTime += Time; // each breath cycle takes 12 seconds
            Timer(Time, true); // small pause between cycles
            // After each message, the program should pause for several seconds and show a countdown.
            elapsedTime += Time;
        } // It should continue until it has reached the number of seconds the user specified for the duration.
        DisplayEndingMessage();
        // The activity should conclude with the standard finishing message for all activities.
    }
}
