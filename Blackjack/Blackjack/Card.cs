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

    public string toSymbol()
    {
        switch (Value.ToString())
        {
          case "Ace":
          case "Jack":
          case "Queen":
          case "King":
              return $"{Value.ToString().Substring(0, 1)}{(char)Suit}";
          default: 
              return $"{(int)Value}{(char)Suit}";
        }
    }
}