using System.Net.Mail;
using System.Text;

namespace Blackjack;

public class Game
{
    private bool running;
    private bool stay;
    
    public Game(Table table)
    {
        Table = table;
        running = true;
        stay = false;
    }
    
    private Table Table { get; set; }
    
    public void Run()
    {
        DealTwo();
        while (running)
        {
            // Display the table
            DisplayTable();
            // Player gets prompted - hit or stay
            int hitOrStay = HitOrStay();
            if (hitOrStay == 1)
            {
                // add card if hit
                Table.PlayerGetsCard();
            } else if (hitOrStay == 0)
            {
                stay = true;
            } else if (hitOrStay == -1)
            {
                Console.WriteLine("Something went wrong!");
            }
            
            // check if player busts
            if (CheckBust(Table.PlayerCards))
            {
                Console.WriteLine("PLAYER BUST - You lost!");
            }
            // check if player has 21
            if (CheckWin(Table.PlayerCards))
            {
                Console.WriteLine("PLAYER BLACKJACK - You won!");
            }
            
            // Dealers gets card - if value below 17 dealer stays
            if (Table.CalculateCardValues(Table.DealerCards) < 17)
            {
                Table.DealerGetsCard();
            }
            // check if dealer busts
            if (CheckBust(Table.DealerCards))
            {
                Console.WriteLine("DEALER BUST - You won!");
            }
            // check if dealer has 21
            if (CheckWin(Table.DealerCards))
            {
                Console.WriteLine("DEALER BLACKJACK - You lost!");
            }

            if (stay)
            {
                int comparison = CompareCards(Table.PlayerCards, Table.DealerCards);
                if (comparison == 1)
                {
                    Console.WriteLine("You won!");
                } else if (comparison == -1)
                {
                    Console.WriteLine("You lost!");
                } else if (comparison == 0)
                {
                    Console.WriteLine("It's a draw!");
                }
            }
        }
    }

    public void DealTwo()
    {
        // Dealer gets 2 cards
        Table.DealerGetsCard();
        Table.DealerGetsCard();
        // Player gets 2 cards
        Table.PlayerGetsCard();
        Table.PlayerGetsCard();
    }

    public void DisplayTable()
    {
        Console.WriteLine("Dealer's hand:");
        Console.WriteLine(ConvertCardsToSymbols(Table.DealerCards) + 
                          "with a value of " + 
                          Table.CalculateCardValues(Table.DealerCards));
        Console.WriteLine("\nYour hand:");
        Console.WriteLine(ConvertCardsToSymbols(Table.PlayerCards) + 
                         "with a value of " + 
                         Table.CalculateCardValues(Table.PlayerCards));
    }

    public string? ConvertCardsToSymbols(List<Card> cards)
    {
        StringBuilder resultString = new();
        foreach (var card in cards)
        {
            resultString?.Append(card.toSymbol() + " ");
        }

        return resultString?.ToString();
    }
    
    public int HitOrStay()
    {
        Console.Write("Do you want to Hit or Stay (h/s)? ");
        string response = "";
            
        while ((response !=  "s") && (response != "h"))
        {
            response = Console.ReadLine() ?? throw new InvalidOperationException();
        }

        if (response == "h")
        {
            return 1;
        } 
        if (response == "s")
        {
            return 0;
        }
        return -1;
    }

    private bool CheckBust(List<Card> hand)
    {
        if (Table.CalculateCardValues(hand) > 21)
        {
            return true;
        }

        return false;
    }
    
    private bool CheckWin(List<Card> hand)
    {
        if (Table.CalculateCardValues(hand) == 21)
        {
            return true;
        }

        return false;
    }

    private int CompareCards(List<Card> playerHand, List<Card> dealerHand)
    {
        // Player wins
        if (Table.CalculateCardValues(playerHand) > Table.CalculateCardValues(dealerHand))
        {
            return 1;
        }  
        // Dealer wins
        if (Table.CalculateCardValues(playerHand) < Table.CalculateCardValues(dealerHand))
        {
            return -1;
        }
        // Draw
        return 0;
    }

}
