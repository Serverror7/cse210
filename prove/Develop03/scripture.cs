public class Scripture
{
    private List<Word> _words;
    private string _reference;
    private bool _isCompletelyHidden;
    public void Hidewords()
    {
        Random random = new Random();
        int index = random.Next(0, _words.Count);
        if (_words[index].IsHidden())
        {
            Hidewords();
            return;
        }
        Word HiddenWord = _words[index];
        _words[index] = HiddenWord.Hide();
    }

    public bool IsCompletelyHidden()
    {
        if (_words.All(word => word.IsHidden()))
        {
            _isCompletelyHidden = true;
        }
        else
        {
            _isCompletelyHidden = false;
        }
        return _isCompletelyHidden;
    }
    public string Reference()
    {
        return _reference;
    }
    public string Display()
    {
        string displayText = _reference + " ";
        foreach (Word word in _words)
        {
            displayText += word.Display() + " ";
        } 
        return displayText;
    }
    public Scripture(string verse, string reference)
    {
        List<string> wordStrings = verse.Split(" ").ToList();
        List<Word> words = new List<Word>();
        foreach (string wordString in wordStrings)
        {
            Word word = new Word(wordString);
            words.Add(word);
        }
        _words = words;
        _reference = reference;
    }

}