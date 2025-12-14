// a card is composed of a card name, mana cost, and rules text.
using System.Data;

public class Card
{
    private string _name;
    private Mana _mana; // Mana is used for casting creatures
    private string _supertype; // I.E. Legendary or Basic
    private string _cardtype; // I.E. Creature or Enchantment for example, although this includes other variants, such as Battle and Tribal Enchantments
    private string _rulestext; // text box
    private string _subtype; // After the type, for example, "Creature - Human Soldier" represents a creature with 1 supertype and 2 subtypes.
    
    public virtual void DisplayCard()
    {
        Console.WriteLine($"--{GetName()}----------------{_mana.PrintMana()}\n{GetSupertype()} {GetCardtype()} - {GetSubtypes()}\n{GetRulestext()}\n------------------------\n");
    }
    public void SetName(string name)
    {
        _name = name;
    }
    public void SetMana(Mana mana)
    {
        _mana = mana;
    }
    public void SetSupertype(string supertype)
    {
        _supertype = supertype;
    }
    public void SetCardtype(string cardtype)
    {
        _cardtype = cardtype;
    }
    public void SetRulestext(string rulestext)
    {
        _rulestext = rulestext;
    }
    public void SetSubtypes(string subtypes)
    {
        _subtype = subtypes;
    }
    public string GetName()
    {
        return _name;
    }
    public Mana GetMana()
    {
        return _mana;
    }
    public string GetColor()
    {
        string color = null;
        if (_mana.GetWhiteCost() > 0)
        {
            color += " White ";
        }
        if (_mana.GetBlackCost() > 0)
        {
            color += " Black ";
        } 
        if (_mana.GetBlueCost() > 0)
        {
            color += " Blue ";
        } 
        if (_mana.GetRedCost() > 0)
        {
            color += " Red ";
        } 
        if (_mana.GetGreenCost() > 0)
        {
            color += " Green ";
        } 
        return color;
    }
    public string GetSupertype()
    {
        return _supertype;
    }
    public string GetCardtype()
    {
        return _cardtype;
    }
    public string GetRulestext()
    {
        return _rulestext;
    }
    public string GetSubtypes()
    {
        return _subtype;
    }
    public virtual void NewCard(string name, Mana manavalue, string supertype, string cardtype, string subtypes, string rulestext)
    {
        SetName(name);
        SetMana(manavalue);
        SetSupertype(supertype);
        SetCardtype(cardtype);
        SetSubtypes(subtypes);
        SetRulestext(rulestext);
    }
        public virtual string ExportCard()
    {
        try
        {
            return $"{GetCardtype()}|{GetName()}|{_mana.PrintMana()}|{GetSupertype()}|{GetSubtypes()}|{GetRulestext()}";
        }
        catch
        {
            return "";
        }
    }   
    public void CreateCard()
    {
        Mana mana = new Mana();
        string name = null;
        string supertype = null;
        string type = null;
        string subtype = null;
        string rulestext = null;
        Console.WriteLine("What is the card's name?");
        name = Console.ReadLine();
        Console.WriteLine("What is the card's supertype? Ie Legendary, Tribal, World, if none, just hit enter.");
        supertype = Console.ReadLine();
        Console.WriteLine("What type is this card? Ie Artifact, Enchantment, Instant");
        type = Console.ReadLine() + " Creature";
        Console.WriteLine("What subtypes does this card have? Ie Lesson, battle,");
        subtype = Console.ReadLine();
        Console.WriteLine("What is the card's rules text?");
        int i = 0;
        while (i == 0)
        {
            Console.WriteLine("Please enter your desired mana cost (X Generic cost W B U R G)");
            mana.StringToMana(Console.ReadLine());
            Console.WriteLine($"To confirm, this is {mana.PrintMana()} correct? y/N");
            string response = Console.ReadLine();
            if (response == "N")
            {
                i = 0;
            }
            else
            {
                i = 1;
            }
        }
        i = 0;
        NewCard(name, mana, supertype, type, subtype, rulestext);

    }
}
