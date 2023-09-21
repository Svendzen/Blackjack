namespace Blackjack;

public class Card
{
    //protected Suits _suit;
    //protected string _value;
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