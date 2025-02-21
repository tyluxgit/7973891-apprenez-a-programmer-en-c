using P3C3; 

class Program
{
    static void Main()
    {
        Dictionary<int, int> toAdd = new Dictionary<int, int>()
        {
            {1,2},
            {3,4},
            {5,6}
        };
        foreach (KeyValuePair<int, int> pair in toAdd)
        {
            Addition addition = new Addition();
            int result = addition.Add(pair.Key, pair.Value);
            System.Console.WriteLine("La somme de " + pair.Key + "+" + pair.Value + "=" + result);
        }
        
    }
}

