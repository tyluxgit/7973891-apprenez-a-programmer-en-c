using P3C4;

class Program
{
    public static void Main()
    {
        Addition();
        Substraction();   
    }
    public static void Addition()
    {
        Console.WriteLine("5+6=" + MathMagiques.Somme(5, 6));
        Test.TestSomme();
    }

    public static void Substraction()
    {
        Console.WriteLine("10-8=" + MathMagiques.Soustraction(10, 8));
        Test.TestSoustraction();
    }
}
