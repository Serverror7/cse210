using System;
using System.IO.Enumeration;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Scripture Memorizer!\n"); // Welcome message
        int run = 0;
        Scripture scripture = new Scripture("For God so loved the world", "John 3:16"); // Set scripture
        while (run == 0)
        {
            Console.WriteLine("Select an option from among the following, or hit enter to continue with the loaded verse:\n1. Continue with loaded scripture\n2. Import a scripture from scripture.txt file\n3. Create a ScriptureTemplate.txt file\n4. Quit\n"); // Prompt text
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine(scripture.Reference()+":\n"); // Pass and display reference
                    Console.WriteLine(scripture.Display()+"\n"); // Pass and display scripture text
                    MemorizeScripture(scripture); // Start memorization process
                    break;
                case "2":
                    Console.WriteLine("Enter the filename to import scripture from: (eg. scripture.txt)"); // Prompt text
                    string filename = Console.ReadLine();
                    scripture = ScriptureImport(filename); // Import scripture from text file can now be used 
                    break;
                case "3":
                    PreprareScriptureExport(); // Prepare scripture export template
                    Console.WriteLine("A template file named 'ScriptureTemplate.txt' has been created. Please edit the text with your reference and scripture and save it. Then continue with the program to import it."); // Inform user
                    break;
                case "4":
                    run = 1; // Quit
                    break;
                default:
                    Console.WriteLine(scripture.Reference()); // Pass and display reference
                    Console.WriteLine(scripture.Display()); // Pass and display scripture text
                    MemorizeScripture(scripture); // Start memorization process
                    break;
            }
        }
    }
static void MemorizeScripture(Scripture scripture)
        {
        while (!scripture.IsCompletelyHidden())
        {
            Console.WriteLine("Press Enter to hide a word or type 'quit' to exit:"); // Prompt text
            string input = Console.ReadLine(); // look for quit
            if (input == "quit")
            {
                break; // quit
            }
            scripture.Hidewords(); // Hide a word
            Console.WriteLine(scripture.Display()+"\n"); // Display scripture

        }
        Console.WriteLine("Press enter to exit:"); // Prompt text
        string exit = Console.ReadLine();
    }
    
    static Scripture ScriptureImport(string filename) // modified from https://byui-cse.github.io/cse210-course-2023/unit02/develop.html
    {
        string lines = System.IO.File.ReadLines(filename).First();
        string[] parts = lines.Split("' , '");
        string reference = parts[0];
        string words = parts[1];
        Scripture scripture = new Scripture(words, reference);
        return scripture;
    }
    static void PreprareScriptureExport() // modified from https://byui-cse.github.io/cse210-course-2023/unit02/develop.html
    {
        string filename = "ScriptureTemplate.txt"; // this function provides a template for exporting scripture to a text file

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            // You can add text to the file with the WriteLine method
            outputFile.WriteLine("place your reference here' , 'and your scripture text here");
        }
    }
}
