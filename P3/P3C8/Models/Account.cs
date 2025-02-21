namespace P3C8.Models;


public abstract class Account  // Classe de base
{
    public int Identifiant { get; set; }
    public decimal Solde { get; set; }
    public AccountHolder Titulaire { get; set; }  // Association avec le titulaire

    public Account(int identifiant, decimal solde, AccountHolder titulaire)
    {
        Identifiant = identifiant;
        Solde = solde;
        Titulaire = titulaire;
    }
}

public class CheckingAccount : Account  // Compte courant
{
    public CheckingAccount(int identifiant, decimal solde, AccountHolder titulaire)
        : base(identifiant, solde, titulaire) { }

}

public class SavingsAccount : Account  // Compte épargne
{
    public SavingsAccount(int identifiant, decimal solde, AccountHolder titulaire)
        : base(identifiant, solde, titulaire) { }
}
