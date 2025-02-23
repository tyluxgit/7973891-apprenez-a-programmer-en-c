namespace Tools_Definition;

public class Tools
{
    public static void WaitingUser()
    {
        Console.WriteLine("Appuyez sur Entrée pour afficher le menu.");
        Console.ReadLine();
    }
}
    public class Transaction(string accountType, string transactionType, double amount)
{
    public DateTime Date { get; set; } = DateTime.Now;
    public string AccountType { get; set; } = accountType;
    public string TransactionType { get; set; } = transactionType;
    public double Amount { get; set; } = amount;
}



