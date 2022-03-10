namespace TrainAsk1.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        int seqCounter = 0;
        int entityCounter = 0;

        // Read the file and display it line by line.  
        using StreamWriter file = new(@"C:\covid\HBV_single.fasta");

        foreach (string line in System.IO.File.ReadLines(@"C:\covid\HBV.fasta"))
        {
            if (line.StartsWith(">"))
            {
                if (entityCounter > 0)
                {
                    System.Console.WriteLine("");
                    file.WriteLine("");
                }
                entityCounter++;
                {
                    System.Console.WriteLine(line);
                    file.WriteLine(line);
                }
            }
            else
            {
                {
                    System.Console.Write(line);
                    file.Write(line);
                }
                seqCounter++;
            }
        }
        file.Close();

        System.Console.WriteLine("There were {0} entities.", entityCounter);
        System.Console.WriteLine("There were {0} sequences.", seqCounter);
        System.Console.ReadLine();
    }
}
