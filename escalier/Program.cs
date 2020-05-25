using System;

namespace escalier
{
    class Program
    {
        static void PrintFloors(int floors)
        {
            for (int i = 0; i < floors; i++)
            {
                for (int j = 0; j < floors; j++)
                {
                    if ((i + j) >= (floors - 1))
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine("");
            }
        }

        static void Main(string[] args)
        {
            int floors;

            if (args.Length == 0)
            {
                floors = 0;
            }
            else
            {
                floors = Convert.ToInt32(args[0]);
            }

            PrintFloors(floors);
        }
    }
}
