IDictionary<string, string> mois = new Dictionary<string, string>();

// TODO : Remplacer les noms par des constantes de type chaine de caractères
mois.Add("Juin", "sixième");
mois.Add("Septembre", "neuvième");
mois.Add("Mars", "cinquième");

// TODO : Corriger la valeur de Mars avec (3)
mois["Mars"] = "troisième";


// TODO : Retirer Juin
mois.Remove("Juin");

// Afficher le contenu du dictionnaire
Console.WriteLine("La liste des mois est :");
foreach (KeyValuePair<string, string> clePaire in mois)
{
    Console.WriteLine(clePaire.Key.ToString() + " est le "+ clePaire.Value + " mois de l'année ");
}