using System;

namespace factoriel
{
    class Program
    {
        static double factoriel(double num)
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
            double num;

            if (args.Length == 0)
                num = 0;
            else
                num = Convert.ToDouble(args[0]);

            Console.WriteLine(factoriel(num));
        }
    }
}
