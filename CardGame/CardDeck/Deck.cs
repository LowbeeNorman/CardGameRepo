using TwentyOne;
using System.Xml.Linq;

namespace TwentyOne
{
    public class Deck
    {
        // Lists to pull names from
        private static List<string> names = new List<string>() { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
        private static List<string> suits = new List<string>() { "Spades", "Diamonds", "Clubs", "Hearts" };

        // Deck after initialization
        private List<Card> deck = new List<Card>();
        private Random rand = new Random();

        public Deck()
        {
            // Build up the different suits
            foreach (string suit in suits)
            {
                // Iterate through each name
                foreach (string name in names)
                {
                    deck.Add(new Card(name, nameToNum(name), suit));
                }
            }
        }

        private static int nameToNum(string name)
        {
            if (name == "Ace")
            {
                return 11;
            }
            else if (name == "Two")
            {
                return 2;
            }
            else if (name == "Three")
            {
                return 3;
            }
            else if (name == "Four")
            {
                return 4;
            }
            else if (name == "Five")
            {
                return 5;
            }
            else if (name == "Six")
            {
                return 6;
            }
            else if (name == "Seven")
            {
                return 7;
            }
            else if (name == "Eight")
            {
                return 8;
            }
            else if (name == "Nine")
            {
                return 9;
            }
            else if (name == "Ten" || name == "Jack" || name == "Queen" || name == "King")
            {
                return 10;
            }
            else
            {
                return -1;
            }
        }
        public Card Draw()
        {
            Card drawCard = deck[0];
            deck.RemoveAt(0);
            return drawCard;
        }

        public void Shuffle()
        {
            deck = deck.OrderBy(x => rand.Next()).ToList();
        }

        private string numToName(long num)
        {
            if (num == 0)
            {
                return "Ace";
            }
            else if (num == 1)
            {
                return "Two";
            }
            else if (num == 2)
            {
                return "Three";
            }
            else if (num == 3)
            {
                return "Four";
            }
            else if (num == 4)
            {
                return "Five";
            }
            else if (num == 5)
            {
                return "Six";
            }
            else if (num == 6)
            {
                return "Seven";
            }
            else if (num == 7)
            {
                return "Eight";
            }
            else if (num == 8)
            {
                return "Nine";
            }
            else if (num == 9)
            {
                return "Ten";
            }
            else if (num == 10)
            {
                return "Jack";
            }
            else if (num == 11)
            {
                return "Queen";
            }
            else if (num == 12)
            {
                return "King";
            }
            else
            {
                return "";
            }
        }
    }
}