using System;

public class PromptGenerator
{
    private string[] prompts = new string[]
    {
        "What was the best part of your day?",
        "What did you learn today?",
        "How did you help someone today?",
        "What made you smile today?",
        "What are you grateful for today?",
        "Why are you happy today?",
        "Write a short story about today.",
        "Write a poem about today.",
        "Write about something that made you angry today.",
        "Write about a fictional/small challenge you could overcome.",
        "Think about a new outlet you can focus on. Write about it."
    };

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(prompts.Length);
        return prompts[index];
    }
}
