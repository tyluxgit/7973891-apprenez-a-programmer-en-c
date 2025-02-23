using System.Globalization;

namespace P3C8.Definitions
{
    public static class Tools
    {
        public static void WaitingUser()
        {
            Console.WriteLine("Appuyez sur Entrée pour afficher le menu.");
            Console.ReadLine();
        }
    }

    public class Transaction
    {
        public DateTime Date { get; private set; }
        public string AccountType { get; private set; }
        public string TransactionType { get; private set; }
        private decimal _amount;

        public Transaction(string accountType, string transactionType, decimal amount)
        {
            Date = DateTime.Now;
            AccountType = accountType;
            TransactionType = transactionType;
            Amount = amount;
        }

        // Controle le montant des transactions
        public decimal Amount
        {
            get { return _amount; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Le montant de la transaction doit être positif.");
                }
                _amount = value;
            }
        }
        public static bool TryParseDecimal(string input, out decimal result)
        {
            // Remplacer les espaces et les virgules par des points
            input = input.Replace(" ", "").Replace(",", ".");

            // Analyser la chaîne normalisée en un nombre décimal
            return decimal.TryParse(
                input,
                NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands,
                CultureInfo.InvariantCulture,
                out result
            );
        }

    }
}
