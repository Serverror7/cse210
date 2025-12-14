public class BasicLand : Card
{
    public override void NewCard(string name, Mana setnull, string supertype, string cardtype, string subtypes, string rulestext)
    {
        SetName(name); // Mountain
        SetSupertype("Basic");
        SetMana(null);
        SetCardtype("Land");
        SetSubtypes(subtypes); // Mountain
        SetRulestext(rulestext); // if needed?
    }
    public override string ExportCard()
    {
        return $"{GetCardtype()}|{GetName()}|0|{GetSupertype()}|{GetSubtypes()}|{GetRulestext()}";
    }
        public override void DisplayCard()
    {
        Console.WriteLine($"--{GetName()}-------------------\n{GetSupertype()} {GetCardtype()} - {GetSubtypes()}\n{GetRulestext()}\n");
    }
    public void CreateLand()
    {
        string name = null;
        string subtype = null;
        string rulestext = null;
        Console.WriteLine("What is the land's name?");
        name = Console.ReadLine();
        Console.WriteLine("What are the land's subtype(s)? Ie Mountain, Island");
        subtype = Console.ReadLine();
        Console.WriteLine("What is the land's rules text? Ie Tap for mana");
        rulestext = Console.ReadLine();
        NewCard(name, null, null, null, subtype, rulestext);
    }
}