public class Deck : Collection
{
    public override void TakeCardFrom(Card card, Collection pack)
    {
        AddCard(card);
        pack.RemoveCard(card);
    }
    public void DeckCheck()
    {
        Console.WriteLine("\n\nTake a look at your deck as it is composed so far.\n\n");
        Console.ReadLine();
        DisplayCollection();
        Console.ReadLine();
        Console.Clear();
    }
    public void DeckSave()
    {
        Console.WriteLine("Would you like to save your deck? y/N");
        string selection = Console.ReadLine();
        if(selection != "N")
        {
            Console.WriteLine("Please enter your desired file name");
            string filename = Console.ReadLine();
            ExportCardlist(filename);
        }
    }
}