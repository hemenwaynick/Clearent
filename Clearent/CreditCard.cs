using System;

namespace Clearent
{
    public record CreditCard
    {
        public CreditCard(CardType cardType)
        {
            Type = cardType;
        }

        public CardType Type { get; }

        public double InterestRate
        {
            get
            {
                switch (Type)
                {
                    case CardType.Visa:
                        return 0.1;
                    case CardType.Mastercard:
                        return 0.05;
                    case CardType.Discover:
                        return 0.01;
                    default:
                        throw new Exception("Invalid card type.");
                }
            }
        }
    }
}
