using System;
using System.Numerics;

namespace factoriel_big
{
    class Programm
    {
        static BigInteger factoriel(BigInteger num)
        {
            if (num == 0)
                return (1);
            else if (num == 1)
                return (1);
            else if (num < 0)
                return (0);
            else
                return num * factoriel(num - 1);
        }
        static void Main(string[] args)
        {
            BigInteger bigNum;
            long num;

            if (args.Length == 0 || !double.TryParse(args[0], out _))
                num = -1;
            else
                num = Convert.ToInt64(args[0]);

            bigNum = new BigInteger(num);
            Console.WriteLine(factoriel(bigNum));
        }
    }
}
