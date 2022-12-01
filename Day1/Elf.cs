using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public class Elf
    {
        List<int> cals = new List<int>();

        public int GetCals
        {
            get
            {
                int cal = 0;

                cals.ForEach(x => cal += x);

                return cal;
            }
        }

        /// <summary>
        /// Elf Class
        /// </summary>
        public Elf(List<int> cals)
        {
            this.cals.AddRange(cals);
        }
    }
}
