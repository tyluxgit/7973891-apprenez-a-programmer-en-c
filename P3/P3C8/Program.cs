using Account_Definition;
using System.Text;
using Tools_Definition;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Tools.WaitingUser();
string choix = "";
// Création d'un compte par défaut
Account defaultAccountHolder = new("John Doe", 123456, 500, 2000);

while (choix != "X")
{
    Console.WriteLine("Veuillez sélectionner une option ci - dessous :");
    Console.WriteLine("[I] Voir les informations sur le titulaire du compte");
    Console.WriteLine("[CS] Compte courant - Consulter le solde");
    Console.WriteLine("[CD] Compte courant - Déposer des fonds");
    Console.WriteLine("[CR] Compte courant - Retirer des fonds");
    Console.WriteLine("[ES] Compte épargne - Consulter le solde");
    Console.WriteLine("[ED] Compte épargne - Déposer des fonds");
    Console.WriteLine("[ER] Compte épargne - Retirer des fonds");
    Console.WriteLine("[X] Quitter");

    choix = Console.ReadLine().ToUpper();
    switch (choix)
    {
        case "I":
            Console.WriteLine("Voir les informations sur le titulaire du compte");
            defaultAccountHolder.AccountHolderInfo(); Tools.WaitingUser();
            break;
        case "CS":
            Console.WriteLine("Compte courant - Consulter le solde");
            defaultAccountHolder.CheckingAccountBalance(); Tools.WaitingUser();
            break;
        case "CD":
            Console.WriteLine("Compte courant - Déposer des fonds");
            Console.WriteLine("Quel montant souhaitez-vous déposer ?");
            double amountCD = Convert.ToDouble(Console.ReadLine());
            defaultAccountHolder.DepositCheckingAccount(amountCD); Tools.WaitingUser();
            break;
        case "CR":
            Console.WriteLine("Compte courant - Retirer des fonds");
            Console.WriteLine($"Quel montant souhaitez-vous retirer ? (Max:{defaultAccountHolder.CheckingBalance:C2})");
            double amountCR = Convert.ToDouble(Console.ReadLine());
            defaultAccountHolder.WithdrawCheckingAccount(amountCR); Tools.WaitingUser();
            break;
        case "ES":
            Console.WriteLine("Compte épargne - Consulter le solde");
            defaultAccountHolder.SavingAccountBalance(); Tools.WaitingUser();
            break;
        case "ED":
            Console.WriteLine("Compte épargne - Déposer des fonds");
            Console.WriteLine("Quel montant souhaitez-vous déposer ?");
            double amountED = Convert.ToDouble(Console.ReadLine());
            defaultAccountHolder.DepositSavingAccount(amountED); Tools.WaitingUser();
            break;
        case "ER":
            Console.WriteLine("Compte épargne - Retirer des fonds");
            Console.WriteLine($"Quel montant souhaitez-vous retirer ? (Max:{defaultAccountHolder.SavingBalance:C2})");
            double amountER = Convert.ToDouble(Console.ReadLine());
            defaultAccountHolder.WithdrawSavingAccount(amountER); Tools.WaitingUser();
            break;
        case "X":
            Console.WriteLine("Quitter");
            defaultAccountHolder.DisplayTransactionHistory();
            defaultAccountHolder.PrintTransactionsToFile(@"C:\temp\output.txt");
            break;
        default:
            Console.WriteLine("Option invalide");
            break;
    }
}
