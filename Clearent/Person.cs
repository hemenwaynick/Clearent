using System.Collections.Generic;

namespace Clearent
{
    public class Person
    {
        public Person(IEnumerable<Wallet> wallets)
        {
            Wallets = wallets;
        }

        public IEnumerable<Wallet> Wallets { get; set; }

        public double TotalInterest(double balance)
        {
            var totalInterest = 0.0;
            foreach (var wallet in Wallets)
            {
                foreach (var creditCard in wallet.CreditCards)
                {
                    totalInterest += creditCard.InterestRate * balance;
                }
            }

            return totalInterest;
        }

        public List<double> InterestPerCard(double balance)
        {
            var interestPerCard = new List<double>();
            foreach (var wallet in Wallets)
            {
                foreach (var creditCard in wallet.CreditCards)
                {
                    interestPerCard.Add(creditCard.InterestRate * balance);
                }
            }

            return interestPerCard;
        }

        public List<double> InterestPerWallet(double balance)
        {
            var interestPerWallet = new List<double>();
            foreach (var wallet in Wallets)
            {
                var interestForWallet = 0.0;
                foreach (var creditCard in wallet.CreditCards)
                {
                    interestForWallet += creditCard.InterestRate * balance;
                }

                interestPerWallet.Add(interestForWallet);
            }

            return interestPerWallet;
        }
    }
}
