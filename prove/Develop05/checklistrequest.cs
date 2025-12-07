using System.Threading.Channels;

class ChecklistRequest : Quest
{
    private int _tasks;
    private int _completed;
    private int _bonus;
    public virtual void CreateQuest(string name, string description, int points, int bonusvalue, int repititions)
    {
        SetName(name);
        SetDescription(description);
        SetScore(points);
        SetCompletion(false);
        _bonus = bonusvalue;
        _tasks = repititions;
        _completed = 0;
    }

    // Provide for a checklist goal that must be accomplished a certain number of times to be complete. Each time the user records this goal they gain some value, but when they achieve the desired amount, they get an extra bonus.
    public override string QuestToSave()
    {
        return $"CK␉{GetCompletion()}␉{GetName()}␉{GetDescription()}␉{GetScore()}␉{_tasks}␉{_completed}␉{_bonus}";
    }
    public override void LoadQuest(string[] data)
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
        try
        {
            _tasks = Int32.Parse(data[5]);
        }
        catch
        {
            _tasks = 3;
        }
        try
        {
            _bonus = Int32.Parse(data[7]);
        }
        catch
        {
            _bonus = 40;
        }
        try
        {
            _completed = Int32.Parse(data[6]);
        }
        catch
        {
            _completed = 0;
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
    public override string PassQuest()
    {
        string complete = null;
        if (GetCompletion() == true){
            complete = "✓"; 
        }
        else
        {
            complete = " ";
        }
        return $"[{complete}] {GetName()}. {GetDescription()}. {GetScore()} points. ({_completed}/{_tasks})";
    }
    public override int EventRegister()
    {
        if (GetCompletion() == false)
        {
            _completed = _completed+1;
            int score = score = GetScore();
            if (_completed  >= _tasks)
            {
                SetCompletion(true);
                score = score + _bonus;
            }
            return score;    
        }
        else
        {
            return 0;
        }
    }
}


