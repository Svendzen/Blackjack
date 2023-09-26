// See https://aka.ms/new-console-template for more information

using Blackjack;

PlayingDeck deck = new();
Table table = new(deck);

Game game = new(table);
game.Run();

