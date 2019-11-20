﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2_day2
{
    class TransportShip
    {
        public int size { get; set; }
        public string name { get; set; }
        public Stack<Cargo> storage = new Stack<Cargo>();
        public int available { get; set; }


        public TransportShip(string _name, int _size)
        {
            name = _name;
            size = _size;
            available = _size;
        }

        public bool AddCargo(Cargo item)
        {
            if (available - item.size < 0)
                return false;
            else
            {
                storage.Push(item);
                available -= item.size;
                return true;
            }
        }

        public Cargo RemoveCargo()
        {
            var removedCargo = storage.Pop();

            if (removedCargo.size > 0)
                available += removedCargo.size;

            return removedCargo;
        }

        public void ListCargo()
        {
            Console.WriteLine("--- Cargo Items ---");
            if(storage.Count < 1)
            {
                Console.WriteLine("<empty>");
            }
            foreach(var item in storage)
                Console.WriteLine(item.description);
            Console.WriteLine("--------- Available space: " + available);
            Console.WriteLine();
        }



    }
}
