using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array2
{
    class Program
    {
        static void Main(string[] args)
        {

            // jaggedArray

            int[][] jaggedArray = new int[3][];

          

            jaggedArray[0] = new int[] { 1, 2, 3, 4, 5 };
            jaggedArray[1] = new int[] { 1, 2, 3};
            jaggedArray[2] = new int[] { 21,32};


            Console.WriteLine(jaggedArray[0][2]); // 3
            Console.WriteLine(jaggedArray[1][2]); // 3
            Console.WriteLine(jaggedArray[2][1]); // 32
 
            int[][] jagarra2 = new int[][]
            {
                new int[] { 1, 2, 3},
                new int[] { 21, 32},
            };

            Console.WriteLine("Length of the array is {0}", jagarra2.Length);

            for (int i = 0; i < jagarra2.Length; i++)
            {
                Console.WriteLine("Element {0}", i);
        
                for(int j=0; j < jagarra2[i].Length; j++)
                {
                    Console.WriteLine("{0}", jagarra2[i][j]);
                }
            }



            Console.ReadKey();
        }
    }
}
