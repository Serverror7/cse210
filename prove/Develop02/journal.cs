public class Journal
{
    public List<Entry> _entries = new List<Entry> { };
    public void Display()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }
    public void Save(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            // You can add text to the file with the WriteLine method
            // outputFile.WriteLine("This will be the first line in the file.");
            //
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}/{entry._prompt}/{entry._userInput}");
            }
        }
    }
    // load file as journal
    
    public string[] Load(string filename)
    {
        string[] lines = System.IO.File.ReadAllLines(filename);
        // https://learn.microsoft.com/en-us/dotnet/api/system.io.file.readalllines?view=net-9.0 source 
        foreach (string line in lines)
        {
            string[] parts = line.Split("/");
            // Take line and cut into date, prompt, userinput
            Entry entry = new Entry();
            // Create a new entry
            entry._date = parts[0];
            // Save date to entry
            entry._prompt = parts[1];
            // Save prompt to entry
            entry._userInput = parts[2];
            // Save userinput to entry
            _entries.Add(entry);
        }
        return lines;
    }
}