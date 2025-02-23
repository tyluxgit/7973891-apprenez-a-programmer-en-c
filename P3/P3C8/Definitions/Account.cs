namespace P3C8.Definitions
{
    public class Account(string name, int accountId, decimal checkingBalance, decimal savingBalance)
    {
        public string Name { get; private set; } = name;
        public int AccountId { get; private set; } = accountId;
        public List<Transaction> Transactions { get; private set; } = [];

        public void AccountHolderInfo()
        {
            Console.WriteLine($"Nom : {Name} - Numéro de compte : {AccountId}");
        }

        public void CheckingAccountBalance()
        {
            Console.WriteLine($"Solde du compte courant : {checkingBalance:C2}");
        }

        public void SavingAccountBalance()
        {
            Console.WriteLine($"Solde du compte épargne : {savingBalance:C2}");
        }
        public decimal GetCheckingBalance()
        {
            return checkingBalance;
        }

        public decimal GetSavingBalance()
        {
            return savingBalance;
        }

        public void DepositCheckingAccount(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Le montant du dépôt doit être positif.");
                return;
            }

            checkingBalance += amount;
            Console.WriteLine($"Dépôt de {amount:C2} sur le compte courant effectué avec succès");
            RecordTransaction("Courant", "Dépôt", amount);
        }

        public void DepositSavingAccount(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Le montant du dépôt doit être positif.");
                return;
            }

            savingBalance += amount;
            Console.WriteLine($"Dépôt de {amount:C2} sur le compte épargne effectué avec succès");
            RecordTransaction("Epargne", "Dépôt", amount);
        }

        public void WithdrawCheckingAccount(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Le montant du retrait doit être positif.");
                return;
            }

            if (checkingBalance - amount < 0)
            {
                Console.WriteLine("Fonds insuffisants");
            }
            else
            {
                checkingBalance -= amount;
                Console.WriteLine($"Retrait de {amount:C2} sur le compte courant effectué avec succès");
                RecordTransaction("Courant", "Retrait", amount);
            }
        }

        public void WithdrawSavingAccount(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Le montant du retrait doit être positif.");
                return;
            }

            if (savingBalance - amount < 0)
            {
                Console.WriteLine("Fonds insuffisants");
            }
            else
            {
                savingBalance -= amount;
                Console.WriteLine($"Retrait de {amount:C2} sur le compte d'épargne effectué avec succès");
                RecordTransaction("Epargne", "Retrait", amount);
            }
        }

        private void RecordTransaction(string accountType, string transactionType, decimal amount)
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
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'écriture dans le fichier : {ex.Message}");
            }
        }
    }
}
