using System;

Console.WriteLine("Welcome to the Activity Menu!!\n"); // Have a menu system to allow the user to choose an activity.
int run = 0;
int activitiesReflection = 0;
int activitiesBreathing = 0;
int activitiesListing = 0;
FileInfo logFilepath = new FileInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "csc.txt"));
while (run == 0)
{
    Console.WriteLine("Select an option from among the following:\n1. Start breathing activity\n2. Start reflecting activity\n3. Start listing activity\n4. Logged statistics\n5. Quit\n"); // Prompt text
    string choice = Console.ReadLine();
    switch (choice)
    {
        case "2":
            ReflectionActivity reflectionActivity = new ReflectionActivity();
            reflectionActivity.ActivityInitialize();
            reflectionActivity.StartReflection();
            activitiesReflection = activitiesReflection + 1;
            break;
        case "1":
            BreathingActivity breathingActivity = new BreathingActivity();
            breathingActivity.ActivityInitialize();
            breathingActivity.StartBreathing();
            activitiesBreathing = activitiesBreathing + 1;
            break;
        case "3":
            ListingActivity listingActivity = new ListingActivity();
            listingActivity.ActivityInitialize();
            listingActivity.StartListing();
            activitiesListing = activitiesListing + 1;
            break;
        case "4":
            Console.WriteLine($"You have completed {activitiesReflection + activitiesBreathing + activitiesListing} activities. These are composed of {activitiesBreathing} breathing activities, {activitiesReflection} reflection activities and {activitiesListing} listing activities.\n\nWould you like to save or load your progress? (s/l/n)");
            choice = Console.ReadLine();
            if (choice == "s")
            {
            // Save the logged activity
                try
                {
                    //Pass the filepath and filename to the StreamWriter Constructor
                    StreamWriter sw = new StreamWriter(logFilepath.ToString());
                    //Write a line of text
                    sw.WriteLine($"{activitiesReflection}+{activitiesBreathing}+{activitiesListing}");
                    //Close the file
                    sw.Close();
                    Console.WriteLine("File sucessfully saved");
                }
                catch(Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
            }
                if (choice == "l")
                {
                            // Open the file to read from.   

                            StreamReader sr = logFilepath.OpenText(); // https://learn.microsoft.com/en-us/dotnet/api/system.io.streamreader.read?view=net-10.0
                            string readText = sr.ReadToEnd(); // https://learn.microsoft.com/en-us/dotnet/standard/io/how-to-read-text-from-a-file

                            string[] activities = readText.Split("+");
                            activitiesReflection = int.Parse(activities[0]); // https://learn.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split
                            activitiesBreathing = int.Parse(activities[1]);
                            activitiesListing = int.Parse(activities[2]);
                }
                        break;
                case "5":
                            run = 1;
                            break;

                            // The interface for the program should remain generally true to the one shown in the video demo.
    }
}