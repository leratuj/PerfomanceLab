using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace zadanie_2
{
    public struct Coord // интерфейс Comparer || Comparable ?
    {
        public double x { get; private set; }
        public double y { get; private set; }

        public Coord(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double CompareTo(Coord center, Coord radius)
        {
            double numerator = Math.Pow(x - center.x, 2) / Math.Pow(radius.x, 2);
            double denumerator = Math.Pow(y - center.y, 2) / Math.Pow(radius.y, 2);
            return (numerator + denumerator);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Coord> points = new List<Coord>();
            string[] xy = new string[2];
            string line;

            foreach (string arg in args)
            {
                StreamReader sr = new StreamReader(arg);

                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    xy = line.Split();
                    points.Add(new Coord(int.Parse(xy[0]), int.Parse(xy[1])));
                }
                sr.Close();
            }

            for(int i = 2; i < points.Count(); i++)
            {
                if (points[i].CompareTo(points[0], points[1]) < 1)
                    Console.WriteLine(1);
                else if (points[i].CompareTo(points[0], points[1]) == 1)
                    Console.WriteLine(0);
                else Console.WriteLine(2);
            }
        }
    }
}
