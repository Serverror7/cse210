public class Creature : Card
{
    private int _power;
    private int _toughness;

    public void SetPower(int power)
    {
        _power = power;
    }
    public void SetToughness(int toughness)
    {
        _toughness = toughness;
    }
    public override void DisplayCard()
    {
        Console.WriteLine($"--{GetName()}----------------{GetMana().PrintMana()}\n{GetSupertype()} {GetCardtype()} - {GetSubtypes()}\n{GetRulestext()}\n------------------------{_power} / {_toughness}\n");
    }
    public void NewCreature(string name, Mana manavalue, string supertype, string cardtype, string subtypes, string rulestext, int power, int toughness)
    {
        SetName(name);
        SetMana(manavalue);
        SetSupertype(supertype);
        SetCardtype(cardtype);
        SetSubtypes(subtypes);
        SetRulestext(rulestext);
        SetPower(power);
        SetToughness(toughness);
    }
    public override string ExportCard()
    {
        return $"{GetCardtype()}|{GetName()}|{GetMana().PrintMana()}|{GetSupertype()}|{GetSubtypes()}|{GetRulestext()}|{_power}|{_toughness}";
    }
    public void CreateCeature()
    {
        Mana mana = new Mana();
        string name = null;
        string supertype = null;
        string type = null;
        string subtype = null;
        string rulestext = null;
        int power = 0;
        int toughness = 0;
        Console.WriteLine("What is the creature's name?");
        name = Console.ReadLine();
        Console.WriteLine("What is the creature's supertype? Ie Legendary, Tribal, World, if none, just hit enter.");
        supertype = Console.ReadLine();
        Console.WriteLine("Does this creature have any additional types? Ie Artifact, if none, just hit enter.");
        type = Console.ReadLine() + " Creature";
        Console.WriteLine("What subtypes does this creature have? Ie Human Soldier Ally");
        subtype = Console.ReadLine();
        Console.WriteLine("What is the creature's rules text?");
        rulestext = Console.ReadLine();
        Console.WriteLine("What is the creature's power?");
        try
        {
            power = int.Parse(Console.ReadLine());
        }
        catch
        {
            power = 0;
        }
        Console.WriteLine("And Toughness?");
                        try
        {
            toughness = int.Parse(Console.ReadLine());
        }
        catch
        {
            toughness = 0;
        }
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
        NewCreature(name, mana, supertype, type, subtype, rulestext, power, toughness);
    }
}