using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace anagrammes
{
    class Program
    {
        static bool IsAnna(string orig, string word)
        {
            List<char> lWord;
            int i;

            if (orig.Length != word.Length)
                return (false);
            lWord = word.ToList();
            for (i = 0; i < orig.Length; i++)
            {
                for (int j = 0; j < lWord.Count; j++)
                {
                    if (lWord[j] == orig[i])
                    {
                        lWord.RemoveAt(j);
                        break;
                    }
                }
            }
            if (lWord.Count == 0 && i == orig.Length)
                return (true);
            return (false);
        }

        static void PrintAnnas(List<string> annas)
        {
            Console.Write("[");
            for(int i = 0; i < annas.Count - 1; i++)
            {
                Console.Write("\"" + annas[i] + "\", ");
            }
            Console.Write("\"" + annas[annas.Count - 1] + "\"]");
        }

        static void Main(string[] args)
        {
            string[] words;
            List<string> annas;

            annas = new List<string>();
            if (args.Length < 2)
                return;
            if ((words = File.ReadAllLines(args[1])) == null)
                return;
            for (int i = 0; i < words.Length; i++)
            {
                if (IsAnna(args[0], words[i]))
                {
                    annas.Add(words[i]);
                }
            }
            PrintAnnas(annas);
        }
    }
}
