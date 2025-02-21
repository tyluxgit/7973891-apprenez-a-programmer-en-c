using System.Text.Json;

namespace P3C8.Models;

public abstract class Account  // Classe de base
{
    public int Identifiant { get; }
    public decimal Solde { get; private set; }  // Modification contrôlée
    public AccountHolder Titulaire { get; }  // Immuable après création

    public Account(int identifiant, decimal solde, AccountHolder titulaire)
    {
        if (identifiant <= 0) throw new ArgumentException("L'identifiant doit être positif.", nameof(identifiant));
        if (solde < 0) throw new ArgumentException("Le solde initial ne peut pas être négatif.", nameof(solde));
        Titulaire = titulaire ?? throw new ArgumentNullException(nameof(titulaire));

        Identifiant = identifiant;
        Solde = solde;
    }

    public void Déposer(decimal montant)
    {
        if (montant <= 0) throw new ArgumentException("Le montant doit être positif.", nameof(montant));
        Solde += montant;
    }

    public bool Retirer(decimal montant)
    {
        if (montant <= 0) throw new ArgumentException("Le montant doit être positif.", nameof(montant));
        if (montant > Solde) return false;  // Refus du retrait si solde insuffisant

        Solde -= montant;
        return true;
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

public class AccountHolder
{
    public int Id { get; init; }
    public string Nom { get; init; }
    public string Prenom { get; init; }
    public int DateNaissance { get; init; }
    public string Email { get; init; }
    public string Telephone { get; init; }
    public string Adresse { get; init; }

    public AccountHolder(int id, string nom, string prenom, int age, string email, string telephone, string adresse)
    {
        if (id <= 0) throw new ArgumentException("L'ID doit être positif.", nameof(id));
        if (age < 0) throw new ArgumentException("L'âge ne peut pas être négatif.", nameof(age));

        Id = id;
        Nom = nom ?? throw new ArgumentNullException(nameof(nom));
        Prenom = prenom ?? throw new ArgumentNullException(nameof(prenom));
        DateNaissance = age;
        Email = email ?? throw new ArgumentNullException(nameof(email));
        Telephone = telephone ?? throw new ArgumentNullException(nameof(telephone));
        Adresse = adresse ?? throw new ArgumentNullException(nameof(adresse));
    }
    public AccountHolder LireClientParId(string filePath, int idRecherche) {
        using FileStream fs = File.OpenRead(filePath);
        using JsonDocument doc = JsonDocument.Parse(fs);

        var root = doc.RootElement.GetProperty("Clients");

        if (root.TryGetProperty(idRecherche.ToString(), out JsonElement clientElement))
        {
            return new AccountHolder
            {
                Id = idRecherche,
                Nom = clientElement.GetProperty("Nom").GetString(),
                Prenom = clientElement.GetProperty("Prenom").GetString(),
                DateNaissance = clientElement.GetProperty("DateNaissance").GetString(),
                Email = clientElement.GetProperty("Email").GetString(),
                Telephone = clientElement.GetProperty("Telephone").GetString(),
                Adresse = clientElement.GetProperty("Adresse").GetString(),
                SoldeCompteCourant = clientElement.GetProperty("SoldeCompteCourant").GetDouble(),
                SoldeCompteEpargne = clientElement.GetProperty("SoldeCompteEpargne").GetDouble()
            };
        }

        return null;
    }
}
