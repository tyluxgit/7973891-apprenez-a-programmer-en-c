using System;
using System.Globalization;
using System.IO;
using System.Text.Json;
using P3C8.Models;


class Program
{
    static void Main()
    {
        // TODO: L'utilisateur doit appuyer sur Entrée pour continuer
        Console.WriteLine("Appuyez sur Entrée pour continuer...");
        Console.ReadLine();
        Console.WriteLine("Saisissez votre identifiant puis Entrée");
        string identifiant = Console.ReadLine();

        if (int.TryParse(identifiant, out int idRecherche))
        {
            AccountHolder clientData = LireClientParId("FichierClientFictifs.json", idRecherche);

            if (clientData != null)
            {
                /* TODO: Afficher un menu avec un message et les options suivantes: 
                     Veuillez sélectionner une option ci-dessous :
                    [I] Voir les informations sur le titulaire du compte
                    [CS] Compte courant - Consulter le solde
                    [CD] Compte courant - Déposer des fonds
                    [CR] Compte courant - Retirer des fonds
                    [ES] Compte épargne - Consulter le solde
                    [ED] Compte épargne - Déposer des fonds
                    [ER] Compte épargne - Retirer des fonds
                    [X] Quitter*/

                //TODO: L'utilisateur doit saisir une option du menu (majuscule ou minuscule) et appuyer sur Entrée, le programme doit afficher un message d'erreur si l'option n'est pas valide
            }

        }
        else
        {
            Console.WriteLine("L'identifiant doit être un nombre entier.");

        }
    }
}