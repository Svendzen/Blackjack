// See https://aka.ms/new-console-template for more information

using Blackjack;

PlayingDeck deck = new();

foreach (Card card in deck.Deck)
{
    //Console.WriteLine(card);
}

deck.DiscardCard();

Console.WriteLine(deck.DiscardPile.Peek());