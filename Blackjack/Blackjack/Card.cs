namespace Blackjack;

public class Card
{
    protected string _suit;
    protected string _value;
    public Card(string suit, string value)
    {
        this._suit = suit;
        this._value = value;
    }
    
    public string Suit { get; set; }
    
    public string Value { get; set; }

    public override string ToString()
    {
        return $"{_value} of {_suit}";
    }
}