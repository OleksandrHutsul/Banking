namespace Banking.Application.Accounts.Commands.CreateAccount;

public static class CardNumberGenerator
{
    public static string GenerateCardNumber()
    {
        var random = new Random();
        var cardNumber = string.Join(" ", Enumerable.Range(0, 4)
            .Select(_ => random.Next(1000, 9999).ToString()));
        return cardNumber;
    }
}
