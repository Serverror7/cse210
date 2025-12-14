// A collection is any list of cards. The reason it is a class is because it will be used to 
// simplify the differences between packs, decks, hands, and cubes, and because it enables us 
// to store simple functions for adding and removing cards, and more importantly faking a "shuffle"
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

public class Collection
{
    
    private List<Card> _cards;

    public List<Card> GetCards()
    {
        return _cards;
    }
    public void AddCard(Card card)
    {
        try
        {
            if (_cards == null)
            {
                _cards = new List<Card> {card};
            }
            else
            {
                _cards.Add(card);
            }   
        }
        catch
        {
            _cards = new List<Card> {card};
        }
    }
    public int Count()
    {
        try
        {
            return _cards.Count();
        }
        catch
        {
            return 0;
        }
    }
    public Card GetCardFromPos(int location)
    {
        try
        {
            Card card = _cards[location];
            return card;
        }
        catch
        {
            Card card = new Card();
            return card;
        }
        
    }
    public virtual Card SelectCard()
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
                }
            }
            catch
            {
                Console.WriteLine("No cards loaded. Or invalid selection."); 
            }
            try
            { 
                Console.WriteLine("Type your selection to edit from this collection");
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
    public Collection SearchCard(string searchPerameter)
    {
        // "n:wither" or "name:w" // "r:enter the" or "rulestext:battle" // "t:creature" or "type:instant"
        // the perameters are n / name, r / rulestext, t / type, c / color, and 
        // if the first search perameter is name, the program will search for a card with the components in the name.
        // the above code searches for either a wither or w in the name of the cards within the collection.
            // step 1 sanatize data
        string[] searchCard = searchPerameter.Split(":");
        // create variable to return to
        Collection results = new Collection();
        try
        {
            if (searchCard[0] == "n" || searchCard[0] == "name")
            {
                foreach (Card card in _cards)
                {
                    if (card.GetName().Contains(searchCard[1])== true)
                    {
                        results.AddCard(card);
                    }
                }
            }
            if (searchCard[0] == "r" || searchCard[0] == "rulestext")
            {
                foreach (Card card in _cards)
                {
                    if (card.GetRulestext().Contains(searchCard[1])== true)
                    {
                        results.AddCard(card);
                    }
                }
            }
            if (searchCard[0] == "t" || searchCard[0] == "type")
            {
                foreach (Card card in _cards)
                {
                    if (card.GetCardtype().Contains(searchCard[1])== true)
                    {
                        results.AddCard(card);
                    }
                }
            }
            if (searchCard[0] == "c" || searchCard[0] == "color")
            {
                foreach (Card card in _cards)
                {
                    if (card.GetColor().Contains(searchCard[1])== true)
                    {
                        results.AddCard(card);
                    }
                }
            }
        }
        catch
        {
            Console.WriteLine("There was an error with your query. Please ensure the card you are looking for exists and that you are using the query correctly.");
        }
        return results;
    }
    public void DisplayCollection()
    {
        try
        {
            foreach (Card card in _cards)
            {
                card.DisplayCard();
            }   
        }
        catch
        {
            Console.WriteLine("Error, no cards are loaded.");
        }
    }

    public void RemoveCard(Card card)
    {
        try
        {
            _cards.Remove(card);    
        }
        catch
        {
        }
    }
    
    public virtual void TakeCardFrom(Card card, Collection collectionfrom)
    {
        if (_cards == null)
        {
            _cards = new List<Card> {card};
        }
        else
        {
            _cards.Add(card);
        }
        collectionfrom.RemoveCard(card);
    }

    public virtual void TakeRandomCardFrom(Collection collectionfrom, int number = 1)
    {
        Random rnd = new Random();
        int r = rnd.Next(collectionfrom.Count());
        for (int i = 0; i < number; i++)
        { // random number the size of the list then the card at that position which is then taken from the first collection and put into the second.
            TakeCardFrom(collectionfrom.GetCardFromPos(rnd.Next(collectionfrom.Count())), collectionfrom);
        }
    }
    public virtual void ImportCard(string cardasstring) // text that takes a cardstring and imports it individually to the collection
    {
        string[] cardcut = cardasstring.Split("|");
        Mana mana = new Mana();
        mana.StringToMana(cardcut[2]);
        if (cardcut[0].Contains("Creature") == true)
        {
            Creature card = new Creature();
            card.NewCard(cardcut[1], mana, cardcut[3], cardcut[0], cardcut[4], cardcut[5]);
            try
            {
                card.SetPower(int.Parse(cardcut[6]));
            }
            catch
            {
                card.SetPower(0);
            }
            try
            {
            card.SetToughness(int.Parse(cardcut[7]));
            }
            catch
            {
                card.SetToughness(4);
            }
            AddCard(card);
        }
        if (cardcut[0].Contains("Land") == true)
        {
            BasicLand card = new BasicLand();
            card.NewCard(cardcut[1], null, cardcut[3], cardcut[0], cardcut[4], cardcut[5]);
            AddCard(card);
        }
        if (cardcut[0].Contains("Land") == false && cardcut[0].Contains("Creature") == false)
        {
            Card card = new Card();
            card.NewCard(cardcut[1], mana, cardcut[3], cardcut[0], cardcut[4], cardcut[5]);
            AddCard(card);
        }
//  $"{Cardtype}|{Name}|{PrintMana}|{Supertype}|{Subtypes}|{Rulestext}";

    }
    public void ImportCollection(string filename)
    {
        string[] lines = System.IO.File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            ImportCard(line);
        }
    }
    public void ExportCardlist(string filename) 
    {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Card card in _cards) // export each card iteravely
                {
                    outputFile.WriteLine(card.ExportCard()); // export each one on a new line
                }
            }
    }
}