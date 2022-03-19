namespace TrainAsk1.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        int seqCounter = 0;
        int entityCounter = 0;

        // Ask user for the maximum number of characters per line.
        int MaxCharsPerLine = 80;
        Console.WriteLine("Would you like to change the number of characters per line? (y/n)");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        string answer = Console.ReadLine();
        if (answer == "y")
        {
            Console.WriteLine("Maximum characters per line:");
            MaxCharsPerLine = Convert.ToInt32(Console.ReadLine());
        }

        // Read the file and display it line by line.  

        Console.WriteLine("Enter file path:");
        string file_path = Console.ReadLine();
        //string file_path = "c:/twork/test.fasta";
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        string[] lines = File.ReadAllLines(file_path);

        using StreamWriter file = new(@"C:\twork\single.fasta");
        var writtenCharacters = 0;
        foreach (string line in lines)
        {
            if (line.StartsWith(">"))
            {
                if (entityCounter > 0)
                {
                    //TODO: Better 
                    System.Console.WriteLine("");
                    file.WriteLine("");

                }
                System.Console.WriteLine(line);
                file.WriteLine(line);
                // writtenCharacters = 0;
                entityCounter++;

            }
            else
            {
                foreach (var c in line)
                {
                    System.Console.Write(c);
                    file.Write(c);
                    writtenCharacters++;
                    if (writtenCharacters == MaxCharsPerLine)
                    {
                        System.Console.WriteLine("");
                        file.WriteLine("");
                        writtenCharacters = 0;

                    }

                }
                seqCounter++;
            }
        }
        file.Close();
        System.Console.WriteLine("");
        System.Console.WriteLine("There were {0} entities.", entityCounter);
        System.Console.WriteLine("There were {0} sequence lines.", seqCounter);
        System.Console.ReadLine();
    }
}
