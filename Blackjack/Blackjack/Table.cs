namespace Blackjack;

public class Table
{
    public Table(PlayingDeck deck)
    {
        Deck = deck;
        DealerCards = new List<Card>();
        PlayerCards = new List<Card>();
    }
    
    public List<Card> DealerCards { get; private set; }
    public List<Card> PlayerCards { get; private set; }
    private PlayingDeck Deck { get; set; }

    public void DealerGetsCard()
    {
        DealerCards.Add(Deck.DrawCard());
    }

    public void PlayerGetsCard()
    {
        PlayerCards.Add(Deck.DrawCard());
    }

    public void DiscardAllCards()
    {
        int numberOfCards = DealerCards.Count();
        for (int i = 0; i < numberOfCards; i++)
        {
            Deck.AddToDiscardPile(DealerCards[0]);
            DealerCards.RemoveAt(0);
        }

        numberOfCards = PlayerCards.Count();
        for (int i = 0; i < numberOfCards; i++)
        {
            Deck.AddToDiscardPile(PlayerCards[0]);
            PlayerCards.RemoveAt(0);
        }
    }

    public int CalculateCardValues(List<Card> hand)
    {
        int totalValue = 0;
        for (int i = 0; i < hand.Count; i++)
        {
            totalValue += (int)hand[i].Value;
        }
        return totalValue;
    }

}