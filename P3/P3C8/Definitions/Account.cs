using System.Text;
using System.Text.Json;

namespace P3C8.Definitions
{
    public class Account(string name, int accountId, decimal checkingBalance, decimal savingBalance)
    {
        private static readonly JsonSerializerOptions jsonSerializerOptions = new()
        {
            WriteIndented = true, // Pour un formatage lisible
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping // Pour éviter l'échappement des caractères non-ASCII
        };

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

        // Dépôt d'argent sur le compte courant
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

        // Dépôt d'argent sur le compte d'épargne
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

        // Retrait du compte courant
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

        // Retrait d'argent du compte d'épargne
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

        // Enregistre les transactions dans la liste
        private void RecordTransaction(string accountType, string transactionType, decimal amount)
        {
            Transaction transaction = new(accountType, transactionType, amount);
            Transactions.Add(transaction);
            Console.WriteLine($"Transaction enregistrée : {accountType} - {transactionType} de {amount:C2}");
        }

        // Affiche l'historique des transactions
        public void DisplayTransactionHistory()
        {
            Console.WriteLine("Historique des transactions :");
            foreach (var transaction in Transactions)
            {
                Console.WriteLine($"{transaction.Date} - {transaction.AccountType} - {transaction.TransactionType}: {transaction.Amount:C2}");
            }
        }

        // Imprime les transactions dans un fichier
        public void PrintTransactionsToFile(string filePath)
        {
            try
            {
                // Sérialiser la liste des transactions en JSON
                string jsonString = JsonSerializer.Serialize(Transactions, jsonSerializerOptions);

                // Écrire le JSON dans un fichier avec encodage UTF-8 avec BOM
                File.WriteAllText(filePath, jsonString, new UTF8Encoding(encoderShouldEmitUTF8Identifier: true));

                Console.WriteLine($"Transactions imprimées dans le fichier JSON : {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'écriture dans le fichier : {ex.Message}");
            }
        }
    }
}
