using System.Linq;
using System.Reflection;
using HitachiQA;

namespace BiBerkLOB.Source.Driver;

public enum TestCreditCards
{
    [TestCreditCard("370000000000002")] AmericanExpress,
    [TestCreditCard("6011000000000012")] Discover,
    [TestCreditCard("3088000000000017")] JCB,
    [TestCreditCard("4111111111111111")] Visa,
    [TestCreditCard("4012888818888")] Visa1,
    [TestCreditCard("4111111111111111")] Visa2,
    [TestCreditCard("5424000000000015")] Mastercard,
    [TestCreditCard("2223000010309703")] Mastercard1,
    [TestCreditCard("2223000010309711")] Mastercard2,
    [TestCreditCard("38000000000006")] DinersClub,
    [TestCreditCard("38000000000006")] CarteBlanche
}

public static class TestCreditCardExtensions
{
    public static string GetNumber(this TestCreditCards card)
    {
        return card.GetType()
            .GetMember(card.ToString())[0]
            .GetCustomAttributes<TestCreditCardAttribute>().First().Number;
    }
}