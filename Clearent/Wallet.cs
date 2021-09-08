using System.Collections.Generic;

namespace Clearent
{
    public class Wallet
    {
        public Wallet(IEnumerable<CreditCard> creditCards)
        {
            CreditCards = creditCards;
        }

        public IEnumerable<CreditCard> CreditCards { get; set; }
    }
}
