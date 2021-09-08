using Clearent;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class InterestTests
    {
        [Fact]
        public void OnePersonOneWallet()
        {
            var visa = new CreditCard(CardType.Visa);
            var mastercard = new CreditCard(CardType.Mastercard);
            var discover = new CreditCard(CardType.Discover);
            var wallet = new Wallet(new List<CreditCard>() { visa, mastercard, discover });
            var person = new Person(new List<Wallet>() { wallet });

            Assert.Equal(16, person.TotalInterest(100));
            Assert.Equal(10, person.InterestPerCard(100)[0]);
            Assert.Equal(5, person.InterestPerCard(100)[1]);
            Assert.Equal(1, person.InterestPerCard(100)[2]);
        }

        [Fact]
        public void OnePersonTwoWallets()
        {
            var visa = new CreditCard(CardType.Visa);
            var mastercard = new CreditCard(CardType.Mastercard);
            var discover = new CreditCard(CardType.Discover);
            var firstWallet = new Wallet(new List<CreditCard>() { visa, discover });
            var secondWallet = new Wallet(new List<CreditCard>() { mastercard });
            var person = new Person(new List<Wallet>() { firstWallet, secondWallet });

            Assert.Equal(16, person.TotalInterest(100));
            Assert.Equal(11, person.InterestPerWallet(100)[0]);
            Assert.Equal(5, person.InterestPerWallet(100)[1]);
        }

        [Fact]
        public void TwoPeopleOneWalletEach()
        {
            var visa = new CreditCard(CardType.Visa);
            var mastercard = new CreditCard(CardType.Mastercard);
            var wallet = new Wallet(new List<CreditCard>() { visa, mastercard });
            var person = new Person(new List<Wallet>() { wallet });

            //Total interest for two people
            Assert.Equal(30, person.TotalInterest(100) + person.TotalInterest(100));
            //Total interest per wallet
            Assert.Equal(15, person.TotalInterest(100));
        }
    }
}
