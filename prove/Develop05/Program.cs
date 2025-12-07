using System;
using System.Runtime.CompilerServices;
using System.Threading.Channels;
int run = 0;
int points = 0;
string goalType = null;
string filename = null;
string goalname = null;
string description = null;
int value = 0;
int repititions = 0;
int bonusvalue = 0;
int number = 0;

bool scoreCollected = false;
List<Quest> quests = new List<Quest>();
SimpleQuest simpleQuest = new SimpleQuest();
EternalRequest eternalRequest = new EternalRequest();
ChecklistRequest checklistRequest = new ChecklistRequest();

Console.WriteLine("Welcome to the Activity Menu!!"); 
while (run == 0)
{
    Console.WriteLine("\nSelect an option from among the following:\n\n  1. Create a new goal\n  2. List goals\n  3. Save goals\n  4. Load goals\n  5. Record an event\n  6. Quit\n"); // Prompt text
    string choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
        // Create a new goal
            // Prompt the User for the type of goal
            Console.WriteLine("\nWhich kind of goal would you like to make?\n1. Simple Goal\n2. Eternal Goal\n3. Checklist Goal");
            goalType = Console.ReadLine();
            Console.WriteLine("\nEnter the name of your goal: ");
            goalname = Console.ReadLine();
            Console.WriteLine("\nWhat will you do for your goal? Describe it. ");
            description = Console.ReadLine();
            Console.WriteLine("\nHow many points will your goal be worth? ");
            value = 0;
            while (value == 0)
            {
                try
                {
                    value = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("\nI'm sorry, I couldn't parse that. Try again. "); 
                }
            }

            if(goalType == "1")
            {
                // goal code here
                simpleQuest.CreateQuest(goalname, description, value);
                quests.Add(simpleQuest);
            }
            if(goalType == "2")
            {
                eternalRequest.CreateQuest(goalname, description, value);
                // eternal goal code here
                quests.Add(eternalRequest);
            }
            if(goalType == "3")
            {
            Console.WriteLine("\nHow many times will your goal be done? ");
            repititions = 0;
            while (repititions == 0)
            {
                try
                {
                    repititions = Int32.Parse(Console.ReadLine());

                }
                catch
                {
                    Console.WriteLine("\nI'm sorry, I couldn't parse that. Try again. "); 
                }
            }
            Console.WriteLine("\nHow many bonus points will your goal be worth? ");
            bonusvalue = 0;
            while (bonusvalue == 0)
            {
                try
                {
                    bonusvalue = Int32.Parse(Console.ReadLine());

                }
                catch
                {
                    Console.WriteLine("\nI'm sorry, I couldn't parse that. Try again. "); 
                }
            }
                checklistRequest.CreateQuest(goalname, description, value, bonusvalue, repititions);
                // checklist goal code here
                quests.Add(checklistRequest);
            }
            Console.WriteLine("\nSucessfully added goal");
            break;
        case "2":
        // list goals
        Console.WriteLine($"\nYou have {points} points\n");
        foreach (Quest goal in quests)
            {
                number = number +1;
                Console.WriteLine($"{number}. {goal.PassQuest()}");
            } 
            number = 0;
            break;
        case "3":
        Console.WriteLine("\n");
        // save goals to text file
            // get filename to save to
            Console.WriteLine("Please enter your desired file name");
            filename = Console.ReadLine();

            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                // save score first
                outputFile.WriteLine(points);
                // save goals in order (format: )
                foreach (Quest quest in quests)
                {
                    outputFile.WriteLine(quest.QuestToSave());
                }
            }
            break;
        case "4":
        Console.WriteLine("\n");
        // load goals from text file
            // ask for filename
            Console.WriteLine("Please enter your desired file name");
            filename = Console.ReadLine();
            string[] lines = System.IO.File.ReadAllLines(filename);
            scoreCollected = false;
            foreach (string line in lines)
            {
                // extract score first
                if (scoreCollected == false)
                {
                    try
                    {
                        points = Int32.Parse(line); //https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Unable to parse '{line}'");
                        points = 0;
                    }
                    scoreCollected = true;
                }
                else{
                    // get as string representation

                    // convert from string to object
                    string[] parts = line.Split("␉"); // cut it into smalls strings

                    if (parts[0] == "SR") // look at first position in array for type
                    {
                        simpleQuest.LoadQuest(parts);
                        quests.Add(simpleQuest);
                    }
                    if (parts[0] == "ET") // look at first position in array for type
                    { // Eternal
                        eternalRequest.LoadQuest(parts);
                        quests.Add(eternalRequest);
                    }
                    if (parts[0] == "CK") // look at first position in array for type
                    { // Checklist
                        checklistRequest.LoadQuest(parts);
                        quests.Add(checklistRequest);
                    }
                }
            }
            break;
        case "5":
        // record a new event

        // list goals
        foreach (Quest goal in quests)
            {
                number = number +1;
                Console.WriteLine($"{number}. {goal.PassQuest()}");
            } 
            
        // select from goals reading user input
        Console.WriteLine("\n Which quest would you like to record to?");
            try
            {
                number = Int32.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("I couldn't parse that, please try again.");
                number = 0;
            }
            // award user with points.
            try
            {
            points = points + quests[number-1].EventRegister();
            Console.WriteLine($"\nCongrats, you now have {points} points.");   
            }
            catch
            {
                
            }
        number = 0;
            break;
        case "6":
        // end the program
        run = 1;
            break;

    }
}