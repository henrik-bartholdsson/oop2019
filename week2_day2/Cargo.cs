using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2_day2
{
    class Cargo
    {
        public string description { get; set; }
        public int size { get; set; }
        public Cargo(string desc, int _size)
        {
            description = desc;
            size = _size;
        }


    }
}
