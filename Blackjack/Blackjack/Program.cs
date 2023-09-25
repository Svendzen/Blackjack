// See https://aka.ms/new-console-template for more information

using Blackjack;

PlayingDeck deck = new();

Console.WriteLine(deck.Count);

Table table = new Table(deck);

table.DealerGetsCard();
table.DealerGetsCard();
table.PlayerGetsCard();
table.PlayerGetsCard();

Console.WriteLine(table.DealerCards[0]);
Console.WriteLine(table.PlayerCards[0] + "\n\n");


foreach (Card card in deck.Deck)
{
    //Console.WriteLine(card);
}

//Console.WriteLine(deck.Count);

Console.WriteLine(table.DealerCards[0]);
Console.WriteLine("player hand: " + table.CalculateCardValues(table.PlayerCards));
Console.WriteLine("dealer hand: " + table.CalculateCardValues(table.DealerCards));

