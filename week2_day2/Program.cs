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
            var myShip = new TransportShip("USCSS Nostromo", 20);
            var beer = new Cargo("Beer", 6);
            var food = new Cargo("Food", 7);
            var tools = new Cargo("Tools", 8);
            var constMat = new Cargo("Construction materials", 11);
            var equipment = new Cargo("Equipment", 3);

            myShip.ListCargo();

            if (!myShip.AddCargo(beer))
                Console.WriteLine("Not enough space");
            if (!myShip.AddCargo(food))
                Console.WriteLine("Not enough space");
            if (!myShip.AddCargo(tools))
                Console.WriteLine("Not enough space");
            if (!myShip.AddCargo(constMat))
                Console.WriteLine("Not enough space");


            myShip.ListCargo();

            var removedItem = myShip.RemoveCargo();
            Console.WriteLine("Removed item: {0}, freed space {1}", removedItem.description, removedItem.size);

            myShip.ListCargo();

            if (!myShip.AddCargo(beer))
                Console.WriteLine("Not enough space");

            myShip.ListCargo();

            Console.ReadKey();

        }
    }
}
