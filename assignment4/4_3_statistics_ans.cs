using System;
using System.Linq;

namespace statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] data = {
                {"StdNum", "Name", "Math", "Science", "English"},
                {"1001", "Alice", "85", "90", "78"},
                {"1002", "Bob", "92", "88", "84"},
                {"1003", "Charlie", "79", "85", "88"},
                {"1004", "David", "94", "76", "92"},
                {"1005", "Eve", "72", "95", "89"}
            };
            // You can convert string to double by
            // double.Parse(str)

            int stdCount = data.GetLength(0) - 1;
            // ---------- TODO ----------
            Console.WriteLine(stdCount);
            Console.WriteLine("Average Scores: ");
            Console.WriteLine($"Math: {(double.Parse(data[1, 2]) + double.Parse(data[2, 2]) + double.Parse(data[3, 2]) + double.Parse(data[4, 2]) + double.Parse(data[5, 2])) / 5}");
            Console.WriteLine($"Science: {(double.Parse(data[1, 3]) + double.Parse(data[2, 3]) + double.Parse(data[3, 3]) + double.Parse(data[4, 3]) + double.Parse(data[5, 3])) / 5}");
            Console.WriteLine($"English: {(double.Parse(data[1, 4]) + double.Parse(data[2, 4]) + double.Parse(data[3, 4]) + double.Parse(data[4, 4]) + double.Parse(data[5, 4])) / 5}");
            Console.WriteLine();
            Console.WriteLine($"Max and min Scores:");
            double[] mathscore = { double.Parse(data[1, 2]), double.Parse(data[2, 2]), double.Parse(data[3, 2]), double.Parse(data[4, 2]), double.Parse(data[5, 2]) };
            Console.WriteLine($"Math: ({mathscore.Max()}, {mathscore.Min()})");
            double[] sciscore = { double.Parse(data[1, 3]), double.Parse(data[2, 3]), double.Parse(data[3, 3]), double.Parse(data[4, 3]), double.Parse(data[5, 3]) };
            Console.WriteLine($"Science: ({sciscore.Max()}, {sciscore.Min()})");
            double[] engscore = { double.Parse(data[1, 4]), double.Parse(data[2, 4]), double.Parse(data[3, 4]), double.Parse(data[4, 4]), double.Parse(data[5, 4]) };
            Console.WriteLine($"English: ({engscore.Max()}, {engscore.Min()})");
            double[] total1 = { double.Parse(data[1, 2]) + double.Parse(data[1, 3]) + double.Parse(data[1, 4]), 1 };
            double[] total2 = { double.Parse(data[2, 2]) + double.Parse(data[2, 3]) + double.Parse(data[2, 4]), 2 };
            double[] total3 = { double.Parse(data[3, 2]) + double.Parse(data[3, 3]) + double.Parse(data[3, 4]), 3 };
            double[] total4 = { double.Parse(data[4, 2]) + double.Parse(data[4, 3]) + double.Parse(data[4, 4]), 4 };
            double[] total5 = { double.Parse(data[5, 2]) + double.Parse(data[5, 3]) + double.Parse(data[5, 4]), 5 };
            double[] totalscores = { total1[0], total2[0], total3[0], total4[0], total5[0] };
            Array.Sort(totalscores);
            Array.Reverse(totalscores);
            int j = 1;
            Console.WriteLine();
            int alice = 0;
            int bob = 0;
            int charlie = 0;
            int david = 0;
            int eve = 0;
            foreach (double i in totalscores)
            {
                if (total1[0] == i)
                {
                    alice = j;
                    j++;
                }
                if (total2[0] == i)
                {
                    bob = j;
                    j++;
                }
                if (total3[0] == i)
                {
                    charlie = j;
                    j++;
                }
                if (total4[0] == i)
                {
                    david = j;
                    j++;
                }
                if (total5[0] == i)
                {
                    eve = j;
                    j++;
                }
            }
            string[] name = { "Alice:", "Bob: ", "Charlie: ", "David: ", "Eve: " };
            int[] totalscore2 = { alice, bob, charlie, david, eve };
            string th = "th";
            string name1 = "";
           
            Console.WriteLine($"Alice: {alice}th");
            Console.WriteLine($"Bob: {bob}th");
            Console.WriteLine($"Charlie: {charlie}th");
            Console.WriteLine($"David: {david}th");
            Console.WriteLine($"Eve: {eve}th");
            // --------------------
        }
    }
}

/* example output

Average Scores: 
Math: 84.40
Science: 86.80
English: 86.20

Max and min Scores: 
Math: (94, 72)
Science: (95, 76)
English: (92, 78)

Students rank by total scores:
Alice: 4th
Bob: 1st
Charlie: 5th
David: 2nd
Eve: 3rd

*/
