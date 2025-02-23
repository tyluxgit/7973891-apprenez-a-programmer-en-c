using System.Text;
using P3C8.Definitions;

class Program
{
    static void Main()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        Tools.WaitingUser();

        Account defaultAccountHolder = new("John Doe", 123456, 500m, 2000m);

        string filePath = @"C:\temp\output.txt"; // Demander à l'utilisateur ou utiliser un fichier de configuration

        while (true)
        {
            // Effacer la console pour afficher le menu
            Console.Clear();
            Console.WriteLine("Veuillez sélectionner une option ci-dessous :");
            Console.WriteLine("[I] Voir les informations sur le titulaire du compte");
            Console.WriteLine("[CS] Compte courant - Consulter le solde");
            Console.WriteLine("[CD] Compte courant - Déposer des fonds");
            Console.WriteLine("[CR] Compte courant - Retirer des fonds");
            Console.WriteLine("[ES] Compte épargne - Consulter le solde");
            Console.WriteLine("[ED] Compte épargne - Déposer des fonds");
            Console.WriteLine("[ER] Compte épargne - Retirer des fonds");
            Console.WriteLine("[X] Quitter");

            // Lire le choix de l'utilisateur
            string choix = Console.ReadLine()?.ToUpper() ?? "";

            // Traiter le choix de l'utilisateur
            switch (choix)
            {
                case "I":
                    Console.WriteLine("Voir les informations sur le titulaire du compte");
                    defaultAccountHolder.AccountHolderInfo();
                    Tools.WaitingUser();
                    break;
                case "CS":
                    Console.WriteLine("Compte courant - Consulter le solde");
                    defaultAccountHolder.CheckingAccountBalance();
                    Tools.WaitingUser();
                    break;
                case "CD":
                    Console.WriteLine("Compte courant - Déposer des fonds");
                    Console.WriteLine("Quel montant souhaitez-vous déposer ?");
                    string inputCD = Console.ReadLine() ?? "";
                    if (Transaction.TryParseDecimal(inputCD, out decimal amountCD) && amountCD > 0)
                    {
                        defaultAccountHolder.DepositCheckingAccount(amountCD);
                    }
                    else
                    {
                        Console.WriteLine("Montant invalide.");
                    }
                    Tools.WaitingUser();
                    break;
                case "CR":
                    Console.WriteLine("Compte courant - Retirer des fonds");
                    Console.WriteLine($"Quel montant souhaitez-vous retirer ? (Max:{defaultAccountHolder.GetCheckingBalance():C2})");
                    string inputCR = Console.ReadLine() ?? "";
                    if (Transaction.TryParseDecimal(inputCR, out decimal amountCR) && amountCR > 0)
                    {
                        defaultAccountHolder.WithdrawCheckingAccount(amountCR);
                    }
                    else
                    {
                        Console.WriteLine("Montant invalide.");
                    }
                    Tools.WaitingUser();
                    break;
                case "ES":
                    Console.WriteLine("Compte épargne - Consulter le solde");
                    defaultAccountHolder.SavingAccountBalance();
                    Tools.WaitingUser();
                    break;
                case "ED":
                    Console.WriteLine("Compte épargne - Déposer des fonds");
                    Console.WriteLine("Quel montant souhaitez-vous déposer ?");
                    string inputED = Console.ReadLine() ?? "";
                    if (Transaction.TryParseDecimal(inputED, out decimal amountED) && amountED > 0)
                    {
                        defaultAccountHolder.DepositSavingAccount(amountED);
                    }
                    else
                    {
                        Console.WriteLine("Montant invalide.");
                    }
                    Tools.WaitingUser();
                    break;
                case "ER":
                    Console.WriteLine("Compte épargne - Retirer des fonds");
                    Console.WriteLine($"Quel montant souhaitez-vous retirer ? (Max:{defaultAccountHolder.GetSavingBalance():C2})");
                    string inputER = Console.ReadLine() ?? "";

                    if (Transaction.TryParseDecimal(inputER, out decimal amountER) && amountER > 0)
                    {
                        defaultAccountHolder.WithdrawSavingAccount(amountER);
                    }
                    else
                    {
                        Console.WriteLine("Montant invalide.");
                    }
                    Tools.WaitingUser();
                    break;
                case "X":
                    Console.WriteLine("Quitter");
                    if (defaultAccountHolder.Transactions.Count == 0)
                    {
                        Console.WriteLine("Aucune transaction à enregistrer.");
                        return;
                    }
                    else
                    {
                        defaultAccountHolder.DisplayTransactionHistory();
                        try
                        {
                            defaultAccountHolder.PrintTransactionsToFile(filePath);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erreur lors de l'écriture dans le fichier : {ex.Message}");
                        }
                        return;
                    }
                default:
                    Console.WriteLine("Option invalide");
                    break;
            }
        }
    }
}
