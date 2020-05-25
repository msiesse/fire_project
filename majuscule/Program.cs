using System;
using System.Text;

namespace majuscule
{
    class Program
    {
        static void Main(string[] args)
        {
            string Caption;
            StringBuilder sb;

            if (args.Length == 0)
            {
                return;
            }
            else
            {
                Caption = args[0];
            }

            sb = new StringBuilder(Caption);
            for (int i = 0; i < Caption.Length; i++)
            {
                if ((i % 2) == 0)
                {
                    sb[i] = char.ToLower(Caption[i]);
                }
                else
                {
                    sb[i] = char.ToUpper(Caption[i]);
                }
            }
            Caption = sb.ToString();
            Console.WriteLine(Caption);
        }
    }
}
