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
            string[] names = { "name1", "name2" };

            Console.WriteLine(names[0]);

            int[,] arr2d = new int[,]
            {
                {1,2,3 },
                {11,12,13 },
                {21,22, 23}
            };

            Console.WriteLine(arr2d[1, 2]);

            string[,,] arr3d = new string[,,]
            {
                {
                    {"000","001","002" },
                    {"010","011","012" },
                    {"020","021", "022" }
                }
            };

            Console.WriteLine(arr3d[0, 2, 1]);

            Console.ReadKey();
        }
    }
}
