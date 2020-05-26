using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace sudoku
{
    class Program
    {
        static bool IsInLine(string[] grille, int i, int j, int k)
        {
            char num;

            num = (char)(k + 48);
            for (int l = 0; l < grille[i].Length; l++)
            {
                if (num == grille[i][l] && l != j)
                    return (true);
            }
            return (false);
        }

        static bool IsInColumn(string[] grille, int i, int j, int k)
        {
            char num;

            num = (char)(k + 48);
            for (int l = 0; l < grille.Length; l++)
            {
                if (num == grille[l][j] && l != i)
                    return (true);
            }
            return (false);
        }

        static bool IsInBlock(string[] grille, int i, int j, int k)
        {
            char num;
            int lMax;
            int cMax;

            num = (char)(k + 48);
            lMax = 4 * (i / 4) + 2;
            cMax = 4 * (j / 4) + 2;

            for (int l = 4 * i / 4; l < lMax; l++)
            {
                for (int c = 4 * j / 4; c < cMax; c++)
                {
                    if (num == grille[l][c] && (l != i || c != j))
                        return (true);
                }
            }
            return (false);
        }

        static bool ResolveCase(string[] grille, int i, int j)
        {
            bool resolved;
            StringBuilder s1;

            if (grille[i][j] != '_')
            {
                if (j == 10 && i != 10)
                    resolved = ResolveCase(grille, i + 1, 0);
                else if (j == 10 && i == 10)
                    return (true);
                else
                    resolved = ResolveCase(grille, i, j + 1);
                return (resolved);
            }

            s1 = new StringBuilder(grille[i]);
            for (int k = 1; k < 10; k++)
            {
                if (!IsInLine(grille, i, j, k) && !IsInColumn(grille, i, j, k)
                    && !IsInBlock(grille, i, j, k))
                {
                    s1[j] = (char)(k + 48);
                    grille[i] = s1.ToString();
                    if (j == 10 && i != 10)
                        resolved = ResolveCase(grille, i + 1, 0);
                    else if (j == 10 && i == 10)
                        return (true);
                    else
                        resolved = ResolveCase(grille, i, j + 1);
                    if (resolved)
                        return (true);
                }
            }
            return (false);
        }

        static void PrintSudoku(string[] grille)
        {
            for (int i = 0; i < grille.Length; i++)
            {
                Console.WriteLine(grille[i]);
            }
        }

        static bool ValidGrille(string[] grille)
        {
            int k;

            if (grille.Length != 11)
                return (false);
            for (int i = 0; i < grille.Length; i++)
            {
                for (int j = 0; j < grille[i].Length; j++)
                {
                    if (grille[i].Length != 11)
                        return (false);
                    k = grille[i][j] - 48;
                    if (grille[i][j] >= '0' && grille[i][j] <= '9')
                    {
                        if (IsInLine(grille, i, j, k) || IsInColumn(grille, i, j, k)
                                || IsInBlock(grille, i, j, k))
                            return (false);
                    }
                }
            }
            return (true);
        }

        static void Main(string[] args)
        {
            string[] grille;

            if (args.Length == 0)
                return;

            if ((grille = File.ReadAllLines(args[0])) == null)
                return;
            if (!ValidGrille(grille))
            {
                Console.WriteLine("Not a valid sudoku");
                return;
            }
            if (ResolveCase(grille, 0, 0) == true)
            {
                PrintSudoku(grille);
            }
        }
    }
}
