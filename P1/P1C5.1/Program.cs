// TODO : Déclarer une variable nommée couleurs d'un array de string de longueur 5
string[] couleurs = new string[5];

// TODO : Remplir le tableau avec les couleurs demandées dans le README.md
couleurs[0] = "rouge";
couleurs[1] = "jaune";
couleurs[2] = "orange";
couleurs[3] = "vert";
couleurs[4] = "bleu";

// TODO : Remplacer vert par émeraude dans le tableau
couleurs[3] = "émeraude";

// Afficher le contenu du tableau
foreach (string couleur in couleurs)
{
    Console.WriteLine(couleur);
}