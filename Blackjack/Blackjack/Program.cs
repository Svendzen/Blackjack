// See https://aka.ms/new-console-template for more information

using Blackjack;

PlayingDeck deck = new();

deck.ShuffleDeck();

Console.WriteLine(deck.Count);
