using System;
class Program
{
    static void Main(string[] args)
    {
        // create a journal
        Journal journal = new Journal();
        // create prompt generator object
        PromptGenerator promptgen = new PromptGenerator();
        int running = 1; // while running = 1, if running =/= 1 exit program.
        while (running != 0)
        {
            Console.WriteLine("Please select one of the following choices: \n0. Exit\n1. Write \n2. Display \n3. Load \n4. Save \n What would you like to do?");
            string userInput = Console.ReadLine();
            int userChoice = int.Parse(userInput);
            switch (userChoice)
            {
                case 1:// write an entry
                    Entry entry = new Entry();
                    Console.WriteLine("\n--- Writing Entry ---\n");
                    // get date and store it in theCurrentTime
                    DateTime theCurrentTime = DateTime.Now;
                    // Store as a string
                    string dateText = theCurrentTime.ToShortDateString();
                    // store the text in the entry
                    entry._date = dateText;
                    // get a random prompt
                    string prompt = promptgen.GetRandomPrompt();
                    entry._prompt = prompt;
                    // get user input
                    entry._userInput = Console.ReadLine();
                    // add entry to journal
                    journal.AddEntry(entry);
                    break;
                case 2:// display journal
                    journal.Display();
                    break;
                case 3:// load journal
                    Console.WriteLine("Please write filename to load:");
                    string filename = Console.ReadLine();
                    journal.Load(filename);
                    Console.WriteLine("File loaded.");
                    break;
                case 4:// save journal
                    Console.WriteLine("Please write filename to save as:");
                    string saveAs = Console.ReadLine();
                    journal.Save(saveAs);
                    Console.WriteLine("File saved.");
                    break;
                case 0: // exit
                    running = 0; // breaks while statement.
                    break;
                default:
                    break;
            } // I took this code from my previous class's assignment, and updated it for here.
            Console.WriteLine("\nPress any key to close...");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}

