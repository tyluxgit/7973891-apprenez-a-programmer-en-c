using Tools_Definition;
namespace Account_Definition;


public class Account(string name, int accountid, double checkingbalance, double savingbalance)
    {
        public string Name { get; set; } = name;
        public int AccountId { get; set; } = accountid;
        public double CheckingBalance { get; set; } = checkingbalance;
        public double SavingBalance { get; set; } = savingbalance;
        public List<Transaction> Transactions { get; private set; } = [];


    public void AccountHolderInfo() 
        {
            Console.WriteLine($"Nom : {Name} - Numéro de compte : {AccountId}");
        }

    public void CheckingAccountBalance()
    {
        Console.WriteLine($"Solde du compte courant : {CheckingBalance:C2}");
    }

    public void SavingAccountBalance()
    {
        Console.WriteLine($"Solde du compte épargne : {SavingBalance:C2}");
    }

    public void DepositCheckingAccount(double amount)
    {
        CheckingBalance += amount;
        Console.WriteLine($"Dépôt de {amount:C2} € sur le compte courant effectué avec succès");
        RecordTransaction("Courant", "Dépôt", amount);
    }

    public void DepositSavingAccount(double amount)
    {
        SavingBalance += amount;
        Console.WriteLine($"Dépôt de {amount:C2} € sur le compte épargne effectué avec succès");
        RecordTransaction("Epargne", "Dépôt", amount);
    }

    public void WithdrawCheckingAccount(double amount)
    {
        if (CheckingBalance - amount < 0)
        {
            Console.WriteLine("Fonds insuffisants");
        }
        else
        {
            CheckingBalance -= amount;
            Console.WriteLine($"Retrait de {amount:C2} € sur le compte courant effectué avec succès");
            RecordTransaction("Courant", "Retrait", amount);
        }
    }
    public void WithdrawSavingAccount(double amount)
    {
        if (SavingBalance - amount < 0)
        {
            Console.WriteLine("Fonds insuffisants");
        }
        else
        {
            SavingBalance -= amount;
            Console.WriteLine($"Retrait de {amount:C2} sur le compte d'épargne effectué avec succès");
            RecordTransaction("Epargne", "Retrait", amount);
        }
    }
    public void RecordTransaction(string accountType, string transactionType, double amount)
    {
        Transaction transaction = new(accountType, transactionType, amount);
        Transactions.Add(transaction);
        Console.WriteLine($"Transaction enregistrée : {accountType} - {transactionType} de {amount:C2}");
    }
    public void DisplayTransactionHistory()
    {
        Console.WriteLine("Historique des transactions :");
        foreach (var transaction in Transactions)
        {
            Console.WriteLine($"{transaction.Date} - {transaction.AccountType} - {transaction.TransactionType}: {transaction.Amount:C2}");
        }
    }
    public void PrintTransactionsToFile(string filePath)
    {
        using (StreamWriter writer = new(filePath))
        {
            writer.WriteLine("Date\tType de compte\tType de transaction\tMontant");
            foreach (var transaction in Transactions)
            {
                writer.WriteLine($"{transaction.Date}\t{transaction.AccountType}\t{transaction.TransactionType}\t{transaction.Amount:C2}");
            }
        }
        Console.WriteLine($"Transactions imprimées dans le fichier : {filePath}");
    }


}