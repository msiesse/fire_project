using System;

namespace tri
{
    class Program
    {

        static int GetNum(string sNum)
        {
            if (double.TryParse(sNum, out _))
            {
                return (Convert.ToInt32(sNum));
            }
            else
                return (0);
        }

        static void DebugArray(int[] array, string name)
        {
            Console.WriteLine(name + ":");
            Console.Write("[");
            for (int i = 0; i < array.Length; i++)
            {
                if (i != array.Length - 1)
                    Console.Write(array[i] + "; ");
                else
                    Console.WriteLine(array[i] + "]");
            }
        }

        static int[] MergeSort(int[] array)
        {
            int[] newArrayLeft;
            int[] newArrayRight;
            int i;
            int j;
            int k;
            

            if (array.Length == 1)
                return (array);

            newArrayLeft = new int[array.Length / 2];
            newArrayRight = new int[array.Length - array.Length / 2];
            Array.Copy(array, 0, newArrayLeft, 0, array.Length / 2);
            Array.Copy(array, array.Length / 2, newArrayRight, 0, array.Length - array.Length / 2);

            newArrayLeft = MergeSort(newArrayLeft);
            newArrayRight = MergeSort(newArrayRight);

         //   DebugArray(newArrayLeft, "Left_sorted");
      //      DebugArray(newArrayRight, "Right_sorted");

            j = 0;
            k = 0;
            i = 0;
            while (j < array.Length / 2 && k < array.Length - array.Length / 2)
            {
                if (newArrayLeft[j] >= newArrayRight[k])
                {
                    array[i] = newArrayLeft[j];
                    j++;
                }
                else
                {
                    array[i] = newArrayRight[k];
                    k++;
                }
                i++;
            }
            while (j < array.Length / 2)
            {
                array[i] = newArrayLeft[j];
                i++;
                j++;
            }
            while (k < array.Length - array.Length / 2)
            {
                array[i] = newArrayRight[k];
                i++;
                k++;
            }
            return (array);
        }

        static void Main(string[] args)
        {
            int[]   sorted;

            sorted = new int[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                sorted[i] = GetNum(args[i]);
            }
            sorted = MergeSort(sorted);
            for (int i = 0; i < sorted.Length; i++)
                Console.Write(sorted[i] + " ");
        }
    }
}
