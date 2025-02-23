namespace P3C8;

    public class Account(string name, int accountid, double checkingbalance, double savingbalance)
    {
        public string Name { get; set; } = name;
        public int AccountId { get; set; } = accountid;
        public double CheckingBalance { get; set; } = checkingbalance;
        public double SavingBalance { get; set; } = savingbalance;


    public void AccountHolderInfo() 
        {
            Console.WriteLine($"Nom : {Name} - Numéro de compte : {AccountId}");
        }

    public void CheckingAccountBalance()
    {
        Console.WriteLine($"Solde du compte courant : {CheckingBalance}");
    }

    public void SavingAccountBalance()
    {
        Console.WriteLine($"Solde du compte épargne : {SavingBalance}");
    }

    public void DepositCheckingAccount(double amount)
    {
        CheckingBalance += amount;
        Console.WriteLine($"Dépôt de {amount} sur le compte courant effectué avec succès");
    }

    public void DepositSavingAccount(double amount)
    {
        SavingBalance += amount;
        Console.WriteLine($"Dépôt de {amount} sur le compte épargne effectué avec succès");
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
            Console.WriteLine($"Retrait de {amount} sur le compte courant effectué avec succès");
        }
    }
    public void WithdrawSavingAccount(double amount)
    {
        if (CheckingBalance - amount < 0)
        {
            Console.WriteLine("Fonds insuffisants");
        }
        else
        {
            CheckingBalance -= amount;
            Console.WriteLine($"Retrait de {amount} sur le compte courant effectué avec succès");
        }
    }
}