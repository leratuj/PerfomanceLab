using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_1
{
    class CircularArray
    {
        private int n;
        private int m;

        private int[] array;

       public CircularArray()
        {
            Console.WriteLine("Введите n и m для массива:");

            string one = Console.ReadLine();
            string[] nm = one.Split();

            this.n = int.Parse(nm[0]);
            this.m = int.Parse(nm[1]);

            array = new int[n];

            for( int i=0; i < n; i++)
            {
                array[i] = i + 1;
                //Console.Write(array[i]);
            }
                     
        }
        public int this[int index]
        {
            get => array[index % n];
         
            set => array[index % n] = value;
        }

        public List<int> path()
        {
            List<int> path_mass = new List<int>();
            path_mass.Add(array[0]);
            int i = 0, k = 0;
            do
            {
                i += m - 1;
                path_mass.Add(this[i]);
                k++;
            } while (this[i] != this[0]);

            path_mass.RemoveAt(k);

            return path_mass;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-Первый-");
            CircularArray mas1 = new CircularArray();
            
            Console.WriteLine("-Второй-");
            CircularArray mas2 = new CircularArray();

            List<int> one = mas1.path();
            List<int> two = mas2.path();

            one.AddRange(two);
            one.ForEach(Console.Write);
            Console.WriteLine();
        }
    }
}
