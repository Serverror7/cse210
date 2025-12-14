using System;
using System.ComponentModel.Design;
using System.Data;
using System.Runtime.CompilerServices;
using System.Threading.Channels;
int run = 0;
string response = null;
int i = 0;
Collection cardpool = new Collection();
// Create packs and deck for draftsim.
Pack pack = new Pack();
Deck deck = new Deck();
// ready hand
Hand hand = new Hand();

Console.WriteLine("Welcome to the DRAFT Menu!!!"); 
while (run == 0)
{
    Console.WriteLine("\nSelect an option from among the following:\n\n  1. Create a new card\n  2. Search among cards in cardpool\n  3. Save playable cardpool\n  4. Load cardpool or deck\n  5. Build a deck in draft sim\n  6. Draw a sample hand from the deck.\n  7. Quit\n"); // Prompt text
    string choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            // edit card
            Console.WriteLine("\nWhat kind of card would you like to make? A Creature, a Land, or Other spell? (only the first character is needed. Caps optional.)");
            response = Console.ReadLine();
            if (response.Contains("C") || response.Contains("c")){
                Creature card = new Creature();
                card.CreateCeature();
                cardpool.AddCard(card);
                Console.WriteLine($"Your card, {card.GetName()} was Added to the cardpool.");
            }
            if (response.Contains("l") || response.Contains("L")){
                BasicLand card = new BasicLand();
                card.CreateLand();
                cardpool.AddCard(card);
                Console.WriteLine($"Your card, {card.GetName()} was Added to the cardpool.");
            }
            if (response.Contains("o") || response.Contains("O"))
            {
                Card card = new Card();
                card.CreateCard();
                cardpool.AddCard(card);
                Console.WriteLine($"Your card, {card.GetName()} was Added to the cardpool.");
            }
            break;
        case "2":
        Console.WriteLine("\nWhat would you like to do?\n1. View your entire collection\n2. Search for specific cards\n");
            response = Console.ReadLine();
            if (response == "1")
            {
                cardpool.DisplayCollection();
            }
            if (response == "2")
            {
                // search cards and Display cards from collection
                Console.WriteLine("\nSearch with the following term examples: \n \nSearching is case sensitive. \n\"n:elf\" or \"name:elf\" \"r:when\" or \"rulestext:when\" \"t:creature\" or \"type:instant\"");
                string searchPerameter = Console.ReadLine();
                cardpool.SearchCard(searchPerameter).DisplayCollection(); 
            }   
            break;
        case "3":
            // Get filename to save to
            Console.WriteLine("Please enter your desired file name");
            string filename = Console.ReadLine();
            cardpool.ExportCardlist(filename); // Add this code to the various collections we will be using.
            break;
        case "4":
        // load  from text file
            // ask for filename
            Console.WriteLine("Please enter your desired file name");
            filename = Console.ReadLine();
            Console.WriteLine("Is this a deck or a pool to take cards out of?");
            response = Console.ReadLine();
            if (response.Contains("p") || response.Contains("o") || response.Contains("l"))
            {
                cardpool.ImportCollection(filename);
                Console.WriteLine($"Imported {cardpool.Count()} cards.");  
            }
            if (response.Contains("d") || response.Contains("e") || response.Contains("c") || response.Contains("k"))
            {
                deck.ImportCollection(filename);
                Console.WriteLine($"Imported {deck.Count()} cards.");  
            }
            break;
        case "5":
            Collection draftpool = cardpool; // copy the collection so nothing bad happens to the cards.
            pack.Draft(draftpool, deck); // run draft program.
            if (deck.Count() > 40)
            {
                deck.DeckSave(); // save the deck
            }
            break;
        case "6":
            Console.WriteLine("\n");
            hand.DrawHand(deck);
            hand = new Hand();
            break;
        case "7":
        // end the program
        run = 1;
            break;

    }
}