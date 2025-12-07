using System.Runtime.InteropServices.Marshalling;

public class Quest
{   // Provide for simple goals that can be marked complete and the user gains some value. I call them points here
    private string _name;
    private string _description;
    private bool _completed;
    private int _points;
 /// Getters and setters for the love of the private variables. Do I have to explain them?
    public string GetName()
    {
        return _name;
    }
    public void SetName(string name)
    {
        _name = name;
    }
        public string GetDescription()
    {
        return _description;
    }
    public void SetDescription(string description)
    {
        _description = description;
    }
    public void SetCompletion(bool completed) 
    {
        _completed = completed;
    }
        public bool GetCompletion() 
    {
        return _completed;
    }
    public int GetScore()
    {
        return _points;
    }
    public void SetScore(int value)
    {
        _points = value;
    }
    // virtual classes I can edit in each subclass
       public virtual void CreateQuest(string name, string description, int points)
    {
        SetName(name);
        SetDescription(description);
        SetScore(points);
        SetCompletion(false);
    }
    public virtual int EventRegister()
    {
        if (GetCompletion() == false)
        {
            SetCompletion(true);
            return GetScore();
        }
        else
        {
            return 0;
        }
    }
    public virtual string QuestToSave()
    {
        return $"SR␉{GetCompletion()}␉{GetName()}␉{GetDescription()}␉{GetScore()}";
    }
    public virtual void LoadQuest(string[] data)
    { // 0 is the id, not used, order is string completion, string name, string description, string points
        SetName(data[2]);
        SetDescription(data[3]);
        try
        {
            SetScore(Int32.Parse(data[4]));
        }
        catch
        {
            SetScore(50);
        }

        if (data[1] == "True")
        {
            SetCompletion(true);
        }
        else
        {
            SetCompletion(false);
        }
    }
    public virtual string PassQuest()
    {
        string complete = null;
        if (GetCompletion() == true){
            complete = "✓"; 
        }
        else
        {
            complete = " ";
        }
        return $"[{complete}] {GetName()}. {GetDescription()}. {GetScore()} points";
    }
};