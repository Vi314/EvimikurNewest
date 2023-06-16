using System.Diagnostics;

public class Program
{
    private static void Main(string[] args)
    {
        var hashTest = new HashSet<int>();
        for (int i = 0; i < 100; i++)
        {
            var rnd = new Random();
            var rndN = rnd.Next(0, 10000);
            var result = hashTest.Add(rndN);
            if (!result)

            { i--; }
        }

        TimeSpan time = new();
        for (int i = 0; i < 10000000; i++)
        {
            var timeStamp = Stopwatch.StartNew();
            var s = hashTest.Where(x => x / 2 == 0 || x / 5 == 0).Select(x => x);
            time += timeStamp.Elapsed;
        }

        Console.WriteLine("*****************************************************************************");
        Console.WriteLine($"Type of List :{hashTest.GetType()}");
        Console.WriteLine($"Amount of members in list :{hashTest.Count}");
        Console.WriteLine("*****************************************************************************");
        Console.WriteLine($"The Overall Time :{(time).TotalMilliseconds}ms");
        Console.WriteLine($"The Average Time :{(time / 10000000).TotalMilliseconds}ms");
        Console.WriteLine("*****************************************************************************");
    }
}