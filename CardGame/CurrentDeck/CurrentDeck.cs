namespace TwentyOne
{
    public class CurrentDeck
    {

        public List<Card> cards { get; } = new List<Card>();

        public CurrentDeck()
        {

        }

        public void Add(Card card)
        {
            cards.Add(card);

        }

        public int calculateValue()
        {
            int result = 0;
            int numOfElevenAces = 0;
            foreach (Card card in cards)
            {
                if (card.Name != "Ace")
                {
                    result += card.Value;
                }
                else
                {
                    numOfElevenAces++;
                    result += card.Value;
                }
                if (result > 21)
                {
                    while (numOfElevenAces > 0 && result > 21)
                    {
                        result -= 10;
                        numOfElevenAces--;
                    }
                }
            }
            return result;
        }
    }
}