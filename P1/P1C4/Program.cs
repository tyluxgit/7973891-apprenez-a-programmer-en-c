using P1C4;
// TODO, étape 1 : instancier un objet de la classe Livre et affecter cet objet à une variable nommée monLivre
// TODO, étape 2 : affecter une valeur aux champs titre, auteur et nombre de pages de votre objet
var monLivre = new Livre() { Titre = "Le Problème à trois corps", Auteur = "Liu Cixin", NombreDePages = 450 };


// Afficher le contenu des champs de cet objet 
Console.WriteLine("Le titre du livre est : " + monLivre.Titre);
Console.WriteLine("Son auteur est " + monLivre.Auteur);
Console.WriteLine("Il compte " + monLivre.NombreDePages + " pages !");