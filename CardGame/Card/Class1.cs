namespace TwentyOne
{
    public class Card
    {

        public string Name { get; }
        public int Value { get; }
        public string Suit { get; }
        public Card(string name, int value, string suit)
        {
            Name = name;
            Value = value;
            Suit = suit;
        }
    }
}