namespace Blackjack;

public class PlayingDeck
{
    public PlayingDeck(int numberOfDecks = 1, bool autoDiscard = true)
    {   
        NumberOfDecks = numberOfDecks;
        AutoDiscard = autoDiscard;
        Deck = new Queue<Card>();
        DiscardPile = new Queue<Card>();
        
        // create and shuffle deck at creation
        CreateDeck();
        ShuffleDeck();
    }
    
    // Getters & Setters (Properties)
    public int NumberOfDecks { get; set; }
    public int Count
    {
        get => Deck.Count;
        
    }
    private bool AutoDiscard { get; set; }
    private Queue<Card> DiscardPile { get; set; }
    public Queue<Card> Deck { get; private set;}
    
    
    // Class Methods
    public void AddCardToDeck(Card card)
    {
        Deck.Enqueue(card);
    }

    public Card DrawCard()
    {
        // if no more cards in deck - empty discard pile into deck and shuffle
        if (Count < 1)
        {
            // if discard pile is also empty
            if (DiscardPile.Count < 1)
            {
                Console.WriteLine("All out of cards! Game over.");
            }
            else
            {
                AddDiscardPileToDeck();
            }
        }
        
        return Deck.Dequeue();
    }
    
    public void AddToDiscardPile(Card discardedCard)
    { 
        DiscardPile.Enqueue(discardedCard);
    }

    public void AddDiscardPileToDeck()
    {
        int itemCount = DiscardPile.Count; // number of cards in discard pile
        
        // add cards from discard pile to deck
        for (int i = 0; i < itemCount; i++)
        {
            AddCardToDeck(DiscardPile.Dequeue());
        }
        
        // shuffle the deck
        ShuffleDeck();
    }
    
    public void ShuffleDeck()
    {
        Random random = new();
        List<Card> tempList = new();
        int itemCount = Deck.Count; // number of cards to be shuffled
        
        // add all cards in deck to a temp list
        for (int i = 0; i < itemCount; i++)
        {
            tempList.Add(Deck.Dequeue());
        }
        
        // pick a random card from list and add it back into the deck
        for (int i = 0; i < itemCount; i++)
        {
            int randInt = random.Next(0, tempList.Count);
            Deck.Enqueue(tempList[randInt]);
            tempList.RemoveAt(randInt);
        }
        
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