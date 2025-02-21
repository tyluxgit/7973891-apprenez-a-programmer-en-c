// TODO : Remplacer le ?? par le code approprié pour créer une liste de chaînes

List <string> invites = new List<string> ();

// TODO : Ajouter Joe, Martin et Marie à la liste.
invites.Add("Joe");
invites.Add("Martin");
invites.Add("Marie");

// TODO : Compléter l'instruction suivante en remplaçant le ?? pour afficher la taille de la liste
Console.WriteLine("Nombre d'invités : " + invites.Count);

// TODO : Remplacer Martin par Jean dans la liste
invites.Insert(invites.IndexOf("Martin"),"Jean");

// TODO : Retirer Joe de la liste
invites.Remove("Joe");

// Afficher le contenu de la liste
Console.Write("Les invités sont :");
foreach (string invite in invites)
{
    Console.Write(" " + invite);
}