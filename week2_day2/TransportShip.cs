using System;
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
        public Stack<Cargo> storage { get; set; }
        public int available { get; set; }


        public TransportShip(string _name, int _size)
        {
            name = _name;
            size = _size;
            available = _size;
            storage.Push(new Cargo("p",1));
        }

        public bool AddCargo(Cargo item)
        {
            int available = size;

            foreach(var i in storage)
            {
                available -= i.size;
            }

            if (available + item.size > size)
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
            var lastCargo = storage.Peek();
            storage.Pop();

            return lastCargo;
        }


        public void ListCargo()
        {
            foreach(var item in storage)
                Console.WriteLine(item);
        }



    }
}
