namespace P3C8.Models;

public class Account
{
    public int Identifiant { get; set; }
    public string Type { get; set; }  // "Courant" ou "Épargne"
    public decimal Solde { get; set; }
    public AccountHolder Titulaire { get; set; }  // Association avec la classe AccountHolder
}

