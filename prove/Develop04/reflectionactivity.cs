
public class ReflectionActivity : Activity
{
    // The activity should begin with the standard starting message and prompt for the duration that is used by all activities.
    // This is inherited.

    // The description of this activity should be something like: "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."

    public void ActivityInitialize()
    {
        SetName("Reflection Activity");
        SetDescription("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
    }
    public void StartReflection()
    {
        DisplayStartingMessage();
        // After the starting message, select a random prompt to show the user such as:

        List<string> prompts = new List<string>()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        // After displaying the prompt, the program should ask the to reflect on questions that relate 
        // to this experience. These questions should be pulled from a list such as the following:
        List<string> questions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        Random rand = new Random(); 
        string prompt = prompts[rand.Next(prompts.Count)]; // Select a random prompt

        Console.WriteLine(prompt); // Display the prompt
        Timer(3, true); // Pause of a little bit + spinner
        // While the program is paused it should display a kind of spinner.
        double elapsedTime = 0;
        double duration = GetDuration();
        string question = null; // create question variable

        while (elapsedTime <= duration) // After each question the program should pause for several seconds before continuing to the next one. 

        {
            question = questions[rand.Next(questions.Count)]; // select question
            Console.WriteLine(question); // write
            Timer(5); // Pause + spinner
            elapsedTime += 5; // increment in 5
        } // if it is greather than or equal to duration, stop
        // It should continue showing random questions until it has reached the number of seconds 
        // the user specified for the duration.

        // The activity should conclude with the standard finishing message for all activities.
        DisplayEndingMessage();
    }
}


