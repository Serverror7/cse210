using System;

public class PromptGenerator
{
    private string[] prompts = new string[]
    {
        "What was the best part of your day?",
        "What did you learn today?",
        "How did you help someone today?",
        "What made you smile today?",
        "What are you grateful for today?"
    };

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(prompts.Length);
        return prompts[index];
    }
}
