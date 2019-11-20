using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2_day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var myShip = new TransportShip("The ship", 20);
            var item1 = new Cargo()
            {
                description = "lkj",
                size = 9
            };

            myShip.AddCargo(item1);

            myShip.ListCargo();

        }
    }
}
