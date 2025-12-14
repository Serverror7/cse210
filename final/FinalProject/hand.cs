public class Hand : Collection
{
    public override void TakeRandomCardFrom(Collection deck, int number = 1)
    {
        Random rnd = new Random();
        int r = rnd.Next(deck.Count());
        for (int i = 0; i < number; i++)
        { // random number the size of the list then the card at that position which is then taken from the first collection and put into the second.
            TakeCardFrom(deck.GetCardFromPos(rnd.Next(deck.Count())), deck);
        }
    }
    public void DrawHand(Deck deck)
    {
        TakeRandomCardFrom(deck, 7);
        DisplayCollection();
    }
}