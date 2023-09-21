namespace Blackjack;

public enum Suits {Hearts, Spades, Diamonds, Clubs}
public enum Values {Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King}
    
public class PlayingDeck
{
    public PlayingDeck(int numberOfDecks = 1)
    {   
        NumberOfDecks = numberOfDecks;
        Deck = new Queue<Card>();
        DiscardPile = new Queue<Card>();
        
        CreateDeck();
    }
    
    public int NumberOfDecks { get; set; }
    
    public Queue<Card> DiscardPile { get; set; }

    public Queue<Card> Deck { get; set;}
    
    public void AddCard(Card card)
    {
        Deck.Enqueue(card);
    }

    public void DiscardCard()
    {
        Card discarded = Deck.Dequeue();
        DiscardPile.Enqueue(discarded);
    }
    
    public void CreateDeck()
    {
        for (int x = 0; x < NumberOfDecks; x++)
        {
            foreach (var i in Enum.GetValues(typeof(Suits)))
            {
                foreach (var j in Enum.GetValues(typeof(Values)))
                {
                    Card card = new((Suits)i, (Values)j);
                    Deck.Enqueue(card);
                }
            }    
        }
        
    }
}