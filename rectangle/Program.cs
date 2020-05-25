using System;
using System.IO;
using System.Collections.Generic;

namespace rectangle
{
    class Program
    {
        static bool  IsRect(string[] secondSquare, string[] firstSquare
                , int i, int j)
        {
            int k = 0;
            while (k < firstSquare.Length && (i + k) < secondSquare.Length)
            {
                int l = 0;
                while (l < firstSquare[k].Length && (j + l) < secondSquare[i + k].Length)
                {
                    if (secondSquare[i + k][j + l] != firstSquare[k][l])
                        return (false);
                    l++;
                }
                if ((j + l) == secondSquare[i + k].Length && l < firstSquare[k].Length)
                    return (false);
                k++;
            }
            if ((i + k) == secondSquare.Length && k < firstSquare.Length)
                return (false);
            return (true);
        }

        static void Main(string[] args)
        {
            string[] firstSquare;
            string[] secondSquare;

            if (args.Length == 0 || args.Length == 1)
                return;

            if ((firstSquare = File.ReadAllLines(args[0])) == null)
                return;
            if ((secondSquare = File.ReadAllLines(args[1])) == null)
                return;

            for (int i = 0; i < secondSquare.Length; i++)
            {
                for (int j = 0; j < secondSquare[i].Length; j++)
                {
                    if (secondSquare[i][j] == firstSquare[0][0])
                    {
                        if (IsRect(secondSquare, firstSquare, i, j))
                        {
                            Console.WriteLine(j + "," + i);
                        }
                    }
                }
            }
        }
    }
}
