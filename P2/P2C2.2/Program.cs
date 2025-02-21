using P2C2._2;

Couleur couleurChoisie = Couleur.Vert;

// TODO : Remplacer la séquence if/else par une instruction switch équivalente qui fonctionne selon la valeur de couleurChoisie

switch (couleurChoisie)
{
    case Couleur.Bleu:
        Console.WriteLine("La couleur est bleue");
        break;
    case Couleur.Vert:
        Console.WriteLine("La couleur est verte");
        break;
    case Couleur.Rouge:
        Console.WriteLine("La couleur est rouge");
        break;
    case Couleur.Jaune:
        Console.WriteLine("La couleur est jaune");
        break;
    default:
        Console.WriteLine("Cette couleur n'est pas connue !");
        break;
}