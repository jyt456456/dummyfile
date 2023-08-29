using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dummydataq
{
    internal class randomFunc
    {


        public double randouble()
        {
            Random rand = new Random();
            double min = 0;
            double max = 41;
            double range = max - min;
            double sample = rand.NextDouble();
            double scaled = (sample * range) + min;

           // Console.WriteLine(scaled);
            return scaled;

        }

        public int randint(int min, int max)
        {

            Random rand = new Random();
            int result = rand.Next(min, max);
            return result;
        }


    }
}
