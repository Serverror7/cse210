public class Word
{
    private string _word;
    private bool _isHidden;
    private int _length;

    public bool IsHidden()
    {
        return _isHidden;
    }
    public string Display()
    {
        if (_isHidden == true)
        {
            string blank = new string('_', _length);
            return blank; // https://stackoverflow.com/questions/411752/best-way-to-repeat-a-character-in-c-sharp
        }
        else
        {
            return _word;
        }
    }
    public Word Hide()
    {
        _isHidden = true;
        return this;
    }

    public Word(string word)
    {
        _word = word;
        _length = word.Length;
        _isHidden = false;
    }
}