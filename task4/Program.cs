using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>();
            string line;
            
            StreamReader sr = new StreamReader(args[0]);

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                if(Int32.TryParse(line, out int x))
                {
                    nums.Add(x);
                }
            }
            sr.Close();

            int[] steps_by_number = new int[nums.Count()];

            for(int i = 0; i < nums.Count(); i++)
            {
                for(int j = 0; j < nums.Count(); j++)
                {
                    if (i == j) continue;
                    steps_by_number[i] += Math.Abs(nums[i] - nums[j]);
                }
            }

            int result = steps_by_number.Min();
            if (result > 20)
                Console.WriteLine("20 ходов недостаточно для приведения всех элементов массива к одному числу");
            else Console.WriteLine(result);
        }
    }
}
