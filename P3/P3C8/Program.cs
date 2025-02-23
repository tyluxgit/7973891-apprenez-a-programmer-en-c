using P3C8;

class Program
{
    static void Main()
    {
        Tools.WaitingUser();
        string choix = "";

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
                    AccountHolder.AccountHolderInfo(); Tools.WaitingUser();
                    break;
                case "CS":
                    Console.WriteLine("Compte courant - Consulter le solde");
                    break;
                case "CD":
                    Console.WriteLine("Compte courant - Déposer des fonds");
                    break;
                case "CR":
                    Console.WriteLine("Compte courant - Retirer des fonds");
                    break;
                case "ES":
                    Console.WriteLine("Compte épargne - Consulter le solde");
                    break;
                case "ED":
                    Console.WriteLine("Compte épargne - Déposer des fonds");
                    break;
                case "ER":
                    Console.WriteLine("Compte épargne - Retirer des fonds");
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