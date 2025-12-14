using System.ComponentModel.Design;

public class Pack : Collection
{
    public void Draft(Collection collection, Deck deck)
    {
        if (collection.Count() < 5)
        {
            Console.WriteLine("\n\nDon't forget to import cards! To draft realistically you will need roughly 360! \n Press enter to continue.");
            Console.ReadLine();
            return;
        }
        Console.WriteLine("This program simulates an MTG draft deckbuilding experience. When you have finished this activity you can simulate drawing potential hands from it. According to magic.wizards.com:\n\n'How to draft: First, players sit around a table in a semi-circle. Each player then opens a booster pack and picks a single card without showing the other players.'\n\nDraft is a wonderful opportunity to learn how to build MTG decks. You will choose cards to build your deck with and once done you will play with that deck. \n\nThis variation of the draft format is brutal because you will be required to draft your lands as well. \n\n\nWhen you are ready to draft, hit any key.");
        Console.ReadLine();
        Console.Clear();
        List<Pack> packs = createPacks(collection);
        Card selection = null;
        foreach (Pack pack in packs)
        {
            selection = pack.SelectCard();
            Console.Clear();
            deck.TakeCardFrom(selection, pack);
        }
        deck.DeckCheck();
        packs = createPacks(collection);
        selection = null;
        foreach (Pack pack in packs)
        {
            selection = pack.SelectCard();
            Console.Clear();
            deck.TakeCardFrom(selection, pack);
        }
        deck.DeckCheck();
        packs = createPacks(collection);
        selection = null;
        foreach (Pack pack in packs)
        {
            selection = pack.SelectCard();
            Console.Clear();
            deck.TakeCardFrom(selection, pack);
        }
        Console.WriteLine("That's it!");
        deck.DeckCheck();
    }
    public List<Pack> createPacks(Collection collection)
    {
        Pack pack = new Pack();
        List<Pack> packs = new List<Pack>{pack};
        Random random = new Random();
        int i=0; // Three rounds of drafting so this process will be done tree times in the actual code
        for (i = 0; i < 15; i++)
        {
            pack = new Pack();
            pack.TakeRandomCardFrom(collection, 15-i);
            try
            {
                packs[i] = pack;
            }
            catch
            {
                packs.Add(pack);
            }
        } 
        return packs;     
    }
        
    public override Card SelectCard()
    {
        int run=0;
        int selection = 0;
        Card card1 = null;
        while (run == 0)
        {
            try
            {
                foreach (Card card in GetCards())
                {
                    Console.WriteLine(selection + 1);
                    card.DisplayCard();
                    selection += 1;
                }
            }
            catch
            {
                Console.WriteLine("No cards loaded. Or invalid selection."); 
            }
            try
            { 
                Console.WriteLine("Chose from the numbered cards above which you will take.");
                selection = int.Parse(Console.ReadLine());
                card1 = GetCardFromPos(selection - 1);
                run = 1;
            }
            catch
            {
                Console.WriteLine("Failed to parse selection.");
            }
        }
        return card1;
    }
    
}
