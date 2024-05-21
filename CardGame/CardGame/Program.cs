using TwentyOne;

namespace CardGame
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Boolean that interrupts the game loop when they stay
            bool stayBool = false;
            // Make both decks, the backing deck and the current deck
            Deck deck = new Deck();
            CurrentDeck currDeck = new CurrentDeck();

            // Shuffle the cards
            deck.Shuffle();

            // Draw two random cards, then add them to the current deck
            Card card1 = deck.Draw();
            currDeck.Add(card1);
            Card card2 = deck.Draw();
            currDeck.Add(card2);

            Console.WriteLine("First card: " + card1.Name + " of " + card1.Suit);
            Thread.Sleep(1000);
            Console.WriteLine("Second card: " + card2.Name + " of " + card2.Suit);

            int totalValue = currDeck.calculateValue();

            // Gameloop for the player to draw
            while (totalValue <= 21 && !stayBool)
            {
                Console.WriteLine("Your total is " + totalValue + ". Type \"stay\" to stay, or else you will get another card");
                string? input = Console.ReadLine();
                if (input == "stay")
                {
                    stayBool = true;
                }
                else
                {
                    Card newCard = deck.Draw();
                    currDeck.Add(newCard);
                    totalValue = currDeck.calculateValue();
                    Thread.Sleep(1000);
                    Console.WriteLine("You drew: " + newCard.Name + " of " + newCard.Suit + "\n");
                    Thread.Sleep(1000);
                    Console.WriteLine("Your current cards are: ");
                    foreach (Card card in currDeck.cards)
                    {
                        Console.WriteLine(card.Name + " of " + card.Suit);
                        Thread.Sleep(500);
                    }
                    Console.WriteLine("\n");
                }
            }
            // If player draws over 21
            if (totalValue > 21)
            {
                Console.WriteLine("You lose, over 21");
            }
            // Gameloop for the AI opponent
            else
            {
                Console.WriteLine("\n" + "Time for your opponent to play" + "\n");
                CurrentDeck aiDeck = new CurrentDeck();
                int aiTotal = 0;
                while (aiTotal <= 21)
                {
                    Thread.Sleep(1000);
                    if (aiTotal < totalValue)
                    {
                        Card currCard = deck.Draw();
                        aiDeck.Add(currCard);
                        aiTotal = aiDeck.calculateValue();
                        Thread.Sleep(800);
                        Console.WriteLine("Opponent drew: " + currCard.Name + " of " + currCard.Suit);
                        Thread.Sleep(800);
                        Console.WriteLine("Opponents current total is: " + aiTotal + "\n");
                        if (aiTotal > totalValue)
                        {
                            break;
                        }
                        continue;
                    }
                    break;
                }
                if (aiTotal > 21 || totalValue > aiTotal)
                {
                    Console.WriteLine("You Win!");
                }
                else
                {
                    Console.WriteLine("You Lose!");
                }
            }

            Console.WriteLine("Press anything to play again, type \"close\" to close the game");
            if (Console.ReadLine() == "close")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("\n" + "----------------------------------------------------------------------------" + "\n" + "\n");
                Main(new string[0]);
            }
        }
    }
}