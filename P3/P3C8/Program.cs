using P3C8;

class Program
{
    static void Main()
    {
        Tools.WaitingUser();
        string choix = "";
        // Création d'un compte par défaut
        Account defaultAccountHolder = new Account("John Doe", 123456, 500, 2000);

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
                    Console.WriteLine("Veuillez saisir le montant à déposer :");
                    double amountCD = Convert.ToDouble(Console.ReadLine());
                    defaultAccountHolder.DepositCheckingAccount(amountCD); Tools.WaitingUser();
                    break;
                case "CR":
                    Console.WriteLine("Compte courant - Retirer des fonds");
                    Console.WriteLine("Veuillez saisir le montant à retirer :");
                    double amountCR = Convert.ToDouble(Console.ReadLine());
                    defaultAccountHolder.WithdrawCheckingAccount(amountCR); Tools.WaitingUser();
                    break;
                case "ES":
                    Console.WriteLine("Compte épargne - Consulter le solde");
                    defaultAccountHolder.SavingAccountBalance(); Tools.WaitingUser();
                    break;
                case "ED":
                    Console.WriteLine("Compte épargne - Déposer des fonds");
                    Console.WriteLine("Veuillez saisir le montant à déposer :");
                    double amountED = Convert.ToDouble(Console.ReadLine());
                    defaultAccountHolder.DepositSavingAccount(amountED); Tools.WaitingUser();
                    break;
                case "ER":
                    Console.WriteLine("Compte épargne - Retirer des fonds");
                    Console.WriteLine("Veuillez saisir le montant à retirer :");
                    double amountER = Convert.ToDouble(Console.ReadLine());
                    defaultAccountHolder.WithdrawSavingAccount(amountER); Tools.WaitingUser();
                    break;
                case "X":
                    Console.WriteLine("Quitter");
                    break;
                default:
                    Console.WriteLine("Option invalide");
                    break;
            }
        }

     
    }
}