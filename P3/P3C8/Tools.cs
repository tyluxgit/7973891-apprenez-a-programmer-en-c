namespace Tools_Definition;

public class Tools
{
    public static void WaitingUser()
    {
        Console.WriteLine("Appuyez sur Entrée pour afficher le menu.");
        Console.ReadLine();
    }
}
    public class Transaction
    {
        public DateTime Date { get; set; }
        public string AccountType { get; set; }
        public string TransactionType { get; set; }
        public double Amount { get; set; }

        public Transaction(string accountType, string transactionType, double amount)
        {
            Date = DateTime.Now;
            AccountType = accountType;
            TransactionType = transactionType;
            Amount = amount;
        }
    }



