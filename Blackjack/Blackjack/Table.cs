namespace Blackjack;

public class Table
{
    public Table(PlayingDeck deck)
    {
        Deck = deck;
    }
    
    private List<Card> DealerCards { get; set; }
    private List<Card> PlayerCards { get; set; }
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

}