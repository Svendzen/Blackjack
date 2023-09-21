namespace Blackjack;

public class Card
{
    public Card(Suits suit, Values value)
    {
        Suit = suit;
        Value = value;
    }

    public Suits Suit { get; set; }
    
    public Values Value { get; set; }
    
    public override string ToString()
    {
        return $"{Value} of {Suit}";
    }
}